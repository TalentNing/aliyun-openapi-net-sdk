/*
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Logging;

namespace Aliyun.Acs.Core.Utils
{
    public class SerilogHelper
    {
        private const string RegexPattern = @"{(.*?)}";

        private const string DefaultTemplate =
            "{channel} {method} {uri} {version} {code} {cost} {hostname} {pid} {NewLine}";

        private static IDictionary<string, string> _loggerMessageMap;
        private static readonly ILog Logger = LogProvider.For<SerilogHelper>();

        internal static long ExecuteTime { get; set; }
        internal static bool EnableLogger { get; private set; }

        private static void BuildKeyValueMap<T>(AcsRequest<T> request, HttpResponse response, long executeTime)
            where T : AcsResponse
        {
            try
            {
                _loggerMessageMap = new Dictionary<string, string>();
                var requestHeader =
                    request.Headers == null ? "" : DictionaryUtil.TransformDicToString(request.Headers);
                var requestContent = request.Content == null ? "" : Encoding.Default.GetString(request.Content);

                var responseHeader = response.Headers == null
                    ? ""
                    : DictionaryUtil.TransformDicToString(response.Headers);
                var responseContent = response.Content == null ? "" : Encoding.Default.GetString(response.Content);

                var hostName = Dns.GetHostName();

                if (null != request.Url)
                {
                    var requestUri = new Uri(request.Url);
                    var host = requestUri.Host;
                    var target = requestUri.PathAndQuery + requestUri.Fragment;

                    _loggerMessageMap.Add("host", host);
                    _loggerMessageMap.Add("target", target);
                }

                _loggerMessageMap.Add("channel", "AlibabaCloud.");
                _loggerMessageMap.Add("request", requestHeader + requestContent);
                _loggerMessageMap.Add("req_headers", requestHeader);

                _loggerMessageMap.Add("method", request.Method.ToString());
                _loggerMessageMap.Add("uri", request.Url);
                _loggerMessageMap.Add("version", "HTTP/" + response.HttpVersion);
                _loggerMessageMap.Add("hostname", hostName);

                _loggerMessageMap.Add("code", response.Status.ToString());
                _loggerMessageMap.Add("error", responseContent);
                _loggerMessageMap.Add("response", responseHeader + responseContent + response.Status);
                _loggerMessageMap.Add("res_headers", responseHeader);

                _loggerMessageMap.Add("pid", Process.GetCurrentProcess().Id.ToString());
                _loggerMessageMap.Add("cost", executeTime + "ms");
            }
            catch (Exception ex)
            {
                LogException(ex, "ErrorCode", ex.ToString());
                throw new ClientException(ex.ToString());
            }
        }

        internal static void SetLogger()
        {
            EnableLogger = true;
        }

        internal static void LogInfo<T>(AcsRequest<T> request, HttpResponse httpResponse, long executeTime)
            where T : AcsResponse
        {
            if (!EnableLogger)
            {
                return;
            }

            BuildKeyValueMap(request, httpResponse, executeTime);

            var logKey = new List<string>();
            var logValue = new List<string>();

            var re = new Regex(RegexPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            var matchCollection = re.Matches(DefaultTemplate);

            if (0 < matchCollection.Count)
            {
                foreach (Match item in matchCollection)
                {
                    logKey.Add(item.Value.Trim('{', '}'));
                }
            }

            foreach (var item in logKey)
            {
                string value;
                _loggerMessageMap.TryGetValue(item, out value);
                logValue.Add(value);
            }

            var logParameters = logValue.Cast<object>().ToArray();
            Logger.Info(DefaultTemplate, logParameters);
        }

        internal static void LogException(Exception ex, string errorCode, string errorMessage)
        {
            if (!EnableLogger)
            {
                return;
            }

            Logger.Error(ex,
                string.Format("AlibabaCloud. ExceptionMessage: ErrorCode:{0}, ErrorMessage:{1},", errorCode,
                    errorMessage));
        }

        internal static void CloseLogger()
        {
            EnableLogger = false;
            _loggerMessageMap = null;
        }
    }
}

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
using System.Collections.Generic;

using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Transform;
using Aliyun.Acs.Core.Utils;
using Aliyun.Acs.Rds.Transform;
using Aliyun.Acs.Rds.Transform.V20140815;

namespace Aliyun.Acs.Rds.Model.V20140815
{
    public class ModifyInstanceCrossBackupPolicyRequest : RpcAcsRequest<ModifyInstanceCrossBackupPolicyResponse>
    {
        public ModifyInstanceCrossBackupPolicyRequest()
            : base("Rds", "2014-08-15", "ModifyInstanceCrossBackupPolicy", "rds", "openAPI")
        {
        }

		private long? resourceOwnerId;

		private int? retentType;

		private string resourceOwnerAccount;

		private string crossBackupType;

		private string logBackupEnabled;

		private string backupEnabled;

		private long? ownerId;

		private string crossBackupRegion;

		private string dBInstanceId;

		private int? retention;

		public long? ResourceOwnerId
		{
			get
			{
				return resourceOwnerId;
			}
			set	
			{
				resourceOwnerId = value;
				DictionaryUtil.Add(QueryParameters, "ResourceOwnerId", value.ToString());
			}
		}

		public int? RetentType
		{
			get
			{
				return retentType;
			}
			set	
			{
				retentType = value;
				DictionaryUtil.Add(QueryParameters, "RetentType", value.ToString());
			}
		}

		public string ResourceOwnerAccount
		{
			get
			{
				return resourceOwnerAccount;
			}
			set	
			{
				resourceOwnerAccount = value;
				DictionaryUtil.Add(QueryParameters, "ResourceOwnerAccount", value);
			}
		}

		public string CrossBackupType
		{
			get
			{
				return crossBackupType;
			}
			set	
			{
				crossBackupType = value;
				DictionaryUtil.Add(QueryParameters, "CrossBackupType", value);
			}
		}

		public string LogBackupEnabled
		{
			get
			{
				return logBackupEnabled;
			}
			set	
			{
				logBackupEnabled = value;
				DictionaryUtil.Add(QueryParameters, "LogBackupEnabled", value);
			}
		}

		public string BackupEnabled
		{
			get
			{
				return backupEnabled;
			}
			set	
			{
				backupEnabled = value;
				DictionaryUtil.Add(QueryParameters, "BackupEnabled", value);
			}
		}

		public long? OwnerId
		{
			get
			{
				return ownerId;
			}
			set	
			{
				ownerId = value;
				DictionaryUtil.Add(QueryParameters, "OwnerId", value.ToString());
			}
		}

		public string CrossBackupRegion
		{
			get
			{
				return crossBackupRegion;
			}
			set	
			{
				crossBackupRegion = value;
				DictionaryUtil.Add(QueryParameters, "CrossBackupRegion", value);
			}
		}

		public string DBInstanceId
		{
			get
			{
				return dBInstanceId;
			}
			set	
			{
				dBInstanceId = value;
				DictionaryUtil.Add(QueryParameters, "DBInstanceId", value);
			}
		}

		public int? Retention
		{
			get
			{
				return retention;
			}
			set	
			{
				retention = value;
				DictionaryUtil.Add(QueryParameters, "Retention", value.ToString());
			}
		}

        public override ModifyInstanceCrossBackupPolicyResponse GetResponse(UnmarshallerContext unmarshallerContext)
        {
            return ModifyInstanceCrossBackupPolicyResponseUnmarshaller.Unmarshall(unmarshallerContext);
        }
    }
}

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
using Aliyun.Acs.Ess.Transform;
using Aliyun.Acs.Ess.Transform.V20140828;

namespace Aliyun.Acs.Ess.Model.V20140828
{
    public class ModifyScalingGroupRequest : RpcAcsRequest<ModifyScalingGroupResponse>
    {
        public ModifyScalingGroupRequest()
            : base("Ess", "2014-08-28", "ModifyScalingGroup", "ess", "openAPI")
        {
        }

		private long? resourceOwnerId;

		private string healthCheckType;

		private string launchTemplateId;

		private string resourceOwnerAccount;

		private string scalingGroupName;

		private string scalingGroupId;

		private List<string> vSwitchIds;

		private string ownerAccount;

		private int? spotInstancePools;

		private string activeScalingConfigurationId;

		private int? minSize;

		private long? ownerId;

		private string launchTemplateVersion;

		private int? onDemandBaseCapacity;

		private int? onDemandPercentageAboveBaseCapacity;

		private bool? spotInstanceRemedy;

		private int? maxSize;

		private int? defaultCooldown;

		private string removalPolicy1;

		private string removalPolicy2;

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

		public string HealthCheckType
		{
			get
			{
				return healthCheckType;
			}
			set	
			{
				healthCheckType = value;
				DictionaryUtil.Add(QueryParameters, "HealthCheckType", value);
			}
		}

		public string LaunchTemplateId
		{
			get
			{
				return launchTemplateId;
			}
			set	
			{
				launchTemplateId = value;
				DictionaryUtil.Add(QueryParameters, "LaunchTemplateId", value);
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

		public string ScalingGroupName
		{
			get
			{
				return scalingGroupName;
			}
			set	
			{
				scalingGroupName = value;
				DictionaryUtil.Add(QueryParameters, "ScalingGroupName", value);
			}
		}

		public string ScalingGroupId
		{
			get
			{
				return scalingGroupId;
			}
			set	
			{
				scalingGroupId = value;
				DictionaryUtil.Add(QueryParameters, "ScalingGroupId", value);
			}
		}

		public List<string> VSwitchIds
		{
			get
			{
				return vSwitchIds;
			}

			set
			{
				vSwitchIds = value;
				for (int i = 0; i < vSwitchIds.Count; i++)
				{
					DictionaryUtil.Add(QueryParameters,"VSwitchIds." + (i + 1) , vSwitchIds[i]);
				}
			}
		}

		public string OwnerAccount
		{
			get
			{
				return ownerAccount;
			}
			set	
			{
				ownerAccount = value;
				DictionaryUtil.Add(QueryParameters, "OwnerAccount", value);
			}
		}

		public int? SpotInstancePools
		{
			get
			{
				return spotInstancePools;
			}
			set	
			{
				spotInstancePools = value;
				DictionaryUtil.Add(QueryParameters, "SpotInstancePools", value.ToString());
			}
		}

		public string ActiveScalingConfigurationId
		{
			get
			{
				return activeScalingConfigurationId;
			}
			set	
			{
				activeScalingConfigurationId = value;
				DictionaryUtil.Add(QueryParameters, "ActiveScalingConfigurationId", value);
			}
		}

		public int? MinSize
		{
			get
			{
				return minSize;
			}
			set	
			{
				minSize = value;
				DictionaryUtil.Add(QueryParameters, "MinSize", value.ToString());
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

		public string LaunchTemplateVersion
		{
			get
			{
				return launchTemplateVersion;
			}
			set	
			{
				launchTemplateVersion = value;
				DictionaryUtil.Add(QueryParameters, "LaunchTemplateVersion", value);
			}
		}

		public int? OnDemandBaseCapacity
		{
			get
			{
				return onDemandBaseCapacity;
			}
			set	
			{
				onDemandBaseCapacity = value;
				DictionaryUtil.Add(QueryParameters, "OnDemandBaseCapacity", value.ToString());
			}
		}

		public int? OnDemandPercentageAboveBaseCapacity
		{
			get
			{
				return onDemandPercentageAboveBaseCapacity;
			}
			set	
			{
				onDemandPercentageAboveBaseCapacity = value;
				DictionaryUtil.Add(QueryParameters, "OnDemandPercentageAboveBaseCapacity", value.ToString());
			}
		}

		public bool? SpotInstanceRemedy
		{
			get
			{
				return spotInstanceRemedy;
			}
			set	
			{
				spotInstanceRemedy = value;
				DictionaryUtil.Add(QueryParameters, "SpotInstanceRemedy", value.ToString());
			}
		}

		public int? MaxSize
		{
			get
			{
				return maxSize;
			}
			set	
			{
				maxSize = value;
				DictionaryUtil.Add(QueryParameters, "MaxSize", value.ToString());
			}
		}

		public int? DefaultCooldown
		{
			get
			{
				return defaultCooldown;
			}
			set	
			{
				defaultCooldown = value;
				DictionaryUtil.Add(QueryParameters, "DefaultCooldown", value.ToString());
			}
		}

		public string RemovalPolicy1
		{
			get
			{
				return removalPolicy1;
			}
			set	
			{
				removalPolicy1 = value;
				DictionaryUtil.Add(QueryParameters, "RemovalPolicy.1", value);
			}
		}

		public string RemovalPolicy2
		{
			get
			{
				return removalPolicy2;
			}
			set	
			{
				removalPolicy2 = value;
				DictionaryUtil.Add(QueryParameters, "RemovalPolicy.2", value);
			}
		}

        public override ModifyScalingGroupResponse GetResponse(UnmarshallerContext unmarshallerContext)
        {
            return ModifyScalingGroupResponseUnmarshaller.Unmarshall(unmarshallerContext);
        }
    }
}

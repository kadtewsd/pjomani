using System;
using System.Collections.Generic;
using Microsoft.ProjectServer.Client;
using PJOMgmt.Util;

namespace PJOMgmt.Resource.Impl
{
    public class ResourceRetriever : AbstractPJOMgmt<EnterpriseResource>
    {
        public ResourceRetriever(PJOForm arg) : base(arg)
        {
        }

        public override string ProcessName
        {
            get
            {
                return "リソース情報の取得";
            }
        }

        public override EventResult<EnterpriseResource> Execute()
        {
            EventResult<EnterpriseResource> result = new EventResult<EnterpriseResource>();
            Param.Util.LoadEnterpriseResources();
            EnterpriseResource resource = Param.Util.ProjContext.EnterpriseResources[0];
            CustomFieldCollection cusCol = resource.CustomFields;
            Param.Util.ProjContext.Load(cusCol);
            Param.Util.ProjContext.ExecuteQuery();
            result.ForResearch = resource.FieldValues;
            result.Result = resource;
            return result;
        }
    }
}

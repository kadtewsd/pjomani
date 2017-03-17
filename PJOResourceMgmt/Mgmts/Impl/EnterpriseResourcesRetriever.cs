using Microsoft.ProjectServer.Client;
using PJOMgmt.Resource.Impl;
using PJOMgmt;
using PJOMgmt.Util;

namespace PJOResourceMgmt.Mgmts.Impl
{
    public class EnterpriseResourcesRetriever : AbstractPJOMgmt<EnterpriseResourceCollection>
    {
        public EnterpriseResourcesRetriever(PJOForm arg) : base(arg)
        {
        }

        public override string ProcessName
        {
            get
            {
                return "エンタープライズリソース取得処理";
            }

        }

        public override EventResult<EnterpriseResourceCollection> Execute()
        {
            EventResult<EnterpriseResourceCollection> result = new EventResult<EnterpriseResourceCollection>();
            Param.Util.LoadEnterpriseResources();
            result.Result = Param.Util.ProjContext.EnterpriseResources;
            return result;
        }

        public override void SetResult(EventResult<EnterpriseResourceCollection> result)
        {
            Param.Form.SetAdditional(result.Result.Count.ToString());
        }
    }
}

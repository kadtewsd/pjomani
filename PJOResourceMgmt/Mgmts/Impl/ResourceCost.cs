using PJOMgmt.Util;
using Microsoft.ProjectServer.Client;
using System;
using Microsoft.SharePoint.Client;

namespace PJOMgmt.Resource.Impl
{
    public class ResourceCost : AbstractPJOMgmt<EnterpriseResourceCollection>
    {
        public ResourceCost(PJOForm arg) : base(arg)
        {
        }

        public override string ProcessName
        {
            get
            {
                return "リソースへの標準単価設定";
            }
        }

        public override EventResult<EnterpriseResourceCollection> Execute()
        {
            EventResult<EnterpriseResourceCollection> result = new EventResult<EnterpriseResourceCollection>();
            Param.Util.LoadEnterpriseResources();
            int enterpriseResourceCount = Param.Util.ProjContext.EnterpriseResources.Count;
            for (int cnt = enterpriseResourceCount - 1; cnt > -1; cnt--)
            {
                EnterpriseResource resource = Param.Util.ProjContext.EnterpriseResources[cnt];
                if (resource.IsGeneric)
                {

                    System.Diagnostics.Debug.WriteLine(string.Format("user {0} is  general!", resource.Name));
                    continue;
                }
                if (resource.ResourceType == EnterpriseResourceType.Cost)
                {

                    System.Diagnostics.Debug.WriteLine(string.Format("user {0} is  cost!", resource.Name));
                    continue;
                }
                EnterpriseResourceCostRateTableCollection enttbl = resource.CostRateTables;
                Param.Util.ProjContext.Load(enttbl, e => e.Include(c => c.CostRates));
                Param.Util.ProjContext.ExecuteQuery();
                for (int i = 0; i < enttbl.Count; i++)
                {
                    EnterpriseResourceCostRateTable tbl = enttbl[i];

                    for (int j = 0; j < tbl.CostRates.Count; j++)
                    {
                        EnterpriseResourceCostRate col = tbl.CostRates[j];
                        col.StandardRate = Param.Form.GetStandardRate();
                        //Param.Util.ProjContext.Load(col, c => c.StandardRate);
                        //Param.Util.ProjContext.Load(tbl);
                        System.Diagnostics.Debug.WriteLine("user {0}'s standard rate is {1}", resource.Name, col.StandardRate);

                        //Param.Util.ProjContext.Load(col);
                        //Param.Util.ProjContext.ExecuteQuery();
                    }
                }
            }

            Param.Util.ProjContext.EnterpriseResources.Update();
            Param.Util.ProjContext.ExecuteQuery();
            result.Result = Param.Util.ProjContext.EnterpriseResources;
            return result;
        }
    }
}

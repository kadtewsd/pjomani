using System;
using Microsoft.ProjectServer.Client;
using Microsoft.SharePoint.Client;
using PJOMgmt.Util;
using System.Collections.Generic;

namespace PJOMgmt.Resource.Impl
{
    public class DeleteEnterpriseResource : AbstractPJOMgmt<EnterpriseResourceCollection>
    {

        IList<ResourceDTO> resourceTestInfo = null;
        public DeleteEnterpriseResource(PJOForm arg) : base(arg)
        {
            resourceTestInfo = Param.Form.TestData;
        }

        public override string ProcessName
        {
            get
            {
                return "エンタープライズリソース削除";
            }
        }

        public override EventResult<EnterpriseResourceCollection> Execute()
        {
            EventResult<EnterpriseResourceCollection> result = new EventResult<EnterpriseResourceCollection>();
            Param.Util.LoadEnterpriseResources();

            int enterpriseResourceCount = Param.Util.ProjContext.EnterpriseResources.Count;
            Console.WriteLine("resource count is " + enterpriseResourceCount.ToString());
            for (int cnt = enterpriseResourceCount - 1; cnt > -1; cnt--)
            {
                EnterpriseResource resource = Param.Util.ProjContext.EnterpriseResources[cnt];
                if (ContainsResource(resource.Name, Param.Form.MaxResource))
                {
                    Console.WriteLine("resource name is " + resource.Name);
                    //resource.DeleteObject();
                    //resource.ForceCheckIn();
                    ClientResult<bool> ret = Param.Util.ProjContext.EnterpriseResources.Remove(resource);
                    //DeleteResource();
                    if (!ret.Value)
                    {
                        Console.WriteLine("resource name " + resource.Name + " is not deleted..");
                    }

                    if (cnt == 0 || cnt % 20 == 0)
                    {
                        Param.Util.UpdateEnterpriseResource();
                    }
                }
            }
            Param.Util.UpdateEnterpriseResource();
            result.Result = Param.Util.ProjContext.EnterpriseResources;
            return result;
        }
        private bool ContainsResource(string resName, int maxCount)
        {
            for (int i = 0; i < maxCount; i++)
            {
                foreach (ResourceDTO resource in this.resourceTestInfo)
                {
                    string target = resource.Name + i.ToString();
                    if (target == resName || resource.Name == resName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}

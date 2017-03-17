using System;
using PJOMgmt.Util;
using Microsoft.ProjectServer.Client;
using System.Collections.Generic;

namespace PJOMgmt.Resource.Impl
{
    public class CreateEnterpriseResource : AbstractPJOMgmt<EnterpriseResourceCollection>
    {
        IList<ResourceDTO> resourceTestInfo = null;
        public CreateEnterpriseResource(PJOForm param) : base(param)
        {
            resourceTestInfo = Param.Form.TestData;
        }

        public override string ProcessName
        {
            get
            {
                return "エンタープライズリソース作成";
            }
        }

        public override EventResult<EnterpriseResourceCollection> Execute()
        {
            EventResult<EnterpriseResourceCollection> result = new EventResult<EnterpriseResourceCollection>();
            int i = 0;
            for (i = 0; i < Param.Form.MaxResource; i++)
            {
                foreach (ResourceDTO resouceDto in resourceTestInfo)
                {
                    EnterpriseResourceCreationInformation res = new EnterpriseResourceCreationInformation();
                    res.Name = resouceDto.Name + i.ToString();
                    res.Id = Guid.NewGuid();
                    Param.Util.ProjContext.EnterpriseResources.Add(res);
                }
            }

            if (Param.Form.AdditionalCount != 0)
            {
                CreateAdditionalResource(Param);
            }
            Param.Util.ProjContext.EnterpriseResources.Update();
            Param.Util.ProjContext.ExecuteQuery();
            result.Result = Param.Util.ProjContext.EnterpriseResources;
            return result;
        }
        private void CreateAdditionalResource(EventParameter Param)
        {
            int idx = 0;
            foreach (ResourceDTO resouceDto in resourceTestInfo)
            {
                if (Param.Form.AdditionalCount == idx)
                {
                    break;
                }

                EnterpriseResourceCreationInformation res = new EnterpriseResourceCreationInformation();
                res.Name = resouceDto.Name;
                res.Id = Guid.NewGuid();
                Param.Util.ProjContext.EnterpriseResources.Add(res);
                idx++;
            }
        }
    }
}

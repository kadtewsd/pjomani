using Microsoft.ProjectServer.Client;
using System;

namespace PJOMgmt.Resource.Impl
{
    public class PublishedResourceBridge : AbstractProjectResourceBridge<PublishedProject, PublishedProjectResourceCollection, PublishedProjectResource>
    {
        public PublishedResourceBridge(PublishedProject argProjectContext) : base(argProjectContext)
        {

        }

        public override Func<PublishedProjectResource, PublishedProjectResource> StandardRateAction
        {
            get
            {
                return new Func<PublishedProjectResource, PublishedProjectResource>(argResource => {
                    // 読み取り専用
                    //argResource.StandardRate = 1;
                    Console.WriteLine("standard rate is readonly.." + argResource.Name + "'s standard rate " +  argResource.StandardRate + " is skipped..");
                    return argResource;
                });
            }
        }

        protected override void AddResource(PublishedProjectResource resource)
        {
            throw new NotImplementedException();
        }

        protected override PublishedProjectResourceCollection GetResourceCollection()
        {
            return this.project.ProjectResources;
        }

        protected override void LoadProjectAndResources()
        {
            throw new NotImplementedException();
        }

        protected override void RemoveResource(PublishedProjectResource resource)
        {
            throw new NotImplementedException();
        }
    }

}

using Microsoft.ProjectServer.Client;
using System;

namespace PJOMgmt.Resource.Impl
{
    public class DraftProjectResourceBridge : AbstractProjectResourceBridge<DraftProject, DraftProjectResourceCollection, DraftProjectResource>
    {

        protected override void LoadProjectAndResources()
        {
            
        }

        public DraftProjectResourceBridge(DraftProject argProjectContext) : base(argProjectContext)
        {

        }

        public override Func<DraftProjectResource, DraftProjectResource> StandardRateAction
        {
            get
            {
                return new Func<DraftProjectResource, DraftProjectResource>(argResource => {
                    Console.WriteLine("draft standard rate can be written.." + argResource.Name + "'s standard rate " + argResource.StandardRate + " is replaced by 1..");
                    argResource.StandardRate = 1;
                    return argResource;
                });
            }
        }

        protected override DraftProjectResourceCollection GetResourceCollection()
        {
            return this.project.ProjectResources;
        }

        protected override void RemoveResource(DraftProjectResource resource)
        {
            this.project.ProjectResources.Remove(resource);
        }

        protected override void AddResource(DraftProjectResource resource)
        {
            //ProjectResourceCreationInformation newResource = new ProjectResourceCreationInformation();
            //this.project.
            //this.project.ProjectResources.Add(resource);
        }
    }
}

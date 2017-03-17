using Microsoft.ProjectServer.Client;
using System;
using System.Collections;

namespace PJOMgmt.Resource
{
    public abstract class AbstractProjectResourceBridge<TProject, TResourceCol, TResource> where TResourceCol : IEnumerable
    {
        protected TProject project;

        public AbstractProjectResourceBridge(TProject argProject)
        {
            this.project = argProject;
            this.LoadProjectAndResources();
        }

        protected abstract void LoadProjectAndResources();

        protected abstract TResourceCol GetResourceCollection();

        protected abstract void RemoveResource(TResource resource);
        
        protected abstract void AddResource(TResource resource);

        public abstract Func<TResource, TResource> StandardRateAction
        {
            get;
        }

        public void SetResourceProperty(Func<TResource, TResource> action)
        {
            foreach (var row in this.GetResourceCollection())
            {
                TResource resource = (TResource) row;
                RemoveResource(resource);
                TResource result = action(resource);
                AddResource(result);
            }
        }
    }
}

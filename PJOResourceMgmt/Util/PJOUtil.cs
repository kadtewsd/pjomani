using Microsoft.ProjectServer.Client;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.SharePoint.Client; //Include メソッドに必要。
using System;
using System.Security;
using System.Net;
using System.Web;

namespace PJOMgmt.Util
{
    public  class PJOUtil
    {

        private ProjectContext projContext = null;

        public ProjectContext ProjContext
        {
            get
            {
                return projContext;
            }
        }

        public PJOUtil(PJOForm argForm)
        {
            BuildPJOContext(argForm);
        }

        private void BuildPJOContext(PJOForm argForm)
        {
            SecureString securePassword = new SecureString();
            foreach (char c in argForm.Password.ToCharArray())
            {
                securePassword.AppendChar(c);
            }

            this.projContext = new ProjectContext(argForm.Url);

            SharePointOnlineCredentials cred = new SharePointOnlineCredentials(argForm.Account, securePassword);
                projContext.Credentials = cred;
        }

        public IList<ResourceDTO> BuildResourceInfo()
        {
            IList<ResourceDTO> resourceTestInfo = new List<ResourceDTO>();

            Assembly assm = System.Reflection.Assembly.GetAssembly(this.GetType());
            using (StreamReader reader = new StreamReader(assm.GetManifestResourceStream("PJOResourceMgmt.resource.csv")))
            {
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    ResourceDTO info = new ResourceDTO(); ;
                    string[] lines = line.Split(',');
                    info.Name = lines[0];
                    info.Alias = lines[1];
                    resourceTestInfo.Add(info);
                }
            }
            return resourceTestInfo;
        }


        public void LoadPublishedProject()
        {
            projContext.Load(projContext.Projects);
            projContext.ExecuteQuery();
        }

        public DraftProject GetDraftProject(PublishedProject published)
        {
            DraftProject draft = null;
            try
            {
                if (published.Draft.IsCheckedOut)
                {
                    return draft;
                }
                draft = published.CheckOut();
            }
            catch (Exception)
            {
                projContext.Load(published, P1 => P1.Draft);
                projContext.ExecuteQuery();
                return GetDraftProject(published);

            }
            projContext.Load(draft);
            projContext.ExecuteQuery();
            return draft;
        }

        public bool IsCheckedOut(PublishedProject published)
        {
            projContext.Load(published.Draft, P1 => P1.IsCheckedOut, P2 => P2.Name);
            projContext.ExecuteQuery();
            Console.WriteLine("project {0} 's IsCheckedOut is {1}", published.Name, published.IsCheckedOut);
            return published.IsCheckedOut;

        }

        public void CheckInDraftProject(DraftProject draft)
        {
            QueueJob publishJob = draft.Publish(true);
            JobState result = projContext.WaitForQueue(publishJob, 3600);
            Console.WriteLine("publish job state is {0}", result);
        }

        public void LoadPublishedProjectResources(PublishedProject published)
        {
            projContext.Load(published.ProjectResources);
            projContext.ExecuteQuery();
        }

        public void LoadDraftProjectResources(DraftProject draft)
        {
            projContext.Load(draft.ProjectResources);
            projContext.ExecuteQuery();
        }

        public void LoadEnterpriseResources()
        {
            projContext.Load(projContext.EnterpriseResources);
            projContext.ExecuteQuery();
        }

        public IEnumerable<PublishedProject> GetPublishedAndDraftProject()
        {
            IEnumerable<PublishedProject> projectList = //projContext.Load(projContext.Projects);
                projContext.LoadQuery(projContext.Projects.Include(p => p.Draft, p => p.Draft.Id, p => p.Draft.IsCheckedOut, p => p.Name));
            projContext.ExecuteQuery();

            return projectList;
        }

        private const string DateTimeFormat = "yyyy/MM/dd hh:mm:ss";

        public bool UpdateEnterpriseResource(int cnt = 0)
        {
            try
            {
                Console.WriteLine("##################################################");
                Console.WriteLine("start resource update operation. " + DateTime.Now.ToString(DateTimeFormat));
                projContext.EnterpriseResources.Update();
                projContext.ExecuteQuery();
                Console.WriteLine("end resource update operation. " + DateTime.Now.ToString(DateTimeFormat));
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("end resource update operation. {0}. Error Message {1}.", DateTime.Now.ToString(DateTimeFormat), e.Message));
                cnt++;
                if (e.Message == "The operation has timed out." && cnt < 10)
                {
                    Console.WriteLine("retry..");
                    return this.UpdateEnterpriseResource(cnt);
                }
            }
            return true;
        }

        public JobState PublishAndCheckInProject(DraftProject draft)
        {
            QueueJob publishJob = null;
            JobState result = JobState.Failed;
            // Update
            publishJob = draft.Update();
            result = projContext.WaitForQueue(publishJob, 3600);

            // Publish
            publishJob = draft.Publish(true);
            result = projContext.WaitForQueue(publishJob, 3600);

            ; result = this.CheckInProjectForce(draft);

            Console.WriteLine("publish job state is {0}", result);
            return result;
        }

        public JobState CheckInProjectForce(DraftProject draft)
        {
            //CheckIn
            QueueJob publishJob = draft.CheckIn(true);
            JobState result = projContext.WaitForQueue(publishJob, 3600);
            return result;
        }

    }
}

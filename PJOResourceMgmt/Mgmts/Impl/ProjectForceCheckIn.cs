using Microsoft.ProjectServer.Client;
using PJOMgmt.Util;
using System.Collections.Generic;

namespace PJOMgmt.Resource.Impl
{
    public class ProjectForceCheckIn : AbstractPJOMgmt<IList<string>>
    {
        public ProjectForceCheckIn(PJOForm arg) : base(arg)
        {
        }

        public override string ProcessName
        {
            get
            {
                return "Project Online のプロジェクトの強制チェックイン";
            }
        }

        public override EventResult<IList<string>> Execute()
        {
            
            EventResult<IList<string>> result = new EventResult<IList<string>>();
            result.Result = new List<string>();
            Param.Util.LoadPublishedProject();

            foreach (PublishedProject publish in Param.Util.ProjContext.Projects)
            {
                if (Param.Util.IsCheckedOut(publish))
                {
                    Param.Util.CheckInProjectForce(publish.Draft);
                    result.Result.Add(publish.Name);
                }
            }
            
            return result;
        }
    }
}

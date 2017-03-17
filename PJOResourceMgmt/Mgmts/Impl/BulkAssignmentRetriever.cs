using System;
using PJOMgmt.Util;
using Microsoft.ProjectServer.Client;
using PJOResourceMgmt.Mgmts.Model;

namespace PJOMgmt.Resource.Impl
{
    public class BulkAssignmentRetriever : AbstractPJOMgmt<ProjectModel>
    {
        public BulkAssignmentRetriever(PJOForm arg) : base(arg)
        {
        }

        public  override string ProcessName
        {
            get
            {
                return "割り当ての読み込み";
            }
        }

        public override EventResult<ProjectModel> Execute()
        {
            EventResult<ProjectModel> result = new EventResult<ProjectModel>();
            Param.Util.ProjContext.Load(Param.Util.ProjContext.Projects);
            Param.Util.ProjContext.ExecuteQuery();
            foreach (PublishedProject project in Param.Util.ProjContext.Projects)
            {
                Console.WriteLine(project.Name);

                Param.Util.ProjContext.Load(project.Tasks);
                Param.Util.ProjContext.ExecuteQuery();
                foreach (PublishedTask task in project.Tasks)
                {
                    //Param.Util.ProjContext.Load(task, t => t.CustomFields);
                    //Param.Util.ProjContext.ExecuteQuery();
                    //Param.Util.ProjContext.Load(task.StatusManager, u => u.LoginName, u => u.Title);
                    //var value = task.FieldValues["TASK_STATUS_MANAGER_NAME"];
                    Param.Util.ProjContext.Load(task.CustomFields);
                    Param.Util.ProjContext.ExecuteQuery();

                    Param.Util.ProjContext.Load(task.Assignments);
                    Param.Util.ProjContext.ExecuteQuery();

                    foreach (PublishedAssignment assn in task.Assignments)
                    {
                        Param.Util.ProjContext.Load(assn, asign => asign.CustomFields);
                        Param.Util.ProjContext.ExecuteQuery();

                        //StatusManager は存在しないクラスとして認識されているようです。初期化されていません、的なエラーが出ます。
                        //Console.WriteLine("task is {0}.  Status manager is {1}", task.Name, task.StatusManager.LoginName);
                        Console.WriteLine("task is {0}.  Status manager is {1}", task.Name);
                    }
                }
            }
            return result;
        }
    }
}

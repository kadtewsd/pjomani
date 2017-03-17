using Microsoft.ProjectServer.Client;

namespace PJOResourceMgmt.Mgmts.Model
{
    public class ProjectModel
    {
        public string Guid { get; set; }

        public string Title { get; set; }

        public string CheckOutBy { get; set; }

        public PublishedProject Project { get; set; }
    }
}

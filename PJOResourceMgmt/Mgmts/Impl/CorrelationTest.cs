using System;
using PJOMgmt.Util;
using System.Net;
using Microsoft.SharePoint.Client;
using System.Security;

namespace PJOMgmt.Resource.Impl
{
    public class CorrelationTest : AbstractPJOMgmt<string>
    {
        public CorrelationTest(PJOForm arg) : base(arg)
        {
        }

        public override string ProcessName
        {
            get
            {
                return "関連付けID取得テスト";
            }
        }

        public override EventResult<string> Execute()
        {

            EventResult<string> result = new EventResult<string>();

            SecureString securePassword = new SecureString();
            foreach (char c in Param.Form.Password.ToCharArray())
            {
                securePassword.AppendChar(c);
            }

            SharePointOnlineCredentials cred = new SharePointOnlineCredentials(Param.Form.Account, securePassword);
            try
            {
                Param.Util.ProjContext.Credentials = cred;
                Param.Util.ProjContext.Load(Param.Util.ProjContext.Projects);
                Param.Util.ProjContext.ExecuteQuery();
                result.Result = Param.Util.ProjContext.TraceCorrelationId;
            }
            catch (Exception e)
            {
                WebException he = (WebException)e;
                Console.WriteLine(Param.Util.ProjContext.TraceCorrelationId);
                Console.WriteLine(he.Response.Headers["SPRequestGUID"]);
                result.Result = Param.Util.ProjContext.TraceCorrelationId;
                result.ForResearch = he.Response.Headers["SPRequestGUID"];
            }

            Console.WriteLine(Param.Util.ProjContext.TraceCorrelationId);
            return result;
        }
    }
}

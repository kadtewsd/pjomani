using Microsoft.ProjectServer.Client;
using PJOMgmt.Util;
using System.Windows.Forms;

namespace PJOMgmt.Resource
{
    public class PJOController
    {

        public PJOController()
        {

        }

        public EventResult<Result> DoMain<Result>(IPJOManipulator<PJOForm, Result>  res)
        {
            
            res.Form.Enabled = false;
            EventResult<Result> result = res.Execute();
            res.SetResult(result);
            res.Form.Enabled = true;
            MessageBox.Show(string.Format("{0} 処理が完了しました。", res.ProcessName));
            return result;
        }
    }
}

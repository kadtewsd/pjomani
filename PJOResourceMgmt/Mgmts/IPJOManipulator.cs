using PJOMgmt.Util;

namespace PJOMgmt.Resource
{
    public interface IPJOManipulator<T,Result> where T : System.Windows.Forms.Form
    {
        EventResult<Result> Execute();

        string ProcessName { get; }

        PJOUtil Util { get; }

        void SetResult(EventResult<Result> result);

        T Form { get; }
    }
}

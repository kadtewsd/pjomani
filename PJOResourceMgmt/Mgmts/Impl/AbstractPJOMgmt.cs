using PJOMgmt.Util;

namespace PJOMgmt.Resource.Impl
{
    public abstract class AbstractPJOMgmt<Result> : IPJOManipulator<PJOForm, Result>
    {
        protected EventParameter Param { get; private set; }


        public AbstractPJOMgmt(PJOForm arg)
        {
            Param = new EventParameter();
            Param.Form = arg;
            Param.Util = new PJOUtil(arg);
        }

        public PJOForm Form
        {
            get
            {
                return Param.Form;
            }
        }
        
        public PJOUtil Util
        {
            get
            {
                return Param.Util;
            }
        }

        public abstract string ProcessName { get; }

        public abstract EventResult<Result> Execute();

        public virtual void SetResult(EventResult<Result> result)
        {
            return;
        }
    }
}

//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class WfHost<H> : IWfHost<H>
        where H : WfHost<H>, new()
    {
        [MethodImpl(Inline)]
        public static H create() => new H();

        public Type Type {get;}

        [MethodImpl(Inline)]
        protected WfHost()
        {
            Type = typeof(H);
        }

        public virtual void Run(IWfRuntime wf)
        {
            try
            {
                Execute(wf);
            }
            catch(Exception e)
            {
                wf.Error(e);
            }
        }

        protected virtual void Init() { }

        protected abstract void Execute(IWfRuntime shell);

        public virtual string Format()
            => Type.Name;

        [MethodImpl(Inline)]
        public static implicit operator WfStepId(WfHost<H> src)
            => src.Type;

        [MethodImpl(Inline)]
        public static implicit operator WfHost(WfHost<H> src)
            => new WfHost(src.Type);
    }
}
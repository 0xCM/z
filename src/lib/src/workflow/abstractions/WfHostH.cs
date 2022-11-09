//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class KillMe<H> : IWfHost
        where H : KillMe<H>, new()
    {
        [MethodImpl(Inline)]
        public static H create() => new H();

        public Type Type {get;}

        [MethodImpl(Inline)]
        protected KillMe()
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
        public static implicit operator StepId(KillMe<H> src)
            => src.Type;

        [MethodImpl(Inline)]
        public static implicit operator KillMe(KillMe<H> src)
            => new KillMe(src.Type);
    }
}
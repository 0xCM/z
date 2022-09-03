//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [PartExecutor]
    public abstract class PartExecutor<P> : IExecutor<P>
        where P : PartExecutor<P>, new()
    {
        public PartId PartId {get;}

        protected PartExecutor()
        {
            PartId = typeof(P).Assembly.Id();
        }

        public abstract void Run();

        public virtual void Run(dynamic context)
            => Run();
    }

    public abstract class PartExecutor<P,C> : PartExecutor<P>, IExecutor<P,C>
        where P : PartExecutor<P,C>, new()
    {
        public virtual void Run(C context)
            => Run();

        public override void Run(dynamic context)
            => Run((C)context);
    }

    public sealed class PartExecutor : PartExecutor<PartExecutor>
    {
        public override void Run()
        {

        }
    }
}
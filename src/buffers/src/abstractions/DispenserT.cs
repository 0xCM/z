//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Dispenser<T> : IAllocDispenser
        where T : Dispenser<T>
    {
        protected static long Seq;

        [MethodImpl(Inline)]
        protected static uint next()
            => (uint)sys.inc(ref Seq);

        protected object Locker;

        protected abstract void Dispose();

        protected bool OwnsResource {get;}

        protected Dispenser(bool owns)
        {
            Locker = new();
            OwnsResource =owns;
        }

        void IDisposable.Dispose()
        {
            if(OwnsResource)
                Dispose();
        }
    }
}
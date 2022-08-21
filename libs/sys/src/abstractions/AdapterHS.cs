//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Adapter<H,S> : IAdapter<H,S>
        where H : Adapter<H,S>, new()
    {
        public S Subject {get; private set;}

        public static H create(S subject)
        {
            var adapter = new H();
            return adapter.Adapt(subject);
        }

        protected Adapter()
        {

        }

        [MethodImpl(Inline)]
        protected Adapter(S subject)
            => Subject = subject;

        [MethodImpl(Inline)]
        public H Adapt(S subject)
        {
            Subject = subject;
            var host = new H();
            return host.Adapt(subject);
        }

        [MethodImpl(Inline)]
        public static implicit operator S(Adapter<H,S> src)
            => src.Subject;

        [MethodImpl(Inline)]
        public static implicit operator H(Adapter<H,S> src)
            => (H)src;

        [MethodImpl(Inline)]
        public static implicit operator Adapter<H,S>(S src)
            => new H().Adapt(src);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct AdapterHost<H,S> : IAdapter<H,S>
        where H : IAdapter<H,S>, new()
    {
        public S Subject {get; private set;}

        [MethodImpl(Inline)]
        public AdapterHost(S subject)
            => Subject = subject;

        [MethodImpl(Inline)]
        public H Adapt(S subject)
        {
            Subject = subject;
            var host = new H();
            return host.Adapt(subject);
        }

        [MethodImpl(Inline)]
        public static implicit operator S(AdapterHost<H,S> src)
            => src.Subject;
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record struct RunningCmd<T>
        where T : ICmd<T>, new()
    {
        public T Spec;

        [MethodImpl(Inline)]
        public RunningCmd(T spec)
        {
            Spec = spec;
        }

        public static implicit operator RunningCmd<T>(T spec)
            => new RunningCmd<T>(spec);
    }
}
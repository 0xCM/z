//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct KillMe : IWfHost
    {
        public readonly Type Type {get;}

        [MethodImpl(Inline)]
        public KillMe(Type type)
        {
            Type = type;
        }

        [MethodImpl(Inline)]
        public static implicit operator StepId(KillMe src)
            => new StepId(src.Type.Name);

        [MethodImpl(Inline)]
        public static implicit operator KillMe(Type src)
            => new KillMe(src);
    }
}
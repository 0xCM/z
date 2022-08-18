//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Relations
    {
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct TargetKey<T>
        {
            public DomainKey Domain {get;}

            public T Rep {get;}

            [MethodImpl(Inline)]
            public TargetKey(DomainKey d, T rep)
            {
                Domain = d;
                Rep = rep;
            }
        }
    }
}
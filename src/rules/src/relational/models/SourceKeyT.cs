//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Relations
    {
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct SourceKey<S>
        {
            public readonly DomainKey Domain;

            public readonly S Rep;

            [MethodImpl(Inline)]
            public SourceKey(DomainKey d, S rep)
            {
                Domain = d;
                Rep = rep;
            }
        }
    }
}
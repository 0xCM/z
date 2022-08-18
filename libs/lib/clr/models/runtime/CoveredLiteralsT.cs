//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CoveredLiterals<C> : ICoveredLiterals<CoveredLiterals<C>>
        where C : struct, ICoveredLiterals<C>
    {
        public C Cover {get;}

        public FieldInfo[] Covered {get;}

        [MethodImpl(Inline)]
        public CoveredLiterals(C src, FieldInfo[] covered)
        {
            Cover = src;
            Covered = typeof(C).Fields();
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;
    using static core;

    public struct CoveredLiterals
    {
        public ValueType Cover;

        public FieldInfo[] Covered {get;}

        [MethodImpl(Inline)]
        public CoveredLiterals(ValueType cover, FieldInfo[] covered)
        {
            Cover = cover;
            Covered = covered;
        }

        [MethodImpl(Inline)]
        public void WriteValues(Span<object> dst)
        {
            var view = @readonly(Covered);
            var count = view.Length;
            var tRef = __makeref(Cover);
            ref var target = ref first(dst);
            for(var i=0u; i<Covered.Length; i++)
                seek(dst,i) = skip(view,i).GetValueDirect(tRef);
        }
    }
}
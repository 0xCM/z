//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EcmaReader;
    
    partial class XTend
    {
        const TypeAttributes NestedMask = (TypeAttributes)0x00000006;

        [MethodImpl(Inline)]
        public static bool IsNested(this TypeAttributes flags)
            => (flags & NestedMask) != 0;
        
    }
}
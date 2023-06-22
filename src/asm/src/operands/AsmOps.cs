//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct AsmOps
    {
        [MethodImpl(Inline), Op]
        public static AsmOpKind kind(AsmOpClass @class, NativeSize size)
            => (AsmOpKind)math.or((ushort)@class, math.sll((ushort)size,8));
    }
}
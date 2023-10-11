//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static sys;

partial class XedFields
{
    [MethodImpl(Inline), Op]
    public static AsmBroadcast broadcast(in XedFieldState src)
        => asm.broadcast(@as<BroadcastKind>(src.BCAST));
}
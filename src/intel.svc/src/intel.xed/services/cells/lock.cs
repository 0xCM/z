//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

partial class XedCells
{
    [MethodImpl(Inline), Op]
    public static LockIndicator @lock(in InstCells src)
        => new (lockable(src), locked(src));
}


//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static XedModels;
using static sys;

using M = XedModels;

public partial class XedFieldReader
{

    
}

public partial class XedFieldWriter
{

    
}

public partial class XedFields
{
    [MethodImpl(Inline), Op]
    public static ref readonly HintKind hint(in XedFieldState src)
        => ref @as<HintKind>(src.HINT);

    [MethodImpl(Inline), Op]
    public static ref readonly M.RepPrefix rep(in XedFieldState src)
        => ref @as<M.RepPrefix>(src.REP);
}

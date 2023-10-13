//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class XedFieldWriter
{
    [MethodImpl(Inline), Op]
    public static ref MachineMode mode(ref XedFieldState src)
        => ref @as<MachineMode>(src.MODE);    
}

partial class XedFields
{
    [MethodImpl(Inline), Op]
    public static ref readonly MachineMode mode(in XedFieldState src)
        => ref @as<MachineMode>(src.MODE);    
}
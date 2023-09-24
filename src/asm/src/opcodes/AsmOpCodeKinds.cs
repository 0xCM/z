//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using Asm;

public class AsmOpCodeKinds
{
    public static AsmOpCodeKinds Instance => _Instance;

    static AsmOpCodeKinds _Instance = new();

    ReadOnlySeq<OpCodeMapInfo> Data;

    AsmOpCodeKinds()
    {
        Data = AsmOpCodes.info();
    }

    public ReadOnlySpan<OpCodeMapInfo> Records
    {
        [MethodImpl(Inline)]
        get => Data;
    }
}

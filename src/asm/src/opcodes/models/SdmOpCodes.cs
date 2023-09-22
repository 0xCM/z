//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[ApiHost]
public partial class SdmOpCodes : AppService<SdmOpCodes>
{
    const NumericKind Closure = UnsignedInts;

    static SdmOpCodes()
    {

    }

    public SdmOpCodes()
    {

    }

    public static string expression(AsmOcToken src)
    {
        return RP.Error;
    }
}

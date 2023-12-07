//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct Digital
{
    [MethodImpl(Inline), Op]
    public static BinaryDigitCode code(BinaryDigitValue src)
        => (BinaryDigitCode)@char(src);

    [MethodImpl(Inline), Op]
    public static OctalDigitCode code(OctalDigitValue src)
        => (OctalDigitCode)@char(src);

    [MethodImpl(Inline), Op]
    public static DecimalDigitCode code(DecimalDigitValue src)
        => (DecimalDigitCode)@char(src);
}

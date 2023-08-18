//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

public class AsmPrefixByte
{
    public static string format<T>(T src)
        where T : unmanaged, IAsmByte
            => src.Value().FormatHex(zpad:true, specifier:true, uppercase:true);
}

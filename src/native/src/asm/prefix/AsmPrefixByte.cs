//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    public class AsmPrefixByte
    {
        public static string format<T>(T src)
            where T : unmanaged, IAsmByte
                => src.IsEmpty ? EmptyString : src.Value().FormatHex(zpad:true, specifier:true, uppercase:true);
    }
}
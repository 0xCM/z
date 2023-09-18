//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

public class AsmEncoderTests
{
    [MethodImpl(Inline)]
    public static AsmEncoderTests service()
        => Instance;

    readonly ByteBlock256 Jcc8Lookup;

    readonly AsmEncoderData Data;

    AsmEncoderTests()
    {
        Data = AsmEncoderData.get();
        Jcc8Lookup = ByteBlock256.Empty;
        Load();
    }

    void Load()
    {
        var src = Data.Jcc8Codes();
        var count = src.Length;
        var dst = Jcc8Lookup.Bytes;
        for(var i=0; i<count; i++)
        {
            ref readonly var code = ref skip(src,i);
            seek(dst,(byte)code) = (byte)code;
        }
    }

    static readonly AsmEncoderTests Instance = new();
}

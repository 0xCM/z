//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public class HexBlocks
{
    public static void render(ITextEmitter dst)
    {
        var count = 256;
        var src = span<byte>(count);
        for(var i=0; i<count; i++)
            seek(src,i) = (byte)i;

        var fields = text.emitter();

        dst.Append($"public static ReadOnlySpan<byte> Values => new byte[{count}]" + "{");
        for(var i=0; i<count; i++)
        {
            dst.Append($"0x{(Hex8)(i)}, ");

            fields.AppendLine($"public const string x{(Hex8)(i)} = {text.dquote((Hex8)(i))};");
            fields.AppendLine();
        }
        dst.Append("};");

        var target = span<AsciSymbol>(256*2);
        Hex.symbols(src, UpperCase, target);
        var symbols = target;
        var @string = symbols.Format();
        Require.invariant(@string == Hex256.Format());
        dst.AppendLine($"public static ReadOnlySpan<byte> String => {text.dquote(@string)}u8;");


        dst.AppendLine(fields.Emit());

    }
 
    static ReadOnlySpan<byte> Hex256u8 => "000102030405060708090A0B0C0D0E0F101112131415161718191A1B1C1D1E1F202122232425262728292A2B2C2D2E2F303132333435363738393A3B3C3D3E3F404142434445464748494A4B4C4D4E4F505152535455565758595A5B5C5D5E5F606162636465666768696A6B6C6D6E6F707172737475767778797A7B7C7D7E7F808182838485868788898A8B8C8D8E8F909192939495969798999A9B9C9D9E9FA0A1A2A3A4A5A6A7A8A9AAABACADAEAFB0B1B2B3B4B5B6B7B8B9BABBBCBDBEBFC0C1C2C3C4C5C6C7C8C9CACBCCCDCECFD0D1D2D3D4D5D6D7D8D9DADBDCDDDEDFE0E1E2E3E4E5E6E7E8E9EAEBECEDEEEFF0F1F2F3F4F5F6F7F8F9FAFBFCFDFEFF"u8;

    static ReadOnlySpan<AsciSymbol> Hex256 => recover<AsciSymbol>(Hex256u8);
}
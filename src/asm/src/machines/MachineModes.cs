//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public class MachineModes
{
    [MethodImpl(Inline)]
    public static int cmp(MachineModeClass a, MachineModeClass b)
    {
        return order(a).CompareTo(order(b));

        static int order(MachineModeClass src)
            => src switch
            {   MachineModeClass.Mode16 => 0,
                MachineModeClass.Mode32 => 1,
                MachineModeClass.Not64 => 2,
                MachineModeClass.Default => 3,
                MachineModeClass.Mode64 => 4,
                _ => 0,
            };
    }

    public static string format(MachineModeClass src, DataFormatCode fc = DataFormatCode.Expr)
        => fc == DataFormatCode.BitWidth ? nsize((byte)src + 1) : EnumRender.format(ClassRender,src,fc);

    public static bool parse(string src, out MachineModeClass dst)
        => ClassParser.Parse(src, out dst);

    static readonly EnumParser<MachineModeClass> ClassParser = new();

    static EnumRender<MachineModeClass> ClassRender = new();

    static string nsize<T>(T src)
        => ((NativeSize)((NativeSizeCode)u8(src))).Format();

    [SymSource("xed"), DataWidth(4)]
    public enum MachineModeKind : byte
    {
        [Symbol("")]
        None,

        [Symbol("32/64", "LONG_64 mode w/64b addressing")]
        LONG_64,

        [Symbol("32/64", "32b protected mode")]
        LONG_COMPAT_32,

        [Symbol("32/64", "16b protected mode")]
        LONG_COMPAT_16,

        [Symbol("32/64", "LEGACY_32 mode, 32b addressing, 32b default data size")]
        LEGACY_32,

        [Symbol("32/64", "LEGACY_16 mode, 16b addressing, 16b default data size")]
        LEGACY_16,

        [Symbol("32/64", "REAL_16 mode, 16b addressing (20b addresses), 16b default data size")]
        REAL_16,

        [Symbol("32/64", "REAL_32 mode, 16b addressing (20b addresses), 32b default data size (CS.D bit = 1)")]
        REAL_32,
    }

    [SymSource("xed"), DataWidth(3)]
    public enum MachineModeClass : sbyte
    {
        [Symbol("16", "MODE=0")]
        Mode16 = 0,

        [Symbol("32", "MODE=1")]
        Mode32 = 1,

        [Symbol("64", "MODE=2")]
        Mode64 = 2,

        [Symbol("16/32", "MODE!=2")]
        Not64 = 3,

        [Symbol("32/64")]
        Default = 4,
    }

    [SymSource("xed"), DataWidth(4), Flags]
    public enum AddressingKind : byte
    {
        [Symbol("")]
        None=0,

        [Symbol("16b", "16b addressing")]
        w16b=2,

        [Symbol("32b", "32b addressing")]
        w32b=4,

        [Symbol("64b", "64b addressing")]
        w64b=8,
    }       
}

//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    /// <summary>
    /// D:\env\sdks\intel\xed\build\xed-operand-width-enum.h
    /// D:\env\db\intel.xed\sources\all-widths.txt
    /// </summary>
    [SymSource("xed"), DataWidth(num7.Width)]
    public enum WidthCode : byte
    {
        [Symbol("")]
        INVALID,

        [Symbol("asz", "Varies with effective address width and may be one of 2, 4, 8")]
        ASZ,

        [Symbol("ssz", "Varies with stack address width and may be one of 2, 4, or 8")]
        SSZ,

        [Symbol("pseudo")]
        PSEUDO,

        [Symbol("pseudox87")]
        PSEUDOX87,

        [Symbol("a16")]
        A16,

        [Symbol("a32")]
        A32,

        [Symbol("b")]
        B,

        [Symbol("d")]
        D,

        [Symbol("i8")]
        I8,

        [Symbol("u8")]
        U8,

        [Symbol("i16")]
        I16,

        [Symbol("u16")]
        U16,

        [Symbol("i32")]
        I32,

        [Symbol("u32")]
        U32,

        [Symbol("i64")]
        I64,

        [Symbol("u64")]
        U64,

        [Symbol("f16")]
        F16,

        [Symbol("f32")]
        F32,

        [Symbol("f64")]
        F64,

        [Symbol("dq")]
        DQ,

        [Symbol("xub")]
        XUB,

        [Symbol("xuw")]
        XUW,

        [Symbol("xud")]
        XUD,

        [Symbol("xuq")]
        XUQ,

        [Symbol("x128")]
        X128,

        [Symbol("xb")]
        XB,

        [Symbol("xw")]
        XW,

        [Symbol("xd")]
        XD,

        [Symbol("xq")]
        XQ,

        [Symbol("zb")]
        ZB,

        [Symbol("zw")]
        ZW,

        [Symbol("zd")]
        ZD,

        [Symbol("zq")]
        ZQ,

        [Symbol("mb")]
        MB,

        [Symbol("mw")]
        MW,

        [Symbol("md")]
        MD,

        [Symbol("mq")]
        MQ,

        [Symbol("m64int")]
        M64INT,

        [Symbol("m64real")]
        M64REAL,

        [Symbol("mem108")]
        MEM108,

        [Symbol("mem14")]
        MEM14,

        [Symbol("mem16")]
        MEM16,

        [Symbol("mem16int")]
        MEM16INT,

        [Symbol("mem28")]
        MEM28,

        [Symbol("mem32int")]
        MEM32INT,

        [Symbol("mem32real")]
        MEM32REAL,

        [Symbol("mem80dec")]
        MEM80DEC,

        [Symbol("mem80real")]
        MEM80REAL,

        [Symbol("f80")]
        F80,

        [Symbol("mem94")]
        MEM94,

        [Symbol("mfpxenv")]
        MFPXENV,

        [Symbol("mxsave")]
        MXSAVE,

        [Symbol("mprefetch")]
        MPREFETCH,

        [Symbol("p")]
        P,

        [Symbol("p2")]
        P2,

        [Symbol("pd")]
        PD,

        [Symbol("ps")]
        PS,

        [Symbol("pi")]
        PI,

        [Symbol("q")]
        Q,

        [Symbol("s")]
        S,

        [Symbol("s64")]
        S64,

        [Symbol("sd")]
        SD,

        [Symbol("si")]
        SI,

        [Symbol("ss")]
        SS,

        [Symbol("v")]
        V,

        [Symbol("y")]
        Y,

        [Symbol("w")]
        W,

        [Symbol("z")]
        Z,

        [Symbol("spw8")]
        SPW8,

        [Symbol("spw")]
        SPW,

        [Symbol("spw5")]
        SPW5,

        [Symbol("spw3")]
        SPW3,

        [Symbol("spw2")]
        SPW2,

        [Symbol("i1")]
        I1,

        [Symbol("i2")]
        I2,

        [Symbol("i3")]
        I3,

        [Symbol("i4")]
        I4,

        [Symbol("i5")]
        I5,

        [Symbol("i6")]
        I6,

        [Symbol("i7")]
        I7,

        [Symbol("var")]
        VAR,

        [Symbol("bnd32")]
        BND32,

        [Symbol("bnd64")]
        BND64,

        [Symbol("pmmsz16")]
        PMMSZ16,

        [Symbol("pmmsz32")]
        PMMSZ32,

        [Symbol("qq")]
        QQ,

        [Symbol("yub")]
        YUB,

        [Symbol("yuw")]
        YUW,

        [Symbol("yud")]
        YUD,

        [Symbol("yuq")]
        YUQ,

        [Symbol("y128")]
        Y128,

        [Symbol("yb")]
        YB,

        [Symbol("yw")]
        YW,

        [Symbol("yd")]
        YD,

        [Symbol("yq")]
        YQ,

        [Symbol("yps")]
        YPS,

        [Symbol("ypd")]
        YPD,

        [Symbol("zbf16")]
        ZBF16,

        [Symbol("vv")]
        VV,

        [Symbol("zv")]
        ZV,

        [Symbol("wrd")]
        WRD,

        [Symbol("mskw")]
        MSKW,

        [Symbol("zmskw")]
        ZMSKW,

        [Symbol("zf32")]
        ZF32,

        [Symbol("zf64")]
        ZF64,

        [Symbol("zub")]
        ZUB,

        [Symbol("zuw")]
        ZUW,

        [Symbol("zud")]
        ZUD,

        [Symbol("zuq")]
        ZUQ,

        [Symbol("zi8")]
        ZI8,

        [Symbol("zi16")]
        ZI16,

        [Symbol("zi32")]
        ZI32,

        [Symbol("zi64")]
        ZI64,

        [Symbol("zu8")]
        ZU8,

        [Symbol("zu16")]
        ZU16,

        [Symbol("zu32")]
        ZU32,

        [Symbol("zu64")]
        ZU64,

        [Symbol("zu128")]
        ZU128,

        [Symbol("m384", "struct/48 bytes")]
        M384,

        [Symbol("m512", "struct/64 bytes")]
        M512,

        [Symbol("ptr")]
        PTR,

        [Symbol("tmemrow")]
        TMEMROW,

        [Symbol("tmemcol")]
        TMEMCOL,

        [Symbol("tv")]
        TV,

        [Symbol("f16")]
        ZF16,
        
        [Symbol("2f16")]
        Z2F16,
    }
}
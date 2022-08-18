//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
using K = Z0.Pow2Scalars;

/// <summary>
/// Defines operand kind identity classifiers
/// </summary>
public enum ApiClassKind : ushort
{
    /// <summary>
    /// The empty identity
    /// </summary>
    None = 0,

    And,

    CNonImpl,

    LProject,

    NonImpl,

    RProject,

    Xor,

    Or,

    Nor,

    Xnor,

    RNot,

    Impl,

    LNot,

    CImpl,

    Nand,

    True,

    Not,

    Reverse,

    Select,

    Inc,

    Dec,

    Negate,

    Negative,

    Positive,

    /// <summary>
    /// Classifies a unary operator that returns true iff its operand has a non-zero value
    /// </summary>
    Nonz,

    Abs,

    Square,

    Sqrt,

    Add,

    /// <summary>
    /// Saturated addition
    /// </summary>
    AddS,

    /// <summary>
    /// Horizontal addition
    /// </summary>
    AddH,

    /// <summary>
    /// Horizontal saturated addition
    /// </summary>
    AddHS,

    /// <summary>
    /// Sum absolute differences
    /// </summary>
    Sad,

    /// <summary>
    /// Horizontal subtraction
    /// </summary>
    Sub,

    SubH,

    SubHS,

    SubS,

    Mul,

    MulLo,

    MulHi,

    MulX,

    Div,

    Divides,

    Mod,

    Clamp,

    Dist,

    ClMul,

    Dot,

    Sll,

    Sllv,

    Srl,

    Srlv,

    Sal,

    Sra,

    Rotl,

    Rotlv,

    Rotr,

    Rotrv,

    XorSl,

    XorSr,

    Xors,

    Eq,

    Neq,

    Lt,

    LtEq,

    Gt,

    GtEq,

    Gtz,

    Ltz,

    Eqz,

    Between,

    EqB,

    NeqB,

    LtB,

    LtEqB,

    GtB,

    GtEqB,

    Within,

    Max,

    Min,

    Identity,

    Sum,

    Avg,

    Avgz,

    Avgi,

    AggMax,

    AggMin,

    TestC,

    BitCopy,

    TestZ,

    Fma,

    ModMul,

    Concat,

    Broadcast,

    Ceil,

    Floor,

    Even,

    Odd,

    Round,

    Pow,

    Ntz,

    Nlz,

    Pop,

    Mux,

    Scatter,

    Gather,

    Mix,

    Rank,

    Bsrl,

    Bsll,

    XorNot,

    Parse,

    EqPred,

    NeqPred,

    LtPred,

    LtEqPred,

    GtPred,

    GtEqPred,

    Rotrx,

    Rotlx,

    Sllx,

    Srlx,

    BitSlice,

    TestBit,

    SetBit,

    TestBits,

    Stitch,

    Slice,

    BitClear,

    MoveMask,

    MoveIMask,

    BitCell,

    Enable,

    Disable,

    Hi,

    Lo,

    Msb,

    Lsb,

    Left,

    Right,

    Replicate,

    HiSeg,

    LoSeg,

    MsbOff,

    Log2,

    Log10,

    Ln,

    Log,

    Split,

    Toggle,

    Pack,

    Unpack,

    HProd,

    TestZnC,

    Same,

    Alloc,

    Init,

    Load,

    Store,

    Flow,

    Zero,

    One,

    Kind,

    /// <summary>
    /// Identifies an operation that evaluates one or more operands to determine that a subject is, or is not, of some target kind
    /// </summary>
    Test,

    Ones,

    Zeroes,

    /// <summary>
    /// Identifies an operation that reifies a switch expression
    /// </summary>
    Switch,

    Copy,

    DivMod,

    /// <summary>
    /// Identifies an operation that computes the effective bit-width of a value
    /// </summary>
    EffWidth,

    /// <summary>
    /// Identifies an operation that computes the effective byte-width of a value
    /// </summary>
    EffSize,

    /// <summary>
    /// Identifies a function that accepts two homogenous values, and perhaps other ingredients, and produces
    /// an output value where each target component represents a join, via some means, of corresponding operand components
    /// </summary>
    Zip,

    Map,

    VZip,

    VMap,

    Recover,

    SeqMap,

    MemAdd,

    MemSub,

    ZeroExtend,

    SignExtend,

    /// <summary>
    /// Classifies bijective operators
    /// </summary>
    Bijection,

    Byteswap,

    Concretizer,

    ParseFunction,

    LsbOff,

    XLsb,

    XMsb,

    AddAssign,

    SubAssign,

    MulAssign,

    DivAssign,

    BitSeg,

    // ~~ Instructions/Intrinsics
    // ~~ -------------------------------------------------------------------------------------------------------------

    CVTSS2SI = K.T11,

    CVTSD2SI,

    PAVGB,

    PAVGW,

    VPAVGB,

    VPAVGW,

    PSHUFLW,

    PSHUFHW,

    PSHUFB,

    VPSHUFB,

    VPERMD,

    VPERMPS,

    VPERMQ,

    VPERMPD,

    Asm = K.T11,

    // ~~ System-level operations
    // ~~ -------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Identifies a function that invokes framework/system operations which are located in an external scope that does not dissolve
    /// </summary>
    Opaque = K.T12,

    KindFactory = K.T13,
}
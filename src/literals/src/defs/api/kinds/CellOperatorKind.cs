//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using NBK = NumericBaseKind;

    using W = CpuCellWidth;
    using P2 = Pow2x32;

    /// <summary>
    /// Defines operator classifiers
    /// </summary>
    [SymSource(api_kinds, NBK.Base16), Flags]
    public enum CellOperationKind : uint
    {
        /// <summary>
        /// Classifies nothing
        /// </summary>
        None = 0,

        /// <summary>
        /// Classifies a fixed operand type
        /// </summary>
        Operand = P2.P2ᐞ10,

        /// <summary>
        /// Classifies a fixed return type
        /// </summary>
        Return = Operand << 1,

        /// <summary>
        /// The first slot
        /// </summary>
        Pos0 = Return << 1,

        /// <summary>
        /// The second slot
        /// </summary>
        Pos1 = Pos0 << 1,

        /// <summary>
        /// The third slot
        /// </summary>
        Pos2 = Pos1 << 1,

        /// <summary>
        /// The fourth slot
        /// </summary>
        Pos3 = Pos2 << 1,

        /// <summary>
        /// The pentultimate slot
        /// </summary>
        Pos4 = Pos3 << 1,

        /// <summary>
        /// The last slot
        /// </summary>
        Pos5 = Pos4 << 1,

        /// <summary>
        /// The signature specification lower bound
        /// </summary>
        SigSpec = Pos5 << 1,

        /// <summary>
        /// The function signature specification lower bound
        /// </summary>
        Function = SigSpec << 1,

        /// <summary>
        /// The operator signature specification lower bound
        /// </summary>
        Operator = SigSpec << 2,

        /// <summary>
        /// A unary function f:w1 -> w1
        /// </summary>
        UnaryFunc1x1 = Function | Op1x0 | Ret1,

        /// <summary>
        /// A unary function f:w1 -> w8
        /// </summary>
        UnaryFunc1x8 = Function | Op1x0 | Ret8,

        /// <summary>
        /// A unary function f:w1 -> w16
        /// </summary>
        UnaryFunc1x16 = Function | Op1x0 | Ret16,

        /// <summary>
        /// A unary function f:w1 -> w32
        /// </summary>
        UnaryFunc1x32 = Function | Op1x0 | Ret32,

        /// <summary>
        /// A unary function f:w1 -> w64
        /// </summary>
        UnaryFunc1x64 = Function | Op1x0 | Ret64,

        /// <summary>
        /// A 1-bit unary operator
        /// </summary>
        UnaryOp1 = Operator | Op1x0 | Ret1,

        /// <summary>
        /// An 8-bit unary operator
        /// </summary>
        UnaryOp8 = Operator | Op8x0 | Ret8,

        /// <summary>
        /// An 16-bit unary operator
        /// </summary>
        UnaryOp16 = Operator | Op16x0 | Ret16,

        /// <summary>
        /// An 32-bit unary operator
        /// </summary>
        UnaryOp32 =  Operator | Op32x0 | Ret32,

        /// <summary>
        /// An 64-bit unary operator
        /// </summary>
        UnaryOp64 = Operator | Op64x0 | Ret64,

        /// <summary>
        /// An 128-bit unary operator
        /// </summary>
        UnaryOp128 = Operator | Op128x0 | Ret128,

        /// <summary>
        /// An 256-bit unary operator
        /// </summary>
        UnaryOp256 = Operator | Op256x0 | Ret256,

        /// <summary>
        /// An 512-bit unary operator
        /// </summary>
        UnaryOp512 = Operator | Op512x0 | Ret512,

        /// <summary>
        /// A 1-bit binary operator
        /// </summary>
        BinaryOp1 = Operator | Op1x0 | Op8x1 | Ret1,

        /// <summary>
        /// An 8-bit binary operator
        /// </summary>
        BinaryOp8 = Operator | Op8x0 | Op8x1 | Ret8,

        /// <summary>
        /// An 16-bit binary operator
        /// </summary>
        BinaryOp16 = Operator | Op16x0 | Cell16x1 | Ret16,

        /// <summary>
        /// An 32-bit binary operator
        /// </summary>
        BinaryOp32 =  Operator | Op32x0 | Cell32x1 |Ret32,

        /// <summary>
        /// An 64-bit binary operator
        /// </summary>
        BinaryOp64 = Operator | Op64x0 | Op64x1 | Ret64,

        /// <summary>
        /// An 128-bit binary operator
        /// </summary>
        BinaryOp128 = Operator | Op128x0 | Op128x1 | Ret128,

        /// <summary>
        /// An 256-bit binary operator
        /// </summary>
        BinaryOp256 = Operator | Op256x0 | Op256x1 | Ret256,

        /// <summary>
        /// An 512-bit binary operator
        /// </summary>
        BinaryOp512 = Operator | Op512x0 | Op512x1 | Ret512,

        /// <summary>
        /// A 1-bit ternary operator
        /// </summary>
        TernaryOp1 = Operator | Op1x0 | Op8x1 | Cell8x2 | Ret1,

        /// <summary>
        /// An 8-bit ternary operator
        /// </summary>
        TernaryOp8 = Operator | Op8x0 | Op8x1 | Cell8x2 | Ret8,

        /// <summary>
        /// An 16-bit ternary operator
        /// </summary>
        TernaryOp16 = Operator | Op16x0 | Cell16x1 | Op16x2 | Ret16,

        /// <summary>
        /// An 32-bit ternary operator
        /// </summary>
        TernaryOp32 =  Operator | Op32x0 | Cell32x1 | Op32x2 | Ret32,

        /// <summary>
        /// An 64-bit ternary operator
        /// </summary>
        TernaryOp64 = Operator | Op64x0 | Op64x1 | Op64x2 | Ret64,

        /// <summary>
        /// An 128-bit ternary operator
        /// </summary>
        TernaryOp128 = Operator | Op128x0 | Op128x1 | Op128x2 | Ret128,

        /// <summary>
        /// An 256-bit ternary operator
        /// </summary>
        TernaryOp256 = Operator | Op256x0 | Op256x1 | Op256x2 | Ret256,

        /// <summary>
        /// An 512-bit ternary operator
        /// </summary>
        TernaryOp512 = Operator | Op512x0 | Op512x1 | Op512x2 | Ret512,

        /// <summary>
        /// The first operand slot
        /// </summary>
        Op0 = Pos0 | Operand,

        /// <summary>
        /// The second operand slot
        /// </summary>
        Op1 = Pos1 | Operand,

        /// <summary>
        /// The third operand slot
        /// </summary>
        Op2 = Pos2 | Operand,

        /// <summary>
        /// The fourth operand slot
        /// </summary>
        Op3 = Pos3 | Operand,

        /// <summary>
        /// The fifth operand slot
        /// </summary>
        Op4 = Pos4 | Operand,

        /// <summary>
        /// 1-bit operand in slot 0
        /// </summary>
        Op1x0 = Op0 | W.W1,

        /// <summary>
        /// 1-bit operand in slot 1
        /// </summary>
        Op1x1 = Op1 | W.W1,

        /// <summary>
        /// 1-bit operand in slot 2
        /// </summary>
        Op1x2 = Op2 | W.W1,

        /// <summary>
        /// 1-bit operand in slot 3
        /// </summary>
        Op1x3 = Op2 | W.W1,

        /// <summary>
        /// 1-bit operand in slot 4
        /// </summary>
        Op1x4 = Op4 | W.W1,

        /// <summary>
        /// 8-bit operand in slot 0
        /// </summary>
        Op8x0 = Op0 | W.W8,

        /// <summary>
        /// 8-bit operand in slot 1
        /// </summary>
        Op8x1 = Op1 | W.W8,

        /// <summary>
        /// 8-bit operand in slot 2
        /// </summary>
        Cell8x2 = Op2 | W.W8,

        /// <summary>
        /// 8-bit operand in slot 3
        /// </summary>
        Op8x3 = Op2 | W.W8,

        /// <summary>
        /// 8-bit operand in slot 4
        /// </summary>
        Op8x4 = Op4 | W.W8,

        /// <summary>
        /// 16-bit operand in slot 0
        /// </summary>
        Op16x0 = Op0 | W.W16,

        /// <summary>
        /// 16-bit operand in slot 1
        /// </summary>
        Cell16x1 = Op1 | W.W16,

        /// <summary>
        /// 16-bit operand in slot 2
        /// </summary>
        Op16x2 = Op2 | W.W16,

        /// <summary>
        /// 16-bit operand in slot 3
        /// </summary>
        Op16x3 = Op2 | W.W16,

        /// <summary>
        /// 16-bit operand in slot 4
        /// </summary>
        Op16x4 = Op4 | W.W16,

        /// <summary>
        /// 32-bit operand in slot 0
        /// </summary>
        Op32x0 = Op0 | W.W32,

        /// <summary>
        /// 32-bit operand in slot 1
        /// </summary>
        Cell32x1 = Op1 | W.W32,

        /// <summary>
        /// 32-bit operand in slot 2
        /// </summary>
        Op32x2 = Op2 | W.W32,

        /// <summary>
        /// 32-bit operand in slot 3
        /// </summary>
        Op32x3 = Op2 | W.W32,

        /// <summary>
        /// 32-bit operand in slot 4
        /// </summary>
        Op32x4 = Op4 | W.W32,

        /// <summary>
        /// 64-bit operand in slot 0
        /// </summary>
        Op64x0 = Op0 | W.W64,

        /// <summary>
        /// 64-bit operand in slot 1
        /// </summary>
        Op64x1 = Op1 | W.W64,

        /// <summary>
        /// 64-bit operand in slot 2
        /// </summary>
        Op64x2 = Op2 | W.W64,

        /// <summary>
        /// 64-bit operand in slot 3
        /// </summary>
        Op64x3 = Op2 | W.W64,

        /// <summary>
        /// 64-bit operand in slot 4
        /// </summary>
        Op64x4 = Op4 | W.W64,

        /// <summary>
        /// 64-bit operand in slot 0
        /// </summary>
        Op128x0 = Op0 | W.W128,

        /// <summary>
        /// 128-bit operand in slot 1
        /// </summary>
        Op128x1 = Op1 | W.W128,

        /// <summary>
        /// 128-bit operand in slot 2
        /// </summary>
        Op128x2 = Op2 | W.W128,

        /// <summary>
        /// 128-bit operand in slot 3
        /// </summary>
        Op128x3 = Op3 | W.W128,

        /// <summary>
        /// 128-bit operand in slot 4
        /// </summary>
        Op128x4 = Op4 | W.W128,

        /// <summary>
        /// 64-bit operand in slot 0
        /// </summary>
        Op256x0 = Op0 | W.W256,

        /// <summary>
        /// 256-bit operand in slot 1
        /// </summary>
        Op256x1 = Op1 | W.W256,

        /// <summary>
        /// 256-bit operand in slot 2
        /// </summary>
        Op256x2 = Op2 | W.W256,

        /// <summary>
        /// 256-bit operand in slot 3
        /// </summary>
        Op256x3 = Op3 | W.W256,

        /// <summary>
        /// 256-bit operand in slot 4
        /// </summary>
        Cell256x4 = Op4 | W.W256,

        /// <summary>
        /// 64-bit operand in slot 0
        /// </summary>
        Op512x0 = Op0 | W.W512,

        /// <summary>
        /// 512-bit operand in slot 1
        /// </summary>
        Op512x1 = Op1 | W.W512,

        /// <summary>
        /// 512-bit operand in slot 2
        /// </summary>
        Op512x2 = Op2 | W.W512,

        /// <summary>
        /// 512-bit operand in slot 3
        /// </summary>
        Op512x3 = Op2 | W.W512,

        /// <summary>
        /// 512-bit operand in slot 4
        /// </summary>
        Op512x4 = Op4 | W.W512,

        /// <summary>
        /// 1-bit return in last slot
        /// </summary>
        Ret1 = Return | W.W1,

        /// <summary>
        /// 8-bit return in last slot
        /// </summary>
        Ret8 = Return | W.W8,

        /// <summary>
        /// 16-bit return in last slot
        /// </summary>
        Ret16 = Return | W.W16,

        /// <summary>
        /// 32-bit return in last slot
        /// </summary>
        Ret32 = Return | W.W32,

        /// <summary>
        /// 64-bit return in last slot
        /// </summary>
        Ret64 = Return | W.W64,

        /// <summary>
        /// 128-bit return in last slot
        /// </summary>
        Ret128 = Return | W.W128,

        /// <summary>
        /// 256-bit return in last slot
        /// </summary>
        Ret256 = Return | W.W256,

        /// <summary>
        /// 512-bit return in last slot
        /// </summary>
        Ret512 = Return | W.W512,
    }
}
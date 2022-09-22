//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CellDelegates;

    public interface IDynexus
    {
        UnaryOp<T> EmitUnaryOp<T>(BufferToken dst, ApiCodeBlock src)
            where T : unmanaged;

        BinaryOp<T> EmitBinaryOp<T>(BufferToken dst, ApiCodeBlock src)
            where T : unmanaged;

        TernaryOp<T> EmitTernaryOp<T>(BufferToken dst, ApiCodeBlock src)
            where T : unmanaged;

        /// <summary>
        /// Creates a unary operator with an embedded immediate value
        /// </summary>
        /// <param name="w">The operand width</param>
        /// <param name="src">The defining method that requires an immediate value</param>
        /// <param name="imm">The immediate value to embed</param>
        Option<DynamicDelegate> CreateUnaryOp(NativeTypeWidth w, MethodInfo src, byte imm);

        /// <summary>
        /// Creates a binary operator with an embedded immediate value
        /// </summary>
        /// <param name="w">The operand width</param>
        /// <param name="src">The defining method that requires an immediate value</param>
        /// <param name="imm">The immediate value to embed</param>
        Option<DynamicDelegate> CreateBinaryOp(NativeTypeWidth w, MethodInfo src, byte imm);

        /// <summary>
        /// Creates a 128-bit vectorized parametric unary operator that consumes an immediate value in the second argument
        /// </summary>
        /// <param name="src">The defining method</param>
        /// <param name="imm">The immediate value to embed</param>
        /// <typeparam name="T">The operand type</typeparam>
        DynamicDelegate<UnaryOp<Vector128<T>>> CreateUnaryOp<T>(MethodInfo src, W128 w, byte imm)
            where T : unmanaged;

        /// <summary>
        /// Creates a parametric 128-bit vectorized binary operator that adapts a like-kinded operator that consumes an immediate value in the third argument
        /// </summary>
        /// <param name="src">The defining method</param>
        /// <param name="imm">The immediate value to embed</param>
        /// <typeparam name="T">The operand type</typeparam>
        DynamicDelegate<BinaryOp<Vector128<T>>> CreateBinaryOp<T>(MethodInfo src, W128 w, byte imm)
            where T : unmanaged;

        /// <summary>
        /// Creates a parametric 128-bit vectorized unary operator that adapts a like-kinded operator that consumes an immediate value in the second argument
        /// </summary>
        /// <param name="src">The defining method</param>
        /// <param name="imm">The immediate value to embed</param>
        /// <typeparam name="T">The operand type</typeparam>
        DynamicDelegate<UnaryOp<Vector256<T>>> CreateUnaryOp<T>(MethodInfo src, W256 w, byte imm)
            where T : unmanaged;

        /// <summary>
        /// Creates a parametric 256-bit vectorized binary operator that adapts a like-kinded operator that consumes an immediate value in the third argument
        /// </summary>
        /// <param name="src">The defining method</param>
        /// <param name="imm">The immediate value to embed</param>
        /// <typeparam name="T">The operand type</typeparam>
        DynamicDelegate<BinaryOp<Vector256<T>>> CreateBinaryOp<T>(MethodInfo src, W256 w, byte imm)
            where T : unmanaged;

        /// <summary>
        /// Loads executable source into an identified buffer and creates a fixed unary operator over the buffer
        /// </summary>
        /// <param name="buffer">The target buffer</param>
        /// <param name="src">The executable source</param>
        /// <typeparam name="F">The fixed operand type</typeparam>
        UnaryOp<F> EmitFixedUnary<F>(BufferToken dst, ApiCodeBlock src);

        /// <summary>
        /// Loads source into a token-identified buffer and covers it with a fixed binary operator
        /// </summary>
        /// <param name="buffer">The target buffer</param>
        /// <param name="src">The code to load</param>
        /// <typeparam name="F">The fixed operand type</typeparam>
        BinaryOp<F> EmitFixedBinary<F>(BufferToken buffer, ApiCodeBlock src);

        /// <summary>
        /// Loads executable source into an identified buffer and creates a fixed unary operator over the buffer
        /// </summary>
        /// <param name="dst">The target buffer</param>
        /// <param name="src">The executable source</param>
        /// <typeparam name="F">The fixed operand type</typeparam>
        TernaryOp<F> EmitFixedTernary<F>(BufferToken dst, ApiCodeBlock src);

        /// <summary>
        /// Creates a fixed 8-bit unary operator from caller-supplied x86 source code
        /// </summary>
        /// <param name="dst">The target buffer sequence</param>
        /// <param name="w">The width selector</param>
        /// <param name="src">The source code</param>
        UnaryOp8 EmitFixedUnary(BufferToken dst, W8 w, ApiCodeBlock src);

        /// <summary>
        /// Creates a fixed 16-bit unary operator from caller-supplied x86 source code
        /// </summary>
        /// <param name="dst">The target buffer sequence</param>
        /// <param name="w">The width selector</param>
        /// <param name="src">The source code</param>
        UnaryOp16 EmitFixedUnary(BufferToken dst, W16 w, ApiCodeBlock src);

        /// <summary>
        /// Creates a fixed 32-bit unary operator from caller-supplied x86 source code
        /// </summary>
        /// <param name="dst">The target buffer sequence</param>
        /// <param name="w">The width selector</param>
        /// <param name="src">The source code</param>
        UnaryOp32 EmitFixedUnary(BufferToken dst, W32 w, ApiCodeBlock src);

        /// <summary>
        /// Creates a fixed 64-bit unary operator from caller-supplied x86 source code
        /// </summary>
        /// <param name="dst">The target buffer sequence</param>
        /// <param name="index">The index of the buffer to load</param>
        /// <param name="w">The width selector</param>
        /// <param name="src">The source code</param>
        UnaryOp64 EmitFixedUnary(BufferToken dst, W64 w, ApiCodeBlock src);

        /// <summary>
        /// Creates a fixed 128-bit unary operator from caller-supplied x86 source code
        /// </summary>
        /// <param name="dst">The target buffer sequence</param>
        /// <param name="w">The width selector</param>
        /// <param name="src">The source code</param>
        UnaryOp128 EmitFixedUnary(BufferToken dst, W128 w, ApiCodeBlock src);

        /// <summary>
        /// Creates a fixed 256-bit unary operator from caller-supplied x86 source code
        /// </summary>
        /// <param name="dst">The target buffer sequence</param>
        /// <param name="w">The width selector</param>
        /// <param name="src">The source code</param>
        UnaryOp256 EmitFixedUnary(BufferToken dst, W256 w, ApiCodeBlock src);

        /// <summary>
        /// Creates a fixed 8-bit binary operator from caller-supplied x86 source code
        /// </summary>
        /// <param name="dst">The target buffer sequence</param>
        /// <param name="index">The index of the buffer to load</param>
        /// <param name="w">The width selector</param>
        /// <param name="src">The source code</param>
        BinaryOp8 EmitFixedBinary(BufferToken dst, W8 w, ApiCodeBlock src);

        /// <summary>
        /// Creates a fixed 16-bit binary operator from caller-supplied x86 source code
        /// </summary>
        /// <param name="dst">The target buffer sequence</param>
        /// <param name="index">The index of the buffer to load</param>
        /// <param name="w">The width selector</param>
        /// <param name="src">The source code</param>
        BinaryOp16 EmitFixedBinary(BufferToken dst, W16 w, ApiCodeBlock src);

        /// <summary>
        /// Creates a fixed 32-bit binary operator from caller-supplied x86 source code
        /// </summary>
        /// <param name="dst">The target buffer sequence</param>
        /// <param name="index">The index of the buffer to load</param>
        /// <param name="w">The width selector</param>
        /// <param name="src">The source code</param>
        BinaryOp32 EmitFixedBinary(BufferToken dst, W32 w, ApiCodeBlock src);

        /// <summary>
        /// Creates a fixed 64-bit binary operator from caller-supplied x86 source code
        /// </summary>
        /// <param name="dst">The target buffer sequence</param>
        /// <param name="index">The index of the buffer to load</param>
        /// <param name="w">The width selector</param>
        /// <param name="src">The source code</param>
        BinaryOp64 EmitFixedBinary(BufferToken dst, W64 w, ApiCodeBlock src);

        /// <summary>
        /// Creates a fixed 128-bit binary operator from caller-supplied x86 source code
        /// </summary>
        /// <param name="dst">The target buffer sequence</param>
        /// <param name="index">The index of the buffer to load</param>
        /// <param name="w">The width selector</param>
        /// <param name="src">The source code</param>
        BinaryOp128 EmitFixedBinary(BufferToken dst, W128 w, ApiCodeBlock src);

        /// <summary>
        /// Creates a fixed 256-bit binary operator from caller-supplied x86 source code
        /// </summary>
        /// <param name="dst">The target buffer sequence</param>
        /// <param name="index">The index of the buffer to load</param>
        /// <param name="w">The width selector</param>
        /// <param name="src">The source code</param>
        BinaryOp256 EmitFixedBinary(BufferToken dst, W256 w, ApiCodeBlock src);
    }
}
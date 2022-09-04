//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static CellDelegates;

    partial class Dynop
    {
        /// <summary>
        /// Creates a fixed 8-bit binary operator from caller-supplied x86 source code
        /// </summary>
        /// <param name="buffer">Identifies the target buffer</param>
        /// <param name="w">The width selector</param>
        /// <param name="src">The source code</param>
        [Op]
        public static BinaryOp8 EmitBinaryCellOp(this BufferToken buffer, N8 w, ApiCodeBlock src)
            => buffer.Load(src.Encoded).EmitBinaryCellOp(w, src.Id);

        /// <summary>
        /// Creates a fixed 16-bit binary operator from caller-supplied x86 source code
        /// </summary>
        /// <param name="buffer">Identifies the target buffer</param>
        /// <param name="w">The width selector</param>
        /// <param name="src">The source code</param>
        [Op]
        public static BinaryOp16 EmitBinaryCellOp(this BufferToken buffer, N16 w, ApiCodeBlock src)
            => buffer.Load(src.Encoded).EmitBinaryCellOp(w, src.Id);

        /// <summary>
        /// Creates a fixed 32-bit binary operator from caller-supplied x86 source code
        /// </summary>
        /// <param name="buffer">Identifies the target buffer</param>
        /// <param name="w">The width selector</param>
        /// <param name="src">The source code</param>
        [Op]
        public static BinaryOp32 EmitBinaryCellOp(this BufferToken buffer, N32 w, ApiCodeBlock src)
            => buffer.Load(src.Encoded).EmitBinaryCellOp(w, src.Id);

        /// <summary>
        /// Creates a fixed 64-bit binary operator from caller-supplied x86 source code
        /// </summary>
        /// <param name="buffer">Identifies the target buffer</param>
        /// <param name="w">The width selector</param>
        /// <param name="src">The source code</param>
        [Op]
        public static BinaryOp64 EmitBinaryCellOp(this BufferToken buffer, N64 w, ApiCodeBlock src)
            => buffer.Load(src.Encoded).EmitBinaryCellOp(w, src.Id);

        /// <summary>
        /// Creates a fixed 128-bit binary operator from caller-supplied x86 source code
        /// </summary>
        /// <param name="buffer">Identifies the target buffer</param>
        /// <param name="w">The width selector</param>
        /// <param name="src">The source code</param>
        [Op]
        public static BinaryOp128 EmitBinaryCellOp(this BufferToken buffer, N128 w, ApiCodeBlock src)
            => buffer.Load(src.Encoded).EmitBinaryCellOp(w, src.Id);

        /// <summary>
        /// Creates a fixed 256-bit binary operator from caller-supplied x86 source code
        /// </summary>
        /// <param name="buffer">Identifies the target buffer</param>
        /// <param name="w">The width selector</param>
        /// <param name="src">The source code</param>
        [Op]
        public static BinaryOp256 EmitBinaryCellOp(this BufferToken buffer, N256 w, ApiCodeBlock src)
            => buffer.Load(src.Encoded).EmitBinaryCellOp(w, src.Id);

        [Op]
        internal static CellDelegate EmitBinaryCellOp(this IBufferToken dst, _OpIdentity id, Type operatorType, Type operandType)
            => dst.Handle.EmitCellular(id,functype:operatorType, result:operandType, args: array(operandType, operandType));

        [Op]
        internal static BinaryOp8 EmitBinaryCellOp(this IBufferToken buffer, N8 w,_OpIdentity id)
            => (BinaryOp8)buffer.EmitBinaryCellOp(id, typeof(BinaryOp8), typeof(Cell8));

        [Op]
        internal static BinaryOp16 EmitBinaryCellOp(this IBufferToken buffer, N16 w, _OpIdentity id)
            => (BinaryOp16)buffer.EmitBinaryCellOp(id, typeof(BinaryOp16), typeof(Cell16));

        [Op]
        internal static BinaryOp32 EmitBinaryCellOp(this IBufferToken buffer, N32 w, _OpIdentity id)
            => (BinaryOp32)buffer.EmitBinaryCellOp(id, typeof(BinaryOp32), typeof(Cell32));

        [Op]
        internal static BinaryOp64 EmitBinaryCellOp(this IBufferToken buffer, N64 w, _OpIdentity id)
            => (BinaryOp64)buffer.EmitBinaryCellOp(id, typeof(BinaryOp64), typeof(Cell64));

        [Op]
        internal static BinaryOp128 EmitBinaryCellOp(this IBufferToken buffer, N128 w, _OpIdentity id)
            => (BinaryOp128)buffer.EmitBinaryCellOp(id, typeof(BinaryOp128), typeof(Cell128));

        [Op]
        internal static BinaryOp256 EmitBinaryCellOp(this IBufferToken buffer, N256 w, _OpIdentity id)
            => (BinaryOp256)buffer.EmitBinaryCellOp(id, typeof(BinaryOp256), typeof(Cell256));

        /// <summary>
        /// Loads source into a token-identified buffer and covers it with a fixed binary operator
        /// </summary>
        /// <param name="buffer">The target buffer</param>
        /// <param name="src">The code to load</param>
        /// <typeparam name="F">The fixed operand type</typeparam>
        public static BinaryOp<F> EmitBinaryCellOp<F>(this BufferToken buffer, ApiCodeBlock src)
            => (BinaryOp<F>)buffer.Load(src.Encoded).EmitBinaryCellOp(src.Id, typeof(BinaryOp<F>), typeof(F));

        internal static BinaryOp<T> EmitBinaryCellOp<T>(this IBufferToken dst, _OpIdentity id)
            where T : unmanaged
                => (BinaryOp<T>)dst.EmitBinaryCellOp(id,typeof(BinaryOp<T>), typeof(T));
    }
}
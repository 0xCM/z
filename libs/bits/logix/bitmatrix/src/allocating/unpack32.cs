//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial class BitMatrixA
    {
        /// <summary>
        /// Allocates a target matrix of order equivalent to that of the source and projects
        /// each bit value into the corresponding cell in the target
        /// </summary>
        /// <param name="A">The source matrix</param>
        /// <typeparam name="T">The element type of the target matrix</typeparam>
        public static Matrix<N8,Bit32> unpack32(in BitMatrix8 A)
        {
            var Z = Matrix.alloc<N8,Bit32>();
            BitMatrix.unpack32(A, Z);
            return Z;
        }

        /// <summary>
        /// Allocates a target matrix of order equivalent to that of the source and projects
        /// each bit value into the corresponding cell in the target
        /// </summary>
        /// <param name="A">The source matrix</param>
        /// <typeparam name="T">The element type of the target matrix</typeparam>
        public static Matrix<N8, Bit32> unpack32(in BitMatrix<byte> A)
        {
            var Z = Matrix.alloc<N8,Bit32>();
            BitMatrix.unpack32(A, Z);
            return  Z;
        }

        /// <summary>
        /// Allocates a target matrix of order equivalent to that of the source and projects
        /// each bit value into the corresponding cell in the target
        /// </summary>
        /// <param name="A">The source matrix</param>
        /// <typeparam name="T">The element type of the target matrix</typeparam>
        public static Matrix<N16,Bit32> unpack32(in BitMatrix16 A)
        {
            var Z = Matrix.alloc<N16,Bit32>();
            BitMatrix.unpack32(A, Z);
            return  Z;
        }

        /// <summary>
        /// Allocates a target matrix of order equivalent to that of the source and projects
        /// each bit value into the corresponding cell in the target
        /// </summary>
        /// <param name="A">The source matrix</param>
        /// <typeparam name="T">The element type of the target matrix</typeparam>
        public static Matrix<N16,Bit32> unpack32(in BitMatrix<ushort> A)
        {
            var Z = Matrix.alloc<N16,Bit32>();
            BitMatrix.unpack32(A, Z);
            return  Z;
        }

        /// <summary>
        /// Allocates a target matrix of order equivalent to that of the source and projects
        /// each bit value into the corresponding cell in the target
        /// </summary>
        /// <param name="A">The source matrix</param>
        /// <typeparam name="T">The element type of the target matrix</typeparam>
        public static Matrix<N32,Bit32> unpack32(in BitMatrix32 A)
        {
            var Z = Matrix.alloc<N32,Bit32>();
            BitMatrix.unpack32(A, Z);
            return  Z;
        }

        /// <summary>
        /// Allocates a target matrix of order equivalent to that of the source and projects
        /// each bit value into the corresponding cell in the target
        /// </summary>
        /// <param name="A">The source matrix</param>
        /// <typeparam name="T">The element type of the target matrix</typeparam>
        public static Matrix<N32,Bit32> unpack32(in BitMatrix<uint> A)
        {
            var Z = Matrix.alloc<N32,Bit32>();
            BitMatrix.unpack32(A, Z);
            return  Z;
        }

        /// <summary>
        /// Allocates a target matrix of order equivalent to that of the source and projects
        /// each bit value into the corresponding cell in the target
        /// </summary>
        /// <param name="A">The source matrix</param>
        /// <typeparam name="T">The element type of the target matrix</typeparam>
        public static Matrix<N64,Bit32> unpack32(in BitMatrix64 A)
        {
            var Z = Matrix.alloc<N64,Bit32>();
            BitMatrix.unpack32(A, Z);
            return Z;
        }

        /// <summary>
        /// Allocates a target matrix of order equivalent to that of the source and projects
        /// each bit value into the corresponding cell in the target
        /// </summary>
        /// <param name="A">The source matrix</param>
        /// <typeparam name="T">The element type of the target matrix</typeparam>
        public static Matrix<N64,Bit32> unpack32(in BitMatrix<ulong> A)
        {
            var Z = Matrix.alloc<N64,Bit32>();
            BitMatrix.unpack32(A, Z);
            return  Z;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    partial class BitMatrix
    {
        /// <summary>
        /// Allocates a square generic bitmatrix filled with a specified row
        /// </summary>
        /// <typeparam name="T">The primal type over which the bitmatrix is constructed</typeparam>
        public static BitMatrix<T> init<T>(ScalarBits<T> src)
            where T : unmanaged
        {
            Span<T> content = new T[BitMatrix<T>.N];
            content.Fill(src);
            return new BitMatrix<T>(content);
        }

        /// <summary>
        /// Allocates a generic bitmatrix filled with a specified row
        /// </summary>
        /// <typeparam name="T">The primal type over which the bitmatrix is constructed</typeparam>
        public static BitMatrix<T> init<T>(ScalarBits<T> src, int rows)
            where T : unmanaged
        {
            Span<T> content = new T[rows];
            content.Fill(src);
            return new BitMatrix<T>(content);
        }

        /// <summary>
        /// Allocates a square bitmatrix of natural order filled with a specified row
        /// </summary>
        /// <typeparam name="N">The square dimension</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        public static BitMatrix<N,T> init<N,T>(T src, N n = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            Span<T> data = new T[BitMatrix<N,T>.TotalCellCount];
            data.Fill(src);
            return new BitMatrix<N, T>(data);
        }

        /// <summary>
        /// Allocates a bitmatrix of natural dimensions filled with a specified cell
        /// </summary>
        /// <typeparam name="M">The row dimension</typeparam>
        /// <typeparam name="N">The column dimension</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        public static BitMatrix<M,N,T> init<M,N,T>(T src, M m = default, N n = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var dst = BitMatrix<M,N,T>.Alloc();
            dst.Content.Fill(src);
            return dst;
        }

        /// <summary>
        /// Allocates a zero-filled square generic bitmatrix
        /// </summary>
        /// <typeparam name="T">The primal type over which the bitmatrix is constructed</typeparam>
        public static BitMatrix<T> alloc<T>()
            where T : unmanaged
                => new BitMatrix<T>(new T[BitMatrix<T>.N]);

        /// <summary>
        /// Allocates a zero-filled generic bitmatrix with a specified number of rows
        /// </summary>
        /// <typeparam name="T">The primal type over which the bitmatrix is constructed</typeparam>
        public static BitMatrix<T> alloc<T>(int rows)
            where T : unmanaged
                => new BitMatrix<T>(new T[rows]);

        /// <summary>
        /// Allocates a zero-filled square bitmatrix of natural order
        /// </summary>
        /// <typeparam name="N">The square dimension</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        public static BitMatrix<N,T> alloc<N,T>(N n = default, T t = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new BitMatrix<N, T>(new T[BitMatrix<N,T>.TotalCellCount]);

        /// <summary>
        /// Allocates a zero-filed bitmatrix of natural dimensions
        /// </summary>
        /// <typeparam name="M">The row dimension</typeparam>
        /// <typeparam name="N">The column dimension</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static BitMatrix<M,N,T> alloc<M,N,T>(M m = default, N n = default, T t = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitMatrix<M,N,T>.Alloc();

        /// <summary>
        /// Allocates a primal bitmatrix
        /// </summary>
        /// <param name="n">The bitness selector</param>
        /// <param name="fill">The value with which the allocated matrix is filled</param>
        public static BitMatrix4 alloc(N4 n, Bit32 fill = default)
            => fill == Bit32.On ? new BitMatrix4(ushort.MaxValue) : new BitMatrix4(ushort.MinValue);

        /// <summary>
        /// Allocates a primal bitmatrix
        /// </summary>
        /// <param name="n">The bitness selector</param>
        /// <param name="fill">The value with which the allocated matrix is filled</param>
        public static BitMatrix8 alloc(N8 n, bit fill = default)
            => new BitMatrix8(((uint)fill)*UInt64.MaxValue);

        /// <summary>
        /// Allocates a primal bitmatrix with rows filled by a specified vector
        /// </summary>
        /// <param name="fill">The row with which the allocated matrix is filled</param>
        public static BitMatrix8 alloc(N8 n, BitVector8 fill)
        {
            var data = new byte[n];
            data.Fill(fill);
            return new BitMatrix8(data);
        }

        /// <summary>
        /// Allocates a primal bitmatrix
        /// </summary>
        /// <param name="n">The bitness selector</param>
        /// <param name="fill">The value with which the allocated matrix is filled</param>
        public static BitMatrix16 alloc(N16 n, bit fill = default)
            => BitMatrix16.Alloc(fill);

        /// <summary>
        /// Allocates a primal bitmatrix with rows filled by a specified vector
        /// </summary>
        /// <param name="fill">The row with which the allocated matrix is filled</param>
        public static BitMatrix16 alloc(BitVector16 fill)
        {
            Span<ushort> data = new ushort[16];
            data.Fill(fill);
            return new BitMatrix16(data);
        }

        /// <summary>
        /// Allocates a primal bitmatrix
        /// </summary>
        /// <param name="n">The bitness selector</param>
        /// <param name="fill">The value with which the allocated matrix is filled</param>
        public static BitMatrix32 alloc(N32 n, bit fill = default)
            => new BitMatrix32(fill);

        /// <summary>
        /// Allocates a primal bitmatrix with rows filled by a specified vector
        /// </summary>
        /// <param name="fill">The row with which the allocated matrix is filled</param>
        public static BitMatrix32 alloc(BitVector32 fill)
        {
            var data = new uint[32];
            data.Fill(fill);
            return new BitMatrix32(data);
        }

        /// <summary>
        /// Allocates a primal bitmatrix
        /// </summary>
        /// <param name="n">The bitness selector</param>
        /// <param name="fill">The value with which the allocated matrix is filled</param>
        public static BitMatrix64 alloc(N64 n, bit fill = default)
            => new BitMatrix64(fill);

        /// <summary>
        /// Allocates a primal bitmatrix with rows filled by a specified vector
        /// </summary>
        /// <param name="fill">The row with which the allocated matrix is filled</param>
        public static BitMatrix64 alloc(BitVector64 fill)
        {
            Span<ulong> data = new ulong[64];
            data.Fill(fill);
            return new BitMatrix64(data);
        }
    }
}
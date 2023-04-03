//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    [ApiHost]
    public readonly struct TruthTables
    {
        static bit on => bit.On;

        static bit off => bit.Off;

        static BitLogix bitlogix => BitLogix.Service;

        /// <summary>
        /// Computes a the signature, also referred to as the truth vector, for an identified unary operator
        /// </summary>
        /// <param name="kind">The operator kind</param>
        [Op]
        public static BitVector4 vector(N4 n, UnaryBitLogicKind kind)
        {
            var x = BitVectors.alloc(n);
            x[0] = bitlogix.Evaluate(kind, off);
            x[1] = bitlogix.Evaluate(kind, on);
            return x;
        }

        /// <summary>
        /// Computes a the signature, also referred to as the truth vector, for an identified binary operator
        /// </summary>
        /// <param name="kind">The operator kind</param>
        [Op]
        public static BitVector4 vector(N4 n, BinaryBitLogicKind kind)
        {
            var x = BitVectors.alloc(n);
            x[0] = bitlogix.Evaluate(kind, off, off);
            x[1] = bitlogix.Evaluate(kind, on, off);
            x[2] = bitlogix.Evaluate(kind, off, on);
            x[3] = bitlogix.Evaluate(kind, on, on);
            return x;
        }


        /// <summary>
        /// Computes a the signature, also referred to as the truth vector, for an identified ternary operator
        /// </summary>
        /// <param name="kind">The operator kind</param>
        [Op]
        public static BitVector8 vector(N8 n, TernaryBitLogicKind kind)
        {
            var x = BitVectors.alloc(n);
            x[0] = bitlogix.Evaluate(kind, off, off, off);
            x[1] = bitlogix.Evaluate(kind, off, off, on);
            x[2] = bitlogix.Evaluate(kind, off, on, off);
            x[3] = bitlogix.Evaluate(kind, off, on, on);
            x[4] = bitlogix.Evaluate(kind, on, off, off);
            x[5] = bitlogix.Evaluate(kind, on, off, on);
            x[6] = bitlogix.Evaluate(kind, on, on, off);
            x[7] = bitlogix.Evaluate(kind, on, on, on);
            return x;
        }

        /// <summary>
        /// Constructs a canonical vector that defines a kind-identified operator
        /// </summary>
        /// <param name="kind">The operator kind</param>
        [Op]
        public static BitVector16 vector(N16 n, BinaryBitLogicKind kind)
        {
            var dst = BitVectors.alloc(n16);
            var s = ((byte)vector(n4, kind)).ToBitString().Truncate(4);
            var f = bitlogix.Lookup(kind);
            dst[0] = off;
            dst[1] = off;
            dst[2] = f(off, off);
            dst[3] = on;
            dst[4] = off;
            dst[5] = f(on, off);
            dst[6] = off;
            dst[7] = on;
            dst[8] = f(off, on);
            dst[9] = on;
            dst[10] = on;
            dst[11] = f(on,on);
            dst[12] = s[0];
            dst[13] = s[1];
            dst[14] = s[2];
            dst[15] = s[3];
            return dst;
        }

        [Op]
        public static BitMatrix<N2,N2,byte> table(UnaryBitLogicKind kind)
        {
            var f = bitlogix.Lookup(kind);
            var table = BitMatrix.alloc<N2,N2,byte>();
            table[0] = BitBlocks.single<N2,byte>(bit.pack(f(off), off));
            table[1] = BitBlocks.single<N2,byte>(bit.pack(f(on), on));
            return table;
        }

        [Op]
        public static BitMatrix<N4,N3,byte> table(BinaryBitLogicKind kind)
        {
            var tt = BitMatrix.alloc<N4,N3,byte>();
            var f = bitlogix.Lookup(kind);
            tt[0] = BitBlocks.single<N3,byte>(bit.pack(f(off, off), off, off));
            tt[1] = BitBlocks.single<N3,byte>(bit.pack(f(on, off), off, on));
            tt[2] = BitBlocks.single<N3,byte>(bit.pack(f(off, on), on, off));
            tt[3] = BitBlocks.single<N3,byte>(bit.pack(f(on, on),  on, on));
            return tt;
        }

        [Op]
        public static BitMatrix<N8,N4,byte> table(TernaryBitLogicKind kind)
        {
            var tt = BitMatrix.alloc<N8,N4,byte>();
            var f = bitlogix.Lookup(kind);
            tt[0] = BitBlocks.single<N4,byte>(bit.pack(f(off, off, off), off, off, off));
            tt[1] = BitBlocks.single<N4,byte>(bit.pack(f(off, off, on), off, off, on));
            tt[2] = BitBlocks.single<N4,byte>(bit.pack(f(off, on, off), off, on, off));
            tt[3] = BitBlocks.single<N4,byte>(bit.pack(f(off, on, on), off, on, on));
            tt[4] = BitBlocks.single<N4,byte>(bit.pack(f(on, off, off), on, off, off));
            tt[5] = BitBlocks.single<N4,byte>(bit.pack(f(on, off, on), on, off, on));
            tt[6] = BitBlocks.single<N4,byte>(bit.pack(f(on, on, off), off, on, on));
            tt[7] = BitBlocks.single<N4,byte>(bit.pack(f(on, on, on), on, on, on));
            return tt;
        }

        public static void save(ReadOnlySpan<UnaryBitLogicKind> src, StreamWriter dst)
        {
            var writer = BitMatrixWriter.share(dst);
            for(var i=0; i<src.Length; i++)
                save(src[i], writer);
        }

        public static void save(ReadOnlySpan<BinaryBitLogicKind> src, StreamWriter dst)
        {
            var writer = BitMatrixWriter.share(dst);
            for(var i=0; i<src.Length; i++)
                save(src[i], writer);
        }

        public static void save(ReadOnlySpan<TernaryBitLogicKind> src, StreamWriter dst)
        {
            var writer = BitMatrixWriter.share(dst);
            for(var i=0; i<src.Length; i++)
                save(src[i], writer);
        }

        public static BitMatrix<N2,N2,byte> save(UnaryBitLogicKind spec, IBitMatrixWriter dst)
        {
            var table = TruthTables.table(spec);
            dst.Write(table,spec);
            return table;
        }

        public static BitMatrix<N4,N3,byte> save(BinaryBitLogicKind spec, IBitMatrixWriter dst)
        {
            var table = TruthTables.table(spec);
            dst.Write(table,spec);
            return table;
        }

        public static BitMatrix<N8,N4,byte> save(TernaryBitLogicKind spec, IBitMatrixWriter dst)
        {
            var table = TruthTables.table(spec);
            dst.Write(table,spec);
            return table;
        }

        /// <summary>
        /// Loads a bitblock from a 4-bit bitvector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static BitBlock<N4,byte> bitblock(BitVector4 src)
            => new BitBlock<N4,byte>(src);

        /// <summary>
        /// Loads a bitblock from an 8-bit bitvector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static BitBlock<N8,byte> bitblock(BitVector8 src)
            => new BitBlock<N8,byte>(src);

        static void WriteUnaryTruth(IBitMatrixWriter dst)
        {
            var ops = bitlogix.UnaryOpKinds.ToArray();
            for(var i=0; i< ops.Length; i++)
            {
                BitVector4 result = (byte)i;
                var table = BitMatrix.alloc<N2,N2,byte>();
                table[0] = BitBlocks.single<N2,byte>(bit.pack(result[0], off));
                table[1] = BitBlocks.single<N2,byte>(bit.pack(result[1], on));
                dst.Write(table);
            }
        }

        static void WriteBinaryTruth(IBitMatrixWriter dst)
        {
            for(var i=0; i< 16; i++)
            {
                BitVector4 result = (byte)i;
                var bbResult = bitblock(result);

                var table = BitMatrix.alloc<N4,N3,byte>();
                table[0] = BitBlocks.single<N3,byte>(bit.pack(result[0], off, off));
                table[1] = BitBlocks.single<N3,byte>(bit.pack(result[1], off, on));
                table[2] = BitBlocks.single<N3,byte>(bit.pack(result[2], on, off));
                table[3] = BitBlocks.single<N3,byte>(bit.pack(result[3], on, on));
                dst.Write(table);
            }
        }

        static void WriteTernaryTruth(IBitMatrixWriter dst)
        {
            for(var i=0; i< 256; i++)
            {
                BitVector8 result = (byte)i;
                var bbResult = bitblock(result);

                var table = BitMatrix.alloc<N8,N4,byte>();
                table[0] = BitBlocks.single<N4,byte>(bit.pack(result[0], off, off, off));
                table[1] = BitBlocks.single<N4,byte>(bit.pack(result[1], off, off, on));
                table[2] = BitBlocks.single<N4,byte>(bit.pack(result[2], off, on, off));
                table[3] = BitBlocks.single<N4,byte>(bit.pack(result[3], off, on, on));
                table[4] = BitBlocks.single<N4,byte>(bit.pack(result[4], on, off, off));
                table[5] = BitBlocks.single<N4,byte>(bit.pack(result[5], on, off, on));
                table[6] = BitBlocks.single<N4,byte>(bit.pack(result[6], on, on, off));
                table[7] = BitBlocks.single<N4,byte>(bit.pack(result[7], on, on, on));
                dst.Write(table);
            }
        }

        static string header<M,N,T>(BitMatrix<M,N,T> src, string label)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
        {
            var lastCol = src.ColCount - 1;
            var result = src.GetCol(lastCol);
            var sig = result.ToBitString().Format();
            var title = $"{label} {sig}";
            var sep = new string('-',80);
            var header = text.join(Eol,title,sep);
            return header;
        }

        static string header<M,N,T,K>(BitMatrix<M,N,T> src, K kind)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
            where K : struct, Enum
        {
            var lastCol = src.ColCount - 1;
            var result = src.GetCol(lastCol);
            var sig = result.ToBitString().Format();
            var title = $"{kind} {sig}";
            var sep = new string('-',80);
            var header = text.join(Eol,title,sep);
            return header;
        }

        static void emit<M,N,T>(BitMatrix<M,N,T> src, TextWriter dst)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
        {
            dst.Write(header(src,"Table"));
            dst.WriteLine(src.Format());
        }

        static void emit<M,N,T,K>(BitMatrix<M,N,T> src, K kind, TextWriter dst)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
            where K: struct, Enum
        {
            dst.Write(header(src,kind));
            dst.WriteLine(src.Format());
        }
    }
}
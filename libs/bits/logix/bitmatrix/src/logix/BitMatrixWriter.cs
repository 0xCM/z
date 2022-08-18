//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    public readonly struct BitMatrixWriter : IBitMatrixWriter<BitMatrixWriter>
    {
        public FS.FilePath TargetPath {get;}

        readonly StreamWriter Stream;

        [MethodImpl(Inline)]
        internal BitMatrixWriter(FS.FilePath dst)
        {
            TargetPath = dst;
            Stream = TargetPath.EnsureParentExists().Writer();
        }

        [MethodImpl(Inline)]
        public static IBitMatrixWriter share(StreamWriter dst)
            => new BitMatrixWriter(dst);

        [MethodImpl(Inline)]
        BitMatrixWriter(StreamWriter dst)
        {
            Stream = dst;
            TargetPath = FS.FilePath.Empty;
        }

        public void Dispose()
        {
            Stream?.Flush();
            Stream?.Close();
        }

        [MethodImpl(Inline)]
        public void Write<T>(in BitMatrix<T> src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                Write(src,n8);
            else if(typeof(T) == typeof(ushort))
                Write(src,n16);
            else if(typeof(T) == typeof(uint))
                Write(src,n32);
            else if(typeof(T) == typeof(ulong))
                Write(src,n64);
            else
                throw no<T>();
        }

        public void Write<M,N,T>(in BitMatrix<M,N,T> src)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
        {
            Stream.Write(CreateHeader(src, "Table"));
            Stream.WriteLine(src.Format());
        }

        public void Write<M,N,T,K>(in BitMatrix<M,N,T> src, K kind)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
            where K: struct, Enum
        {
            Stream.Write(CreateHeader(src, kind));
            Stream.WriteLine(src.Format());
        }

        static string CreateHeader<M,N,T>(BitMatrix<M,N,T> src, string label)
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

        static string CreateHeader<M,N,T,K>(BitMatrix<M,N,T> src, K kind)
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

        [MethodImpl(Inline)]
        void Write<T>(BitMatrix<T> src, N8 order)
            where T : unmanaged
                => Write(BitMatrix.load<N8,N8,byte>(src.Data.Bytes()));

        [MethodImpl(Inline)]
        void Write<T>(BitMatrix<T> src, N16 order)
            where T : unmanaged
                => Write(BitMatrix.load<N16,N16,ushort>(src.Data.AsUInt16()));

        [MethodImpl(Inline)]
        void Write<T>(BitMatrix<T> src, N32 order)
            where T : unmanaged
                => Write(BitMatrix.load<N32,N32,uint>(src.Data.AsUInt32()));

        [MethodImpl(Inline)]
        void Write<T>(BitMatrix<T> src, N64 order)
            where T : unmanaged
                => Write(BitMatrix.load<N64,N64,ulong>(src.Data.AsUInt64()));
    }
}
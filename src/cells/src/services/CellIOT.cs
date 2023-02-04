//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public unsafe readonly struct CellIO<T>
        where T : unmanaged
    {
        readonly MemoryAddress Source;

        readonly ByteSize SourceSize;

        readonly MemoryAddress Target;

        readonly ByteSize TargetSize;

        [MethodImpl(Inline)]
        public CellIO(in Cells<T> src, in Cells<T> dst)
        {
            Source = sys.address(src);
            Target = sys.address(dst);
            SourceSize = src.Length*size<T>();
            TargetSize = dst.Length*size<T>();
        }

        public uint TargetCapacity
        {
            [MethodImpl(Inline)]
            get => TargetSize/size<T>();
        }

        public uint SourceCapacity
        {
            [MethodImpl(Inline)]
            get => SourceSize/size<T>();
        }

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public uint Copy(N16 n)
            => CellCopy.copy<T>(n, Source.Pointer<T>(), Target.Pointer<T>());
    }
}
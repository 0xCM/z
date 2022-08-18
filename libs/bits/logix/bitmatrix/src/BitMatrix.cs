//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public partial class BitMatrix
    {
        const NumericKind Closure = NumericKind.UnsignedInts;
    }

    public interface IBitMatrixServices
    {
        IBitMatrixWriter Writer(FS.FilePath dst)
            => new BitMatrixWriter(dst);
    }

    public readonly struct BitMatrixServices : IBitMatrixServices
    {
        public static IBitMatrixServices Factory => default(BitMatrixServices);
    }

    partial class XTend
    {
        static string format<N,T>(BitBlock<N,T> src, BitFormat? config = null)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => src.ToBitString().Format(config);

        [MethodImpl(Inline)]
        public static string Format<N,T>(this BitBlock<N,T> src, BitFormat? config = null)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => format(src,config);
    }
}
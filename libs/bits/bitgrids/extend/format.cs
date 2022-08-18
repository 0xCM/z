//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitGridX
    {
        public static string Format<T>(this BitSpanBlocks256<T> src, bool showrow = false, int? maxbits = null)
            where T : unmanaged
                => BitGrid.format(src, showrow, maxbits);

        public static string Format<T>(this BitGrid32<T> src, int? cols = null, bool showrow = false, int? maxbits = null)
            where T : unmanaged
                => BitGrid.format(src, cols, showrow, maxbits);

        public static string Format<T>(this BitGrid64<T> src, int? cols = null, bool showrow = false, int? maxbits = null)
            where T : unmanaged
                => BitGrid.format(src, cols, showrow, maxbits);

        public static string Format<M,N,T>(this BitGrid<M,N,T> src)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitGrid.format(src);

        public static string Format<M,N,T>(this BitGrid16<M,N,T> src, bool showrow = false, int? maxbits = null)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitGrid.format(src, showrow, maxbits);

        public static string Format<M,N,T>(this BitGrid32<M,N,T> src, int? maxbits = null, bool showrow = false)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitGrid.format(src, showrow, maxbits);

        public static string Format<M,N,T>(this BitGrid64<M,N,T> src, bool showrow = false, int? maxbits = null)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitGrid.format(src, showrow, maxbits);

        public static string Format<M,N,T>(this BitGrid128<M,N,T> src, bool showrow = false, int? maxbits = null)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitGrid.format(src, showrow, maxbits);

        public static string Format<M,N,T>(this BitGrid256<M,N,T> src, int? maxbits = null, bool showrow = false)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitGrid.format(src, showrow, maxbits);

        public static string Format<M,N,T>(this SubGrid16<M,N,T> src, bool showrow = false, int? maxbits = null)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitGrid.format(src, showrow, maxbits);

        public static string Format<M,N,T>(this SubGrid32<M,N,T> src, bool showrow = false, int? maxbits = null)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitGrid.format(src, showrow, maxbits);

        public static string Format<M,N,T>(this SubGrid64<M,N,T> src, bool showrow = false, int? maxbits = null)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitGrid.format(src, showrow, maxbits);

        public static string Format<M,N,T>(this SubGrid128<M,N,T> src, bool showrow = false, int? maxbits = null)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitGrid.format(src, showrow, maxbits);

        public static string Format<M,N,T>(this SubGrid256<M,N,T> src, bool showrow = false, int? maxbits = null)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitGrid.format(src, showrow, maxbits);

    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class BitGrid
    {
        public static string format<M,N>(ushort data, bool showrow = false, int? maxbits = null)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
                => bytes(data).FormatGridBits(nat32i<N>(), maxbits ?? (int)NatCalc.mul<M,N>(), showrow);

        public static string format<M,N>(uint data, bool showrow = false, int? maxbits = null)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
                => bytes(data).FormatGridBits(nat32i<N>(), maxbits ?? (int)NatCalc.mul<M,N>(), showrow);

        public static string format<M,N>(ulong data, bool showrow = false, int? maxbits = null)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
                => bytes(data).FormatGridBits(nat32i<N>(), maxbits ?? (int)NatCalc.mul<M,N>(), showrow);

        public static string format<M,N,T>(Vector128<T> data, bool showrow = false, int? maxbits = null)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => data.ToSpan().FormatGridBits(nat32i<N>(), maxbits ?? (int)NatCalc.mul<M,N>(), showrow);

        public static string format<M,N,T>(Vector256<T> data, bool showrow = false, int? maxbits = null)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => data.ToSpan().FormatGridBits(nat32i<N>(), maxbits ?? (int)NatCalc.mul<M,N>(), showrow);
    }
}
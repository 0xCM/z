//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Delegates
    {
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Func<T,T,T> generic<T>(in Func<sbyte,sbyte,sbyte> src)
            where T : unmanaged
                => ref edit<Func<sbyte,sbyte,sbyte>, Func<T,T,T>>(src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Func<T,T,T> generic<T>(in Func<byte,byte,byte> src)
            where T : unmanaged
                => ref edit<Func<byte,byte,byte>,Func<T,T,T>>(src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Func<T,T,T> generic<T>(in Func<ushort,ushort,ushort> src)
            where T : unmanaged
                => ref edit<Func<ushort,ushort,ushort>,Func<T,T,T>>(src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Func<T,T,T> generic<T>(in Func<short,short,short> src)
            where T : unmanaged
                => ref edit<Func<short,short,short>,Func<T,T,T>>(src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Func<T,T,T> generic<T>(in Func<int,int,int> src)
            where T : unmanaged
                => ref edit<Func<int,int,int>,Func<T,T,T>>(src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Func<T,T,T> generic<T>(in Func<uint,uint,uint> src)
            where T : unmanaged
                => ref edit<Func<uint,uint,uint>,Func<T,T,T>>(src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Func<T,T,T> generic<T>(in Func<long,long,long> src)
            where T : unmanaged
                => ref edit<Func<long,long,long>,Func<T,T,T>>(src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Func<T,T,T> generic<T>(in Func<ulong,ulong,ulong> src)
            where T : unmanaged
                => ref edit<Func<ulong,ulong,ulong>,Func<T,T,T>>(src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Func<T,T,T> generic<T>(in Func<float,float,float> src)
            where T : unmanaged
                => ref edit<Func<float,float,float>,Func<T,T,T>>(src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Func<T,T,T> generic<T>(in Func<double,double,double> src)
            where T : unmanaged
                => ref edit<Func<double,double,double>,Func<T,T,T>>(src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Func<T,T,bool> generic<T>(in Func<decimal,decimal,bool> src)
            where T : unmanaged
                => ref edit<Func<decimal,decimal,bool>,Func<T,T,bool>>(src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Func<T,T,bool> generic<T>(in Func<byte,byte,bool> src)
            where T : unmanaged
                => ref edit<Func<byte,byte,bool>, Func<T,T,bool>>(src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Func<T,T,bool> generic<T>(in Func<ushort,ushort,bool> src)
            where T : unmanaged
                => ref edit<Func<ushort,ushort,bool>, Func<T,T,bool>>(src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Func<T,T,bool> generic<T>(in Func<uint,uint,bool> src)
            where T : unmanaged
                => ref edit<Func<uint,uint,bool>, Func<T,T,bool>>(src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Func<T,T,bool> generic<T>(in Func<ulong,ulong,bool> src)
            where T : unmanaged
                => ref edit<Func<ulong,ulong,bool>, Func<T,T,bool>>(src);
    }
}
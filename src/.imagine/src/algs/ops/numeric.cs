//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
     using static System.Runtime.CompilerServices.Unsafe;

    partial class Algs
    {
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static sbyte int8<T>(T src)
            => As<T,sbyte>(ref src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static sbyte? int8<T>(T? src)
            where T : unmanaged
                => As<T?, sbyte?>(ref src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static short int16<T>(T src)
            => As<T,short>(ref src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static short? int16<T>(T? src)
            where T : unmanaged
                => As<T?, short?>(ref src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static int int32<T>(T src)
            => As<T,int>(ref src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static int? int32<T>(T? src)
            where T : unmanaged
                => As<T?, int?>(ref src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static long int64<T>(T src)
            => As<T,long>(ref src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static long? int64<T>(T? src)
            where T : unmanaged
                => As<T?,long?>(ref src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static byte uint8<T>(T src)
            => As<T,byte>(ref src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ushort uint16<T>(T src)
            => As<T,ushort>(ref src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static uint uint32<T>(T src)
            => As<T,uint>(ref src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ulong uint64<T>(T src)
            => As<T,ulong>(ref src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ulong? uint64<T>(T? src)
            where T : unmanaged
                => As<T?,ulong?>(ref src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static float float32<T>(T src)
            => As<T,float>(ref src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static double float64<T>(T src)
            => As<T,double>(ref src);


        /// <summary>
        /// Converts a <see cref='sbyte'/> to a <see cref='byte'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static byte uint8(sbyte src)
            => (byte)src;

        /// <summary>
        /// Defines an identity function over <see cref='byte'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static byte uint8(byte src)
            => (byte)src;

        /// <summary>
        /// Converts a <see cref='short'/> to a <see cref='byte'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static byte uint8(short src)
            => (byte)src;

        /// <summary>
        /// Converts a <see cref='ushort'/> to a <see cref='byte'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static byte uint8(ushort src)
            => (byte)src;

        /// <summary>
        /// Converts a <see cref='int'/> to a <see cref='byte'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static byte uint8(int src)
            => (byte)src;

        /// <summary>
        /// Converts a <see cref='uint'/> to a <see cref='byte'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static byte uint8(uint src)
            => (byte)src;

        /// <summary>
        /// Converts a <see cref='long'/> to a <see cref='byte'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static byte uint8(long src)
            => (byte)src;

        /// <summary>
        /// Converts a <see cref='ulong'/> to a <see cref='byte'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static uint uint8(ulong src)
            => (uint)src;

        [MethodImpl(Inline), Op]
        public static sbyte int8(float src)
            => (sbyte)((int)src);

        /// <summary>
        /// Forces a <see cref='double'/> to a <see cref='sbyte'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static sbyte int8(double src)
            => (sbyte)((long)src);

        /// <summary>
        /// Forces a <see cref='float'/> to a <see cref='short'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static short int16(float src)
            => (short)((int)src);

        /// <summary>
        /// Forces a <see cref='double'/> to a <see cref='short'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static short int16(double src)
            => (short)((long)src);

        /// <summary>
        /// Forces a <see cref='float'/> to a <see cref='byte'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static byte uint8(float src)
            => (byte)(sbyte)src;

        /// <summary>
        /// Forces a <see cref='double'/> to a <see cref='byte'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static byte uint8(double src)
            => (byte)(sbyte)src;

        [MethodImpl(Inline), Op]
        public static ushort uint16(float src)
            => (ushort)((int)src);

        /// <summary>
        /// Forces a <see cref='double'/> to a <see cref='ushort'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static ushort uint16(double src)
            => (ushort)((long)src);

        [MethodImpl(Inline), Op]
        public static int int32(float src)
            => (int)src;

        [MethodImpl(Inline), Op]
        public static int int32(double src)
            => (int)src;

        /// <summary>
        /// Forces a <see cref='float'/> to a <see cref='uint'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static uint uint32(float src)
            => (uint)((long)src);

        [MethodImpl(Inline), Op]
        public static uint uint32(double src)
            => (uint)((long)src);

        [MethodImpl(Inline), Op]
        public static long int64(float src)
            => (long)src;

        [MethodImpl(Inline), Op]
        public static long int64(double src)
            => (long)src;

        [MethodImpl(Inline), Op]
        public static ulong uint64(float src)
            => (ulong)((long)src);

        [MethodImpl(Inline), Op]
        public static ulong uint64(double src)
            => (ulong)((long)src);

        [MethodImpl(Inline), Op]
        public static ushort uint16(sbyte src)
            => (ushort)src;

        [MethodImpl(Inline), Op]
        public static ushort uint16(byte src)
            => (ushort)src;

        [MethodImpl(Inline), Op]
        public static short int16(sbyte src)
            => (short)src;

        [MethodImpl(Inline), Op]
        public static short int16(byte src)
            => (short)src;

        [MethodImpl(Inline), Op]
        public static short int16(short src)
            => (short)src;

        [MethodImpl(Inline), Op]
        public static short int16(ushort src)
            => (short)src;

        [MethodImpl(Inline), Op]
        public static short int16(int src)
            => (short)src;

        [MethodImpl(Inline), Op]
        public static short int16(uint src)
            => (short)src;

        [MethodImpl(Inline), Op]
        public static short int16(long src)
            => (short)src;

        [MethodImpl(Inline), Op]
        public static short int16(ulong src)
            => (short)src;

        [MethodImpl(Inline), Op]
        public static sbyte int8(sbyte src)
            => (sbyte)src;

        [MethodImpl(Inline), Op]
        public static sbyte int8(byte src)
            => (sbyte)src;

        [MethodImpl(Inline), Op]
        public static sbyte int8(short src)
            => (sbyte)src;

        [MethodImpl(Inline), Op]
        public static sbyte int8(ushort src)
            => (sbyte)src;

        [MethodImpl(Inline), Op]
        public static sbyte int8(int src)
            => (sbyte)src;

        [MethodImpl(Inline), Op]
        public static sbyte int8(uint src)
            => (sbyte)src;

        [MethodImpl(Inline), Op]
        public static sbyte int8(long src)
            => (sbyte)src;

        [MethodImpl(Inline), Op]
        public static sbyte int8(ulong src)
            => (sbyte)src;

        [MethodImpl(Inline), Op]
        public static int int32(sbyte src)
            => (int)src;

        [MethodImpl(Inline), Op]
        public static int int32(byte src)
            => (int)src;

        [MethodImpl(Inline), Op]
        public static int int32(short src)
            => (int)src;

        [MethodImpl(Inline), Op]
        public static int int32(ushort src)
            => (int)src;

        [MethodImpl(Inline), Op]
        public static int int32(int src)
            => (int)src;

        [MethodImpl(Inline), Op]
        public static int int32(uint src)
            => (int)src;

        [MethodImpl(Inline), Op]
        public static int int32(long src)
            => (int)src;

        [MethodImpl(Inline), Op]
        public static int int32(ulong src)
            => (int)src;

        /// <summary>
        /// Forces a <see cref='short'/> to a <see cref='ushort'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static ushort uint16(short src)
            => (ushort)src;

        /// <summary>
        /// Defines an indentity operator over the <see cref='ushort'/> domain
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static ushort uint16(ushort src)
            => (ushort)src;

        /// <summary>
        /// Forces a <see cref='int'/> to a <see cref='ushort'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static ushort uint16(int src)
            => (ushort)src;

        /// <summary>
        /// Forces a <see cref='uint'/> to a <see cref='ushort'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static ushort uint16(uint src)
            => (ushort)src;

        /// <summary>
        /// Forces a <see cref='long'/> to a <see cref='ushort'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static ushort uint16(long src)
            => (ushort)src;

        /// <summary>
        /// Forces a <see cref='ulong'/> to a <see cref='ushort'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static ushort uint16(ulong src)
            => (ushort)src;

        /// <summary>
        /// Forces a <see cref='sbyte'/> to a <see cref='uint'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static uint uint32(sbyte src)
            => (uint)src;

        /// <summary>
        /// Extends a <see cref='byte'/> to a <see cref='uint'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static uint uint32(byte src)
            => (uint)src;

        [MethodImpl(Inline), Op]
        public static uint uint32(short src)
            => (uint)src;

        [MethodImpl(Inline), Op]
        public static uint uint32(ushort src)
            => (uint)src;

        [MethodImpl(Inline), Op]
        public static uint uint32(int src)
            => (uint)src;

        [MethodImpl(Inline), Op]
        public static uint uint32(uint src)
            => (uint)src;

        [MethodImpl(Inline), Op]
        public static uint uint32(long src)
            => (uint)src;

        [MethodImpl(Inline), Op]
        public static uint uint32(ulong src)
            => (uint)src;

        /// <summary>
        /// Extends a <see cref='sbyte'/> to a <see cref='ulong'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static ulong uint64(sbyte src)
            => (ulong)src;

        /// <summary>
        /// Extends a <see cref='byte'/> to a <see cref='ulong'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static ulong uint64(byte src)
            => (ulong)src;

        /// <summary>
        /// Extends a <see cref='short'/> to a <see cref='ulong'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static ulong uint64(short src)
            => (ulong)src;

        /// <summary>
        /// Extends a <see cref='ushort'/> to a <see cref='ulong'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static ulong uint64(ushort src)
            => (ulong)src;

        /// <summary>
        /// Extends a <see cref='int'/> to a <see cref='ulong'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static ulong uint64(int src)
            => (ulong)src;

        /// <summary>
        /// Extends a <see cref='uint'/> to a <see cref='ulong'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static ulong uint64(uint src)
            => (ulong)src;

        [MethodImpl(Inline), Op]
        public static ulong uint64(long src)
            => (ulong)src;

        [MethodImpl(Inline), Op]
        public static ulong uint64(ulong src)
            => (ulong)src;

        [MethodImpl(Inline), Op]
        public static long int64(sbyte src)
            => (long)src;

        [MethodImpl(Inline), Op]
        public static long int64(byte src)
            => (long)src;

        [MethodImpl(Inline), Op]
        public static long int64(short src)
            => (long)src;

        [MethodImpl(Inline), Op]
        public static long int64(ushort src)
            => (long)src;

        [MethodImpl(Inline), Op]
        public static long int64(int src)
            => (long)src;

        [MethodImpl(Inline), Op]
        public static long int64(uint src)
            => (long)src;

        [MethodImpl(Inline), Op]
        public static long int64(long src)
            => (long)src;

        [MethodImpl(Inline), Op]
        public static long int64(ulong src)
            => (long)src;

        [MethodImpl(Inline), Op]
        public static float float32(sbyte src)
            => (float)src;

        [MethodImpl(Inline), Op]
        public static float float32(byte src)
            => (float)(int)src;

        [MethodImpl(Inline), Op]
        public static float float32(short src)
            => (float)src;

        [MethodImpl(Inline), Op]
        public static float float32(ushort src)
            => (float)(int)src;

        [MethodImpl(Inline), Op]
        public static float float32(int src)
            => (float)src;

        [MethodImpl(Inline), Op]
        public static float float32(uint src)
            => (float)(int)src;

        [MethodImpl(Inline), Op]
        public static float float32(long src)
            => (float)(int)src;

        [MethodImpl(Inline), Op]
        public static float float32(ulong src)
            => (float)(int)src;

        [MethodImpl(Inline), Op]
        public static float float32(float src)
            => (float)src;

        [MethodImpl(Inline), Op]
        public static float float32(double src)
            => (float)src;

        [MethodImpl(Inline), Op]
        public static double float64(sbyte src)
            => (double)(long)src;

        [MethodImpl(Inline), Op]
        public static double float64(byte src)
            => (double)(long)src;

        [MethodImpl(Inline), Op]
        public static double float64(short src)
            => (double)(long)src;

        [MethodImpl(Inline), Op]
        public static double float64(ushort src)
            => (double)(int)src;

        [MethodImpl(Inline), Op]
        public static double float64(int src)
            => (double)(long)src;

        [MethodImpl(Inline), Op]
        public static double float64(uint src)
            => (double)(long)src;

        [MethodImpl(Inline), Op]
        public static double float64(long src)
            => (double)(long)src;

        [MethodImpl(Inline), Op]
        public static double float64(ulong src)
            => (double)(long)src;

        [MethodImpl(Inline), Op]
        public static double float64(float src)
            => (double)src;

        [MethodImpl(Inline), Op]
        public static double float64(double src)
            => (double)src;
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class math
    {
        [MethodImpl(Inline), Avg]
        public static sbyte avg(ReadOnlySpan<sbyte> src, bool @checked)
            => @checked ? avg_checked(src) : avg_unchecked(src);

        [MethodImpl(Inline), Avg]
        public static byte avg(ReadOnlySpan<byte> src, bool @checked)
            => @checked ? avg_checked(src) : avg_unchecked(src);

        [MethodImpl(Inline), Avg]
        public static short avg(ReadOnlySpan<short> src, bool @checked)
            => @checked ? avg_checked(src) : avg_unchecked(src);

        [MethodImpl(Inline), Avg]
        public static ushort avg(ReadOnlySpan<ushort> src, bool @checked)
            => @checked ? avg_checked(src) : avg_unchecked(src);

        [MethodImpl(Inline), Avg]
        public static int avg(ReadOnlySpan<int> src, bool @checked)
            => @checked ? avg_checked(src) : avg_unchecked(src);

        [MethodImpl(Inline), Avg]
        public static uint avg(ReadOnlySpan<uint> src, bool @checked)
            => @checked ? avg_checked(src) : avg_unchecked(src);

        [MethodImpl(Inline), Avg]
        public static long avg(ReadOnlySpan<long> src, bool @checked)
            => @checked ? avg_checked(src) : avg_unchecked(src);

        [MethodImpl(Inline), Avg]
        public static ulong avg(ReadOnlySpan<ulong> src, bool @checked)
            => @checked ? avg_checked(src) : avg_unchecked(src);

        [MethodImpl(Inline), Avg]
        public static sbyte avg(ReadOnlySpan<sbyte> src)
            => avg(src, true);

        [MethodImpl(Inline), Avg]
        public static byte avg(ReadOnlySpan<byte> src)
            => avg(src, true);

        [MethodImpl(Inline), Avg]
        public static short avg(ReadOnlySpan<short> src)
            => avg(src, true);

        [MethodImpl(Inline), Avg]
        public static ushort avg(ReadOnlySpan<ushort> src)
            => avg(src, true);

        [MethodImpl(Inline), Avg]
        public static int avg(ReadOnlySpan<int> src)
            => avg(src, true);

        [MethodImpl(Inline), Avg]
        public static uint avg(ReadOnlySpan<uint> src)
            => avg(src, true);

        [MethodImpl(Inline), Avg]
        public static long avg(ReadOnlySpan<long> src)
            => avg(src, true);

        [MethodImpl(Inline), Avg]
        public static ulong avg(ReadOnlySpan<ulong> src)
            => avg(src, true);

        [MethodImpl(Inline), Avg]
        public static float avg(ReadOnlySpan<float> src, bool @checked)
            => @checked ? avg_checked(src) : avg_unchecked(src);

        [MethodImpl(Inline), Avg]
        public static double avg(ReadOnlySpan<double> src, bool @checked)
            => @checked ? avg_checked(src) : avg_unchecked(src);

        [MethodImpl(Inline), Avg]
        public static float avg(ReadOnlySpan<float> src)
            => avg(src,true);

        [MethodImpl(Inline), Avg]
        public static double avg(ReadOnlySpan<double> src)
            => avg(src,true);

        [MethodImpl(Inline), Op]
        static sbyte avg_unchecked(ReadOnlySpan<sbyte> src)
        {
            unchecked
            {
                var sum = default(long);

                ref readonly var current = ref first(src);
                for(var i=0u; i<src.Length; i++)
                    sum += sys.skip(current,i);

                return (sbyte)(sum/(long)src.Length);
            }
        }

        [MethodImpl(Inline), Op]
        static byte avg_unchecked(ReadOnlySpan<byte> src)
        {
            unchecked
            {
                var sum = default(ulong);

                ref readonly var current = ref first(src);
                for(var i=0u; i<src.Length; i++)
                    sum += sys.skip(current,i);

                return (byte)(sum/(ulong)src.Length);
            }
        }

        [MethodImpl(Inline), Op]
        static short avg_unchecked(ReadOnlySpan<short> src)
        {
            unchecked
            {
                var sum = default(long);

                ref readonly var current = ref first(src);
                for(var i=0u; i<src.Length; i++)
                    sum += sys.skip(current,i);

                return (short)(sum/(long)src.Length);
            }
        }

        [MethodImpl(Inline), Op]
        static ushort avg_unchecked(ReadOnlySpan<ushort> src)
        {
            unchecked
            {
                var sum = default(ulong);

                ref readonly var current = ref first(src);
                for(var i=0u; i<src.Length; i++)
                    sum += skip(current,i);

                return (ushort)(sum/(ulong)src.Length);
            }
        }

        [MethodImpl(Inline), Op]
        static int avg_unchecked(ReadOnlySpan<int> src)
        {
            unchecked
            {
                var sum = default(long);

                ref readonly var current = ref first(src);
                for(var i=0u; i<src.Length; i++)
                    sum += sys.skip(current,i);

                return (int)(sum/(long)src.Length);
            }
        }

        [MethodImpl(Inline), Op]
        static uint avg_unchecked(ReadOnlySpan<uint> src)
        {
            unchecked
            {
                var sum = default(ulong);

                ref readonly var current = ref first(src);
                for(var i=0u; i<src.Length; i++)
                    sum += sys.skip(current,i);

                return (uint)(sum/(ulong)src.Length);
            }
        }

        [MethodImpl(Inline), Op]
        static long avg_unchecked(ReadOnlySpan<long> src)
        {
            unchecked
            {
                var sum = default(long);

                ref readonly var current = ref first(src);
                for(var i=0u; i<src.Length; i++)
                    sum += sys.skip(current,i);

                return sum/src.Length;
            }
        }

        [MethodImpl(Inline), Op]
        static ulong avg_unchecked(ReadOnlySpan<ulong> src)
        {
            unchecked
            {
                var sum = default(ulong);

                ref readonly var current = ref first(src);
                for(var i=0u; i<src.Length; i++)
                    sum += sys.skip(current,i);

                return sum/(ulong)src.Length;
            }
        }

        [MethodImpl(Inline), Op]
        static sbyte avg_checked(ReadOnlySpan<sbyte> src)
            {checked{ return avg_unchecked(src);}}

        [MethodImpl(Inline), Op]
        static byte avg_checked(ReadOnlySpan<byte> src)
            {checked{ return avg_unchecked(src);}}

        [MethodImpl(Inline), Op]
        static short avg_checked(ReadOnlySpan<short> src)
            {checked{ return avg_unchecked(src);}}

        [MethodImpl(Inline), Op]
        static ushort avg_checked(ReadOnlySpan<ushort> src)
            {checked{ return avg_unchecked(src);}}

        [MethodImpl(Inline), Op]
        static int avg_checked(ReadOnlySpan<int> src)
            {checked{ return avg_unchecked(src);}}

        [MethodImpl(Inline), Op]
        static uint avg_checked(ReadOnlySpan<uint> src)
            {checked{ return avg_unchecked(src);}}

        [MethodImpl(Inline), Op]
        static long avg_checked(ReadOnlySpan<long> src)
            {checked{ return avg_unchecked(src);}}

        [MethodImpl(Inline), Op]
        static ulong avg_checked(ReadOnlySpan<ulong> src)
            {checked{ return avg_unchecked(src);}}

        [MethodImpl(Inline), Op]
        static float avg_checked(ReadOnlySpan<float> src)
            {checked{ return avg_unchecked(src);}}

        [MethodImpl(Inline), Op]
        static double avg_checked(ReadOnlySpan<double> src)
            {checked{ return avg_unchecked(src);}}

        [MethodImpl(Inline), Op]
        static float avg_unchecked(ReadOnlySpan<float> src)
        {
            unchecked
            {
                var sum = default(double);

                ref readonly var current = ref first(src);
                for(var i=0u; i<src.Length; i++)
                    sum += sys.skip(current,i);

                return (float)(sum/(float)src.Length);
            }
        }

        [MethodImpl(Inline), Op]
        static double avg_unchecked(ReadOnlySpan<double> src)
        {
            unchecked
            {
                var sum = default(double);

                ref readonly var current = ref first(src);
                for(var i=0u; i<src.Length; i++)
                    sum += sys.skip(current,i);

                return sum/(double)src.Length;
            }
        }
    }
}
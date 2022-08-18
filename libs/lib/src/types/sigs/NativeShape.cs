//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct NativeShape : IEquatable<NativeShape>
    {
        [MethodImpl(Inline), Op]
        public static NativeShape define(int n1 = 0, int n2 = 0, int n4 = 0, int n8 = 0, int n16 = 0, int n32 = 0, int n64 = 0)
        {
            var dst = new NativeShape();
            dst.N1 = n1;
            dst.N2 = n2;
            dst.N4 = n4;
            dst.N8 = n8;
            dst.N16 = n16;
            dst.N32 = n32;
            dst.N64 = n64;
            return dst;
        }

        public static NativeShape calc(ReadOnlySpan<byte> src, NativeSizeCode segmax = NativeSizeCode.W512)
        {
            var dst = new NativeShape();
            return calc(src,segmax, ref dst);
        }

        [Op]
        public static ref NativeShape calc(ReadOnlySpan<byte> src, NativeSize segmax, ref NativeShape dst)
        {
            const byte N1  = 1;
            const byte N2  = 2;
            const byte N4  = 4;
            const byte N8  = 8;
            const byte N16 = 16;
            const byte N32 = 32;
            const byte N64 = 64;

            var max = (uint)segmax.ByteCount;

            var count = src.Length;
            if(count == 0)
                return ref dst;

            var mod = -1;
            var div = 0;
            while(mod != 0 && count != 0)
            {
                if(count >= N64 && N64 <= max)
                {
                    div = count/N64;
                    dst.N64 = div;
                    mod = count/N64;
                    count -= div*N64;
                }
                else if(count >= N32 && N32 <= max)
                {
                    div = count/N32;
                    dst.N32 = div;
                    mod = count/N32;
                    count -= div*N32;
                }
                else if(count >= N16 && N16 <= max)
                {
                    div = count/N16;
                    dst.N16 = div;
                    mod = count/N16;
                    count -= div*N16;
                }
                else if(count >= N8 && N8 <= max)
                {
                    div = count/N8;
                    dst.N8 = div;
                    mod = count/N8;
                    count -= div*N8;
                }
                else if(count >= N4 && N4 <= max)
                {
                    div = count/N4;
                    dst.N4 = div;
                    mod = count/N4;
                    count -= div*N4;
                }
                else if(count >= N2 && N2 <= max)
                {
                    div = count/N2;
                    dst.N2 = div;
                    mod = count/N2;
                    count -= div*N2;
                }
                else if(count == N1)
                {
                    div = N1;
                    dst.N1 = div;
                    mod = 0;
                    count -= div*N1;
                }
            }

            return ref dst;
        }

        public int N1;

        public int N2;

        public int N4;

        public int N8;

        public int N16;

        public int N32;

        public int N64;

        int _Pad;

        [MethodImpl(Inline)]
        static ref readonly Cell256 cell(in NativeShape src)
            => ref @as<NativeShape,Cell256>(src);

        [MethodImpl(Inline)]
        public bool Equals(NativeShape src)
        {
            ref readonly var a = ref @as<NativeShape,Cell256>(this);
            ref readonly var b = ref @as<NativeShape,Cell256>(src);
            return cell(this).Equals(cell(src));
        }

        public override int GetHashCode()
            => cell(this).GetHashCode();

        public override bool Equals(object src)
            => src is NativeShape x && Equals(x);

        public string Format()
        {
            const string RP = "{0}:{1}";
            const string Sep = ", ";

            var dst = text.buffer();
            var segs = 0;
            if(N1 != 0)
            {
                dst.AppendFormat(RP, nameof(N1), N1);
                segs++;
            }

            if(N2 != 0)
            {
                if(segs != 0)
                    dst.Append(Sep);
                dst.AppendFormat(RP, nameof(N2), N2);
                segs++;
            }

            if(N4 != 0)
            {
                if(segs != 0)
                    dst.Append(Sep);
                dst.AppendFormat(RP, nameof(N4), N4);
                segs++;
            }

            if(N8 != 0)
            {
                if(segs != 0)
                    dst.Append(Sep);
                dst.AppendFormat(RP, nameof(N8), N8);
                segs++;
            }

            if(N16 != 0)
            {
                if(segs != 0)
                    dst.Append(Sep);
                dst.AppendFormat(RP, nameof(N16), N16);
                segs++;
            }

            if(N32 != 0)
            {
                if(segs != 0)
                    dst.Append(Sep);
                dst.AppendFormat(RP, nameof(N32), N32);
                segs++;
            }

            if(N64 != 0)
            {
                if(segs != 0)
                    dst.Append(Sep);
                dst.AppendFormat(RP, nameof(N64), N64);
                segs++;
            }

            return dst.Emit();
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static bool operator ==(NativeShape a, NativeShape b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(NativeShape a, NativeShape b)
            => !a.Equals(b);
    }
}
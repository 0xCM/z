//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class NativeSigs
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct Shape : IEquatable<Shape>
    {
        public int N1;

        public int N2;

        public int N4;

        public int N8;

        public int N16;

        public int N32;

        public int N64;

        int _Pad;

        [MethodImpl(Inline)]
        static ref readonly Cell256 cell(in Shape src)
            => ref @as<Shape,Cell256>(src);

        [MethodImpl(Inline)]
        public bool Equals(Shape src)
        {
            ref readonly var a = ref @as<Shape,Cell256>(this);
            ref readonly var b = ref @as<Shape,Cell256>(src);
            return cell(this).Equals(cell(src));
        }

        public override int GetHashCode()
            => cell(this).GetHashCode();

        public override bool Equals(object src)
            => src is Shape x && Equals(x);

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
        public static bool operator ==(Shape a, Shape b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(Shape a, Shape b)
            => !a.Equals(b);
    }
}
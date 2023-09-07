//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct InstFieldSeg : IEquatable<InstFieldSeg>, IComparable<InstFieldSeg>
        {
            public readonly FieldKind Field;

            public readonly InstSegType Type;

            readonly ByteBlock3 Pad;

            [MethodImpl(Inline)]
            internal InstFieldSeg(FieldKind field, BitNumber<byte> src)
            {
                Field = field;
                Type = InstSegTypes.type(src.Width, src.Value);
                Pad = default;
                sys.@as<BitNumber<byte>>(Pad.First) = src;
            }

            [MethodImpl(Inline)]
            internal InstFieldSeg(FieldKind field, InstSegType type)
            {
                Field = field;
                Type = type;
                Pad = default;
            }

            public bool IsSymbolic
            {
                [MethodImpl(Inline)]
                get => Type.IsSymbolic;
            }

            public bool IsLiteral
            {
                [MethodImpl(Inline)]
                get => Type.IsLiteral;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Field == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Field != 0;
            }

            [MethodImpl(Inline)]
            public BitNumber<byte> ToLiteral()
                => sys.@as<BitNumber<byte>>(Pad.First);

            public int CompareTo(InstFieldSeg src)
            {
                var result = Xed.cmp(Field,src.Field);
                if(result == 0)
                {
                    if(IsLiteral && src.IsLiteral)
                        result = ToLiteral().CompareTo(src.ToLiteral());
                    else if(!IsLiteral && !src.IsLiteral)
                        result = Type.Id.CompareTo(src.Type.Id);
                    else if(IsLiteral && !src.IsLiteral)
                        result = -1;
                    else
                        result = 1;
                }
                return result;
            }

            [MethodImpl(Inline)]
            public bool Equals(InstFieldSeg src)
                => Field == src.Field && Type == src.Type;

            public override int GetHashCode()
                => (int)sys.hash(Type.GetHashCode(),(uint)Field);

            public override bool Equals(object src)
                => src is InstFieldSeg s && Equals(s);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static bool operator ==(InstFieldSeg a, InstFieldSeg b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator !=(InstFieldSeg a, InstFieldSeg b)
                => !a.Equals(b);

            [MethodImpl(Inline)]
            public static explicit operator ulong(InstFieldSeg src)
                => sys.@as<InstFieldSeg,ulong>(src);

            [MethodImpl(Inline)]
            public static explicit operator InstFieldSeg(ulong src)
                => sys.@as<ulong,InstFieldSeg>(src);

            public static InstFieldSeg Empty => default;
        }
    }
}
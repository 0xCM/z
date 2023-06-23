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
        public readonly struct InstSegType : IEquatable<InstSegType>
        {
            public readonly byte Id;

            public readonly byte Width;

            public readonly byte Literal;

            readonly byte Pad;

            [MethodImpl(Inline)]
            public InstSegType(byte id)
            {
                Id = id;
                Literal = 0;
                Width = 0;
                Pad = 0;
            }

            [MethodImpl(Inline)]
            public InstSegType(uint value)
            {
                Id = (byte)(value & 0xFF);
                Pad = 0;
                if(Id != 0)
                {
                    Width = (byte)((value >> 8) & 0xFF);
                    Literal = (byte)((value >> 16) & 0xFF);
                }
                else
                {
                    Width = 0;
                    Literal = 0;
                }
            }

            [MethodImpl(Inline)]
            internal InstSegType(byte n, byte literal)
            {
                Id = 0;
                Width = n;
                Literal = literal;
                Pad = 0;
            }

            public bool IsSymbolic
            {
                [MethodImpl(Inline)]
                get => Width == 0 && Id !=0;
            }

            public bool IsLiteral
            {
                [MethodImpl(Inline)]
                get => Width != 0 & Id == 0;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Id == 0 && Width == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => !IsEmpty;
            }

            [MethodImpl(Inline)]
            public byte LiteralValue()
                => Literal;

            public string Format()
            {
                var dst = EmptyString;
                if(IsLiteral)
                {
                    switch(Width)
                    {
                        case 1:
                            dst = XedRender.format((uint1)Literal);
                        break;
                        case 2:
                            dst = XedRender.format((uint2)Literal);
                        break;
                        case 3:
                            dst = XedRender.format((uint3)Literal);
                        break;
                        case 4:
                            dst = XedRender.format((uint4)Literal);
                        break;
                    }
                }
                else
                {
                    dst = InstSegTypes.pattern(this);
                }

                return dst;
            }

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public bool Equals(InstSegType src)
                => (uint)this == (uint)src;

            public override int GetHashCode()
                => (int)(uint)this;

            public override bool Equals(object src)
                => src is InstSegType x && Equals(x);

            [MethodImpl(Inline)]
            public static explicit operator uint(InstSegType src)
                => src.Id;

            [MethodImpl(Inline)]
            public static explicit operator InstSegType(uint src)
                => new InstSegType(src);

            [MethodImpl(Inline)]
            public static bool operator ==(InstSegType a, InstSegType b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator !=(InstSegType a, InstSegType b)
                => !a.Equals(b);

            public static InstSegType Empty => default;
        }
    }
}
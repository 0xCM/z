//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static LimitValues;
    using static TaggedLiterals;
    using static bits;

    [ApiHost]
    public struct BitMask
    {
        public static Index<BitMaskInfo> masks(Type src)
        {
            var fields = span(src.LiteralFields());
            var dst = list<BitMaskInfo>();
            for(var i=0u; i<fields.Length; i++)
            {
                ref readonly var field = ref skip(fields,i);
                var tc = Type.GetTypeCode(field.FieldType);
                var vRaw = field.GetRawConstantValue();
                if(IsMultiLiteral(field))
                    dst.AddRange(masks(polymorphic(field), vRaw));
                else if(IsBinaryLiteral(field))
                    dst.Add(BitMaskData.describe(binaryliteral(field,vRaw)));
                else
                    dst.Add(BitMaskData.describe(ClrLiterals.numeric(base2, field.Name, vRaw, BitRender.format(vRaw, tc))));
            }
            return dst.ToArray();
        }

        public static Index<BitMaskInfo> masks(LiteralInfo src, object value)
        {
            var input = src.Text;
            var fence = CharFence.define(Chars.LBracket, Chars.RBracket);
            var content = input;
            var fenced = Fenced.test(input, fence);
            if(fenced)
            {
                if(!Fenced.unfence(input, fence, out content))
                    return sys.empty<BitMaskInfo>();
            }

            var components = @readonly(content.SplitClean(FieldDelimiter));
            var count = components.Length;
            var dst = alloc<BitMaskInfo>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var component = ref skip(components,i);
                var length = component.Length;
                if(length > 0)
                {
                    var nbi = NumericBases.indicator(first(component));
                    var nbk = NumericBases.kind(nbi);

                    if(nbi != 0)
                        seek(dst, i) = BitMaskData.describe(ClrLiterals.numeric(nbk, src.Name, value, component.Substring(1)));
                    else
                    {
                        nbi = NumericBases.indicator(component[length - 1]);
                        nbi = nbi != 0 ? nbi : NumericBaseIndicator.Base2;
                        seek(dst, i) = BitMaskData.describe(ClrLiterals.numeric(nbk, src.Name, value, component.Substring(0, length - 1)));
                    }
                }
                else
                    seek(dst, i) = BitMaskData.describe(NumericLiteral.Empty);
            }

            return dst;
        }

        /// <summary>
        /// Creates a mask that covers an inclusive range of bits
        /// </summary>
        /// <param name="w">The target width selector</param>
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the last bit</param>
        [MethodImpl(Inline), Enable]
        public static byte ones(W8 w, byte i0, byte i1)
            => math.sll(zhi(max(w), segwidth(i0,i1)), i0);

        /// <summary>
        /// Creates a mask that covers an inclusive range of bits
        /// </summary>
        /// <param name="w">The target width selector</param>
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the last bit</param>
        [MethodImpl(Inline), Enable]
        public static ushort ones(W16 w, byte i0, byte i1)
            => math.sll(zhi(max(w), segwidth(i0,i1)), i0);

        /// <summary>
        /// Creates a mask that covers an inclusive range of bits
        /// </summary>
        /// <param name="w">The target width selector</param>
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the last bit</param>
        [MethodImpl(Inline), Enable]
        public static uint ones(W32 w, byte i0, byte i1)
            => math.sll(zhi(max(w), segwidth(i0,i1)), i0);

        /// <summary>
        /// Creates a mask that covers an inclusive range of bits
        /// </summary>
        /// <param name="w">The target width selector</param>
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the last bit</param>
        [MethodImpl(Inline), Enable]
        public static ulong ones(W64 w, byte i0, byte i1)
            => math.sll(zhi(max(w), segwidth(i0,i1)), i0);

        [MethodImpl(Inline), Op]
        public static BitMask one(byte width, byte pos)
            => bit.enable(0ul,pos);

        [MethodImpl(Inline), Op]
        public static BitMask mask(byte value)
            => new BitMask(value);

        [MethodImpl(Inline), Op]
        public static BitMask mask(ushort value)
            => new BitMask(value);

        [MethodImpl(Inline), Op]
        public static BitMask mask(uint value)
            => new BitMask(value);

        [MethodImpl(Inline), Op]
        public static BitMask mask(ulong value)
            => new BitMask(value);

        [MethodImpl(Inline), Op]
        public static BitMask mask(byte width, ulong value)
            => new BitMask(width, value);

        [MethodImpl(Inline), Op]
        public static BitMask mask(W8 w, byte i0, byte i1)
            => new BitMask((byte)w, ones(w, i0, i1));

        [MethodImpl(Inline), Op]
        public static BitMask mask(W16 w, byte i0, byte i1)
            => new BitMask((byte)w, ones(w, i0, i1));

        [MethodImpl(Inline), Op]
        public static BitMask mask(W32 w, byte i0, byte i1)
            => new BitMask((byte)w, ones(w, i0, i1));

        [MethodImpl(Inline), Op]
        public static BitMask mask(W64 w, byte i0, byte i1)
            => new BitMask((byte)w, ones(w, i0, i1));

        [Op]
        public static BitMask mask(NativeSize size, byte i0, byte i1)
            => size.Code switch{
                NativeSizeCode.W8 => mask(w8, i0, i1),
                NativeSizeCode.W16 => mask(w16, i0, i1),
                NativeSizeCode.W32 => mask(w32, i0, i1),
                NativeSizeCode.W64 => mask(w64, i0, i1),
                _ => BitMask.Empty
            };

        public readonly byte Width;

        public ulong Value;

        [MethodImpl(Inline)]
        public BitMask(byte value)
        {
            Width = 8;
            Value = value;
        }

        [MethodImpl(Inline)]
        public BitMask(ushort value)
        {
            Width = 16;
            Value = value;
        }

        [MethodImpl(Inline)]
        public BitMask(uint value)
        {
            Width = 32;
            Value = value;
        }

        [MethodImpl(Inline)]
        public BitMask(ulong value)
        {
            Width = 64;
            Value = value;
        }

        [MethodImpl(Inline)]
        public BitMask(byte width, ulong value)
        {
            Width = width;
            Value = value;
        }

        [MethodImpl(Inline)]
        public byte Apply(byte src)
            => math.and((byte)Value, src);

        [MethodImpl(Inline)]
        public ushort Apply(ushort src)
            => math.and((ushort)Value, src);

        [MethodImpl(Inline)]
        public uint Apply(uint src)
            => math.and((uint)Value, src);

        [MethodImpl(Inline)]
        public ulong Apply(ulong src)
            => math.and(Value, src);

        [MethodImpl(Inline)]
        public BitMask And(BitMask src)
            => new BitMask(math.max(Width,src.Width), Value & src.Value);

        [MethodImpl(Inline)]
        public BitMask Or(BitMask src)
            => new BitMask(math.max(Width,src.Width), Value | src.Value);

        [MethodImpl(Inline)]
        public BitMask Xor(BitMask src)
            => new BitMask(math.max(Width,src.Width), Value ^ src.Value);

        [MethodImpl(Inline)]
        public BitMask Invert()
            => new BitMask(Width, ~Value);

        [MethodImpl(Inline)]
        public BitMask Negate()
            => new BitMask(Width, math.negate(Value));

        [MethodImpl(Inline)]
        public BitMask Sll(byte count)
        {
            var value = Value << count;
            var width = math.max(bits.effwidth(value), Width);
            return new BitMask(width,value);
        }

        [MethodImpl(Inline)]
        public BitMask Srl(byte count)
        {
            var value = Value << count;
            var width = math.min(bits.effwidth(value), Width);
            return new BitMask(width,value);
        }

        public string Format()
            => ((BitMaskData)this).Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static BitMask operator ~(BitMask src)
            => src.Invert();

        [MethodImpl(Inline)]
        public static BitMask operator -(BitMask src)
            => src.Negate();

        [MethodImpl(Inline)]
        public static BitMask operator &(BitMask a, BitMask b)
            => a.And(b);

        [MethodImpl(Inline)]
        public static BitMask operator |(BitMask a, BitMask b)
            => a.Or(b);

        [MethodImpl(Inline)]
        public static BitMask operator ^(BitMask a, BitMask b)
            => a.Xor(b);

        [MethodImpl(Inline)]
        public static BitMask operator <<(BitMask a, int count)
            => a.Sll((byte)count);

        [MethodImpl(Inline)]
        public static BitMask operator >>(BitMask a, int count)
            => a.Srl((byte)count);

        [MethodImpl(Inline)]
        public static implicit operator BitMask(ulong src)
            => new BitMask(src);

        [MethodImpl(Inline)]
        public static implicit operator BitMaskData(BitMask src)
            => new BitMaskData(src.Value, src.Width);

        public static BitMask Empty => default;
    }
}
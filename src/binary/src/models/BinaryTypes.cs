//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class BinaryTypes
    {
        public static BinaryRecordType record(string name, params IBinaryField[] fields)
            => new BinaryRecordType(name, fields);

        public static IntegerType signed(ushort width) 
            => new (Sign.Signed, width);
        
        public static IntegerType unsigned(ushort width) 
            => new (Sign.Unsigned, width);
        
        public static AlignedSegment segment(string name, ByteSize size, ByteSize alignment) 
            => new (name, size, alignment);

        public static UnmanagedType unmanaged(string name, BitWidth width)
            => new UnmanagedType(name,width, width);

        public static UnmanagedType unmanged<T>()
            where T : unmanaged
                => new UnmanagedType(typeof(T).Name, width<T>(), width<T>());

        public enum Sign : sbyte
        {
            Signed = -1,

            None = 0,

            Unsigned = 1
        }

        public static bool parse(char c, out Sign dst)
        {
            var result = false;
            dst = 0;
            switch(c)
            {
                case 'i':
                    dst = Sign.Signed;
                    result = true;
                break;
                case 'u':
                    dst = Sign.Unsigned;
                    result = true;
                break;                                       
            }
            
            return result;
        }

        public static bool parse(ReadOnlySpan<char> src, out IntegerType dst)
        {
            var result = false;
            dst = default;
            Span<char> buffer = stackalloc char[6];
            result = parse(first(src), out Sign sign);
            if(result && DigitParsers.parse(base10, slice(src,1), out ushort width))
            {
                dst = new IntegerType(sign, width);
                result = true;
            }
            return result;
        }

        public static IntegerType integer(Sign sign, ushort width)
            => new (sign,width);

        public static BinarySeq seq(BinaryType ct, uint n)
            => new BinarySeq(ct,n);

        public abstract record class BinarySegment : BinaryType
        {
            protected BinarySegment(@string name)
                : base(name)
            {
                
            }
        }

        public record class StreamType : BinaryType
        {
            public StreamType(@string name)
                : base(name)
            {

            }
        }

        public record class AlignedSegment : BinarySegment
        {
            public AlignedSegment(@string name, ByteSize size, ByteSize aligment)
                : base(name)
            {
                Size = size;
                Alignment = aligment;
            }

            public readonly ByteSize Size;

            public readonly ByteSize Alignment;
        }

        public record class UnmanagedType : BinaryType
        {
            public UnmanagedType(@string name, BitWidth width, BitWidth aligned)
                : base(name)
            {
                Width = width;
                AlignedWidth = aligned;
            }

            public readonly BitWidth Width;

            public readonly BitWidth AlignedWidth;
        }

        public sealed record class IntegerType : UnmanagedType
        {
            internal static string name(Sign sign, ushort width)
                => sign == Sign.Signed  ? $"i{width}" : $"u{width}";

            internal IntegerType(Sign sign, ushort width)
                : base(name(sign, width), width, BinaryCalcs.align(width, 8))
            {
                Sign = sign;
            }

            public readonly Sign Sign;

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => (Hash16)(ushort)Sign | (Hash16)(ushort)Width;
            }

            public override int GetHashCode()
                => Hash;
            
            public bool Equals(IntegerType src)
                => Sign == src.Sign && Width == src.Width;

            public override string ToString()
                => Name;
        }

        public record class BinarySeq : BinaryType
        {
            public BinarySeq(BinaryType ct, uint n)
                : base($"{ct}[{n}]")
            {
                CellType = ct;

                CellCount = n;
            }

            public readonly BinaryType CellType;

            public readonly uint CellCount;            
        }

        public record class BinaryRecordType : BinaryType
        {
            public BinaryRecordType(@string name, IBinaryField[] fields)
                : base(name)
            {
                Fields = fields;
            }
            
            public readonly ReadOnlySeq<IBinaryField> Fields;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class BinaryTypes
    {
        public static bool parse(ReadOnlySpan<char> src, out IntegerType dst)
        {
            var result = false;
            var count = src.Length;
            dst = default;
            var sign = default(char);
            Span<DecimalDigitSym> digits = stackalloc DecimalDigitSym[6];
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(i == 0)
                {
                    switch(c)
                    {
                        case 'i':
                            sign = 'i';
                        break;
                        case 'u':
                            sign = 'u';
                        break;                        
                    }
                    if(sign == 0)
                        break;
                }
                else
                {
                    switch(c)
                    {
                        case '0':
                        break;
                        case '1':
                        break;
                        case '2':
                        break;
                        case '3':
                        break;
                        case '4':
                        break;
                        case '5':
                        break;
                        case '6':
                        break;
                        case '7':
                        break;
                        case '8':
                        break;
                        case '9':
                        break;
                    }
                }
            }
            return result;
        }
        public static IntegerType integer(bool signed, uint width)
            => new (signed,width);

        public static BinarySeq seq(BinaryType ct, uint n)
            => new BinarySeq(ct,n);

        public abstract record class SegmentType : BinaryType
        {
            protected SegmentType(@string name)
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

        public record class Aligned : SegmentType
        {
            public Aligned(@string name, ByteSize aligment)
                : base(name)
            {
                Alignment = aligment;
            }

            public readonly ByteSize Alignment;           
        }

        public sealed record class IntegerType : BinaryType
        {
            internal static string name(bool signed, BitWidth width)
                => signed ? $"i{(uint)width}" : $"u{(uint)width}";

            internal IntegerType(bool signed, BitWidth width)
                : base(name(signed,width))
            {
                Signed = signed;
                Width = width;
            }

            public readonly bool Signed;

            public readonly BitWidth Width;
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

        public record class RecordType : BinaryType
        {
            public RecordType(@string name, IBinaryField[] fields)
                : base(name)
            {
                Fields = fields;
            }
            
            public readonly ReadOnlySeq<IBinaryField> Fields;
        }
    }
}
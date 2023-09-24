//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct AddressParser
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Attempts to parse an address segment in standard form, [start,end]
        /// </summary>
        /// <param name="src">The source text</param>
        [Parser]
        public static Outcome range(string src, out MemoryRange dst)
        {
            var option = range(src);
            if(option)
            {
                dst = option.Value;
                return true;
            }
            else
            {
                dst = MemoryRange.Empty;
                return false;
            }
        }

        static Option<MemoryRange> range(string src)
             => from i0 in src.FirstIndexOf(Chars.LBracket)
                from i1 in src.FirstIndexOf(Chars.RBracket)
                let inner = src.Substring(i0 + 1, i1 - i0 - 1)
                let parts = inner.Split(Chars.Comma).Trim()
                where parts.Length == 2
                from start in HexNumericParser.parse64u(parts[0]).ToOption()
                from end in HexNumericParser.parse64u(parts[1]).ToOption()
                select new MemoryRange((MemoryAddress)start, (MemoryAddress)end);

        [Parser]
        public static Outcome parse(ReadOnlySpan<char> src, out MemoryAddress dst)
        {
            var result = Hex.parse64u(src, out var a);
            if(result)
            {
                dst = a;
                return true;
            }
            else
            {
                dst = MemoryAddress.Zero;
                return false;
            }
        }

        [Parser]
        public static bool parse(string src, out Address64 dst)
        {
            var result = Hex.parse64u(src, out var a);
            if(result)
            {
                dst = a;
                return true;
            }
            else
            {
                dst = Address64.Zero;
                return false;
            }
        }

        [Parser]
        public static Outcome parse(string src, out Address32 dst)
        {
            var result = Hex.parse32u(src, out var a);
            if(result)
            {
                dst = a;
                return true;
            }
            else
            {
                dst = Address32.Zero;
                return false;
            }
        }

        [Parser]
        public static Outcome parse(string src, out Address16 dst)
        {
            var result = Hex.parse16u(src, out var a);
            if(result)
            {
                dst = a;
                return true;
            }
            else
            {
                dst = Address16.Zero;
                return false;
            }
        }

        [Parser]
        public static Outcome parse(string src, out Address8 dst)
        {
            var result = Hex.parse8u(src, out var a);
            if(result)
            {
                dst = a;
                return true;
            }
            else
            {
                dst = Address8.Zero;
                return false;
            }
        }
    }

    partial struct Msg
    {
        public static MsgPattern<string> AddressParseFailure => "Parsing address from {0} failed";
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct DataParser
    {
        public static MsgPattern<NameOld,string> ParseFailure => "Parse failure {0}:{1}";

        public static Outcome asci<S,N>(string src, N n, out S dst)
            where S : struct, IAsciSeq<S,N>
            where N : unmanaged, ITypeNat
                => AsciG.parse(src, n, out dst);

        public static bool parse(string src, out PartName dst)
        {
            dst = text.trim(src);
            return true;
        }

        public static bool parse(string src, out DataSize dst)
            => Sizes.parse(src, out dst);

        public static bool parse(string src, out Hex4 dst)
            => HexParser.parse(src, out dst);

        public static bool parse(string src, out Hex8 dst)
            => HexParser.parse(src, out dst);

        public static bool parse(string src, out Hex16 dst)
            => HexParser.parse(src, out dst);

        public static bool parse(string src, out Hex32 dst)
            => HexParser.parse(src, out dst);

        public static bool parse(string src, out Hex64 dst)
            => HexParser.parse(src, out dst);

        public static bool parse(ReadOnlySpan<char> src, out Hex32 dst)
            => HexParser.parse(src, out dst);

        public static bool parse(ReadOnlySpan<char> src, out Hex64 dst)
            => HexParser.parse(src, out dst);

        public static Outcome parse(string src, out SymVal dst)
            => SymVal.parse(src, out dst);

        public static Outcome parse(string src, out MemoryAddress dst)
            => AddressParser.parse(src, out dst);

        public static Outcome parse(string src, out Address32 dst)
            => AddressParser.parse(src, out dst);

        public static Outcome parse(string src, out Address16 dst)
            => AddressParser.parse(src, out dst);

        public static Outcome eparse<T>(string src, out T dst)
            where T : unmanaged
                => Enums.parse(src, out dst);

        public static Outcome parse(string src, out ByteSize dst)
            => Sizes.parse(src, out dst);

        public static Outcome parse(string src, out SymExpr dst)
            => SymExpr.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out string dst)
        {
            dst = src ?? EmptyString;
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out @string dst)
        {
            dst = src ?? EmptyString;
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out text31 dst)
        {
            dst = src ?? EmptyString;
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out byte dst)
            => NumericParser.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out sbyte dst)
            => NumericParser.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out short dst)
            => NumericParser.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out ushort dst)
            => NumericParser.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out int dst)
            => NumericParser.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out uint dst)
            => NumericParser.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out long dst)
            => NumericParser.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out ulong dst)
            => NumericParser.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out float dst)
            => NumericParser.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out double dst)
            => NumericParser.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out bool dst)
        {
            dst = default;
            var result = BitParser.semantic(src, out var b);
            if(result)
                dst = b;
            return result;
        }

        public static Outcome parse(string src, out bit dst)
            => BitParser.parse(src, out dst);

        [Parser]
        public static Outcome numeric<T>(string src, out T dst)
            => NumericParser.parse(src, out dst);

        [Parser]
        public static Outcome parse(string src, out Identifier dst)
        {
            dst = text.trim(src ?? EmptyString);
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out SymIdentity dst)
        {
            dst = text.trim(src ?? EmptyString);
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out TextBlock dst)
        {
            dst = src ?? EmptyString;
            return true;
        }


        [Parser]
        public static Outcome parse(string src, out FilePath dst)
        {
            dst = FS.path(src);
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out _FileUri dst)
        {
            dst = FS.path(src);
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out FileUri dst)
        {
            dst = FS.path(src);
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out BinaryCode dst)
        {
            var result = Hex.hexdata(src, out var data);
            if(result)
            {
                dst = data;
                return result;
            }
            else
            {
                dst = BinaryCode.Empty;
                return (false, Msg.ParsingBytesFailed.Format(src));
            }
        }

        public static Outcome parse(string src, out OpUri dst)
            => ApiIdentity.parse(src, out dst);
     }

     partial struct Msg
     {
         public static MsgPattern<string> ParsingBytesFailed => "Parsing bytes from {0} failed";
     }
}
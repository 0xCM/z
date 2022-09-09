//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    using static core;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct HostAsmRecord : IComparable<HostAsmRecord>
    {
        public const string TableId = "asm.statements";

        public static Outcome parse(in TextRow src, out HostAsmRecord dst)
        {
            const byte FieldCount = HostAsmRecord.FieldCount;
            var result = Outcome.Success;
            var count = src.CellCount;
            var cells = src.Cells;
            dst = default;
            if(src.CellCount != FieldCount)
                return (false, AppMsg.FieldCountMismatch.Format(FieldCount, src.CellCount));

            var i=0;
            result = DataParser.parse(skip(cells, i++), out dst.BlockAddress);
            if(result.Fail)
                return result;

            result = DataParser.parse(skip(cells, i++), out dst.IP);
            if(result.Fail)
                return result;

            result = DataParser.parse(skip(cells, i++), out dst.BlockOffset);
            if(result.Fail)
                return result;

            AsmExpr.parse(skip(cells,i++), out dst.Expression);
            dst.Encoded = ApiNative.asmhex(skip(cells, i++));
            result = AsmSigInfo.parse(skip(cells, i++), out dst.Sig);
            if(result.Fail)
                return result;

            dst.OpCode = skip(cells, i++);
            dst.Bitstring = ApiNative.bitstring(dst.Encoded);

            result = DataParser.parse(skip(cells, i++), out dst.OpUri);
            if(result.Fail)
                return (false, AppMsg.UriParseFailure.Format(skip(cells,i-1)));

            return result;
        }


        public const byte FieldCount = 9;

        public MemoryAddress BlockAddress;

        public MemoryAddress IP;

        public Address16 BlockOffset;

        public AsmExpr Expression;

        public AsmHexCode Encoded;

		public AsmSigInfo Sig;

        public TextBlock OpCode;

        public string Bitstring;

        public OpUri OpUri;

        public bool IsValid()
            => Expression.IsValid;

        [MethodImpl(Inline)]
        public int CompareTo(HostAsmRecord src)
            => IP.CompareTo(src.IP);

        public string Format()
            => string.Format("{0} {1,-36} # {2} => {3}",
                        BlockOffset,
                        Expression,
                        string.Format("({0})<{1}>[{2}] => {3}", Sig, OpCode, Encoded.Size, Encoded.Format()),
                        Encoded.BitString
                        );

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{16,16,16,64,32,64,32,128,80};
    }
}
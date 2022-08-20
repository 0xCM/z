//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ProcessAsmRecord : IComparable<ProcessAsmRecord>, IAsmHexProvider<ProcessAsmRecord>
    {
        const string TableId = "asm.global";

        public const byte FieldCount = 11;

        public const ushort RowPad = 680;

        /// <summary>
        /// A 0-based monotonic value that serves as a surrogate key
        /// </summary>
        [Render(12)]
        public uint Sequence;

        /// <summary>
        /// A 0-based 32-bit offset
        /// </summary>
        [Render(16)]
        public Address32 GlobalOffset;

        /// <summary>
        /// The IP block address
        /// </summary>
        [Render(16)]
        public MemoryAddress BlockAddress;

        /// <summary>
        /// The IP address
        /// </summary>
        [Render(16)]
        public MemoryAddress IP;

        /// <summary>
        /// The block-relative IP offset
        /// </summary>
        [Render(16)]
        public Address16 BlockOffset;

        [Render(42)]
        public AsmExpr Statement;

        [Render(32)]
        public AsmHexCode Encoded;

        [Render(42)]
		public AsmSigInfo Sig;

        [Render(32)]
        public TextBlock OpCode;

        [Render(128)]
        public string Bitstring;

        [Render(80)]
        public OpUri OpUri;

        [MethodImpl(Inline)]
        public ref readonly AsmHexCode AsmHex(out AsmHexCode hex)
        {
            hex = Encoded;
            return ref hex;
        }

        [MethodImpl(Inline)]
        public int CompareTo(ProcessAsmRecord src)
            => IP.CompareTo(src.IP);

        public override int GetHashCode()
            => (int)Sequence;

        public static ProcessAsmRecord Empty => default;
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents an asm statement together with its context and encoding
    /// </summary>
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public record struct AssembledAsm
    {
        public const string TableId = "asm.assembled";

        public LineNumber SourceLine;

        public Hex64 Id;

        public MemoryAddress IP;

        public AsmExpr Asm;

        public AsmHexCode Encoded;

        public TextBlock Bitstring;
    }
}
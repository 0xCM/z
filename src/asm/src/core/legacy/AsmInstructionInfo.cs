//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Describes an assembly instruction
    /// </summary>
    public class AsmInstructionInfo
    {
        /// <summary>
        /// The encoded bytes
        /// </summary>
        public readonly CodeBlock Encoded;

        /// <summary>
        /// The zero-based offset of the function, relative to the base address
        /// </summary>
        public readonly uint Offset;

        /// <summary>
        /// The instruction content, suitable for display
        /// </summary>
        public readonly AsmExpr Statement;

        /// <summary>
        /// The instruction string paired with the op code
        /// </summary>
        public readonly AsmFormInfo AsmForm;

        [MethodImpl(Inline)]
        public AsmInstructionInfo(MemoryAddress @base, uint offset, AsmExpr statment, AsmFormInfo form, byte[] code)
        {
            Encoded = new CodeBlock(@base, code);
            Offset = offset;
            Statement = statment;
            AsmForm = form;
        }
    }
}
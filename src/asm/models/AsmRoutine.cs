//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Describes the assembly encoding of a member api
    /// </summary>
    public class AsmRoutine : IComparable<AsmRoutine>
    {
        /// <summary>
        /// The defining operation uri
        /// </summary>
        public readonly _OpUri Uri;

        /// <summary>
        /// The source member signature
        /// </summary>
        public readonly @string DisplaySig;

        /// <summary>
        /// The function encoding
        /// </summary>
        public readonly ApiCodeBlock Code;

        /// <summary>
        /// The encoded instructions
        /// </summary>
        public readonly Index<ApiInstruction> Instructions;

        /// <summary>
        /// Specifies the reason for capture termination
        /// </summary>
        public readonly ExtractTermCode TermCode;

        /// <summary>
        /// Specifies formatted assembly code
        /// </summary>
        public readonly Func<AsmRoutine,string> AsmRender;

        [MethodImpl(Inline)]
        public AsmRoutine(_OpUri uri, @string sig, ApiCodeBlock code, ExtractTermCode term, Index<ApiInstruction> instructions, Func<AsmRoutine,string> render = null)
        {
            Uri = uri;
            DisplaySig = sig;
            Instructions = instructions;
            Code = code;
            TermCode = term;
            AsmRender = render ?? (r => Code.Format());
        }

        [MethodImpl(Inline)]
        public int CompareTo(AsmRoutine other)
            => Code.BaseAddress.CompareTo(other.BaseAddress);

        /// <summary>
        /// The head of the address range
        /// </summary>
        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Code.BaseAddress;
        }

        /// <summary>
        /// The number of encoded instructions
        /// </summary>
        public int InstructionCount
        {
            [MethodImpl(Inline)]
            get => Instructions.Length;
        }

        public bool IsEmpty
            => InstructionCount == 0;

        public bool IsNonEmpty
            => InstructionCount != 0;

        public static AsmRoutine Empty
            => new AsmRoutine(_OpUri.Empty, @string.Empty, ApiCodeBlock.Empty, 0, Index<ApiInstruction>.Empty);
    }
}
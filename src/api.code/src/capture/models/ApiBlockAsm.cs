//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Encapsulates a contiguous instruction sequence along with the captured bits
    /// </summary>
    public readonly struct ApiBlockAsm
    {
        /// <summary>
        /// Encoded assembly
        /// </summary>
        public readonly ApiCodeBlock Encoded;

        /// <summary>
        /// The decoded instructions
        /// </summary>
        public readonly Index<IceInstruction> Decoded;

        /// <summary>
        /// The reason capture was terminated
        /// </summary>
        public readonly ExtractTermCode TermCode;

        [MethodImpl(Inline)]
        public ApiBlockAsm(ApiCodeBlock encoded, IceInstruction[] decoded, ExtractTermCode term = 0)
        {
            Encoded = encoded;
            Decoded = decoded;
            TermCode = term;
        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Encoded.BaseAddress;
        }

        public ReadOnlySpan<IceInstruction> Instructions
        {
            [MethodImpl(Inline)]
            get => Decoded.View;
        }

        /// <summary>
        /// Queries/Manipulates an index-identified instruction
        /// </summary>
        public ref IceInstruction this[int i]
            => ref Decoded[i];

        public int InstructionCount
            => Decoded.Length;
    }
}
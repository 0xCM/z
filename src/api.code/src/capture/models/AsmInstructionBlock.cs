//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;
    using System.Linq;

    using Asm;

    /// <summary>
    /// Defines an *unbased* sequence of instructions
    /// </summary>
    public readonly struct AsmInstructionBlock : IEnumerable<IceInstruction>, IEquatable<AsmInstructionBlock>
    {
        readonly Index<IceInstruction> _Instructions;

        public ApiCodeBlock Code {get;}

        [MethodImpl(Inline)]
        public AsmInstructionBlock(OpUri uri, IceInstruction[] src, BinaryCode code)
        {
            _Instructions = src;
            if(_Instructions.IsNonEmpty)
                Code = new ApiCodeBlock(_Instructions.First.IP, uri, code);
            else
                Code = ApiCodeBlock.Empty;
        }

        public OpUri Uri => Code.OpUri;

        public ref readonly IceInstruction First
        {
            [MethodImpl(Inline)]
            get => ref _Instructions.First;
        }        

        public ReadOnlySpan<IceInstruction> Instructions
        {
            [MethodImpl(Inline)]
            get => _Instructions.View;
        }

        public IceInstruction[] InstructionStorage
            => _Instructions.Storage;

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Code.BaseAddress;
        }

        public ref readonly IceInstruction this[int index]
        {
            [MethodImpl(Inline)]
            get => ref _Instructions[index];
        }

        public ref readonly IceInstruction this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref _Instructions[index];
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => _Instructions.Length;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)_Instructions.Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => _Instructions.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => _Instructions.IsNonEmpty;
        }

        [MethodImpl(Inline)]
        public bool Equals(AsmInstructionBlock src)
            => _Instructions.Equals(src._Instructions);

        public string Format()
            => _Instructions.Format();

        public override string ToString()
            => Format();

        IEnumerator<IceInstruction> IEnumerable<IceInstruction>.GetEnumerator()
            => _Instructions.AsEnumerable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => _Instructions.AsEnumerable().GetEnumerator();

        public static implicit operator IceInstruction[](AsmInstructionBlock src)
            => src._Instructions;

        public static AsmInstructionBlock Empty
            => new AsmInstructionBlock(OpUri.Empty, sys.empty<IceInstruction>(), BinaryCode.Empty);
    }
}
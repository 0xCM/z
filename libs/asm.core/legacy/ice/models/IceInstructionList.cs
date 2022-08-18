//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Collections;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;

    /// <summary>
    /// Defines a contiguous *based* instruction sequence
    /// </summary>
    public readonly struct IceInstructionList : IEnumerable<IceInstruction>
    {
        readonly IceInstruction[] Data;

        public CodeBlock Encoded {get;}

        [MethodImpl(Inline)]
        public IceInstructionList(IceInstruction[] src, CodeBlock code)
        {
            Data = src;
            Encoded = code;
        }

        public ReadOnlySpan<IceInstruction> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public IceInstruction[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Count Count
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public bool IsEmpty
        {
             [MethodImpl(Inline)]
             get => Data == null || Data.Length == 0;
        }

        public IEnumerator<IceInstruction> GetEnumerator()
            => ((IReadOnlyList<IceInstruction>)Data).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => Data.GetEnumerator();

        public static IceInstructionList Empty
            => new IceInstructionList(sys.empty<IceInstruction>(), CodeBlock.Empty);
    }
}
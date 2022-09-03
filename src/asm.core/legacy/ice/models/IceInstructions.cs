//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;

    public readonly struct IceInstructions
    {
        readonly List<IceInstruction> Data;

        public CodeBlock Encoded {get;}

        [MethodImpl(Inline)]
        public IceInstructions(List<IceInstruction> data, CodeBlock code)
        {
            Data = data;
            Encoded = code;
        }

        public ReadOnlySpan<IceInstruction> View
        {
            [MethodImpl(Inline)]
            get => Data.ViewDeposited();
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Count;
        }

        public bool IsEmpty
        {
             [MethodImpl(Inline)]
             get => Data == null || Count == 0;
        }

        public bool IsNonEmpty
        {
             [MethodImpl(Inline)]
             get => !IsEmpty;
        }

        public static IceInstructions Empty
            => new IceInstructions(core.list<IceInstruction>(), CodeBlock.Empty);
    }
}
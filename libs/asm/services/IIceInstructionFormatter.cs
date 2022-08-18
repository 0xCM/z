//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using Iced = Iced.Intel;

    public interface IIceInstructionFormatter
    {
        string FormatInstruction(in Iced.Instruction src, ulong @base);

        ReadOnlySpan<string> FormatInstructions(Iced.InstructionList src, ulong @base);
    }
}
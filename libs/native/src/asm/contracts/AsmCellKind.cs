//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Flags]
    public enum AsmCellKind : uint
    {
        None = 0,

        // identifier:
        BlockLabel = 1,

        // 0005h
        OffsetLabel = 2,

        // mov rax,[rcx]
        Instruction = 4,

        // ; ...
        Comment = 8,

        CodeSize = 16,

        // 48 8b 01
        HexCode = 32,

        // MOV r64, r/m64
        Sig = 64,

        // REX.W 8B /r
        OpCode = 128,

        // 0000 1010 ..
        BitCode = 256,

        // A label of some sort
        Label = 512,

        // A statement or one of its parts
        Expr = 1024,

        // .xyx a,b,c
        Directive = 2048,

        DirectiveOp = Directive*2,

        InlineComment = DirectiveOp*2,

        Mnemonic = InlineComment*2,

        Block = Mnemonic*2,

        OffsetValue = Block*2,
    }
}
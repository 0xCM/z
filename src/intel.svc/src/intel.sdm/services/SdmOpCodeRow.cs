//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[Record(TableName)]
public record SdmOpCodeRow : IComparable<SdmOpCodeRow>
{
    const string TableName = "sdm.opcodes";

    [Render(64)]
    public string Instruction;

    [Render(32)]
    public string OpCode;

    [Render(20)]
    public string Encoding;

    [Render(16)]
    public string Mode64;

    [Render(16)]
    public string LegacyMode;

    [Render(1)]
    public string Description;   

    public int CompareTo(SdmOpCodeRow src)
    {
        var result = Instruction.CompareTo(src.Instruction);
        if(result == 0)
            result = OpCode.CompareTo(src.OpCode);
        return result;
    }
}

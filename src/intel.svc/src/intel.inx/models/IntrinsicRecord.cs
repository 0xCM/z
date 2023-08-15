//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static IntrinsicsDoc;

[Record(TableId)]
public struct IntelIntrinsicRecord : IComparable<IntelIntrinsicRecord>, ISequential<IntelIntrinsicRecord>
{
    const string TableId = "intel.intrinsics";

    [Render(8)]
    public uint Key;

    [Render(42)]
    public @string Name;

    [Render(32)]
    public CpuIdMembership CpuId;

    [Render(8)]
    public ushort FormId;

    [Render(64)]
    public XedModels.XedInstForm InstForm;

    [Render(18)]
    public XedInstClass InstClass;

    [Render(56)]
    public Instruction InstSig;

    [Render(32)]
    public InstructionTypes Types;

    [Render(32)]
    public Category Category;

    [Render(1)]
    public FunctionSig Signature;

    uint ISequential.Seq
    {
        get => Key;
        set => Key = value;
    }

    public int CompareTo(IntelIntrinsicRecord src)
    {
        var result = InstForm.CompareTo(src.InstForm);
        if(result == 0)
            result = Name.CompareTo(src.Name);
        return result;
    }

    public static IntelIntrinsicRecord empty()
    {
        var dst = default(IntelIntrinsicRecord);
        dst.Key = 0;
        dst.Name = EmptyString;
        dst.CpuId = CpuIdMembership.Empty;
        dst.FormId = 0;
        dst.InstForm = XedModels.XedInstForm.Empty;
        dst.InstClass = XedInstClass.Empty;
        dst.InstSig = Instruction.Empty;
        dst.Types = InstructionTypes.Empty;
        dst.Category = EmptyString;
        dst.Signature = FunctionSig.Empty;
        return dst;
    }

    public static IntelIntrinsicRecord Empty => empty();
}

//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    using static IntrinsicsDoc;

    [Record(TableId)]
    public struct IntelIntrinsicRecord : IComparable<IntelIntrinsicRecord>, ISequential<IntelIntrinsicRecord>
    {
        const string TableId = "intrinsics";

        [Render(8)]
        public uint Key;

        [Render(42)]
        public string Name;

        [Render(32)]
        public DelimitedIndex<CpuId> CpuId;

        [Render(8)]
        public ushort FormId;

        [Render(64)]
        public InstForm InstForm;

        [Render(18)]
        public AmsInstClass InstClass;

        [Render(56)]
        public Instruction InstSig;

        [Render(32)]
        public DelimitedIndex<InstructionType> Types;

        [Render(32)]
        public string Category;

        [Render(1)]
        public DocSig Signature;

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
            dst.CpuId = new (sys.empty<CpuId>());
            dst.FormId = 0;
            dst.InstForm = InstForm.Empty;
            dst.InstClass = AmsInstClass.Empty;
            dst.InstSig = Instruction.Empty;
            dst.Types = new (sys.empty<InstructionType>());
            dst.Category = EmptyString;
            dst.Signature = DocSig.Empty;
            return dst;
        }

        public static IntelIntrinsicRecord Empty => empty();
    }
}
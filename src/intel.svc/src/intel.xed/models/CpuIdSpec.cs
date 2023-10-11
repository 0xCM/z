//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    [StructLayout(StructLayout,Pack=1),Record(TableId)]
    public record struct CpuIdSpec : IComparable<CpuIdSpec>, ISequential<CpuIdSpec>
    {
        public const string TableId = "xed.cpuid";

        [Render(6)]
        public ushort Seq;

        [Render(64)]
        public asci64 Definition;

        [Render(32)]
        public asci32 IsaName;

        [MethodImpl(Inline)]
        public CpuIdSpec(ushort seq, asci64 spec, asci32 isa)
        {
            Seq = seq;
            Definition = spec;
            IsaName = isa;
        }

        uint ISequential.Seq
        {
            get => Seq;
            set => Seq = (ushort)value;
        }

        public int CompareTo(CpuIdSpec src)
        {
            var result = Definition.CompareTo(src.Definition);
            if(result == 0)
                result = IsaName.CompareTo(src.IsaName);
            return result;
        }
    }
}

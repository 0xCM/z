//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [StructLayout(StructLayout,Pack=1),Record(TableId)]
        public record struct CpuIdImport : IComparable<CpuIdImport>, ISequential<CpuIdImport>
        {
            public const string TableId = "xed.cpuid";

            [Render(6)]
            public ushort Seq;

            [Render(64)]
            public asci64 Spec;

            [Render(32)]
            public asci32 IsaName;

            [MethodImpl(Inline)]
            public CpuIdImport(ushort seq, asci64 spec, asci32 isa)
            {
                Seq = seq;
                Spec = spec;
                IsaName = isa;
            }

            uint ISequential.Seq
            {
                get => Seq;
                set => Seq = (ushort)value;
            }

            public int CompareTo(CpuIdImport src)
            {
                var result = Spec.CompareTo(src.Spec);
                if(result == 0)
                    result = IsaName.CompareTo(src.IsaName);
                return result;
            }
        }
    }
}
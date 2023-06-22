//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedModels
    {
        [StructLayout(StructLayout,Pack=1), Record(TableId)]
        public record struct IsaImport : ISequential<IsaImport>, IComparable<IsaImport>
        {
            public const string TableId = "xed.isa";

            [Render(6)]
            public byte Seq;

            [Render(48)]
            public asci64 XedName;

            [Render(32)]
            public asci32 IsaName;

            uint ISequential.Seq
            {
                get => Seq;
                set => Seq = (byte)value;
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Seq;
            }

            public override int GetHashCode()
                => Hash;

            public int CompareTo(IsaImport src)
                => IsaName.CompareTo(src.IsaName);
        }
    }
}
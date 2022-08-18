//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1,Size=(int)Size)]
        public struct InstLayoutBlock
        {
            public const uint Size = 256;

            public Span<LayoutCell> Cells
            {
                [MethodImpl(Inline)]
                get => recover<LayoutCell>(bytes(this));
            }

            public ref LayoutCell this[int i]
            {
                [MethodImpl(Inline)]
                get => ref  seek(Cells,i);
            }

            public ref LayoutCell this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref  seek(Cells,i);
            }
        }
    }
}
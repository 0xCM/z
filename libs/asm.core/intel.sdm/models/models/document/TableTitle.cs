//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    partial struct SdmModels
    {
        public struct TableTitle
        {
            public TableNumber Table;

            public CharBlock80 Label;

            [MethodImpl(Inline)]
            public TableTitle(TableNumber tn, CharBlock80 label)
            {
                Table = tn;
                Label = label;
            }

            public string Format()
                => format(this);

            public override string ToString()
                => Format();

            public static TableTitle Empty
            {
                [MethodImpl(Inline)]
                get => new TableTitle(TableNumber.Empty, CharBlock80.Empty);
            }
        }
    }
}
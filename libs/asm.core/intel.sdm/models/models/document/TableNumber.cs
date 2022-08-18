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
        public readonly struct TableNumber
        {
            readonly CharBlock8 Storage;

            [MethodImpl(Inline)]
            public TableNumber(CharBlock8 data)
            {
                Storage = data;
            }

            public ReadOnlySpan<char> Data
            {
                [MethodImpl(Inline)]
                get => Storage.Data;
            }

            public ReadOnlySpan<char> String
            {
                [MethodImpl(Inline)]
                get => Storage.String;
            }

            public static TableNumber Empty
            {
                [MethodImpl(Inline)]
                get => new TableNumber(EmptyString);
            }

            public string Format()
                => format(this);

            public override string ToString()
                => Format();
        }
    }
}
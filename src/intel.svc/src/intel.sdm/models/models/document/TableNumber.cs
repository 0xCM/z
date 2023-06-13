//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
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


            public string String
            {
                [MethodImpl(Inline)]
                get => Storage.Format();
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
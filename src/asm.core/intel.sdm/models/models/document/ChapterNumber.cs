//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        public struct ChapterNumber
        {
            public byte Value;

            [MethodImpl(Inline)]
            public ChapterNumber(byte number)
            {
                Value = number;
            }

            public string Format()
                => Value.ToString();

            public override string ToString()
                => Format();

            public static implicit operator ChapterNumber(byte src)
                => new ChapterNumber(src);

            public static implicit operator ChapterNumber(int src)
                => new ChapterNumber((byte)src);

            public static ChapterNumber Empty => default;
        }
    }
}
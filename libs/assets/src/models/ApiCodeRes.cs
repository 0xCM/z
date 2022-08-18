//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    public readonly struct ApiCodeRes
    {
        public readonly Index<BinaryResSpec> Data;

        [MethodImpl(Inline)]
        public ApiCodeRes(BinaryResSpec[] src)
        {
            Data = src;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public ref readonly BinaryResSpec this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public static ApiCodeRes Empty
            => new ApiCodeRes(array<BinaryResSpec>());
    }
}
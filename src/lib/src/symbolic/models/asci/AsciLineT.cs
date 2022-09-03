//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly ref struct AsciLineCover<T>
        where T : unmanaged
    {
        readonly ReadOnlySpan<T> Data;

        [MethodImpl(Inline)]
        public AsciLineCover(ReadOnlySpan<T> src)
        {
            Data = src;
        }

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public int RenderLength
        {
            [MethodImpl(Inline)]
            get => Data.Length + LineNumber.RenderLength;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.Length != 0;
        }

        public string Format()
            => Asci.format(this);

        public override string ToString()
            => Format();

        public static AsciLineCover<T> Empty
        {
            [MethodImpl(Inline)]
            get => new AsciLineCover<T>(sys.empty<T>());
        }
    }
}
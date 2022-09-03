//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NameList : IIndex<NameOld>
    {
        readonly Index<NameOld> Data;

        public NameOld ListName {get;}

        [MethodImpl(Inline)]
        public NameList(NameOld name, NameOld[] src)
        {
            ListName = name;
            Data = src;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public Span<NameOld> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<NameOld> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public NameOld[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public static implicit operator NameList((NameOld name, NameOld[] names) src)
            => new NameList(src.name, src.names);

        [MethodImpl(Inline)]
        public static implicit operator NameList((string name, string[] names) src)
            => (src.name, src.names.Select(x => (NameOld)x));
    }
}
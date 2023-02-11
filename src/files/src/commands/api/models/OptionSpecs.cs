//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct OptionSpecs : IIndex<OptionSpecs,ushort,OptionSpec>
    {
        readonly Index<OptionSpec> Data;

        [MethodImpl(Inline)]
        public OptionSpecs(OptionSpec[] src)
            => Data = src;

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref OptionSpec this[ushort index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public OptionSpec[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public string Format()
            => Seq.format(Storage,Eol);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator OptionSpecs(OptionSpec[] src)
            => new OptionSpecs(src);

        [MethodImpl(Inline)]
        public static implicit operator OptionSpec[](OptionSpecs src)
            => src.Storage;
    }
}
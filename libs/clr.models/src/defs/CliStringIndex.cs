//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    public readonly struct CliStringIndex : ICliHeapKey<CliStringIndex>
    {
        public CliHeapKind HeapKind => CliHeapKind.String;

        public uint Value {get;}

        [MethodImpl(Inline)]
        public CliStringIndex(uint value)
        {
            Value = value;
        }

        [MethodImpl(Inline)]
        public CliStringIndex(StringHandle value)
            => Value = u32(value);

        public string Format()
            => Value.ToString("X");

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CliHeapKey(CliStringIndex src)
            => new CliHeapKey(src.HeapKind, src.Value);

        [MethodImpl(Inline)]
        public static implicit operator CliStringIndex(StringHandle src)
            => new CliStringIndex(src);

        [MethodImpl(Inline)]
        public static implicit operator StringHandle(CliStringIndex src)
            => @as<CliStringIndex,StringHandle>(src);
    }
}
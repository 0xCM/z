//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CliTable<T>
        where T : struct, IRecord<T>
    {
        public CliTableKind Kind {get;}

        public Index<T> Rows {get;}

        [MethodImpl(Inline)]
        public CliTable(CliTableKind value)
        {
            Kind = (CliTableKind)value;
            Rows = Index<T>.Empty;
        }

        public string Name
        {
            [MethodImpl(Inline)]
            get => Kind.ToString();
        }

        public byte Id
        {
            [MethodImpl(Inline)]
            get => (byte)Kind;
        }

        public string Format()
            => string.Format("{0:X2}", (byte)Kind);

        public override string ToString()
            => Format();
    }
}
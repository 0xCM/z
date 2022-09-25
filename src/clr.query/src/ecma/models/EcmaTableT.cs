//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EcmaTable<T>
        where T : struct
    {
        public EcmaTableKind Kind {get;}

        public Index<T> Rows {get;}

        [MethodImpl(Inline)]
        public EcmaTable(EcmaTableKind value)
        {
            Kind = (EcmaTableKind)value;
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
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct PrimalClass
    {
        public readonly PrimalKind Kind;

        public PrimalClass(PrimalKind kind)
        {
            Kind = kind;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Kind;
        }

        public string Format()
            => Kind.ToString().ToLower();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator PrimalClass(PrimalKind src)
            => new PrimalClass(src);

        [MethodImpl(Inline)]
        public static implicit operator PrimalKind(PrimalClass src)
            => src.Kind;
    }
}
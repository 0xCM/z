//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct GenericState : ITextual
    {
        public readonly GenericStateKind State;

        [MethodImpl(Inline)]
        public GenericState(byte state)
            => State = (GenericStateKind)state;

        [MethodImpl(Inline)]
        public GenericState(GenericStateKind state)
            => State = state;

        public string Format()
            => State.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool IsGeneric()
            => State == GenericStateKind.OpenGeneric;

        public override int GetHashCode()
            => State.GetHashCode();

        public override bool Equals(object src)
            => src is GenericState p && p.State == State;

        [MethodImpl(Inline)]
        public static bool operator ==(GenericState g1, GenericState g2)
            => g1.State == g2.State;

        [MethodImpl(Inline)]
        public static bool operator !=(GenericState g1, GenericState g2)
            => g1.State != g2.State;

        [MethodImpl(Inline)]
        public static implicit operator bool(GenericState src)
            => src.State != 0;

        [MethodImpl(Inline)]
        public static implicit operator GenericState(byte src)
            => new GenericState(src);

        [MethodImpl(Inline)]
        public static implicit operator byte(GenericState src)
            => (byte)src.State;

        [MethodImpl(Inline)]
        public static implicit operator GenericState(bool src)
            => new GenericState(src ? (byte)1 : (byte)0);

        [MethodImpl(Inline)]
        public static implicit operator GenericState(GenericStateKind src)
            => new GenericState(src);
    }
}
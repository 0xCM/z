//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// A terminal atomic
    /// </summary>
    public readonly struct Atom<K> : IAtom<K>
    {
        public readonly K Value {get;}

        [MethodImpl(Inline)]
        public Atom(K value)
        {
            Value = value;
        }

        public bool IsEmpty
        {
            get => sys.empty(Value.ToString());
        }

        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Value.GetHashCode();

        public static Atom<K> Empty => default;

        [MethodImpl(Inline)]
        public static implicit operator K(Atom<K> src)
            => src.Value;
   }
}
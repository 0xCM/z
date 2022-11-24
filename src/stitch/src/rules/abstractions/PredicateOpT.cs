//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class PredicateOp<T> : IPredicate<T>
    {
        public static PredicateOp<T> Empty => default;

        public string Name {get;}

        [MethodImpl(Inline)]
        public PredicateOp(string name)
        {
            Name = name ?? EmptyString;
        }

        public bool IsEmpty => sys.empty(Name);


        [MethodImpl(Inline)]
        public abstract bool Invoke(T src);

        public string Format()
            => string.Format("{0}:{1} -> {2}", Name, typeof(T).Name, "bool");

        public override string ToString()
            => Format();
    }
}
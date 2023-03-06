//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    public abstract record class Expr<T> : IExpr<T>, IEquatable<T>
        where T : Expr<T>, new()
    {
        public abstract bool IsEmpty {get;}

        public bool Equals(T src)
        {
            return false;
        }

        public abstract string Format();

        public abstract Hash32 Hash {get;}

        public override int GetHashCode()
            => Hash;
        
        protected abstract bool Eq(T src);

        public virtual bool IsNonEmpty
        {
            get => !IsEmpty;
        }

        public override string ToString()
            => Format();
    }
}
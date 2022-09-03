//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class SourceCode<F,C> : IDataType<F>, ISourceCode<C>
        where F : SourceCode<F,C>, new()
        where C : IEquatable<C>, IComparable<C>, new()
    {
        readonly C _Content;

        public ref readonly C Content
        {
            get => ref _Content;
        }

        protected SourceCode(C content)
        {
            _Content = content;
        }

        public abstract bool IsEmpty {get;}
        
        public abstract Hash32 Hash {get;}

        public int CompareTo(F src)
            => _Content.CompareTo(src._Content);

        public bool Equals(F src)
            => _Content.Equals(src._Content);

        public abstract string Format();

        public sealed override string ToString()
            => Format();        

        public static F Empty => new();
    }
}
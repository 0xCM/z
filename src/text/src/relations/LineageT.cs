//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class Lineage<F,T> : IEquatable<F>
        where F : Lineage<F,T>, new()
        where T : IEquatable<T>
    {
        public readonly Index<T> Ancestors;

        public virtual T Subject {get;}

        public virtual bool IsEmpty {get;}

        protected Lineage(T name, T[] ancestors)
        {
            Subject = name;
            Ancestors = ancestors;
            IsEmpty = false;
        }

        protected Lineage(T subject)
        {
            Subject = subject;
            Ancestors = Index<T>.Empty;
            IsEmpty = false;
        }

        protected Lineage()
        {
            Ancestors = sys.empty<T>();
            IsEmpty = true;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public bool HasAncestor
        {
            [MethodImpl(Inline)]
            get => Ancestors.IsNonEmpty;
        }

        const string Sep = " -> ";

        public virtual string Format()
            => Format(Sep);

        string Format(string sep)
        {
            var dst = text.buffer();
            if(IsNonEmpty && Subject!=null)
            {
                dst.Append(Subject);
                var count = Ancestors.Count;
                for(var i=0; i<count; i++)
                {
                    dst.Append(sep);
                    dst.Append(Ancestors[i]);
                }
            }
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        public bool Equals(F src)
        {
            if(src is null)
                return false;

            if(object.ReferenceEquals(this,src))
                return true;

            if(!Subject.Equals(src.Subject))
                return false;

            var count = Ancestors.Length;
            if(count != src.Ancestors.Length)
                return false;

            for(var i=0; i<count; i++)
            {
                if(!Ancestors[i].Equals(src.Ancestors[i]))
                    return false;
            }
            return true;
        }

        public static F Empty => new();
    }
}
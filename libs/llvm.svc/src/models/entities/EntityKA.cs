//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Entity<K,A>
    {
        protected Dictionary<K,A> Lookup;

        protected ConcurrentDictionary<string,object> Values = new();

        protected Index<A> AttribIndex;

        public ReadOnlySpan<A> Attributes
        {
            [MethodImpl(Inline)]
            get => AttribIndex;
        }

        protected T Value<T>(string name, Func<T> f)
            => (T)Values.GetOrAdd(name,f());

        protected T Value<T>(K key, Func<A,T> f, T @default)
        {
            if(Lookup.TryGetValue(key, out var a))
            {
                var t = f(a);
                return (T)Values.GetOrAdd(key.ToString(), k => t);
            }
            else
                return @default;
        }

        public virtual A this[K field]
        {
            get
            {
                if(Lookup.TryGetValue(field, out var value))
                    return value;
                else
                    return EmptyAttribute;
            }
        }

        protected A Attrib(K field)
            => this[field];

        protected Entity(A[] src)
        {
            AttribIndex = src;
            Lookup = new();
            var count = src.Length;
            var keyf = KeyFunction;
            foreach(var field in src)
            {
                if(field == null)
                    continue;

                if(!Lookup.TryAdd(keyf(field), field))
                {

                }
            }
        }

        protected virtual A EmptyAttribute => default;

        protected abstract Func<A,K> KeyFunction {get;}
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class EnvVars<T> : ReadOnlySeq<EnvVars<T>,EnvVar<T>>
        where T : IEquatable<T>
    {
        readonly ConstLookup<Name,T> Lookup;

        public EnvVars()
        {


        }

        public EnvVars(EnvVar<T>[] src)
            : base(src)
        {
            Lookup = src.Select(x => (x.Name, x.Value)).ToDictionary();
        }

        public bool Find(Name name, out T value)
            => Lookup.Find(name, out value);

        public ReadOnlySpan<Name> Names
        {
            [MethodImpl(Inline)]
            get => Lookup.Keys;
        }

        public static implicit operator EnvVars<T>(EnvVar<T>[] src)
            => new EnvVars<T>(src);
    }
}
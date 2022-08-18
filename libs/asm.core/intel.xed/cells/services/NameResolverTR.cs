//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public abstract class NameResolver<T,R>
        where T : NameResolver<T,R>, new()
        where R : INameResolver<R>, new()
    {
        static ConcurrentDictionary<string, int> _Resolvers = new();

        static ConcurrentDictionary<int, string> _ResolverLookup = new();

        static int _ResolverSeq = 0;

        [MethodImpl(Inline)]
        static int ResolverSeq()
            => inc(ref _ResolverSeq);

        public static readonly T Instance = new T();

        public R Create(string src)
        {
            var id =  _Resolvers.GetOrAdd(src, _ => ResolverSeq());
            _ResolverLookup.TryAdd(id,src);
            var dst = new R();
            return dst.WithId(id);
        }

        public string Resolve(R src)
            => src.IsNonEmpty ? _ResolverLookup[src.NameId] : EmptyString;
    }
}
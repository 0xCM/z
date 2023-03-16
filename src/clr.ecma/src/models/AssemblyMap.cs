//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class AssemblyMap : IDisposable
    {
        readonly AssemblyIndex Index;

        readonly ConcurrentDictionary<AssemblyKey, MappedAssembly> Lookup;

        readonly ReadOnlySeq<AssemblyKey> _Keys;

        internal AssemblyMap(AssemblyIndex index)
        {
            Index = index;
            Lookup = new();
            iter(index.Distinct(), entry => Lookup.TryAdd(entry.Key, MappedAssembly.map(entry.Path)), true);
            _Keys = Lookup.Keys.Array().Sort();
        }           

        public ref readonly ReadOnlySeq<AssemblyKey> Keys
        {
            [MethodImpl(Inline)]
            get => ref _Keys;
        }

        [MethodImpl(Inline)]
        public MappedAssembly Assembly(AssemblyKey key)
            => Lookup[key];

        public void Dispose()
        {
            iter(Lookup.Values, value => value.Dispose());
        }

        public MappedAssembly this[AssemblyKey key]
        {
            [MethodImpl(Inline)]
            get => Assembly(key);
        }

        public ICollection<MappedAssembly> Assemblies 
            => Lookup.Values;        
    }
}
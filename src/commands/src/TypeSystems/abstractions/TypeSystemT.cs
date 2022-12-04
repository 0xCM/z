//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace TypeSystems
{
    public abstract class TypeSystem<T> : ITypeSystem<T>
        where T : TypeSystem<T>, new()
    {
        public virtual @string Name => typeof(T).Name;

        static T _Instance = new();

        public static ref readonly T Instance => ref _Instance;

        ref readonly T ITypeSystem<T>.Instance
            => ref Instance;    
    }
}
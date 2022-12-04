//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace TypeSystems
{
    public abstract class TypeDef<R,T> : TypeDef<T>, IType<R,T>
        where R : TypeDef<R,T>, new()
    {
        static readonly R _Instance;

        ref readonly R IType<R,T>.Representative
            => ref _Instance;

        public static ref readonly R Representative => ref _Instance;        
    }
}
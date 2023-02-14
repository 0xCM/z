//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TypeAlias<T> : ITypeAlias<T>
        where T : IType
    {
        public T Type {get;}

        public Identifier Alias {get;}

        [MethodImpl(Inline)]
        public TypeAlias(T type, Identifier alias)
        {
            Type = type;
            Alias = alias;
        }

        [MethodImpl(Inline)]
        public static implicit operator TypeAlias(TypeAlias<T> src)
            => new TypeAlias(src.Type, src.Alias);
    }
}
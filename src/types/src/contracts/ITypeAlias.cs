//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITypeAlias
    {
        IType Type {get;}

        Identifier Alias {get;}
    }

    public interface ITypeAlias<T> : ITypeAlias
        where T : IType
    {
        new T Type {get;}

        IType ITypeAlias.Type
            => Type;
    }
}
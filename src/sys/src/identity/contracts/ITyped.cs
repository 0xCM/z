//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ITyped
    {
        IType Type {get;}
    }

    [Free]
    public interface ITyped<T> : ITyped
        where T : IType, new()
    {
        new T Type => new();

        IType ITyped.Type 
            => Type;
    }
}
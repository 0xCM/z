//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IBinding
    {
        dynamic Value {get;}
    }

    [Free]
    public interface IBinding<T> : IBinding
    {
        new T Value {get;}

        dynamic IBinding.Value
            => Value;
    }
}
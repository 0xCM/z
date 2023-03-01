//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    public interface IConst
    {
        @string Name {get;}

        uint Ordinal {get;}

        @string Description {get;}

        dynamic Value {get;}
    }

    public interface IConst<T> : IConst
    {
        new T Value {get;}

        dynamic IConst.Value
            => Value;
    }
}

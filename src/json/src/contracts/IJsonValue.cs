//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IJsonValue : IExpr
    {
        dynamic Content {get;}

        IJsonType Type {get;}
    }

    public interface IJsonValue<V> : IJsonValue
        where V : new()
    {
        new V Content {get;}        

        dynamic IJsonValue.Content
            => Content;
    }    
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IParseResult : IMonadic
    {
        Type SourceType {get;}

        Type TargetType {get;}

        bool Succeeded {get;}

        object Value {get;}
    }

    public interface IParseResult<S,T> : IParseResult
    {
        Type IParseResult.SourceType
            => typeof(S);

        Type IParseResult.TargetType
            => typeof(T);

        new T Value {get;}

        object IParseResult.Value
            => Value;
    }
}
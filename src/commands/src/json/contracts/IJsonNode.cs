//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text.Json;
    using System.Text.Json.Nodes;

    public interface IJsonNode : IExpr
    {
        JsonNode Data {get;}

        string IExpr.Format()
            => Data.ToString();

        string ToJsonString(JsonSerializerOptions? options = null)
            => Data.ToJsonString(options);
    }

    public interface IJsonNode<V> : IJsonNode
        where V : new()
    {

    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text.Json;

    public interface ICmdSerializer : ISerializer<ICmd,JsonDocument>
    {

    }

    public interface ICmdSerializer<C> : ISerializer<C,JsonDocument>
    {

    }
}
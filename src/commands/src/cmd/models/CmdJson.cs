//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public abstract record class CmdJson
    {
        public JsonText Data {get;}

        

    }
    public record class CmdJson<T> 
    {

    }

}
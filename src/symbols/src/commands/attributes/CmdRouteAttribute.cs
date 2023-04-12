//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdRouteAttribute : Attribute
    {
        public CmdRouteAttribute(string name)
        {
            Route = name;
        }

        public readonly ApiCmdRoute Route;
    }
}
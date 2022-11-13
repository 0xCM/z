//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdFxAttribute : OpAttribute
    {
        public CmdFxAttribute()
        {
            Name = EmptyString;
        }

        public CmdFxAttribute(string name)
        {
            //Uri = new CmdUri(CmdKind.App, )
            Name = name;
        }

        public readonly string Name;
    }
}
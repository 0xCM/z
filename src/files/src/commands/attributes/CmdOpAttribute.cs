//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdOpAttribute : Attribute
    {
        public string Name {get;}

        public CmdOpAttribute(string name)
        {
            Name = name;
        }
    }
}
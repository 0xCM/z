//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [AttributeUsage(AttributeTargets.Field)]
    public class CmdSpecAttribute : Attribute
    {
        public CmdSpecAttribute(string name, string description = "")
        {
            Name = name;
            Description = description;
        }

        public string Name {get;}

        public string Description {get;}
    }
}
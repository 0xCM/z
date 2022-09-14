//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Identifies a concrete command specification
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class CmdAttribute : Attribute
    {
        public CmdAttribute(string name, string desc = EmptyString)
        {
            Name = name;
            Description = desc;
        }

        public string Name {get;}

        public string Description {get;}
    }
}
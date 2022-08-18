//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class RngAttribute : Attribute
    {
        public RngAttribute(string name)
        {
            Name = name;
        }

        public string Name {get;}
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class TypeSystemAttribute : Attribute
    {
        public TypeSystemAttribute(string name)
        {
            Name = name;
        }        

        public readonly @string Name;
    }
}

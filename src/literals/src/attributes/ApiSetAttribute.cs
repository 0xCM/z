//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class)]
    public class ApiSetAttribute : Attribute
    {
        public readonly string Name;

        public ApiSetAttribute()
        {
            Name = EmptyString;
        }

        public ApiSetAttribute(string name)
        {
            Name = name;
        }
    }
}
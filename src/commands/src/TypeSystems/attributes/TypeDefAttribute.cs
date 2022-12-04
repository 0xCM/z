//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace TypeSystems
{
    public class TypeDefAttribute : Attribute
    {
        public readonly @string Scope;

        public readonly @string TypeName;

        public TypeDefAttribute(string scope)
        {
            Scope = scope;
            TypeName = EmptyString;
        }

        public TypeDefAttribute(string scope, string name)
        {
            Scope = scope;
            TypeName = name;            
        }
    }
}
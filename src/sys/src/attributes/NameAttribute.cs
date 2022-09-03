//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Specifies a name, and optionally an alias, for an element
    /// </summary>
    public class NameAttribute : Attribute
    {
        public NameAttribute(string name)
        {
            Name = name;
            Alias = EmptyString;
        }

        public NameAttribute(string name, string alias)
        {
            Name = name;
            Alias = alias;
        }

        public string Name {get;}

        public string Alias {get;}

        public bool HasAlias => !string.IsNullOrWhiteSpace(Alias);
    }
}
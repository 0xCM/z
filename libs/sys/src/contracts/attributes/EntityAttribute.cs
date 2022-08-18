//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class EntityAttribute : Attribute
    {
        public EntityAttribute()
        {
            EntityKind = EmptyString;
        }
        public EntityAttribute(string kind)
        {
            EntityKind = kind;
        }

        public string EntityKind {get;}
    }
}
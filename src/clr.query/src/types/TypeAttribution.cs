//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    public readonly struct TypeAttribution<T>
        where T : Attribute
    {
        public Type Type {get;}

        public T Tag {get;}

        public TypeAttribution(Type type, T tag)
        {
            Type = type;
            Tag = tag;
        }
    }
}

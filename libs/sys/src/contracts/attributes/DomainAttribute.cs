//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class DomainAttribute : Attribute
    {
        public DomainAttribute(Type src)
        {
            PointType = src;
        }

        public DomainAttribute()
        {
            PointType = typeof(void);
        }

        public Type PointType {get;}
    }
}
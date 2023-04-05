//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang.Dot
{
    public class AttributeList : ReadOnlySeq<AttributeList,Attribute>
    {

        public AttributeList()
        {

        }

        public AttributeList(params Attribute[] src)
            : base(src)
        {
            
        }
    }

}

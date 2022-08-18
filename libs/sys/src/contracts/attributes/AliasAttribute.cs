//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AliasAttribute : Attribute
    {
        public string[] AliasList {get;}

        public AliasAttribute(params string[] list)
        {
            AliasList = list;
        }
    }
}
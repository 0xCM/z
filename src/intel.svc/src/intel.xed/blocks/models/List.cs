//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedZ
{
    public class List : Sequence
    {
        public List(string name, string[] terms)
            : base(name, terms)
        {
        }        
        
        protected override Fence<char> Boundary => ('[', ']');
    }
}

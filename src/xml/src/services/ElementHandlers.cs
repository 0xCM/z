//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public class ElementHandlers : Dictionary<string,Action<IXmlElement>>
    {
        public void AddHandler(string node, Action<IXmlElement> handler)
            => Add(node, handler);
    }
}
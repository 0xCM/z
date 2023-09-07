//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XmlParts;

public interface IXmlElement : IXmlPart<string>
{
    XmlAttributes Attributes {get;}
}

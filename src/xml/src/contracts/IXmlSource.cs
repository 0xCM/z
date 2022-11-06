//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IXmlSource : IDisposable
    {
        bool Read(out IXmlPart dst);
    }
}
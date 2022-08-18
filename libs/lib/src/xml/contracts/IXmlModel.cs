//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IXmlModel
    {

    }

    public interface IXmlModel<T> : IXmlModel
        where T : struct, IXmlModel<T>
    {

    }
}
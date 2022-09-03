//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IExprComposer
    {
        IExprDeprecated Compose(params IExprDeprecated[] src);
    }
}
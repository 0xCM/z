//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IApiOps
    {
        bool Find(string spec, out IApiCmdMethod runner);

        ref readonly ReadOnlySeq<ApiOp> Defs {get;}

        ICollection<IApiCmdMethod> Invokers {get;}
    }
}
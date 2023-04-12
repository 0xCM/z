//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IApiCmdMethods
    {
        bool Find(string spec, out ApiCmdMethod op);

        ref readonly ReadOnlySeq<ApiCmdMethod> Defs {get;}
    }
}
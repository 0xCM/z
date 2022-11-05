//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IWfCmdSpecs
    {
        bool Find(string spec, out IWfCmdRunner runner);

        ref readonly ReadOnlySeq<WfOp> Defs {get;}

        ICollection<IWfCmdRunner> Invokers {get;}
    }
}
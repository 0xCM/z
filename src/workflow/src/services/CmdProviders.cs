//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class CmdProviders : CmdProviders<CmdProviders>
    {
        readonly Func<IWfRuntime,ReadOnlySeq<ICmdProvider>> Factory;

        public CmdProviders()
        {
            Factory = wf => ReadOnlySeq<ICmdProvider>.Empty;
        }

        CmdProviders(ICmdProvider[] src)
            : base(src)
        {
            Factory = _ => src;
        }

        public CmdProviders(Func<IWfRuntime,ReadOnlySeq<ICmdProvider>> f)
        {
            Factory = f;
        }

        public override CmdProviders Init(IWfRuntime wf)
            => new(Factory(wf).Unwrap());
    }
}
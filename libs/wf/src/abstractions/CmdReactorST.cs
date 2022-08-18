//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [CmdReactor]
    public abstract class CmdReactor<R,C,T> : WfSvc<R>, ICmdReactor<C,T>
        where C : struct, ICmd
        where R : CmdReactor<R,C,T>, new()
    {
        public static C Spec() => new C();

        public CmdId CmdId => Spec().CmdId;

        protected abstract T Run(C cmd);

        public CmdResult<C,T> Invoke(C cmd)
        {
            try
            {
                return new CmdResult<C,T>(cmd, true, Run(cmd));
            }
            catch(Exception e)
            {
                Wf.Error(e);
                return new CmdResult<C,T>(cmd, e);
            }
        }

        CmdResult ICmdReactor.Invoke(ICmd src)
            => Invoke((C)src);
    }
}
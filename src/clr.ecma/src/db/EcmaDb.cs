//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class EcmaDb : IDisposable
    {
        readonly IWfRuntime Wf;

        readonly IWfChannel Channel;

        readonly IDbArchive Root;

        readonly FileIndex Index;

        internal EcmaDb(IWfRuntime wf, IDbArchive root)
        {
            Wf = wf;
            Channel = wf.Channel;
            Root = root;
            Index = new();            
        }

        void LoadIndex()
        {

        }

        void EmitIndex()
        {
            
        }


        public void Dispose()
        {

        }
    }
}
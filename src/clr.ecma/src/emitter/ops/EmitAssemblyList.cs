//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaEmitter
    {
        public void EmitAssemblyList(IDbArchive src, FilePath dst)    
            => Channel.TableEmit(EcmaReader.assemblies(Channel, src).Records(), dst);
    }
}
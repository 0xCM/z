//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaEmitter
    {
        public void EmitAssemblyList(IDbArchive src, FilePath dst)    
            => Channel.TableEmit(Ecma.list(Ecma.assemblies(Channel, src).View), dst);
        
        public void EmitAssemblyList(ReadOnlySpan<AssemblyFile> src, FilePath dst)
            => Channel.TableEmit(Ecma.list(src), dst);
    }
}
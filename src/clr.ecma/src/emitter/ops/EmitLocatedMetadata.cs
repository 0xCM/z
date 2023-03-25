//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaEmitter
    {
        public void EmitLocatedMetadata(ReadOnlySeq<Assembly> src, IDbArchive dst, uint bpl = 64)
        {
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var a = ref src[i];
                EmitLocatedMetadata(a, bpl, dst.Path(a.GetSimpleName(), FileKind.LocatedHex));
            }
        }

        public void EmitLocatedMetadata(Assembly src, uint bpl, FilePath dst)
        {
            try
            {
                var flow = Channel.EmittingFile(dst);
                ByteSize size = HexEmitter.emit(ClrAssembly.metadata(src), bpl, dst);
                Channel.EmittedBytes(flow, size);
            }
            catch(Exception e)
            {
                Channel.Error(e);
            }
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaEmitter
    {
        public void EmitMetadumps(ReadOnlySeq<Assembly> src, IWfChannel channel, IDbArchive dst)
        {
            iter(src, x => EmitMetadump(x, channel, dst.Path(x.GetSimpleName(),FileKind.Txt)), PllExec);
        }

        public Task<ExecToken> EmitMetadump(Assembly src, IWfChannel channel, FilePath dst)
        {
            ExecToken Exec()
            {
                var token = ExecToken.Empty;
                try
                {
                    var flow = channel.EmittingFile(dst);
                    using var target = dst.Writer();
                    var reader = EcmaReader.create(src);
                    MsilCodeModels.mdv(reader.MetadataReader, target).Visualize();
                    token = channel.EmittedFile(flow);
                }
                catch(Exception e)
                {
                    channel.Error(e);
                }
                return token;
            }
            return sys.start(Exec);
        }
    }
}
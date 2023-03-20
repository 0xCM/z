//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaEmitter
    {
        public void EmitMsilMetadata(ReadOnlySeq<Assembly> src, IDbArchive dst)
            => iter(src, a => EmitMsilMetadata(a,dst), true);

        public void EmitMsilMetadata(Assembly src, IDbArchive dst)
        {
            void Exec()
            {
                var methods = ReadOnlySpan<MsilRow>.Empty;
                var srcPath = FS.path(src.Location);
                if(Ecma.valid(srcPath))
                {
                    using var reader = PeReader.create(srcPath);
                    methods = reader.ReadMsil();
                    if(methods.Length != 0)
                        Channel.TableEmit(methods, dst.Table<MsilRow>(src.GetSimpleName()));
                }
            }
            Try(Exec);
        }
    }
}
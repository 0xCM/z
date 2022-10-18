//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaEmitter
    {
        public uint EmitIlDat(IApiPack dst)
            => EmitMsilMetadata(ApiMd.Parts, dst);

        public uint EmitMsilMetadata(ReadOnlySeq<Assembly> src, IApiPack dst)
        {
            var total = 0u;
            var count = src.Length;
            for(var i=0; i<count; i++)
                EmitMsilMetadata(src[i], dst);
            return total;
        }

        public void EmitMsilMetadata(Assembly src, IApiPack dst)
        {
            void Exec()
            {
                var path = dst.Metadata(EcmaSections.MsilData).Table<MsilRow>(src.GetSimpleName());
                var methods = ReadOnlySpan<MsilRow>.Empty;
                var srcPath = FS.path(src.Location);
                if(EcmaFiles.valid(srcPath))
                {
                    using var reader = PeReader.create(srcPath);
                    methods = reader.ReadMsil();
                    var view = methods;
                    var count = (uint)methods.Length;
                    if(count != 0)
                        TableEmit(methods, path);
                }
            }
            Try(Exec);
        }

        public void EmitMsilMetadata(ReadOnlySeq<Assembly> src, IDbArchive dst)
            => iter(src, a => EmitMsilMetadata(a,dst), true);

        public void EmitMsilMetadata(Assembly src, IDbArchive dst)
        {
            void Exec()
            {
                var methods = ReadOnlySpan<MsilRow>.Empty;
                var srcPath = FS.path(src.Location);
                if(EcmaFiles.valid(srcPath))
                {
                    using var reader = PeReader.create(srcPath);
                    methods = reader.ReadMsil();
                    if(methods.Length != 0)
                        TableEmit(methods, dst.Table<MsilRow>(src.GetSimpleName()));
                }
            }
            Try(Exec);
        }
    }
}
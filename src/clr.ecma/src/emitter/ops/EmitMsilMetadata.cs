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
            => iter(src, a => EmitMsilMetadata(a.GetAssemblyFile(),dst), true);

        public void EmitMsilMetadata(AssemblyFile src, IDbArchive dst)
        {
            using var reader = PeReader.create(src.Path);
            var methods = reader.ReadMsil();
            if(methods.Length != 0)
                Channel.TableEmit(methods, dst.Table<MsilRow>(src.AssemblyName.Format()));
        }
    }
}
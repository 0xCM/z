//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaSections;

    partial class EcmaEmitter
    {
        public void EmitMemberRefs(IApiPack dst)
            => iter(ApiMd.Parts, c => EmitMemberRefs(c,dst), PllExec);

        public void EmitMemberRefs(IDbArchive dst)
            => iter(ApiMd.Parts, c => EmitMemberRefs(c,dst), PllExec);

        public void EmitMemberRefs(ReadOnlySeq<Assembly> src, IDbArchive dst)
            => iter(src, a => EmitMemberRefs(a,dst), PllExec);

        public void EmitMemberRefs(Assembly src, IApiPack dst)
        {
            using var reader = PeReader.create(FS.path(src.Location));
            TableEmit(reader.ReadMemberRefs(), dst.Metadata(MemberRefs).Table<EcmaMemberRef>(src.GetSimpleName()));
        }

        public void EmitMemberRefs(Assembly src, IDbArchive dst)
        {
            using var reader = PeReader.create(FS.path(src.Location));
            TableEmit(reader.ReadMemberRefs(), dst.Table<EcmaMemberRef>(src.GetSimpleName()));
        }
    }
}
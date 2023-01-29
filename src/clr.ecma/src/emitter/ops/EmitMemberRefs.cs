//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaTables;

    partial class EcmaEmitter
    {
        public void EmitMemberRefs(ReadOnlySeq<Assembly> src, IDbArchive dst)
            => iter(src, a => EmitMemberRefs(a,dst), PllExec);

        public void EmitMemberRefs(Assembly src, IDbArchive dst)
        {
            using var reader = PeReader.create(FS.path(src.Location));
            Channel.TableEmit(reader.ReadMemberRefs(), dst.Table<MemberRef>(src.GetSimpleName()));
        }
    }
}
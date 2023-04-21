//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Ecma;

    partial class EcmaEmitter
    {
        public void EmitMemberRefs(ReadOnlySeq<Assembly> src, IDbArchive dst)
            => iter(src, a => EmitMemberRefs(a,dst), PllExec);

        public void EmitMemberRefs(Assembly src, IDbArchive dst)
        {
            var reader = EcmaReader.create(src);
            Channel.TableEmit(reader.ReadMemberRefs(), dst.Table<MemberRefRow>(src.GetSimpleName()));
        }
    }
}
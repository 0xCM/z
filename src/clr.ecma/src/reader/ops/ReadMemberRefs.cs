//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaTables;

    partial class EcmaReader
    {
        [MethodImpl(Inline), Op]
        public MemberReference ReadMemberRef(MemberReferenceHandle src)
            => MD.GetMemberReference(src);

        public ref MemberRefRow ReadMemberRef(MemberReferenceHandle handle, ref MemberRefRow dst)
        {
            var src = MD.GetMemberReference(handle);
            dst.Token = EcmaTokens.token(handle);
            dst.Name = src.Name;
            dst.Parent = EcmaTokens.token(src.Parent);
            dst.RefKind = (MemberRefKind)src.GetKind();
            dst.Sig = src.Signature;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public void ReadMemberRefs(ReadOnlySpan<MemberReferenceHandle> src, Span<MemberRefRow> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                ReadMemberRef(skip(src,i), ref seek(dst,i));
        }

        public ReadOnlySeq<MemberRefRow> ReadMemberRefs()
        {
            var handles = MemberRefHandles();
            var dst = sys.alloc<MemberRefRow>(handles.Length);
            ReadMemberRefs(handles,dst);
            return dst;
        }
    }
}
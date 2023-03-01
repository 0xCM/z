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
        public ref MemberRef ReadMemberRef(MemberReferenceHandle handle, ref MemberRef dst)
        {
            var src = MD.GetMemberReference(handle);
            dst.Token = EcmaTokens.token(handle);
            dst.Name = MD.GetString(src.Name);
            dst.Parent = EcmaTokens.token(src.Parent);
            dst.RefKind = (MemberRefKind)src.GetKind();
            dst.Sig = MD.GetBlobBytes(src.Signature);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public void ReadMemberRefs(ReadOnlySpan<MemberReferenceHandle> src, Span<MemberRef> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                ReadMemberRef(skip(src,i), ref seek(dst,i));
        }

        public ReadOnlySeq<MemberRef> ReadMemberRefs()
        {
            var handles = MemberRefHandles();
            var dst = sys.alloc<MemberRef>(handles.Length);
            ReadMemberRefs(handles,dst);
            return dst;
        }
    }
}
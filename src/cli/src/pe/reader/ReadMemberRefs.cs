//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;

    partial class PeReader
    {
        public ref MemberRefInfo ReadMemberRef(MemberReferenceHandle handle, ref MemberRefInfo dst)
        {
            var src = MD.GetMemberReference(handle);
            dst.Token = Clr.token(handle);
            dst.Name = MD.GetString(src.Name);
            dst.Parent = Clr.token(src.Parent);
            dst.RefKind = (MemberRefKind)src.GetKind();
            dst.Sig = MD.GetBlobBytes(src.Signature);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public void ReadMemberRefs(ReadOnlySpan<MemberReferenceHandle> src, Span<MemberRefInfo> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                ReadMemberRef(skip(src,i), ref seek(dst,i));
        }

        public ReadOnlySeq<MemberRefInfo> ReadMemberRefs()
        {
            var handles = MemberRefHandles;
            var dst = sys.alloc<MemberRefInfo>(handles.Length);
            ReadMemberRefs(handles,dst);
            return dst;
        }
    }
}
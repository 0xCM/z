//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class PeReader
    {
        public ref EcmaMemberRef ReadMemberRef(MemberReferenceHandle handle, ref EcmaMemberRef dst)
        {
            var src = MD.GetMemberReference(handle);
            dst.Token = Ecma.token(handle);
            dst.Name = MD.GetString(src.Name);
            dst.Parent = Ecma.token(src.Parent);
            dst.RefKind = (MemberRefKind)src.GetKind();
            dst.Sig = MD.GetBlobBytes(src.Signature);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public void ReadMemberRefs(ReadOnlySpan<MemberReferenceHandle> src, Span<EcmaMemberRef> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                ReadMemberRef(skip(src,i), ref seek(dst,i));
        }

        public ReadOnlySeq<EcmaMemberRef> ReadMemberRefs()
        {
            var handles = MemberRefHandles;
            var dst = sys.alloc<EcmaMemberRef>(handles.Length);
            ReadMemberRefs(handles,dst);
            return dst;
        }
    }
}
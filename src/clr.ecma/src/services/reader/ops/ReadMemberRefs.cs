//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Ecma;
    using System.Linq;

    partial class EcmaReader
    {
        [MethodImpl(Inline), Op]
        public MemberReference ReadMemberRef(MemberReferenceHandle src)
            => MD.GetMemberReference(src);

        public MemberRefRow ReadMemberRefRow(MemberReferenceHandle handle)
        {
            var dst = new MemberRefRow();
            var src = MD.GetMemberReference(handle);
            dst.Index = EcmaTokens.token(handle);
            dst.Name = src.Name;
            dst.Class = EcmaTokens.token(src.Parent);
            dst.RefKind = src.GetKind();
            dst.Sig = src.Signature;
            return dst;
        }

        public IEnumerable<MemberRefRow> ReadMemberRefs()    
            => MD.MemberReferences.Select(ReadMemberRefRow);
    }
}
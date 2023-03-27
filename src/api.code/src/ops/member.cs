//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class ApiCode
    {
        [Op]
        public static ApiMember member(in ResolvedMethod src)
            => new ApiMember(src.Uri, src.Method, src.EntryPoint, ClrDynamic.msil(src.EntryPoint, src.Uri, src.Method));

        [Op]
        public static EncodedMember member(in ApiEncoded src)
        {
            var token = src.Token;
            var dst = new EncodedMember();
            dst.Id = token.Id;
            dst.EntryAddress = token.EntryAddress;
            dst.TargetAddress = token.TargetAddress;
            if(token.EntryAddress != token.TargetAddress)
            {
                dst.Disp = AsmRel.disp32((token.EntryAddress, JmpRel32.InstSize), token.TargetAddress);
                dst.StubAsm = string.Format("jmp near ptr {0:x}h", (int)AsmRel.target(dst.Disp));
            }
            dst.CodeSize = (ushort)src.Code.Size;
            dst.Sig = token.Sig.Format();
            dst.Uri = token.Uri.Format();
            var result = ApiIdentity.parse(dst.Uri, out var uri);
            if(result.Fail)
                Errors.Throw(AppMsg.ParseFailure.Format(nameof(uri), dst.Uri));
            dst.Host = uri.Host.Format();
            return dst;
        }
    }
}
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

    }
}
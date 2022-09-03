//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ApiEvalContext
    {
        public readonly BufferTokens Buffers;

        public readonly MemberCodeBlock ApiCode;

        [MethodImpl(Inline)]
        public ApiEvalContext(BufferTokens buffers, MemberCodeBlock code)
        {
            Buffers = buffers;
            ApiCode = code;
        }

        public ApiCodeBlock ApiBits
        {
            [MethodImpl(Inline)]
            get => ApiCode.Encoded;
        }

        public ApiMember Member
        {
            [MethodImpl(Inline)]
            get =>  ApiCode.Member;
        }
    }
}
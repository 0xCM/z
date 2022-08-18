//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct SdmModels
    {
        public readonly struct EncodingCrossRef
        {
            public CharBlock4 Identifier {get;}

            [MethodImpl(Inline)]
            public EncodingCrossRef(CharBlock4 identifier)
            {
                Identifier = identifier;
            }

            [MethodImpl(Inline)]
            public static implicit operator EncodingCrossRef(string src)
                => new EncodingCrossRef(src);
        }
    }
}
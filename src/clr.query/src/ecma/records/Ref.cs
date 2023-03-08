//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaModels
    {     
        public record class Ref
        {
            public EcmaToken Token;

            public Ref(EcmaToken token)
            {
                Token = token;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Token.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Token.IsNonEmpty;
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Token.Hash;
            }

            public string Format()
                => Token.Format();

            public override string ToString()
                => Format();
        }
    }
}
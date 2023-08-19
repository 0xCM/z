//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    public readonly record struct TokenSeq : ITokenSeq
    {        
        public readonly ReadOnlySeq<Token> Tokens;

        public TokenSeq(ReadOnlySeq<Token> tokens)
        {
            Tokens = tokens;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Tokens.Count;
        }

        public ref readonly Token this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Tokens[index];
        }

        public ref readonly Token this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Tokens[index];
        }

        public IEnumerable<Paired<string,ReadOnlySeq<Token>>> Groups()
            => from g in Tokens.GroupBy(x => x.Group)
                orderby g.Key
                select Tuples.paired(g.Key, (ReadOnlySeq<Token>)g.Array());

        ReadOnlySeq<Token> ITokenSeq.Tokens
            => Tokens;
    }
}
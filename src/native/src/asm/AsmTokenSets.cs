//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static sys;

    public sealed class TokenSet : ReadOnlySeq<TypeList>
    {
        public TokenSet()
        {

        }

        public TokenSet(TypeList[] types)
            : base(types)
        {

        }
    }

    public class AsmTokenSets
    {
        static TypeList OpCodes;
        

        static AsmTokenSets()
        {


        }

    }
}
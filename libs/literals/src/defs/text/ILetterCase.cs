//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ILetterCase
    {
        bool IsUpper {get;}

        bool IsLower {get;}

        LetterCaseKind Kind {get;}
    }

    public interface ILetterCase<C> : ILetterCase
        where C : unmanaged, ILetterCase<C>
    {

    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IVar : IExpr
    {
        @string Name {get;}

        object Value();

        bool HasValue  {get;}

        char Prefix => Chars.Dollar;

        Fence<char> Fence => (Chars.LBrace, Chars.RBrace);

        bool IsPrefixed => Prefix != 0;

        bool IsFenced => Fence.Left != 0 && Fence.Right != 0;

        bool IsPrefixedFence => IsPrefixed && IsFenced;
    }

    [Free]
    public interface IVar<T> : IVar
        where T : IEquatable<T>, IComparable<T>
    {
        new T Value();

        object IVar.Value() 
            => Value();
    }
}
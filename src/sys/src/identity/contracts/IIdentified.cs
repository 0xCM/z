//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes an identifier
    /// </summary>
    [Free]
    public interface IIdentified : ITextual
    {
        string IdentityText {get;}

        Identifier Identifier
            => new Identifier(IdentityText);

        bool IsEmpty
            => string.IsNullOrWhiteSpace(IdentityText);

        bool IsNonEmpty
            => !IsEmpty;

        string ITextual.Format()
            => IdentityText;
    }
}
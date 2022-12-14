//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{   
    public interface IUriPart : IExpr
    {
        UriPartKind Kind {get;}

        bool INullity.IsEmpty
            => Kind == 0;

        bool INullity.IsNonEmpty
            => Kind != 0;
    }    
}
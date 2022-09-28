//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{   
    public interface IUriScheme : IUriPart
    {
        string Name {get;}

        bool INullity.IsEmpty
            => sys.empty(Name);

        bool INullity.IsNonEmpty
            => sys.nonempty(Name);

        string IExpr.Format()
            => Name;

        UriPartKind IUriPart.Kind 
            => UriPartKind.Scheme;
    }

    public interface IUriScheme<S> : IUriScheme
        where S : unmanaged, IUriScheme<S> 
    {

    }
}
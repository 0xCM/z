//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{   
    public interface IUri
    {
        string SchemeName {get;}
    }

    public interface IUri<S> : IUri
        where S : IUriScheme
    {
        S Scheme {get;}

        string IUri.SchemeName 
            => Scheme.Name;
    }
}
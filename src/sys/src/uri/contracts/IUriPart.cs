//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{   
    public interface IUriPart
    {
        UriPartKind Kind {get;}
    }    

    public interface IUriScheme : IUriPart
    {
        string Name {get;}
    }
}
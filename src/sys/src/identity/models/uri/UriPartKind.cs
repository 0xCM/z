//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{   
    public enum UriPartKind : byte
    {
        None,

        Scheme,

        User,

        Host,

        Port,

        Path,

        Query,

        Frag
    }
}
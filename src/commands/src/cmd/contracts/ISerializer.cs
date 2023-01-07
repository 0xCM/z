//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISerializer
    {
        MimeType FormatType {get;}

        dynamic Format(dynamic src);

        dynamic Hydrate(dynamic src);
    }

    public interface ISerializer<S,F> : ISerializer
    {
        F Format(S src);
        
        S Hydrate(F src);

        dynamic ISerializer.Format(dynamic src)
            => Format((S)src);

        dynamic ISerializer.Hydrate(dynamic src)
            => Hydrate((F)src);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IApiUri : IIdentified, IDataString
    {
        string UriText {get;}

        string IIdentified.IdentityText
            => UriText;
    }

    [Free]
    public interface IApiUri<T> : IApiUri, IIdentification<T>, IDataString<T>
        where T : IApiUri<T>
    {

    }
}
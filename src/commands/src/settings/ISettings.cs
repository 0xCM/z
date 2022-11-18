//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Settings;

    [Free]
    public interface ISettings<S> : ISettings
        where S : ISettings<S>, new()
    {
        @string ISettings.Name
            => typeof(S).Name;

        string IExpr.Format()
            => api.format((S)this, Chars.Eq);

        SettingLookup ISettings.Lookup 
            => AsciLines.lookup((S)this);
    }
}
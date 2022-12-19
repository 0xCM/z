//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = SettingsApi;

    [Free]
    public interface ISettings : IExpr
    {
        @string Name {get;}

        SettingLookup Lookup {get;}

        bool INullity.IsEmpty
            => Lookup.IsEmpty;

        bool INullity.IsNonEmpty
            => Lookup.IsNonEmpty;

        string IExpr.Format()
            => api.format(this);
    }

    [Free]
    public interface ISettings<S> : ISettings
        where S : ISettings<S>, new()
    {
        @string ISettings.Name
            => typeof(S).Name;

        string IExpr.Format()
            => api.format((S)this, Chars.Eq);

        SettingLookup ISettings.Lookup 
            => api.lookup((S)this);
    }
}
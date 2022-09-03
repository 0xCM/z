//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Settings;

    [Free]
    public interface ISettings : IExpr
    {
        Name Name {get;}

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
        Name ISettings.Name
            => typeof(S).Name;

        SettingLookup ISettings.Lookup
            => api.lookup((S)this);

        string IExpr.Format()
            => api.format((S)this, Chars.Eq);
    }
}
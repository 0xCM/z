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
        @string Name {get;}

        SettingLookup Lookup {get;}

        bool INullity.IsEmpty
            => Lookup.IsEmpty;

        bool INullity.IsNonEmpty
            => Lookup.IsNonEmpty;

        string IExpr.Format()
            => api.format(this);
    }
}
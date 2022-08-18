//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Settings
    {
        public static Name name(Type src)
            => src.Tag<SettingsAttribute>().MapValueOrElse(tag => tag.Name, () => (Name)src.DisplayName());

        public static Name name<T>()
            => name(typeof(T));
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Settings
    {
        public static @string name(Type src)
            => src.Tag<SettingsAttribute>().MapValueOrElse(tag => tag.Name, () => (@string)src.DisplayName());

        public static @string name<T>()
            => name(typeof(T));
    }
}
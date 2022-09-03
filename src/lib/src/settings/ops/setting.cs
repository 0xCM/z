//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Settings
    {
        [MethodImpl(Inline), Op]
        public static Setting64 setting(Name name, asci64 value)
            => new Setting64(name,value);

        [MethodImpl(Inline), Op]
        public static Setting<Name,V> asci<V>(Name name, V value)
            where V : IAsciSeq<V>
                => new Setting<Name,V>(name,value);

        [MethodImpl(Inline)]
        public static SettingLookup<Name,V> asci<V>(params Setting<Name,V>[] src)
            where V : IAsciSeq<V>
                => new SettingLookup<Name,V>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Setting<T> setting<T>(Name name, T value)
            => new Setting<T>(name, value);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Setting<T> setting<T>(Name name, SettingType type, T value)
            => new Setting<T>(name, type, value);

        [MethodImpl(Inline), Op]
        public static Setting setting(Name name, SettingType type, string value)
            => new Setting(name, type, value);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Setting<T> setting<T>(Setting src, Func<string,T> parser)
            => new Setting<T>(src.Name, parser(src.ValueText));
    }
}
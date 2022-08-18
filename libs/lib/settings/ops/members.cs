//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Settings
    {
        [MethodImpl(Inline), Op]
        public static SettingMembers members(Type src)
            => new (src.PublicInstanceFields().Where(f => !f.IsInitOnly));

        public static SettingMembers<T> members<T>()
            where T : new()
                => new SettingMembers<T>(members(typeof(T)));
    }
}
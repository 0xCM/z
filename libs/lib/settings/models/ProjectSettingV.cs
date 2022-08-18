//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct ProjectSetting<V>
        where V : IEquatable<V>
    {
        public readonly @string Key;

        public readonly V Value;

        [MethodImpl(Inline)]
        public ProjectSetting(@string key, V value)
        {
            Key = key;
            Value = value;
        }

        [MethodImpl(Inline)]
        public static implicit operator ProjectSetting(ProjectSetting<V> src)
            => new ProjectSetting($"{src.Key}", src.Value);
    }
}
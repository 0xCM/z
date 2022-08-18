//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct ProjectSetting<K,V>
        where V : IEquatable<V>
    {
        public readonly K Key;

        public readonly V Value;

        [MethodImpl(Inline)]
        public ProjectSetting(K key, V value)
        {
            Key = key;
            Value = value;
        }

        [MethodImpl(Inline)]
        public static implicit operator ProjectSetting<V>(ProjectSetting<K,V> src)
            => new ProjectSetting<V>($"{src.Key}", src.Value);

        [MethodImpl(Inline)]
        public static implicit operator ProjectSetting(ProjectSetting<K,V> src)
            => new ProjectSetting($"{src.Key}", src.Value);
    }
}
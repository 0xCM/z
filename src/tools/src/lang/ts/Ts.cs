//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ts
{
    public partial class Ts
    {
        [MethodImpl(Inline)]
        public static TokenLift<K,V> token<K,V>(K key, V value)
            => new(key,value);
    }
}
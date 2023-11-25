//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct Hex
{
    [MethodImpl(Inline), Op]
    public static HexString hexstring(ReadOnlySpan<char> src)
        => new (src);

    [MethodImpl(Inline), Op]
    public static HexString<Hex1Kind> hexstring(N1 n)
        => hexstring<Hex1Kind>();

    [MethodImpl(Inline), Op]
    public static HexString<Hex2Kind> hexstring(N2 n)
        => hexstring<Hex2Kind>();

    [MethodImpl(Inline), Op]
    public static HexString<Hex3Kind> hexstring(N3 n)
        => hexstring<Hex3Kind>();

    [MethodImpl(Inline), Op]
    public static HexString<Hex4Kind> hexstring(N4 n)
        => hexstring<Hex4Kind>();

    [MethodImpl(Inline)]
    public static HexString<K> hexstring<K>()
        where K : unmanaged, Enum
    {
        if(typeof(K) == typeof(Hex1Kind))
            return generic<K>(new HexString<Hex1Kind>(Hex1Text.x00));
        else if(typeof(K) == typeof(Hex2Kind))
            return generic<K>(new HexString<Hex2Kind>(Hex2Text.x00));
        else if(typeof(K) == typeof(Hex3Kind))
            return generic<K>(new HexString<Hex3Kind>(Hex3Text.x00));
        else if(typeof(K) == typeof(Hex4Kind))
            return generic<K>(new HexString<Hex4Kind>(Hex4Text.x00));
        else
            return HexString<K>.Empty;
    }
}

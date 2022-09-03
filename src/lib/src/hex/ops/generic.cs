//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Hex
    {
        [MethodImpl(Inline)]
        public static ref HexString<K> generic<K>(in HexString<Hex1Kind> src)
            where K : unmanaged
                => ref @as<HexString<Hex1Kind>,HexString<K>>(edit(src));

        [MethodImpl(Inline)]
        public static ref HexString<K> generic<K>(in HexString<Hex2Kind> src)
            where K : unmanaged
                => ref @as<HexString<Hex2Kind>,HexString<K>>(edit(src));

        [MethodImpl(Inline)]
        public static ref HexString<K> generic<K>(in HexString<Hex3Kind> src)
            where K : unmanaged
                => ref @as<HexString<Hex3Kind>,HexString<K>>(edit(src));

        [MethodImpl(Inline)]
        public static ref HexString<K> generic<K>(in HexString<Hex4Kind> src)
            where K : unmanaged
                => ref @as<HexString<Hex4Kind>, HexString<K>>(edit(src));

        [MethodImpl(Inline)]
        public static ref HexStrings<K> generic<K>(in HexStrings<Hex1Kind> src)
            where K : unmanaged
                => ref @as<HexStrings<Hex1Kind>, HexStrings<K>>(edit(src));

        [MethodImpl(Inline)]
        public static ref HexStrings<K> generic<K>(in HexStrings<Hex2Kind> src)
            where K : unmanaged
                => ref @as<HexStrings<Hex2Kind>, HexStrings<K>>(edit(src));

        [MethodImpl(Inline)]
        public static ref HexStrings<K> generic<K>(in HexStrings<Hex3Kind> src)
            where K : unmanaged
                => ref @as<HexStrings<Hex3Kind>, HexStrings<K>>(edit(src));

        [MethodImpl(Inline)]
        public static ref HexStrings<K> generic<K>(in HexStrings<Hex4Kind> src)
            where K : unmanaged
                => ref @as<HexStrings<Hex4Kind>, HexStrings<K>>(edit(src));
    }
}
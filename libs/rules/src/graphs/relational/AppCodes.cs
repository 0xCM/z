//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly struct AppCodes
    {
        const NumericKind Closure = UnsignedInts;

        const byte DomainWidth = 16;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static AppCode<K> encode<K>(asci32 domain, asci32 name, Hex32 code)
            where K : unmanaged
                => new AppCode<K>(domain, name, @as<ulong,K>((ulong)code));

        [MethodImpl(Inline), Op]
        public static AppCode encode(asci32 name, asci32 domain, Hex32 code)
            => new AppCode(domain, name, code);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Hex32 decode<K>(AppCode<K> src)
            where K : unmanaged
                => (uint)(bw64(src.Data) >> DomainWidth);

        [MethodImpl(Inline), Op]
        public static Hex32 decode(in AppCode src)
            => (uint)(src.Data >> DomainWidth);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static AppCode untype<K>(in AppCode<K> src)
            where K : unmanaged
                => new AppCode(src.Domain, src.Name, bw64(src.Data));

        public static string format(in AppCode src)
        {
            var val = decode(src).Format();
            var tbl = src.Domain;
            var name = src.Name;
            return string.Format("{0} {1} {2}:{3}",name, (char)LogicSym.Def, tbl, val);
        }

        public readonly struct AppCode<K>
            where K : unmanaged
        {
            public readonly asci32 Domain;

            public readonly asci32 Name;

            public readonly K Data;

            [MethodImpl(Inline)]
            public AppCode(asci32 domain, asci32 name, K data)
            {
                Domain = domain;
                Name = name;
                Data = data;
            }

            public Hex32 Code
            {
                [MethodImpl(Inline)]
                get => decode(this);
            }

            public string Format()
                => format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator AppCode(AppCode<K> src)
                => untype(src);
        }

        public readonly struct AppCode
        {
            public readonly asci32 Domain;

            public readonly asci32 Name;

            public readonly ulong Data;

            [MethodImpl(Inline)]
            public AppCode(asci32 domain, asci32 name, ulong data)
            {
                Domain = domain;
                Data = data;
                Name = name;
            }

            public Hex32 Code
            {
                [MethodImpl(Inline)]
                get => decode(this);
            }

            public string Format()
                => format(this);

            public override string ToString()
                => Format();
        }
    }
}
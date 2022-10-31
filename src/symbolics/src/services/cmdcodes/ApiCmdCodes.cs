//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly struct ApiCmdCodes
    {
        const NumericKind Closure = UnsignedInts;

        const byte DomainWidth = 16;

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> serialize(in ApiCmdCode src)
            => bytes(src);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> serialize<K>(in ApiCmdCode<K> src)
            where K : unmanaged
                => bytes(src);

        [MethodImpl(Inline), Op]
        public static ApiCmdCode hydrate(ReadOnlySpan<byte> src)
            => @as<ApiCmdCode>(src);

        [MethodImpl(Inline), Op]
        public static ApiCmdCode hydrate<K>(ReadOnlySpan<byte> src)
            where K : unmanaged
                => @as<ApiCmdCode<K>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ApiCmdCode<K> encode<K>(asci32 domain, asci32 name, K data)
            where K : unmanaged
                => new ApiCmdCode<K>(domain, name, data);

        [MethodImpl(Inline), Op]
        public static ApiCmdCode encode(asci32 name, asci32 domain, ulong data)
            => new ApiCmdCode(domain, name, data);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ApiCmdCode untype<K>(in ApiCmdCode<K> src)
            where K : unmanaged
                => new ApiCmdCode(src.Domain, src.Name, bw64(src.Data));

        public static string format(in ApiCmdCode src)
        {
            var val = src.CmdId.Format();
            var tbl = src.Domain;
            var name = src.Name;
            return string.Format("{0} {1} {2}:{3}",name, (char)LogicSym.Def, tbl, val);
        }
    }
}
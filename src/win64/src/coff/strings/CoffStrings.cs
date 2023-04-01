//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost,Free]
    public class CoffStrings
    {
        [MethodImpl(Inline), Op]
        public static uint size(in CoffStringTable src)
            => first(recover<uint>(slice(src.Data,0,4)));

        public static string format(in CoffStringTable src, in CoffSymbol sym)
        {
            ref readonly var name = ref sym.Name;
            var value = sym.Value;
            var kind = name.NameKind;
            var address = kind == CoffNameKind.String ? Address32.Zero : name.Address;
            var dst = EmptyString;
            if(value < Hex16.Max)
            {
                if(address.IsNonZero)
                    dst = entry(src, name.Address).Format();
                else
                {
                    if(kind == CoffNameKind.String)
                    {
                        var len = length(src,sym.Name);
                        dst = recover<AsciCode>(slice(bytes(name), 0,len)).Format();
                    }
                }
            }
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static uint length(in CoffStringTable strings, Address32 offset)
        {
            var data = slice(strings.Data, (uint)offset);
            var max = strings.Data.Length;
            var len = 0u;
            var i=0u;
            while(i < max && (sbyte)skip(data,i++) > 0)
                len++;
            return len;
        }

        [MethodImpl(Inline), Op]
        public static uint length(in CoffStringTable strings, CoffSymbolName name)
        {
            var kind = name.NameKind;
            var len  = 0u;
            if(kind == CoffNameKind.String)
                len = AQ.length(recover<AsciCode>(bytes(name)));
            else if(kind == CoffNameKind.Address)
                len = length(strings, name.Address);
            return len;
        }

        public static string format(in CoffStringTable strings, CoffSymbolName name)
        {
            var len = length(strings, name);
            var dst = EmptyString;
            if(len <= 8)
                dst = recover<AsciCode>(slice(bytes(name),0,len)).Format();
            else if(name.Address.IsNonZero)
                dst = entry(strings, name.Address).Format();
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciCode> entry(in CoffStringTable strings, Address32 offset)
        {
            var data = slice(strings.Data, (uint)offset);
            return recover<AsciCode>(slice(data,0, length(strings,offset)));
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<CoffSymbol> symbols(ReadOnlySpan<byte> src, uint offset, uint count)
            => slice(recover<CoffSymbol>(slice(src,offset)), 0, count);
    }
}
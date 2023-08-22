//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

[ApiHost]
public class MemoryStores
{
    public static MemoryStores load(ReadOnlySpan<ProcessMemoryRegion> src)
    {
        var count = src.Length;
        var symbols = create(count);
        for(var i=0; i<count; i++)
        {
            ref readonly var region = ref skip(src,i);
            symbols.Deposit(region.BaseAddress, region.Size, region.ImageName);
        }
        return symbols;
    }

    public static MemoryStores stores(ReadOnlySpan<ProcessPartition> src)
    {
        var count = src.Length;
        var dst = create(count);
        for(var i=0; i<count; i++)
        {
            ref readonly var part = ref skip(src,i);
            dst.Deposit(part.MinAddress, part.Size, part.ImageName);
        }
        return dst;
    }

    public static bool perfect(ReadOnlySpan<MemorySymbol> src, out Index<HashEntry<MemorySymbol>> dst)
    {
        var codes = src.Select(x => x.HashCode);
        var count = (uint)codes.Length;
        dst = sys.alloc<HashEntry<MemorySymbol>>(count);
        ref var records = ref dst.First;
        for(var i=0u; i<count; i++)
        {
            ref var entry = ref dst[i];
            ref readonly var hash = ref skip(codes,i);
            entry.Seq = (hash % count);
            entry.Code = hash;
            entry.Content = skip(src,i);
        }

        var distinct = dst.ToHashSet();
        return distinct.Count == count;
    }

    [MethodImpl(Inline), Op]
    public static ReadOnlySpan<byte> load(ReadOnlySpan<MemorySegment> src, MemorySlot n)
        => MemorySegs.load(src,n);

    [MethodImpl(Inline), Op]
    public static ref readonly byte cell(ReadOnlySpan<MemorySegment> src, MemorySlot n, int i)
        => ref MemorySegs.cell(src,n,i);

    [MethodImpl(Inline)]
    public static ulong sib(ReadOnlySpan<MemorySegment> refs, in MemorySlot n, int i, byte scale, ushort offset)
        => MemorySegs.sib(refs, n, i, scale, offset);

    /// <summary>
    /// Hashes an address
    /// </summary>
    /// <param name="capacity">The number slots in the bucket</param>
    /// <param name="src">The address to hash</param>
    [MethodImpl(Inline), Op]
    public static uint hash(MemoryAddress src)
        => (uint)src;

    [MethodImpl(Inline), Op]
    public static MemorySymbol symbol(uint key, Identifier name, SegRef seg)
    {
        var dst = new MemorySymbol();
        dst.Key = key;
        dst.Address = seg.BaseAddress;
        dst.HashCode = sys.hash(name);
        dst.Size = seg.Size;
        dst.Expr = name.Content;
        return dst;
    }

    [MethodImpl(Inline), Op]
    public static MemorySymbol symbol(uint key, StringAddress address)
    {
        var dst = new MemorySymbol();
        var chars = address.View;
        dst.Key = key;
        dst.Address = address;
        dst.HashCode = sys.hash(chars);
        dst.Size = chars.Length*2;
        dst.Expr = text.format(chars);
        return dst;
    }

    [Op]
    public static uint hash(ReadOnlySpan<MemoryAddress> src, Span<AddressHash> dst)
    {
        var count = (uint)src.Length;
        for(var i=0u; i<count; i++)
        {
            ref readonly var address = ref skip(src,i);
            ref var target = ref seek(dst,i);
            if(address == 0u)
                continue;

            target.Index = i;
            target.Address = address;
            target.HashCode = hash(address);
        }
        return count;
    }

    public static MemoryStores create(uint capacity)
        => new (capacity);

    public static MemoryStores create(int capacity)
        => new ((uint)capacity);

    [MethodImpl(Inline), Op]
    public static uint bucket(MemoryAddress src, uint capacity)
        => hash(src) % (capacity);

    [MethodImpl(Inline), Op]
    public static uint bucket(Hash32 hash, uint capacity)
        => hash % capacity;

    [Op]
    public static MemoryStore lookup(Index<MemorySymbol> symbols, uint count)
    {
        var capacity = (uint)symbols.Length;
        var keys = sys.alloc<uint>(capacity);
        ref var k = ref first(keys);
        ref var s = ref symbols.First;
        for(var i=0; i<count; i++)
        {
            ref var symbol = ref seek(s,i);
            symbol.HashCode = hash(symbol.Address);
            seek(k,  bucket(symbol.HashCode, capacity)) = symbol.Key;

        }
        return new MemoryStore(symbols, keys, capacity);
    }

    Index<MemoryAddress> _Addresses;

    Index<MemorySymbol> _Symbols;

    uint CurrentIndex;

    uint Capacity;

    public uint EntryCount
    {
        [MethodImpl(Inline)]
        get => CurrentIndex;
    }

    public ReadOnlySpan<MemoryAddress> Addresses
    {
        [MethodImpl(Inline)]
        get => slice(_Addresses.View,0,EntryCount);
    }

    MemoryStores(uint count)
    {
        Capacity = count;
        _Addresses = sys.alloc<MemoryAddress>(count);
        _Symbols = sys.alloc<MemorySymbol>(count);
        CurrentIndex = 0;
    }

    [MethodImpl(Inline), Op]
    public bool IsDefined(uint index)
        => (index < Capacity - 1) && _Symbols[index].IsNonEmpty;

    [Op]
    public MemorySymbol Deposit(MemoryAddress address, ByteSize size, SymExpr expr)
    {
        if(CurrentIndex < Capacity - 1)
        {
            _Addresses[CurrentIndex] = address;
            var deposited = new MemorySymbol(CurrentIndex, 0, address, size, expr);
            _Symbols[CurrentIndex] = deposited;
            CurrentIndex++;
            return deposited;
        }
        else
            return MemorySymbol.Empty;
    }

    public MemoryStore ToLookup()
        => lookup(_Symbols, EntryCount);
}

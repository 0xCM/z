//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly partial struct BitRecords
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static BitRecordField field(asci16 name, byte index, uint offset, byte width)
            => new BitRecordField(name, index, offset, width);

        [MethodImpl(Inline), Op]
        public static BitRecordSchema schema(asci16 name, BitRecordField[] fields)
            => new BitRecordSchema(asci16.Null, name, fields);

        [MethodImpl(Inline), Op]
        public static BitRecordSchema schema(asci16 scope, asci16 name, BitRecordField[] fields)
            => new BitRecordSchema(scope, name, fields);

        [MethodImpl(Inline), Op]
        public static uint serialize(in BitRecordField src, Span<byte> dst)
            => store(bytes(src), dst);

        [MethodImpl(Inline), Op]
        public static BitRecord record(byte[] src)
            => new BitRecord(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitRecord<T> record<T>(T src)
            where T : unmanaged
                => new BitRecord<T>(src);

        const uint Align32 = 32u;

        const uint Align16 = 16u;

        const uint Align8 = 8u;

        const uint Align4 = 4u;

        [Op]
        static uint store(ReadOnlySpan<byte> src, Span<byte> dst)
        {
            var size = (uint)core.min(src.Length, dst.Length);
            var rem = 0u;
            var dep = 0u;
            if(size >= Align32)
            {
                var blocks = size/Align32;
                rem = size % Align32;
                dep = blocks * Align32;
                store32(src, dst, blocks);
            }
            else if(size >= Align16)
            {
                var blocks = size / Align16;
                rem = size % Align16;
                dep = blocks * Align16;
                store16(src,dst,blocks);
            }
            else if(size >= Align8)
            {
                var blocks = size / Align8;
                rem = size % Align8;
                dep = blocks * Align8;
                store8(src,dst,blocks);
            }
            else if(size >= Align4)
            {
                var blocks = size / Align4;
                rem = size % Align4;
                dep = blocks * Align4;
                store4(src,dst,blocks);
            }
            else
            {
                dep = size;
                for(var i=0; i<size; i++)
                    seek(dst,i) = skip(src,i);
            }

            if(rem != 0)
                dep += store(Spans.slice(src,0,dep), slice(dst,0,dep));

            return dep;
        }

        [MethodImpl(Inline), Op]
        static void store4(ReadOnlySpan<byte> src, Span<byte> dst, uint blocks)
        {
            ref readonly var a = ref @as<byte,uint>(first(src));
            ref var b = ref @as<byte,uint>(first(dst));
            for(var i=0; i<blocks; i++)
                seek(b,i) = skip(b,i);
        }

        [MethodImpl(Inline), Op]
        static void store8(ReadOnlySpan<byte> src, Span<byte> dst, uint blocks)
        {
            ref readonly var a = ref @as<byte,ulong>(first(src));
            ref var b = ref @as<byte,ulong>(first(dst));
            for(var i=0; i<blocks; i++)
                seek(b,i) = skip(b,i);
        }

        [MethodImpl(Inline), Op]
        static void store16(ReadOnlySpan<byte> src, Span<byte> dst, uint blocks)
        {
            ref readonly var a = ref @as<byte,ByteBlock16>(first(src));
            ref var b = ref @as<byte,ByteBlock16>(first(dst));
            for(var i=0; i<blocks; i++)
                seek(b,i) = skip(b,i);
        }

        [MethodImpl(Inline), Op]
        static void store32(ReadOnlySpan<byte> src, Span<byte> dst, uint blocks)
        {
            ref readonly var a = ref @as<byte,ByteBlock32>(first(src));
            ref var b = ref @as<byte,ByteBlock32>(first(dst));
            for(var i=0; i<blocks; i++)
                seek(b,i) = skip(b,i);
        }
    }
}
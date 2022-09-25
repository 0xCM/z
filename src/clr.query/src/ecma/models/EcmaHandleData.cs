//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct EcmaHandleData : IComparable<EcmaHandleData>, IEquatable<EcmaHandleData>
    {
        [MethodImpl(Inline), Op]
        public static EcmaRowKey key(Handle src)
        {
            var data = EcmaHandleData.from(src);
            return new EcmaRowKey(data.Table, data.RowId);
        }

        [MethodImpl(Inline), Op]
        public static EcmaRowKey key(EntityHandle src)
        {
            var dat = EcmaHandleData.from(src);
            return new EcmaRowKey(dat.Table, dat.RowId);
        }

        [MethodImpl(Inline), Op]
        public static EntityHandle handle(uint src)
            => @as<uint,EntityHandle>(src);

        [MethodImpl(Inline), Op]
        public static EcmaHandleData from(Handle src)
            => @as<Handle,EcmaHandleData>(src);

        [MethodImpl(Inline), Op]
        public static EcmaHandleData from(EntityHandle src)
        {
            var row = uint32(src) & 0xFFFFFF;
            var kind = (EcmaTableKind)(uint32(src) >> 24);
            return new EcmaHandleData(kind,row);
        }

        [MethodImpl(Inline), Op]
        static Handle ecmahandle(EcmaHandleData src)
            => @as<EcmaHandleData,Handle>(src);

        public readonly uint RowId;

        public readonly EcmaTableKind Table;

        [MethodImpl(Inline)]
        public EcmaHandleData(EcmaTableKind table, uint row)
        {
            RowId = row;
            Table = table;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => RowId == 0;
        }

        [MethodImpl(Inline)]

        public bool Equals(EcmaHandleData src)
            => Table == src.Table && RowId == src.RowId;

        [MethodImpl(Inline)]
        public int CompareTo(EcmaHandleData src)
            => Table != src.Table ? ((byte)Table).CompareTo((byte)src.Table) : RowId.CompareTo(src.RowId);

        public string Format()
            => string.Format("{0:X2}:{1:x6}", (byte)Table, RowId);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Handle(EcmaHandleData src)
            => ecmahandle(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaHandleData(Handle src)
            => from(src);
    }
}
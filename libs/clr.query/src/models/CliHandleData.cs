//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct CliHandleData : IComparable<CliHandleData>, IEquatable<CliHandleData>
    {
        [MethodImpl(Inline), Op]
        public static CliRowKey key(Handle src)
        {
            var data = CliHandleData.from(src);
            return new CliRowKey(data.Table, data.RowId);
        }

        [MethodImpl(Inline), Op]
        public static CliRowKey key(EntityHandle src)
        {
            var dat = CliHandleData.from(src);
            return new CliRowKey(dat.Table, dat.RowId);
        }

        [MethodImpl(Inline), Op]
        public Handle handle(CliToken src)
            => handle(new CliHandleData(src.Table, src.Row));

        [MethodImpl(Inline), Op]
        public static EntityHandle handle(uint src)
            => @as<uint,EntityHandle>(src);

        [MethodImpl(Inline), Op]
        public static ClrHandle<RuntimeMethodHandle> MethodHandle(Module src, CliToken token)
            => new ClrHandle<RuntimeMethodHandle>(ClrArtifactKind.Method, token, src.ModuleHandle.GetRuntimeMethodHandleFromMetadataToken((int)token));

        [MethodImpl(Inline), Op]
        public static ClrHandle<RuntimeFieldHandle> FieldHandle(Module src, CliToken token)
            => new ClrHandle<RuntimeFieldHandle>(ClrArtifactKind.Field, token, src.ModuleHandle.GetRuntimeFieldHandleFromMetadataToken((int)token));

        [MethodImpl(Inline), Op]
        public static ClrHandle<RuntimeTypeHandle> TypeHandle(Module src, CliToken token)
            => new ClrHandle<RuntimeTypeHandle>(ClrArtifactKind.Type, token, src.ModuleHandle.GetRuntimeTypeHandleFromMetadataToken((int)token));
        [MethodImpl(Inline), Op]
        public static CliHandleData from(Handle src)
            => @as<Handle,CliHandleData>(src);

        [MethodImpl(Inline), Op]
        public static CliHandleData from(EntityHandle src)
        {
            var row = uint32(src) & 0xFFFFFF;
            var kind = (CliTableKind)(uint32(src) >> 24);
            return new CliHandleData(kind,row);
        }

        [MethodImpl(Inline), Op]
        public static Handle handle(CliHandleData src)
            => @as<CliHandleData,Handle>(src);

        public readonly uint RowId;

        public readonly CliTableKind Table;

        [MethodImpl(Inline)]
        public CliHandleData(CliTableKind table, uint row)
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

        public bool Equals(CliHandleData src)
            => Table == src.Table && RowId == src.RowId;

        [MethodImpl(Inline)]
        public int CompareTo(CliHandleData src)
            => Table != src.Table ? ((byte)Table).CompareTo((byte)src.Table) : RowId.CompareTo(src.RowId);

        public string Format()
            => string.Format("{0:X2}:{1:x6}", (byte)Table, RowId);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Handle(CliHandleData src)
            => handle(src);

        [MethodImpl(Inline)]
        public static implicit operator CliHandleData(Handle src)
            => from(src);
    }
}
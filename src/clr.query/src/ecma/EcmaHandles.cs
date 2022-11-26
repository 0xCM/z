//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly struct EcmaHandles
    {       
        [Parser]

        [MethodImpl(Inline), Op]
        public static EcmaTableKind table(Handle handle)
            => EcmaHandleData.from(handle).Table;

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
        public static EcmaHandleData datahandle(EntityHandle src)
        {
            var row = uint32(src) & 0xFFFFFF;
            var kind = (EcmaTableKind)(uint32(src) >> 24);
            return new EcmaHandleData(kind,row);
        }

        [MethodImpl(Inline), Op]
        public static Type clrtype(Module src, EcmaToken token)
            => src.ResolveType((int)token);

        [MethodImpl(Inline), Op]
        public static EcmaHandle<RuntimeMethodHandle> method(Module src, EcmaToken token)
            => new EcmaHandle<RuntimeMethodHandle>(ClrArtifactKind.Method, token, methodhandle(src,token));

        [MethodImpl(Inline), Op]
        public static EcmaHandle<RuntimeTypeHandle> type(Module src, EcmaToken token)
            => new EcmaHandle<RuntimeTypeHandle>(ClrArtifactKind.Type, token, typehandle(src,token));

        [MethodImpl(Inline), Op]
        public static EcmaHandle<RuntimeFieldHandle> field(Module src, EcmaToken token)
            => new EcmaHandle<RuntimeFieldHandle>(ClrArtifactKind.Field, token, fieldhandle(src,token));

        [MethodImpl(Inline), Op]
        public Handle handle(EcmaToken src)
            => handle(new EcmaHandleData(src.Table, src.Row));

        [MethodImpl(Inline), Op]
        public static Handle handle(EcmaHandleData src)
            => @as<EcmaHandleData,Handle>(src);

        [MethodImpl(Inline), Op]
        public static EcmaHandleData datahandle(Handle src)
            => @as<Handle,EcmaHandleData>(src);

        [MethodImpl(Inline), Op]
        public static RuntimeTypeHandle typehandle(Module src, EcmaToken token)
            => src.ModuleHandle.GetRuntimeTypeHandleFromMetadataToken((int)token);

        [MethodImpl(Inline), Op]
        public static RuntimeMethodHandle methodhandle(Module src, EcmaToken token)
            => src.ModuleHandle.GetRuntimeMethodHandleFromMetadataToken((int)token);

        [MethodImpl(Inline), Op]
        public static RuntimeFieldHandle fieldhandle(Module src, EcmaToken token)
            => src.ModuleHandle.GetRuntimeFieldHandleFromMetadataToken((int)token);

        [MethodImpl(Inline), Op]
        public static uint row(EntityHandle src)
            => uint32(src) & 0xFFFFFF;

        [MethodImpl(Inline), Op]
        public static EcmaTableKind table(Type src)
            => (EcmaTableKind)(u32(src.MetadataToken) >> 24);

        [MethodImpl(Inline), Op]
        public static EcmaTableKind table(MethodInfo src)
            => (EcmaTableKind)(u32(src.MetadataToken) >> 24);

        [MethodImpl(Inline), Op]
        public static EcmaTableKind table(EventInfo src)
            => (EcmaTableKind)(u32(src.MetadataToken) >> 24);

        [MethodImpl(Inline), Op]
        public static EcmaTableKind table(FieldInfo src)
            => (EcmaTableKind)(u32(src.MetadataToken) >> 24);

        [MethodImpl(Inline), Op]
        public static EcmaTableKind table(PropertyInfo src)
             => (EcmaTableKind)(u32(src.MetadataToken) >> 24);

        [MethodImpl(Inline), Op]
        public static uint row(Type src)
            => u32(src.MetadataToken) & 0xFFFFFF;

        [MethodImpl(Inline), Op]
        public static uint row(MethodInfo src)
            => u32(src.MetadataToken) & 0xFFFFFF;

        [MethodImpl(Inline), Op]
        public static uint row(EventInfo src)
            => u32(src.MetadataToken) & 0xFFFFFF;

        [Op]
        public static void load(ReadOnlySpan<EcmaHandle> src, Span<EcmaHandleRow> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var handle = ref skip(src,i);
                ref var record = ref seek(dst,i);
                record.Address = handle.Pointer.Address;
                record.Token = handle.Token;
                record.Kind = handle.Kind;
            }
        }

        [Op]
        public static ReadOnlySpan<EcmaHandle<RuntimeTypeHandle>> types(Assembly src)
        {
            var metadata = src.Types();
            var count = metadata.Length;
            var buffer = sys.alloc<EcmaHandle<RuntimeTypeHandle>>(count);
            types(metadata, src.ManifestModule, buffer);
            return buffer;
        }

        [Op]
        public static ReadOnlySpan<EcmaHandle<RuntimeFieldHandle>> fields(Assembly src)
        {
            var metadata = src.Fields();
            var count = metadata.Length;
            var buffer = sys.alloc<EcmaHandle<RuntimeFieldHandle>>(count);
            fields(metadata, src.ManifestModule, buffer);
            return buffer;
        }

        [Op]
        public static ReadOnlySpan<EcmaHandle<RuntimeMethodHandle>> methods(Assembly src)
        {
            var concrete = src.Methods().Concrete();
            var count = concrete.Length;
            var buffer = sys.alloc<EcmaHandle<RuntimeMethodHandle>>(count);
            methods(concrete, src.ManifestModule, buffer);
            return buffer;
        }

        [Op]
        public static void fields(ReadOnlySpan<FieldInfo> src, Module module, Span<EcmaHandle<RuntimeFieldHandle>> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = field(module, EcmaTokens.token(skip(src,i)));
        }

        [Op]
        public static void types(ReadOnlySpan<Type> src, Module module, Span<EcmaHandle<RuntimeTypeHandle>> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = type(module, EcmaTokens.token(skip(src,i)));
        }

        [Op]
        public static void methods(ReadOnlySpan<MethodInfo> src, Module module, Span<EcmaHandle<RuntimeMethodHandle>> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = method(module, EcmaTokens.token(skip(src,i)));
        }
    }
}
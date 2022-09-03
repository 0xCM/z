//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;

    [ApiHost]
    public readonly struct ClrHandles
    {
        [Op]
        public static void load(ReadOnlySpan<ClrHandle> src, Span<ClrHandleRecord> dst)
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
        public static ReadOnlySpan<ClrHandle<RuntimeTypeHandle>> types(Assembly src)
        {
            var metadata = src.Types();
            var count = metadata.Length;
            var buffer = sys.alloc<ClrHandle<RuntimeTypeHandle>>(count);
            types(metadata, src.ManifestModule, buffer);
            return buffer;
        }

        [Op]
        public static ReadOnlySpan<ClrHandle<RuntimeFieldHandle>> fields(Assembly src)
        {
            var metadata = src.Fields();
            var count = metadata.Length;
            var buffer = sys.alloc<ClrHandle<RuntimeFieldHandle>>(count);
            fields(metadata, src.ManifestModule, buffer);
            return buffer;
        }

        [Op]
        public static ReadOnlySpan<ClrHandle<RuntimeMethodHandle>> methods(Assembly src)
        {
            var concrete = src.Methods().Concrete();
            var count = concrete.Length;
            var buffer = sys.alloc<ClrHandle<RuntimeMethodHandle>>(count);
            methods(concrete, src.ManifestModule, buffer);
            return buffer;
        }

        [Op]
        public static void fields(ReadOnlySpan<FieldInfo> src, Module module, Span<ClrHandle<RuntimeFieldHandle>> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = field(module, Clr.token(skip(src,i)));
        }


        [Op]
        public static void types(ReadOnlySpan<Type> src, Module module, Span<ClrHandle<RuntimeTypeHandle>> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = type(module, Clr.token(skip(src,i)));
        }

        [Op]
        public static void methods(ReadOnlySpan<MethodInfo> src, Module module, Span<ClrHandle<RuntimeMethodHandle>> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = method(module, Clr.token(skip(src,i)));
        }

        [MethodImpl(Inline), Op]
        public static ClrHandle<RuntimeMethodHandle> method(Module src, CliToken token)
            => new ClrHandle<RuntimeMethodHandle>(ClrArtifactKind.Method, token, Clr.methodhandle(src,token));

        [MethodImpl(Inline), Op]
        public static ClrHandle<RuntimeTypeHandle> type(Module src, CliToken token)
            => new ClrHandle<RuntimeTypeHandle>(ClrArtifactKind.Type, token, Clr.typehandle(src,token));

        [MethodImpl(Inline), Op]
        public static ClrHandle<RuntimeFieldHandle> field(Module src, CliToken token)
            => new ClrHandle<RuntimeFieldHandle>(ClrArtifactKind.Field, token, Clr.fieldhandle(src,token));

        [MethodImpl(Inline), Op]
        public static ClrHandle untype(in ClrHandle<RuntimeMethodHandle> src)
            => new ClrHandle(src.Kind, src.Token, src.Handle.GetFunctionPointer());

        [MethodImpl(Inline), Op]
        public static ClrHandle untype(in ClrHandle<RuntimeFieldHandle> src)
            => new ClrHandle(src.Kind, src.Token, src.Handle.Value);

        [MethodImpl(Inline), Op]
        public static ClrHandle untype(in ClrHandle<RuntimeTypeHandle> src)
            => new ClrHandle(src.Kind, src.Token, src.Handle.Value);

        [MethodImpl(Inline)]
        public static ClrHandle untype<T>(in ClrHandle<T> src)
            where T : struct
        {
            if(typeof(T) == typeof(RuntimeMethodHandle))
                return untype(@as<ClrHandle<T>,ClrHandle<RuntimeMethodHandle>>(src));
            else if(typeof(T) == typeof(RuntimeFieldHandle))
                return untype(@as<ClrHandle<T>,ClrHandle<RuntimeFieldHandle>>(src));
            else if(typeof(T) == typeof(RuntimeTypeHandle))
                return untype(@as<ClrHandle<T>,ClrHandle<RuntimeTypeHandle>>(src));
            else
                throw no<T>();
        }
    }
}
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
                seek(dst,i) = field(module, Ecma.token(skip(src,i)));
        }


        [Op]
        public static void types(ReadOnlySpan<Type> src, Module module, Span<EcmaHandle<RuntimeTypeHandle>> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = type(module, Ecma.token(skip(src,i)));
        }

        [Op]
        public static void methods(ReadOnlySpan<MethodInfo> src, Module module, Span<EcmaHandle<RuntimeMethodHandle>> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = method(module, Ecma.token(skip(src,i)));
        }

        [MethodImpl(Inline), Op]
        public static EcmaHandle<RuntimeMethodHandle> method(Module src, EcmaToken token)
            => new EcmaHandle<RuntimeMethodHandle>(ClrArtifactKind.Method, token, Ecma.methodhandle(src,token));

        [MethodImpl(Inline), Op]
        public static EcmaHandle<RuntimeTypeHandle> type(Module src, EcmaToken token)
            => new EcmaHandle<RuntimeTypeHandle>(ClrArtifactKind.Type, token, Ecma.typehandle(src,token));

        [MethodImpl(Inline), Op]
        public static EcmaHandle<RuntimeFieldHandle> field(Module src, EcmaToken token)
            => new EcmaHandle<RuntimeFieldHandle>(ClrArtifactKind.Field, token, Ecma.fieldhandle(src,token));

        [MethodImpl(Inline), Op]
        public static EcmaHandle untype(in EcmaHandle<RuntimeMethodHandle> src)
            => new EcmaHandle(src.Kind, src.Token, src.Handle.GetFunctionPointer());

        [MethodImpl(Inline), Op]
        public static EcmaHandle untype(in EcmaHandle<RuntimeFieldHandle> src)
            => new EcmaHandle(src.Kind, src.Token, src.Handle.Value);

        [MethodImpl(Inline), Op]
        public static EcmaHandle untype(in EcmaHandle<RuntimeTypeHandle> src)
            => new EcmaHandle(src.Kind, src.Token, src.Handle.Value);

        [MethodImpl(Inline)]
        public static EcmaHandle untype<T>(in EcmaHandle<T> src)
            where T : struct
        {
            if(typeof(T) == typeof(RuntimeMethodHandle))
                return untype(@as<EcmaHandle<T>,EcmaHandle<RuntimeMethodHandle>>(src));
            else if(typeof(T) == typeof(RuntimeFieldHandle))
                return untype(@as<EcmaHandle<T>,EcmaHandle<RuntimeFieldHandle>>(src));
            else if(typeof(T) == typeof(RuntimeTypeHandle))
                return untype(@as<EcmaHandle<T>,EcmaHandle<RuntimeTypeHandle>>(src));
            else
                throw no<T>();
        }
    }
}
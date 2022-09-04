//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly struct ClrDynamic
    {
        const NumericKind Closure = UnsignedInts;

        public static ApiMemberInfo describe(in ResolvedMethod src)
        {
            var dst = new ApiMemberInfo();
            var msil = ClrDynamic.msil(src.EntryPoint, src.Uri, src.Method);
            dst.EntryPoint = src.EntryPoint;
            dst.ApiKind = src.Method.ApiClass();
            dst.CliSig = msil.CliSig;
            dst.DisplaySig = src.Method.DisplaySig().Format();
            dst.Token = msil.Token;
            dst.Uri = src.Uri.Format();
            dst.MsilCode = msil.CliCode;
            return dst;
        }

        [Op]
        public static ApiMsil msil(MemoryAddress @base, _OpUri uri, MethodInfo src)
            => new ApiMsil(src.MetadataToken, @base, src.DisplaySig(), uri, src.ResolveSignature(), src.GetMethodBody().GetILAsByteArray(), src.GetMethodImplementationFlags());

        [MethodImpl(Inline), Op]
        public static MethodBase method(RuntimeMethodHandle src)
            => MethodBase.GetMethodFromHandle(src);

        [Op]
        public static MsilCompilation compilation(DynamicMethod src)
            => new MsilCompilation(MsilCode.define(default, src.ResolveSignature(), msildata(src), src.GetMethodImplementationFlags()), _pointer(src));

        [Op]
        public static MsilCompilation compilation(DynamicDelegate src)
            => compilation(src.Target);

        [Op]
        public static MsilCompilation compilation(MemoryAddress @base, MethodInfo src)
            => new MsilCompilation(MsilCode.define(default, src.ResolveSignature(), src.GetMethodBody().GetILAsByteArray(), src.GetMethodImplementationFlags()), @base);

        [Op]
        public static RuntimeMethodHandle handle(DynamicMethod src)
        {
            var method = typeof(DynamicMethod).GetMethod("GetMethodDescriptor", BindingFlags.NonPublic | BindingFlags.Instance);
            return (RuntimeMethodHandle)method.Invoke(src, null);
        }

        /// <summary>
        /// Creates a dynamic pointer from an untyped dynamic delegate
        /// </summary>
        /// <param name="src">The source delegate</param>
        /// <param name="handle">A proxy for the unmanaged pointer</param>
        [MethodImpl(Inline), Op]
        public static DynamicPointer pointer(DynamicDelegate src)
            => pointer(src, _pointer(src.Target));

        [MethodImpl(Inline), Op]
        public static DynamicPointer pointer(DynamicDelegate src, IntPtr handle)
            => new DynamicPointer(src, handle);

        /// <summary>
        /// Creates a dynamic pointer from a generic dynamic delegate
        /// </summary>
        /// <param name="src">The source delegate</param>
        /// <param name="handle">A proxy for the unmanaged pointer</param>
        /// <typeparam name="D">The delegate type</typeparam>
        public static DynamicPointer pointer<D>(DynamicDelegate<D> src)
            where D : Delegate
                => pointer(src);

        public static MethodSlots<I> slots<I>(Type src)
            where I : unmanaged
                => new MethodSlots<I>(slots(src));

        [Op]
        public static ReadOnlySeq<MethodSlot> slots(Type src)
        {
            var methods = src.DeclaredMethods();
            var count = methods.Length;
            var dst = alloc<MethodSlot>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var method = ref methods[i];
                RuntimeHelpers.PrepareMethod(method.MethodHandle);
                seek(dst,i) = new MethodSlot(method.Name, method.MethodHandle.GetFunctionPointer());
            }
            return dst;
        }

        /// <summary>
        /// Finds the magical function pointer for a dynamic method
        /// </summary>
        /// <param name="method">The source method</param>
        /// <remarks>See https://stackoverflow.com/questions/45972562/c-sharp-how-to-get-runtimemethodhandle-from-dynamicmethod</remarks>
        static IntPtr _pointer(DynamicMethod method)
        {
            var descriptor = typeof(DynamicMethod).GetMethod("GetMethodDescriptor", BindingFlags.NonPublic | BindingFlags.Instance);
            return ((RuntimeMethodHandle)descriptor.Invoke(method, null)).GetFunctionPointer();
        }

        /// <summary>
        /// See https://stackoverflow.com/questions/4148297/resolving-the-tokens-found-in-the-il-from-a-dynamic-method/35711376#35711376
        /// </summary>
        [Op]
        static byte[] msildata(DynamicMethod src)
        {
            var resolver = typeof(DynamicMethod).GetField("m_resolver", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(src);
            if (resolver == null)
                throw new ArgumentException("The dynamic method's IL has not been finalized.");
            return (byte[])resolver.GetType().GetField("m_code", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(resolver);
        }
    }
}
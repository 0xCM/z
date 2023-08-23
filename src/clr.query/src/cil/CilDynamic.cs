//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Free]
public class CilDynamic
{
    [MethodImpl(Inline), Op]
    public static MethodBase method(RuntimeMethodHandle src)
        => MethodBase.GetMethodFromHandle(src);

    [MethodImpl(Inline), Op]
    public static DynamicPointer pointer(DynamicDelegate src, IntPtr handle)
        => new (src, handle);

    /// <summary>
    /// Creates a dynamic pointer from an untyped dynamic delegate
    /// </summary>
    /// <param name="src">The source delegate</param>
    /// <param name="handle">A proxy for the unmanaged pointer</param>
    [MethodImpl(Inline), Op]
    public static DynamicPointer pointer(DynamicDelegate src)
        => pointer(src, pointer(src.Target));

    /// <summary>
    /// Creates a dynamic pointer from a generic dynamic delegate
    /// </summary>
    /// <param name="src">The source delegate</param>
    /// <param name="handle">A proxy for the unmanaged pointer</param>
    /// <typeparam name="D">The delegate type</typeparam>
    public static DynamicPointer pointer<D>(DynamicDelegate<D> src)
        where D : Delegate
            => pointer(src.Untyped);

    [Op]
    public static RuntimeMethodHandle handle(DynamicMethod src)
    {
        var method = typeof(DynamicMethod).GetMethod("GetMethodDescriptor", BindingFlags.NonPublic | BindingFlags.Instance);
        return (RuntimeMethodHandle)method.Invoke(src, null);
    }

    [Op]
    public static CilMember member(MemoryAddress @base, OpUri uri, MethodInfo src)
        => new (src.MetadataToken, @base, src.DisplaySig(), uri, src.ResolveSignature(), src.GetMethodBody().GetILAsByteArray(), src.GetMethodImplementationFlags());

    [Op]
    public static CilEntryPoint entry(DynamicMethod src)
        => new (CilCode.define(default, src.ResolveSignature(), cilbytes(src), src.GetMethodImplementationFlags()), pointer(src));

    [Op]
    public static CilEntryPoint entry(DynamicDelegate src)
        => entry(src.Target);

    [Op]
    public static CilEntryPoint entry(MemoryAddress @base, MethodInfo src)
        => new (CilCode.define(default, src.ResolveSignature(), src.GetMethodBody().GetILAsByteArray(), src.GetMethodImplementationFlags()), @base);

    /// <summary>
    /// Finds the magical function pointer for a dynamic method
    /// </summary>
    /// <param name="method">The source method</param>
    /// <remarks>See https://stackoverflow.com/questions/45972562/c-sharp-how-to-get-runtimemethodhandle-from-dynamicmethod</remarks>
    public static IntPtr pointer(DynamicMethod method)
    {
        var descriptor = typeof(DynamicMethod).GetMethod("GetMethodDescriptor", BindingFlags.NonPublic | BindingFlags.Instance);
        return ((RuntimeMethodHandle)descriptor.Invoke(method, null)).GetFunctionPointer();
    }

    /// <summary>
    /// See https://stackoverflow.com/questions/4148297/resolving-the-tokens-found-in-the-il-from-a-dynamic-method/35711376#35711376
    /// </summary>
    [Op]
    public static byte[] cilbytes(DynamicMethod src)
    {
        var resolver = typeof(DynamicMethod).GetField("m_resolver", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(src);
        if (resolver == null)
            throw new ArgumentException("The dynamic method's IL has not been finalized.");
        return (byte[])resolver.GetType().GetField("m_code", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(resolver);
    }
}

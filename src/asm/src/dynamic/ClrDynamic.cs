//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

[ApiHost]
public readonly struct ClrDynamic
{
    const NumericKind Closure = UnsignedInts;

    public static ApiMemberInfo describe(in ResolvedMethod src)
    {
        var dst = new ApiMemberInfo();
        var msil = CilDynamic.member(src.EntryPoint, src.Uri, src.Method);
        dst.EntryPoint = src.EntryPoint;
        dst.ApiKind = src.Method.ApiClass();
        dst.CliSig = msil.CliSig;
        dst.DisplaySig = src.Method.DisplaySig().Format();
        dst.Token = msil.Token;
        dst.Uri = src.Uri.Format();
        dst.MsilCode = msil.CliCode;
        return dst;
    }

    public static MethodSlots<I> slots<I>(Type src)
        where I : unmanaged
            => new (slots(src));

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
}

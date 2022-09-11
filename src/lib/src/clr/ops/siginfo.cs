//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Clr
    {        
        // [Op]
        // public static ClrTypeSigInfo siginfo(Type type)
        // {
        //     var dst = new ClrTypeSigInfo();
        //     dst.DisplayName = type.HasElementType ? type.ElementType().DisplayName() : type.EffectiveType().DisplayName();
        //     dst.IsOpenGeneric = type.IsGenericType && !type.IsConstructedGenericType;
        //     dst.IsClosedGeneric = type.IsConstructedGenericType;
        //     dst.IsByRef = type.IsRef();
        //     dst.IsIn = false;
        //     dst.IsOut = false;
        //     dst.IsPointer = type.IsPointer;
        //     dst.Modifier = dst.IsIn ? "in " : dst.IsOut ? "out " : dst.IsByRef ? "ref " : EmptyString;
        //     dst.IsArray = type.IsArray;
        //     return dst;
        // }

        // [Op]
        // public static ClrTypeSigInfo siginfo(ParameterInfo src)
        // {
        //     var dst = new ClrTypeSigInfo();
        //     var type = src.ParameterType;
        //     dst.DisplayName = type.HasElementType ? type.ElementType().DisplayName() : type.EffectiveType().DisplayName();
        //     dst.IsOpenGeneric = type.IsGenericType && !type.IsConstructedGenericType;
        //     dst.IsClosedGeneric = type.IsConstructedGenericType;
        //     dst.IsByRef = type.IsRef();
        //     dst.IsIn = src.IsIn;
        //     dst.IsOut = src.IsOut;
        //     dst.IsPointer = type.IsPointer;
        //     dst.Modifier = dst.IsIn ? "in " : dst.IsOut ? "out " : dst.IsByRef ? "ref " : EmptyString;
        //     dst.IsArray = type.IsArray;
        //     return dst;
        // }
    }
}
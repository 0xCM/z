//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static SpanBlocks;

[Free]
public static class DynamicImmediate
{
    public static DynamicMethod DynamicSignature(string name, Type owner, Type @return, params Type[] args)
        => new (name: name,
            attributes: MethodAttributes.Public | MethodAttributes.Static,
            callingConvention: CallingConventions.Standard,
            returnType: @return,
            parameterTypes: args,
            owner: owner,
            skipVisibility: false);

    public static DynamicDelegate EmbedV128UnaryOpImm(MethodInfo src, byte imm8, OpIdentity id)
    {
        Require.invariant(src.ReturnType.IsVector(), () => $"Method {src.Name} does not return a vector value");
        var tCell = src.ReturnType.SuppliedTypeArgs().Single();
        var wrapped = src.Reify(tCell);
        var idTarget = id.WithImm8(imm8);
        var tOperand = typeof(Vector128<>).MakeGenericType(tCell);
        var tWrapper = typeof(UnaryOp<>).MakeGenericType(tOperand);
        var target = DynamicSignature(wrapped.Name, wrapped.DeclaringType, tOperand, tOperand);
        target.GetILGenerator().EmitImmUnaryCall(wrapped, imm8);
        return Delegates.dynamic(idTarget, wrapped, target, tWrapper);
    }

    public static DynamicDelegate EmbedV256UnaryOpImm(MethodInfo src, byte imm8, OpIdentity id)
    {
        Require.invariant(src.ReturnType.IsVector(), () => $"Method {src.Name} does not return a vector value");
        var tCell = src.ReturnType.SuppliedTypeArgs().Single();
        var wrapped = src.Reify(tCell);
        var idTarget = id.WithImm8(imm8);
        var tOperand = typeof(Vector256<>).MakeGenericType(tCell);
        var tWrapper = typeof(UnaryOp<>).MakeGenericType(tOperand);
        var target = DynamicSignature(wrapped.Name, wrapped.DeclaringType, tOperand, tOperand);
        target.GetILGenerator().EmitImmUnaryCall(wrapped, imm8);
        return Delegates.dynamic(idTarget, wrapped, target, tWrapper);
    }

    public static DynamicDelegate EmbedV128BinaryOpImm(MethodInfo src, byte imm8, OpIdentity id)
    {
        Require.invariant(src.ReturnType.IsVector(), () => $"Method {src.Name} does not return a vector value");
        var tCell = src.ReturnType.SuppliedTypeArgs().Single();
        var wrapped = src.Reify(tCell);
        var idTarget = id.WithImm8(imm8);
        var tOperand = typeof(Vector128<>).MakeGenericType(tCell);
        var tWrapper = typeof(BinaryOp<>).MakeGenericType(tOperand);
        var target = DynamicSignature(wrapped.Name, wrapped.DeclaringType, tOperand, tOperand, tOperand);
        target.GetILGenerator().EmitImmBinaryCall(wrapped, imm8);
        return Delegates.dynamic(idTarget, wrapped, target, tWrapper);
    }

    public static DynamicDelegate EmbedV256BinaryOpImm(MethodInfo src, byte imm8, OpIdentity id)
    {
        Require.invariant(src.ReturnType.IsVector(), () => $"Method {src.Name} does not return a vector value");
        var tCell = src.ReturnType.SuppliedTypeArgs().Single();
        var wrapped = src.Reify(tCell);
        var idTarget = id.WithImm8(imm8);
        var tOperand = typeof(Vector256<>).MakeGenericType(tCell);
        var tWrapper = typeof(BinaryOp<>).MakeGenericType(tOperand);
        var target = DynamicSignature(wrapped.Name, wrapped.DeclaringType, tOperand, tOperand, tOperand);
        target.GetILGenerator().EmitImmBinaryCall(wrapped, imm8);
        return Delegates.dynamic(idTarget, wrapped, target, tWrapper);
    }

    public static Option<DynamicDelegate> EmbedVUnaryOpImm(MethodInfo src, byte imm8, OpIdentity id)
    {
        try
        {
            var width = VK.width(src.ReturnType);
            return width switch{
                NativeTypeWidth.W128 => EmbedV128UnaryOpImm(src, imm8, id),
                NativeTypeWidth.W256 => EmbedV256UnaryOpImm(src, imm8, id),
                _ => Option.none<DynamicDelegate>()
            };
        }
        catch(Exception e)
        {
            term.error(e);
            return Option.none<DynamicDelegate>();
        }
    }

    public static Option<DynamicDelegate> EmbedVUnaryOpImm(W128 w, MethodInfo src, byte imm8, OpIdentity id)
        => Option.Try(() => EmbedV128UnaryOpImm(src, imm8, id));

    public static Option<DynamicDelegate> EmbedVUnaryOpImm(W256 w, MethodInfo src, byte imm8, OpIdentity id)
        => Option.Try(() => EmbedV256UnaryOpImm(src, imm8, id));

    public static Option<DynamicDelegate> EmbedVBinaryOpImm(W128 w, MethodInfo src, byte imm8, OpIdentity id)
        => Option.Try(() => EmbedV128BinaryOpImm(src, imm8, id));

    public static Option<DynamicDelegate> EmbedVBinaryOpImm(W256 w, MethodInfo src, byte imm8, OpIdentity id)
        => Option.Try(() => EmbedV256BinaryOpImm(src, imm8, id));

    public static DynamicDelegate<UnaryOp<Vector128<T>>> EmbedVUnaryOpImm<T>(Vec128Kind<T> k, OpIdentity id, MethodInfo src, byte imm8)
        where T : unmanaged
    {
        var wrapped = src.Reify(typeof(T));
        var idTarget = id.WithImm8(imm8);
        var tOperand = typeof(Vector128<T>);
        var target = DynamicSignature(wrapped.Name, wrapped.DeclaringType, tOperand, tOperand);
        target.GetILGenerator().EmitImmUnaryCall(wrapped, imm8);
        return Delegates.dynamic<UnaryOp<Vector128<T>>>(idTarget, wrapped, target);
    }

    public static DynamicDelegate<UnaryOp<Vector256<T>>> EmbedVUnaryOpImm<T>(Vec256Kind<T> k, OpIdentity id, MethodInfo src, byte imm8)
        where T : unmanaged
    {
        var wrapped = src.Reify(typeof(T));
        var idTarget = id.WithImm8(imm8);
        var tOperand = typeof(Vector256<T>);
        var target = DynamicSignature(wrapped.Name, wrapped.DeclaringType, tOperand, tOperand);
        target.GetILGenerator().EmitImmUnaryCall(wrapped, imm8);
        return Delegates.dynamic<UnaryOp<Vector256<T>>>(idTarget, wrapped, target);
    }

    public static DynamicDelegate<BinaryOp<Vector128<T>>> EmbedVBinaryOpImm<T>(Vec128Kind<T> k, OpIdentity id, MethodInfo src, byte imm8)
        where T : unmanaged
    {
        var wrapped = src.Reify(typeof(T));
        var idTarget = id.WithImm8(imm8);
        var tOperand = typeof(Vector128<T>);
        var target = DynamicSignature(wrapped.Name, wrapped.DeclaringType, tOperand, tOperand, tOperand);
        target.GetILGenerator().EmitImmBinaryCall(wrapped,imm8);
        return Delegates.dynamic<BinaryOp<Vector128<T>>>(idTarget, wrapped, target);
    }

    public static DynamicDelegate<UnarySpanOp128<T>> EmbedBlockedUnaryOpImm<T>(W128 w, OpIdentity id, MethodInfo src, byte imm8)
        where T : unmanaged
    {
        var wrapped = src.Reify(typeof(T));
        var idTarget = id.WithImm8(imm8);
        var tOperand = typeof(SpanBlock128<T>);
        var target = DynamicSignature(wrapped.Name, wrapped.DeclaringType, @return: tOperand, args: array(tOperand, tOperand));
        var gTarget = target.GetILGenerator();
        gTarget.Emit(OpCodes.Ldarg_0);
        gTarget.EmitImmLoad(imm8);
        gTarget.Emit(OpCodes.Ldarg_1);
        gTarget.EmitCall(OpCodes.Call, wrapped, null);
        gTarget.Emit(OpCodes.Ret);
        return Delegates.dynamic<UnarySpanOp128<T>>(idTarget, wrapped, target);
    }
}

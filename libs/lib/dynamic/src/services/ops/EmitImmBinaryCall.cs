//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Dynop
    {
        [Op]
        internal static void EmitImmBinaryCall(this ILGenerator gTarget, MethodInfo wrapped, byte imm8)
        {
            gTarget.Emit(OpCodes.Ldarg_0);
            gTarget.Emit(OpCodes.Ldarg_1);
            gTarget.EmitImmLoad(imm8);
            gTarget.EmitCall(OpCodes.Call, wrapped, null);
            gTarget.Emit(OpCodes.Ret);
        }
    }
}
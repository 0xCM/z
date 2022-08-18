//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Reflection.Emit;

    partial class Dynop
    {
        [Op]
        internal static void EmitImmUnaryCall(this ILGenerator gTarget, MethodInfo wrapped, byte imm8)
        {
            gTarget.Emit(OpCodes.Ldarg_0);
            gTarget.EmitImmLoad(imm8);
            gTarget.EmitCall(OpCodes.Call, wrapped, null);
            gTarget.Emit(OpCodes.Ret);
        }
    }
}
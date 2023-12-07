//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class Dynop
{
    [Op]
    internal static CellDelegate EmitCellular(this IntPtr src, OpIdentity id, Type functype, Type result, params Type[] args)
    {
        var method = new DynamicMethod(id, result, args, functype.Module);
        var g = method.GetILGenerator();
        switch(args.Length)
        {
            case 1:
                g.Emit(OpCodes.Ldarg_0);
            break;
            case 2:
                g.Emit(OpCodes.Ldarg_0);
                g.Emit(OpCodes.Ldarg_1);
            break;
            case 3:
                g.Emit(OpCodes.Ldarg_0);
                g.Emit(OpCodes.Ldarg_1);
                g.Emit(OpCodes.Ldarg_2);
            break;
            case 4:
                g.Emit(OpCodes.Ldarg_0);
                g.Emit(OpCodes.Ldarg_1);
                g.Emit(OpCodes.Ldarg_2);
                g.Emit(OpCodes.Ldarg_3);
            break;

        }
        g.Emit(OpCodes.Ldc_I8, (long)src);
        g.EmitCalli(OpCodes.Calli, CallingConvention.StdCall, result, args);
        g.Emit(OpCodes.Ret);
        return CellDelegates.define(id, src, method, method.CreateDelegate(functype));
    }
}

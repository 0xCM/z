//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Reflection.Emit;

    partial class Dynop
    {
        [Op]
        internal static ILGenerator EmitImmLoad(this ILGenerator gTarget, byte imm)
        {
            var code = imm switch {
                0 => OpCodes.Ldc_I4_0,
                1 => OpCodes.Ldc_I4_1,
                2 => OpCodes.Ldc_I4_2,
                3 => OpCodes.Ldc_I4_3,
                4 => OpCodes.Ldc_I4_4,
                5 => OpCodes.Ldc_I4_5,
                6 => OpCodes.Ldc_I4_6,
                7 => OpCodes.Ldc_I4_7,
                8 => OpCodes.Ldc_I4_8,
                _ => OpCodes.Ldc_I4_S
            };
            if(imm <= 8)
                gTarget.Emit(code);
            else
                gTarget.Emit(code, imm);

            return gTarget;
        }
    }
}
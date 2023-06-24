//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedModels;
    using static NativeClass;

    using W = XedModels.WidthCode;

    partial class Xed
    {
        [Op]
        public static NativeClass nclass(WidthCode src)
        {
            var dst = NativeClass.None;
            switch(src)
            {
                case W.P:
                case W.P2:
                case W.MPREFETCH:
                case W.VAR:
                case W.PMMSZ16:
                case W.PMMSZ32:
                case W.VV:
                case W.ZV:
                    dst = 0;
                    break;
                case W.MSKW:
                case W.ZMSKW:
                case W.I1:
                    dst = B;
                    break;

                case W.BND32:
                case W.BND64:
                case W.WRD:
                case W.B:
                case W.U8:
                case W.U16:
                case W.U32:
                case W.U64:
                case W.X128:
                case W.XUB:
                case W.XUW:
                case W.XUD:
                case W.XUQ:
                case W.Y128:
                case W.YUB:
                case W.YUW:
                case W.YUD:
                case W.YUQ:
                case W.ZUB:
                case W.ZU8:
                case W.ZU16:
                case W.ZU32:
                case W.ZU64:

                case W.ZUD:
                case W.ZUW:
                case W.ZUQ:
                case W.ZU128:

                case W.MEM16:
                case W.MEM28:
                case W.MEM14:
                case W.MEM94:
                case W.MEM108:
                case W.M512:
                case W.M384:

                case W.TMEMCOL:
                case W.TMEMROW:
                case W.TV:
                case W.PTR:
                    dst = U;
                    break;

                case W.A16:
                case W.A32:
                case W.ASZ:
                case W.SSZ:

                case W.PI:

                case W.I2:
                case W.I3:
                case W.I4:
                case W.I5:
                case W.I6:
                case W.I7:

                case W.I8:
                case W.I16:
                case W.I32:
                case W.I64:

                case W.W:
                case W.D:
                case W.Q:

                case W.V:
                case W.Y:
                case W.Z:

                case W.DQ:
                case W.QQ:
                case W.MQ:

                case W.MB:
                case W.MW:
                case W.MD:

                case W.XB:
                case W.XW:
                case W.XD:
                case W.XQ:

                case W.YB:
                case W.YW:
                case W.YD:
                case W.YQ:

                case W.ZB:
                case W.ZW:
                case W.ZD:
                case W.ZQ:

                case W.ZI8:
                case W.ZI16:
                case W.ZI32:
                case W.ZI64:

                case W.SPW:
                case W.SPW2:
                case W.SPW3:
                case W.SPW5:
                case W.SPW8:

                case W.MEM16INT:
                case W.MEM32INT:
                case W.M64INT:
                    dst = I;
                    break;

                case W.F16:
                case W.F32:
                case W.F64:
                case W.F80:

                case W.SI:
                case W.SD:

                case W.YPS:
                case W.YPD:
                case W.ZBF16:

                case W.PS:
                case W.PD:
                case W.ZF32:
                case W.ZF64:
                case W.S:
                case W.S64:
                case W.SS:
                case W.MEM32REAL:
                case W.M64REAL:
                case W.MEM80REAL:
                case W.ZF16:
                case W.Z2F16:
                    dst = F;
                    break;
            }

            return dst;
        }
    }
}
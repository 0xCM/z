//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    
    using static XedModels;

    using I = Asm.RFlagIndex;

    partial class XedRules
    {

        [Op]
        public static bool convert(XedFlagEffect src, out FlagEffect dst)
        {
            var index = z8i;
            switch(src.Flag)
            {
                case XedRegFlag._if:
                    index = (sbyte)I.IF;
                break;
                case XedRegFlag.ac:
                    index = (sbyte)I.AC;
                break;

                case XedRegFlag.af:
                    index = (sbyte)I.AF;
                break;

                case XedRegFlag.cf:
                    index = (sbyte)I.CF;
                break;

                case XedRegFlag.df:
                    index = (sbyte)I.DF;
                break;

                case XedRegFlag.id:
                    index = (sbyte)I.ID;
                break;
                case XedRegFlag.of:
                    index = (sbyte)I.OF;
                break;
                case XedRegFlag.pf:
                    index = (sbyte)I.PF;
                break;
                case XedRegFlag.rf:
                    index = (sbyte)I.RF;
                break;
                case XedRegFlag.sf:
                    index = (sbyte)I.SF;
                break;
                case XedRegFlag.tf:
                    index = (sbyte)I.TF;
                break;
                case XedRegFlag.vif:
                    index = (sbyte)I.VIF;
                break;
                case XedRegFlag.vip:
                    index = (sbyte)I.VIP;
                break;
                case XedRegFlag.vm:
                    index = (sbyte)I.VM;
                break;
                case XedRegFlag.zf:
                    index = (sbyte)I.ZF;
                break;

                case XedRegFlag.nt:
                case XedRegFlag.iopl:
                case XedRegFlag.fc0:
                case XedRegFlag.fc1:
                case XedRegFlag.fc2:
                case XedRegFlag.fc3:
                break;
            }

            var result = index >= 0;
            if(result)
                dst = new FlagEffect(RFlags.bits((I)index), src.Effect);
            else
                dst = default;
            return result;
        }
    }
}
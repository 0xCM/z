//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    partial class IntelSdm
    {
        public void ImportForms()
        {
            ImportForms(CalcFormDescriptors());
        }

        void ImportForms(SdmFormDescriptors src)
        {
            var path = SdmPaths.FormDetailDst();
            var lookup = dict<Identifier,SdmFormDetail>();
            var keys = src.Keys;
            var count = keys.Length;
            var buffer = alloc<SdmFormDetail>(count);

            for(var i=0u; i<count; i++)
            {
                ref readonly var key = ref skip(keys,i);
                ref var dst = ref seek(buffer,i);
                var form = src[key];
                dst.Id = form.Id;
                dst.Seq = i;
                dst.Name = form.Name;
                dst.Sig = form.Sig;
                dst.OpCode = form.OpCode;
                dst.Mode64 = ((form.Mode & AsmBitModeKind.Mode64) != 0);
                dst.Mode32 = ((form.Mode & AsmBitModeKind.Mode32) != 0);
                dst.IsRex = SdmOpCodes.rex(form.OpCode);
                dst.IsVex = SdmOpCodes.vex(form.OpCode);
                dst.IsEvex = SdmOpCodes.evex(form.OpCode);
                dst.Description = form.Description;
            }
            
            buffer.Sort();
            for(var i=0u; i<count; i++)
                seek(buffer,i).Seq = i;

            Require.invariant(buffer.Select(x => x.Id).Distinct().Length == count);

            TableEmit(buffer, SdmPaths.FormDetailDst());
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    partial class IntelSdm
    {
        public void ExportSigOps()
        {
            var dst = SdmPaths.Targets().Path("sdm.sigs.operands", FileKind.Csv);
            ExportSigOps(Channel, CalcFormDescriptors(), dst);
        }

        public void ExportSigOps(IWfChannel channel, SdmFormDescriptors src, FilePath dst)
        {
            const string RP = "{0,-8} | {1,-16} | {2,-6} | {3,-48} | {4}";
            var emitting = channel.EmittingFile(dst);
            using var writer = dst.Writer();
            writer.WriteLine(string.Format(RP, "FormSeq", "Mnemonic", "OpSeq", "Sig","OpCode"));
            var keys = src.Keys;
            var counter = 0u;
            var count = keys.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var key = ref skip(keys,i);
                var form = src[key];
                var sig = form.Sig;
                writer.WriteLine(string.Format(RP, i, form.Mnemonic, EmptyString, sig, form.OpCode));
                counter++;

                for(byte j=0; j<sig.OpCount; j++, counter++)
                    writer.WriteLine(string.Format(RP, i, sig.Mnemonic, j, sig[j], form.OpCode));
            }

            channel.EmittedFile(emitting,counter);            
        }
    }
}
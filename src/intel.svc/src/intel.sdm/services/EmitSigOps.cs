//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    partial class IntelSdm
    {
        public Outcome EmitSigOps(SdmFormDescriptors src)
        {
            const string RP = "{0,-8} | {1,-16} | {2,-6} | {3,-48} | {4}";
            var result = Outcome.Success;
            var dst = SdmPaths.Output().Path("sdm.sigs.operands", FileKind.Csv);
            var emitting = EmittingFile(dst);
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

            if(result)
                EmittedFile(emitting,counter);

            return result;
        }
    }
}
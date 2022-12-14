//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelSdm
    {
        void CheckModes(Index<SdmOpCodeDetail> src)
        {
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var detail = ref src[i];
                var m64 = detail.Mode64.Format().Trim();
                var m32 = detail.Mode32.Format().Trim();
                if(!(m64 == "Valid" || m64 == "Invalid"))
                    Warn($"Invalid 64-bit mode specifier for {detail.AsmSig.Format().Trim()}");
                if(!(m32 == "Valid" || m32 == "Invalid"))
                    Warn($"Invalid 32-bit mode specifier for {detail.AsmSig.Format().Trim()}");
            }
        }

        public void Emit(Index<SdmOpCodeDetail> src)
        {
            CheckModes(src);
            TableEmit(src, SdmPaths.SdmTable<SdmOpCodeDetail>(), TextEncodingKind.Unicode);
        }
    }
}
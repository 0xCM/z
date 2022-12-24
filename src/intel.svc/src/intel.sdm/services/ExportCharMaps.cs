//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelSdm
    {
        public Outcome ExportCharMaps()
        {
            var map = CharMaps.create(TextEncodings.Unicode, TextEncodings.Asci);
            CharMapper.emit(Channel, map, SdmPaths.CharMapDst());
            CharMapper.unmapped(Channel, map, SdmPaths.SdmSrcPath(), SdmPaths.UnmappedCharLog());
            return true;
        }
    }
}
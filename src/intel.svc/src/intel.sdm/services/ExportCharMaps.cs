//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelSdm
    {
        public void ExportCharMaps()
        {
            var map = CharMaps.create(TextEncodings.Unicode, TextEncodings.Asci);
            CharMaps.emit(Channel, map, SdmPaths.CharMapSettings());
            CharMaps.unmapped(Channel, map, SdmPaths.SdmSrcPath(), SdmPaths.UnmappedCharLog());
        }
    }
}
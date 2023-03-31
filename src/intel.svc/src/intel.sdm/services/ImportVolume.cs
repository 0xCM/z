//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelSdm
    {
        public void ImportVolumes()
        {
            ImportVolume(1);
            ImportVolume(2);
            ImportVolume(3);
            ImportVolume(4);
        }

        void ImportVolume(byte vol)
        {
            var src = SdmPaths.SdmSrcVol(vol);
            if(!src.Exists)
                sys.@throw($"{src.ToUri()} has gone missing");
            var dst = SdmPaths.SdmDstVol(vol);
            var emitting = Channel.EmittingFile(dst);
            var counter = 0u;
            using var reader = src.UnicodeLineReader();
            using var writer = dst.UnicodeWriter();
            while(reader.Next(out var line))
            {
                writer.WriteLine(line.Format());
                counter++;
            }
            EmittedFile(emitting,counter);
        }
    }
}
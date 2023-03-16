//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public struct MethodDebugInfo
    {
        public ImmutableArray<string> Sig;

        public BinaryCode SequencePoints;
    }

    partial class EcmaReader
    {
        [MethodImpl(Inline), Op]
        public MethodDebugInformation ReadMethodDebugInfo(MethodDebugInformationHandle src)
            => MD.GetMethodDebugInformation(src);
        
        public ReadOnlySeq<MethodDebugInfo> ReadMethodDebugInfo()
        {
            var handles = MethodDebugInfoHandles();
            var count = handles.Length;
            var buffer = alloc<MethodDebugInfo>(count);
            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                var info = ReadMethodDebugInfo(skip(handles,i));
                dst.Sig = MD.GetStandaloneSignature(info.LocalSignature).DecodeLocalSignature(GSTP,null);
                dst.SequencePoints = Blob(info.SequencePointsBlob);                                
            }
            return buffer;
        }
    }
}
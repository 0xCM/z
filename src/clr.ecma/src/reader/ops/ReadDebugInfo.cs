//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EcmaTables;

    partial class EcmaReader
    {
        [MethodImpl(Inline), Op]
        public MethodDebugInformation ReadDebugInfo(MethodDebugInformationHandle src)
            => MD.GetMethodDebugInformation(src);

        public ReadOnlySeq<MethodDebugInformation> ReadMethodDebugInfo()
            => MethodDebugInfoHandles().Map(ReadDebugInfo);
    }
}
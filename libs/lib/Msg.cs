//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Msg
    {

        public static MsgPattern<Count> LoadingHexFileBlocks => "Loading hex blocks from {0} files";

        public static MsgPattern<Count> LoadedHexBlocks => "Loaded {0} hex blocks";

        public static MsgPattern<Count> ProcessingApiHexFiles => "Processing {0} api hex files";

        public static MsgPattern<Count> AccumulatedDescriptors => "Accumulated {0} descriptors";


        public static MsgPattern<Fence<char>> OpCodeFenceNotFound => "Op code fence {0} not found";
    }
}

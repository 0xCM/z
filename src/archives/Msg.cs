//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    struct Msg
    {
        public static MsgPattern<_FileUri,TextEncodingKind,Count> SplittingFile
            => "Splitting {0} into {1}-encoded parts with a maximum of {2} lines each";

        public static MsgPattern<Count,_FileUri,Count> FinishedFileSplit
            => "Partitioned {0} lines from {1} into {2} parts";
    }
}

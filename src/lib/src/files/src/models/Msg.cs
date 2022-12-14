//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        public struct Msg
        {
            public static MsgPattern<_FileUri> ParsingFile => "Parsing {0}";

            public static MsgPattern<_FileUri> ParsedFile => "Parsed {0}";

            public static MsgPattern<_FileUri> DoesNotExist => "The file {0} has gone missing";

            public static MsgPattern<_FileUri> Empty => "The file {0} is impty";

            public static MsgPattern<FolderPath> DirDoesNotExist => "The directory {0} has gone missing";
        }
    }
}
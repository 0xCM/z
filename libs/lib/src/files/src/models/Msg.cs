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
            public static MsgPattern<FS.FileUri> ParsingFile => "Parsing {0}";

            public static MsgPattern<FS.FileUri> ParsedFile => "Parsed {0}";

            public static MsgPattern<FS.FileUri> DoesNotExist => "The file {0} has gone missing";

            public static MsgPattern<FS.FileUri> Empty => "The file {0} is impty";

            public static MsgPattern<FS.FolderPath> DirDoesNotExist => "The directory {0} has gone missing";
        }
    }
}
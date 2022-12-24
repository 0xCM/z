//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppMsgs
    {
        public static MsgPattern<string,string> ParseFailure
            => "Could not parse {0} from {1}";

        public static MsgPattern<FileUri> FileExists
            => "The path {0} exists and yet it shold not";

        public static MsgPattern<FileUri> FileMissing
            => "The path {0} does not exist and yet it should";

        public static MsgPattern<ByteSize,FileUri> EmittedBytes
            => "Emitted {0} bytes to {1}";

        public static MsgPattern<FileUri,Count,Count> CsvHeaderMismatch
            => "The records defined in {0} require {0} fields but {1} were found in the source";

        public static MsgPattern<Count,Count,string> CsvDataMismatch
            => "The target requires {0} fields but {1} were found in {2}";

        public static MsgPattern<Count,Count> FieldCountMismatch
            => "The target requires {0} fields but {1} were found in the source";

        public static MsgPattern<Count,Count,string> CellCountMismatch
            => "The target requires {0} fields but {1} were found in {2}";

        public static RenderPattern<TableId,Count,FileUri> EmittedTable
            => "Emitted <{1}> <{0}> rows to {2}";

        public static RenderPattern<TableId,FileUri> EmittingTable
            => "Emitting <{0}> to {1}";

        public static RenderPattern<FileUri> EmittingFile
            => "Emitting {0}";

        public static RenderPattern<FileUri> EmittedFile
            => "Emitted {0}";

        public static RenderPattern<object> UnhandledCase
            => "Unhandled Case: {0}";
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiComplete]
    partial struct Msg
    {
        public static MsgPattern<Count> CollectingBlocks => "Collecting code blocks from {0} routines";

        public static MsgPattern<ByteSize> CollectedBlocks => "Collecting {0} code blocks";

        public static MsgPattern<Count> CreatingStatements => "Creating {0} statements";

        public static MsgPattern<FolderPath> ObliteratingDirectory => "Obliterating the directory {0}";

        public static MsgPattern<FolderPath> ObliteratedDirectory => "Consigned the directory {0} to oblivion";

        public static MsgPattern<ApiHostUri> EmittingHostRoutines => "Emitting {0} routines";

        public static MsgPattern<Count,ApiHostUri,FileUri> EmittedHostRoutines => "Emitted {0} {1} routines to {2}";

        public static MsgPattern<Count> CreatingAsmRowsFromBlocks => "Creating AsmRows for {0} blocks";

        public static MsgPattern<Count> CreatedAsmRowsFromBlocks => "Created {0} AsmRows";

        public static MsgPattern<Count> DecodingParts => "Decoding {0} parts";

        public static MsgPattern<Count,PartName> DecodingPartRoutines => "Decoding {0} {1} hosts";

        public static MsgPattern<Count,PartName,ApiDecoderStats> DecodedPartRoutines => "Decoded {0} {1} routines | {2}";

        public static MsgPattern<ApiHostUri> DecodingHostRoutines => "Decoding {0} routines";

        public static MsgPattern<Count,ApiHostUri> DecodedHostRoutines => "Decoded {0} {1} routines";

        public static MsgPattern<Count,Count> DecodedMachine => "Decoded {0} routines from {1} parts";

        public static MsgPattern<Count> CollectingBitstrings => "Collecting distinct bitstrings from {0} statements";

        public static MsgPattern<Count> CollectedBitstrings => "Collecting {0} distinct bitstrings";

        public static MsgPattern<Count,ApiHostUri> DecodedHostMembers => "Decoded {0} {1} members";

        public static MsgPattern<Count> ExtractingResolved => "Extracting data for {0} resolved parts";

        public static MsgPattern<Count> ExtractedResolved => "Extracted data for {0} members";

        public static MsgPattern<Count> CreatedStatements => "Created {0} statements";

        public static MsgPattern<OpUri> TerminalNotFound => "Terminal for {0} not found";

        public static MsgPattern<ApiHostUri,Count> RunningHostEmissionWorkflow => "Running {0} emission workflow for {1} members";

        public static MsgPattern<Count,ApiHostUri> ParsedExtractBlocks => "Parsed {0} {1} extract blocks";

        public static MsgPattern<ApiHostUri> CreatingApiStatements => "Creating {0} host api statements";

        public static MsgPattern<ApiHostUri,Count> CreatedApiStatements => "Created {0} {1} host api statement";

        public static MsgPattern<Count,Count,FileUri> ParsedStatements => "Parsed {0} full rows and {1} partial rows from {2}";

        public static MsgPattern<FileUri> LoadingStatements
            => "Loading statements from {0}";

        public static MsgPattern<Count,FileUri> LoadedStatments
            => "Loading {0} statements from {1}";

        public static MsgPattern<Count,FileUri> ProcessingStatments
            => "Processing {0} statements from {1}";

        public static MsgPattern<Count,FileUri> ProcessedStatements
            => "Processed {0} statements from {1}";

        public static MsgPattern<FolderPath> CapturingRoutines => "Capturing routines from {0}";

        public static MsgPattern<Count,Count> CapturedRoutines => "Captured {0} routines from {1} hosts";

        public static MsgPattern<Count, DelimitedIndex<PartId>> RunningMachine => "Executing machine workflow for {0} parts: {1}";

        public static MsgPattern<Count, DelimitedIndex<PartId>> RanMachine => "Executed machine workflow for {0} parts: {1}";

    }
}
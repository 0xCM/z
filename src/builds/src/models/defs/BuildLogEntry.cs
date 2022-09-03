//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Build
    {
        [Record(TableId)]
        public record struct BuildLogEntry
        {
            public const string TableId = "logs.build";

            public BuildEventKind EventKind;

            public EventLevel EventLevel;

            public Timestamp Timestamp;

            public TextBlock Message;

            public Identifier HelpKeyword;

            public Identifier SenderName;
        }
    }
}
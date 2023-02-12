//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static sys;

    partial class XedModels
    {
        public class InstImportBlocks
        {
            public MemoryFile DataSource;

            public SortedLookup<InstForm,uint> Forms;

            public Index<InstBlockImport> Imports;

            public Index<InstBlockImport> Duplicates;

            public InstBlockLines BlockLines;

            public LineMap<InstBlockLineSpec> LineMap;

            public ConcurrentDictionary<InstForm,string> FormBlocks;

            public ConcurrentDictionary<InstForm,string> FormHeaders;

            public InstImportBlocks()
            {
                Forms = dict<InstForm,uint>();
            }

            public string Description(InstForm form)
                => FormBlocks[form];

            public string Header(InstForm form)
                => FormHeaders[form];

            public SortedLookup<string,InstBlockImport> ImportLookup;

            public static InstImportBlocks Empty => new();
        }
    }
}
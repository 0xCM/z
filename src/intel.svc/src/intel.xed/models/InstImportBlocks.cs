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

            public SortedLookup<XedInstForm,uint> Forms;

            public Index<InstBlockImport> Imports;

            public Index<InstBlockImport> Duplicates;

            public InstBlockLines BlockLines;

            public LineMap<InstBlockLineSpec> LineMap;

            public ConcurrentDictionary<XedInstForm,string> FormBlocks;

            public ConcurrentDictionary<XedInstForm,string> FormHeaders;

            public InstImportBlocks()
            {
                Forms = dict<XedInstForm,uint>();
            }

            public string Description(XedInstForm form)
                => FormBlocks[form];

            public string Header(XedInstForm form)
                => FormHeaders[form];

            public SortedLookup<string,InstBlockImport> ImportLookup;

            public static InstImportBlocks Empty => new();
        }
    }
}
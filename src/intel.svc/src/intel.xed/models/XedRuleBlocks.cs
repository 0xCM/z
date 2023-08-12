//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static sys;

partial class XedModels
{
    public class XedRuleBlocks
    {
        public ReadOnlySeq<LineStats> Stats = sys.empty<LineStats>();

        public SortedLookup<XedInstForm,uint> Forms = dict<XedInstForm,uint>();

        public Index<InstBlockImport> Imports = sys.empty<InstBlockImport>();

        public Index<InstBlockImport> Duplicates = sys.empty<InstBlockImport>();

        public InstBlockLines BlockLines = new();

        public LineMap<InstBlockLineSpec> LineMap = new();

        public ConcurrentDictionary<XedInstForm,string> FormBlocks = new();

        public ConcurrentDictionary<XedInstForm,string> FormHeaders = new();

        public SortedLookup<string,InstBlockImport> ImportLookup = dict<string,InstBlockImport>();

        public XedRuleBlocks()
        {

        }

        public string Description(XedInstForm form)
            => FormBlocks[form];

        public string Header(XedInstForm form)
            => FormHeaders[form];

        public static XedRuleBlocks Empty => new();
    }
}

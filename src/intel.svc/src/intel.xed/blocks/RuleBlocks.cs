//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static sys;

partial class XedZ
{
    public class RuleBlocks
    {
        public ReadOnlySeq<LineStats> Stats = sys.empty<LineStats>();

        public SortedLookup<XedInstForm,uint> Forms = dict<XedInstForm,uint>();

        public Index<InstBlockImport> Imports = sys.empty<InstBlockImport>();

        public InstBlockLines BlockLines = new();

        public LineMap<InstBlockLineSpec> LineMap = new();

        public ConcurrentDictionary<XedInstForm,List<string>> FormBlocks = new();

        public ConcurrentDictionary<XedInstForm,string> FormHeaders = new();

        public RuleBlocks()
        {

        }

        public List<string> Description(XedInstForm form)
            => FormBlocks[form];

        public string Header(XedInstForm form)
            => FormHeaders[form];

        public static RuleBlocks Empty => new();
    }
}

//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    partial class XedDataFlow
    {
        class FormImportDatasets
        {
            public ConcurrentDictionary<XedInstForm,string> Descriptions = new();

            public ConcurrentDictionary<XedInstForm,string> Headers = new();

            public SortedLookup<XedInstForm,uint> Sorted;

            public void Include(XedInstForm form, BlockImportDatasets src)
            {
                if(form.IsNonEmpty)
                {
                    var line = src.BlockLines[form];
                    var dst = InstBlockImport.Empty;
                    var content = src.FormData[form];
                    var seq = Sorted[form];
                    Descriptions[form] = content;
                    Headers[form] = string.Format("{0,-64} | {1:D5} | {2:D2} | {3:D6} | {4:D6}", form, seq, line.Lines, line.MinLine, line.MaxLine);
                }
            }
        }
    }
}
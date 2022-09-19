//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    partial class XedImport
    {
        class FormImportDatasets
        {
            public ConcurrentDictionary<InstForm,string> Descriptions = new();

            public ConcurrentDictionary<InstForm,string> Headers = new();

            public SortedLookup<InstForm,uint> Sorted;

            public void Include(InstForm form, BlockImportDatasets src)
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
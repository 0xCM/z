//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static sys;
    
    partial class XedForms
    {
        public static ReadOnlySpan<QueryResult> search(Index<FormImport> src, string monic, IWfChannel channel)
        {
            const string RenderPattern = "class:{0,-24} form:{1,-32} category:{2,-16} isa:{3,-16} ext:{4,-16} attribs:{5}";
            var types = Symbols.index<InstFormType>();
            var cats = Symbols.index<CategoryKind>();
            var _isa = Symbols.index<InstIsaKind>();
            var classes = Symbols.index<AsmInstKind>();
            var extensions = Symbols.index<ExtensionKind>();
            var count = src.Length;
            var dst = list<QueryResult>();
            for(var i=0; i<count; i++)
            {
                ref readonly var form = ref src[i];
                if(form.InstForm.IsNonEmpty)
                    continue;

                ref readonly var isa = ref _isa[form.IsaKind];
                ref readonly var ext = ref extensions[form.Extension];
                ref readonly var cat = ref cats[form.Category];

                if(form.InstClass.Classifier.Format().StartsWith(monic, StringComparison.InvariantCultureIgnoreCase))
                {
                    var result = QueryResult.Empty;
                    result.SearchPattern = monic;
                    result.InstClass = form.InstClass;
                    result.InstForm = form.InstForm;
                    result.Isa = isa.Kind;
                    result.Extension = ext.Kind;
                    result.Attributes = form.Attributes;
                    dst.Add(result);
                }
            }

            var path = XedPaths.Service.DbTargets().Path(FS.file(monic, FS.Csv));
            var records = dst.ViewDeposited();
            channel.TableEmit(records, path);
            return records;
        }
    }
}
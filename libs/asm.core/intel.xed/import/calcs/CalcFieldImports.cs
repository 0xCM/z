//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static XedModels;
    using static core;

    partial class XedImport
    {
        public Index<FieldImport> CalcFieldImports()
        {
            var src = XedPaths.DocSource(XedDocKind.Fields);
            var dst = list<FieldImport>();
            var result = Outcome.Success;
            var line = EmptyString;
            var lines = src.ReadLines().Reader();
            while(lines.Next(out line))
            {
                var content = line.Trim();
                if(text.empty(content) || text.begins(content,Chars.Hash))
                    continue;

                var cells = text.split(text.despace(content), Chars.Space).Reader();
                var record = FieldImport.Empty;
                record.Name = cells.Next();

                cells.Next();
                result = FieldTypes.ExprKind(cells.Next(), out XedFieldType ft);
                if(result.Fail)
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(record.FieldType), cells.Prior()));
                else
                    record.FieldType = ft;

                result = DataParser.parse(cells.Next(), out record.Width);
                if(result.Fail)
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(record.Width), cells.Prior()));

                if(!Visibilities.ExprKind(cells.Next(), out record.Visibility))
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(record.Visibility), cells.Prior()));

                dst.Add(record);
            }

            return dst.ToArray().Sort();
        }
    }
}
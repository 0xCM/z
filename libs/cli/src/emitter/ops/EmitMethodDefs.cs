//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;
    using static Arrays;

    partial class CliEmitter
    {
        public void EmitMethodDefs(ReadOnlySpan<Assembly> src, IApiPack dst)
            => iter(src, a => EmitMethodDefs(a, dst), true);

        void EmitMethodDefs(Assembly src, IApiPack dst)
        {
            void Exec()
            {
                var path = dst.Metadata(CliSections.Methods).PrefixedTable<MethodDefInfo>(src.GetSimpleName());
                var formatter = Tables.formatter<MethodDefInfo>();
                var flow = EmittingTable<MethodDefInfo>(path);
                using var writer = path.Writer();
                writer.WriteLine(formatter.FormatHeader());
                var reader = CliReader.create(src);
                var records = reader.ReadMethodDefInfo();
                var count = records.Length;
                for(var j=0; j<count; j++)
                    writer.WriteLine(formatter.Format(skip(records, j)));
                EmittedTable(flow, count);
            }

            Try(Exec);
        }
    }
}
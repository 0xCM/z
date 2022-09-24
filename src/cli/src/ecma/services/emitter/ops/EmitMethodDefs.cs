//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaEmitter
    {
        public void EmitMethodDefs(ReadOnlySpan<Assembly> src, IApiPack dst)
            => iter(src, a => EmitMethodDefs(a, dst), true);

        void EmitMethodDefs(Assembly src, IApiPack dst)
        {
            void Exec()
            {
                var path = dst.Metadata(EcmaSections.Methods).PrefixedTable<MethodDefInfo>(src.GetSimpleName());
                var formatter = Tables.formatter<MethodDefInfo>();
                var flow = EmittingTable<MethodDefInfo>(path);
                using var writer = path.Writer();
                writer.WriteLine(formatter.FormatHeader());
                var reader = EcmaReader.create(src);
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
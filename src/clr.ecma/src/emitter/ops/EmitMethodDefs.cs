//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaTables;

    partial class EcmaEmitter
    {
        public void EmitMethodDefs(ReadOnlySeq<Assembly> src, IApiPack dst)
            => iter(src, a => EmitMethodDefs(a, dst), PllExec);

        public void EmitMethodDefs(ReadOnlySeq<Assembly> src, IDbArchive dst)
            => iter(src, a => EmitMethodDefs(a, dst), PllExec);

        void EmitMethodDefs(Assembly src, IApiPack dst)
        {
            void Exec()
            {
                var path = dst.Metadata(EcmaSections.Methods).PrefixedTable<MethodDef>(src.GetSimpleName());
                var formatter = CsvChannels.formatter<MethodDef>();
                var flow = EmittingTable<MethodDef>(path);
                using var writer = path.Writer();
                writer.WriteLine(formatter.FormatHeader());
                var reader = EcmaReader.create(src);
                var records = reader.ReadMethodDefInfo();
                var count = records.Length;
                for(var j=0; j<count; j++)
                    writer.WriteLine(formatter.Format(records[j]));
                EmittedTable(flow, count);
            }

            Try(Exec);
        }

        void EmitMethodDefs(Assembly src, IDbArchive dst)
        {
            void Exec()
            {
                var reader = EcmaReader.create(src);
                var buffer = list<MethodDef>();
                reader.ReadMethodDefs(buffer);
                TableEmit(buffer.ViewDeposited(), dst.PrefixedTable<MethodDef>(src.GetSimpleName()));
            }

            Try(Exec);
        }
    }
}
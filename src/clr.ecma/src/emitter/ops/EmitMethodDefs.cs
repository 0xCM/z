//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaEmitter
    {
        public void EmitMethodDefs(ReadOnlySeq<Assembly> src, IApiPack dst)
            => iter(src, a => EmitMethodDefs(a, dst), PllExec);

        void EmitMethodDefs(Assembly src, IApiPack dst)
        {
            void Exec()
            {
                var path = dst.Metadata(EcmaSections.Methods).PrefixedTable<EcmaMethodDef>(src.GetSimpleName());
                var formatter = Tables.formatter<EcmaMethodDef>();
                var flow = EmittingTable<EcmaMethodDef>(path);
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

        public void EmitMethodDefs(ReadOnlySeq<Assembly> src, IDbArchive dst)
            => iter(src, a => EmitMethodDefs(a, dst), PllExec);

        void EmitMethodDefs(Assembly src, IDbArchive dst)
        {
            void Exec()
            {
                var reader = EcmaReader.create(src);
                var buffer = list<EcmaMethodDef>();
                reader.ReadMethodDefs(buffer);
                TableEmit(buffer.ViewDeposited(), dst.PrefixedTable<EcmaMethodDef>(src.GetSimpleName()));
            }

            Try(Exec);
        }
    }
}
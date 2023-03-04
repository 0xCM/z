//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaModels;

    partial class EcmaEmitter
    {
        public void EmitFieldMetadata(ReadOnlySpan<Assembly> src, IDbArchive dst)
        {
            var count = 0u;
            var flow = Running(src.Length);
            iter(src, part => EmitFieldMetadata(part, dst), true);
            Ran(flow, count);
        }

        void EmitFieldMetadata(Assembly src, IDbArchive dst)
        {
            exec(true,
            () => EmitConstFields(src, dst),
            () => EmitMemberFields(src, dst),
            () => EmitFieldDefs(src, dst)
            );
        }

        void EmitMemberFields(Assembly src, IDbArchive dst)
        {
            try
            {
                var name = src.GetSimpleName();
                var path = dst.Metadata(EcmaSections.MemberFields).PrefixedTable<EcmaFieldInfo>(name);
                var flow = EmittingTable<EcmaFieldInfo>(path);
                var reader = EcmaReader.create(src);
                var fields = reader.ReadFieldInfo();
                var count = (uint)fields.Length;
                var formatter = CsvTables.formatter<EcmaFieldInfo>();
                using var writer = path.Writer();
                writer.WriteLine(formatter.FormatHeader());
                foreach(var item in fields)
                    writer.WriteLine(formatter.Format(item));
                EmittedTable(flow, count);
            }
            catch(Exception e)
            {
                Error(e.Message);
            }
        }

        void EmitFieldDefs(Assembly src, IDbArchive dst)
        {
            try
            {
                var name = src.GetSimpleName();
                var path = dst.Metadata(EcmaSections.FieldDefs).PrefixedTable<EcmaFieldDefInfo>(name);
                if(path.Exists)
                    Errors.ThrowWithOrigin(AppMsg.FileExists.Format(path));

                var flow = EmittingTable<EcmaFieldDefInfo>(path);
                var reader = EcmaReader.create(src);
                var handles = reader.FieldDefHandles();
                var count = handles.Length;
                using var writer = path.Writer();
                var formatter = CsvTables.formatter<EcmaFieldDefInfo>();
                writer.WriteLine(formatter.FormatHeader());
                for(var j=0; j<count; j++)
                {
                    var row = new Field();
                    var info = new EcmaFieldDefInfo();
                    ref readonly var handle = ref skip(handles,j);
                    reader.Row(handle, ref row);
                    info.Token = EcmaTokens.token(handle);
                    info.Component = name;
                    info.Attributes = row.Attributes;
                    info.CliSig = reader.Blob(row.Sig);
                    info.Name = reader.String(row.Name);
                    writer.WriteLine(formatter.Format(info));
                }
                EmittedTable(flow, count);
            }
            catch(Exception e)
            {
                Error(e);
            }
        }
    }
}
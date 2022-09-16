//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class CliEmitter
    {
        public void EmitLiterals(IApiPack dst)
            => iter(ApiMd.Parts, c => EmitFieldLiterals(c, dst), true);

        void EmitFieldLiterals(Assembly src, IApiPack dst)
        {
            var fields = ClrFields.literals(src.Types());
            if(fields.Length != 0)
                Emit(fields, dst.Metadata(CliSections.Literals).Path(FS.file(src.GetSimpleName(), FileKind.Csv)));
        }

        void Emit(ReadOnlySpan<FieldRef> src, FilePath dst)
        {
            const string Sep = "| ";

            static string formatLine(in FieldRef src)
            {
                const string Sep = "| ";

                var content = ClrLiterals.format(src).PadRight(48);
                var address = src.Address.Format().PadRight(16);
                var width = src.Width.Content.ToString().PadRight(16);
                var type = src.Field.DeclaringType.Name.PadRight(36);
                var field = src.Field.Name.PadRight(36);
                var line = string.Concat(address, Sep, width, Sep,type, Sep, field, Sep, content, Sep);
                return line;
            }

            static string FormatHeader()
                => string.Concat(
                    "FieldAddress".PadRight(16), Sep,
                    "FieldWidth".PadRight(16), Sep,
                    "DeclaringType".PadRight(36), Sep,
                    "FieldName".PadRight(36), Sep,
                    "Value".PadRight(48), Sep
                    );

            var flow = EmittingFile(dst);
            var input = src;
            var count = input.Length;
            var buffer = sys.alloc<Paired<FieldRef,string>>(count);
            ref var emissions = ref first(buffer);

            using var writer = dst.Writer();
            writer.WriteLine(FormatHeader());

            for(var i=0u; i<count; i++)
            {
                try
                {
                    ref readonly var field = ref skip(input,i);
                    var formatted = formatLine(field);
                    seek(emissions, i) = (field,formatted);

                    writer.WriteLine(formatted);
                }
                catch(Exception e)
                {
                    Warn(e.Message);
                }
            }

            EmittedFile(flow, count);
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public record class ApiCmdSpec : IApiCmd<ApiCmdSpec>
    {
        public static string format<T>(T src)
            where T : ICmd, new()
        {
            var buffer = text.emitter();
            buffer.AppendFormat("{0}{1}", src.CmdId, Chars.LParen);
            var fields = ClrFields.instance(typeof(T));
            if(fields.Length != 0)
                render(src, fields, buffer);

            buffer.Append(Chars.RParen);
            return buffer.Emit();
        }

        static void render(object src, ReadOnlySpan<ClrFieldAdapter> fields, ITextEmitter dst)
        {
            var count = fields.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref skip(fields,i);
                dst.AppendFormat(RP.Assign, field.Name, field.GetValue(src));
                if(i != count - 1)
                    dst.Append(", ");
            }
        }                            

        public static string format(ApiCmdSpec src)
        {
            if(src.IsEmpty)
                return EmptyString;

            var dst = text.buffer();
            dst.Append(src.Name);
            var count = src.Args.Count;
            for(ushort i=0; i<count; i++)
            {
                var arg = src.Args[i];
                if(nonempty(arg.Name))
                {
                    dst.Append(Chars.Space);
                    dst.Append(arg.Name);
                }

                if(nonempty(arg.Value))
                {
                    dst.Append(Chars.Space);
                    dst.Append(arg.Value);
                }
            }
            return dst.Emit();
        }

        public readonly @string Name;

        public readonly CmdArgs Args;

        [MethodImpl(Inline)]
        public ApiCmdSpec()
        {
            Name = EmptyString;
            Args = CmdArgs.Empty;
        }

        [MethodImpl(Inline)]
        public ApiCmdSpec(string name, CmdArgs args)
        {
            Name = name;
            Args = args;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ApiCmdSpec((string name, CmdArgs args) src)
            => new ApiCmdSpec(src.name, src.args);

        public static ApiCmdSpec Empty
        {
            [MethodImpl(Inline)]
            get => new ApiCmdSpec();
        }
    }
}
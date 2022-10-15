//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost, Free]
    public class CmdTypes
    {
        [Op]
        public static async Task<int> start(ToolCmdSpec cmd, CmdContext context, Action<string> status, Action<string> error)
        {
            var info = new ProcessStartInfo
            {
                FileName = cmd.Tool.Format(),
                Arguments = cmd.Format(),
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true
            };

            var process = new Process {StartInfo = info};

            if (!context.WorkingDir.IsNonEmpty)
                process.StartInfo.WorkingDirectory = context.WorkingDir.Name;

            iter(context.EnvVars, v => process.StartInfo.Environment.Add(v.Name, v.Value));
            process.OutputDataReceived += (s,d) => status(d.Data ?? EmptyString);
            process.ErrorDataReceived += (s,d) => error(d.Data ?? EmptyString);
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            return await wait(process);

            static async Task<int> wait(Process process)
            {
                return await Task.Run(() => {
                    process.WaitForExit();
                    return Task.FromResult(process.ExitCode);
                });
            }
        }

        [Op, Closures(UInt64k)]
        public static ToolCmdSpec spec<T>(Tool tool, in T src)
            where T : struct
        {
            var t = typeof(T);
            var fields = Clr.fields(t);
            var count = fields.Length;
            var reflected = sys.alloc<ClrFieldValue>(count);
            ClrFields.values(src, fields, reflected);
            var buffer = sys.alloc<ToolCmdArg>(count);
            var target = span(buffer);
            var values = @readonly(reflected);
            for(var i=0u; i<count; i++)
            {
                ref readonly var fv = ref skip(values,i);
                seek(target,i) = new ToolCmdArg(fv.Field.Name, fv.Value?.ToString() ?? EmptyString);
            }
            return new ToolCmdSpec(tool, CmdTypes.identify(t), buffer);
        }

        public static Name identify<T>()
            => identify(typeof(T));

        [Op]
        public static Name identify(Type spec)
        {
            var tag = spec.Tag<CmdAttribute>();
            if(tag)
            {
                var name = tag.Value.Name;
                if(empty(name))
                    return spec.Name;
                else
                    return name;
            }
            else
                return spec.Name;
        }

        [Op]
        public static void render(CmdTypeInfo src, ITextBuffer dst)
        {
            dst.Append(src.Source.Name);
            var fields = src.Fields.View;;
            var count = fields.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref skip(fields,count);
                dst.Append(string.Format(" | {0}:{1}", field.FieldName, field.Expr));
            }
        }

        [Op]
        public static string format(CmdTypeInfo src)
        {
            var buffer = text.buffer();
            render(src, buffer);
            return buffer.Emit();
        }

        public static string format(CmdField src)
            => string.Format($"{src.FieldName}:{src.Expr}");

        public static string expr(FieldInfo src)
            => src.Tag<CmdArgAttribute>().MapValueOrDefault(x => text.ifempty(x.Expression,src.Name), src.Name);

        public static Index<CmdField> fields(Type src)
            => src.DeclaredInstanceFields().Mapi((i,x) => new CmdField((byte)i, x, expr(x)));

        public static Type[] tagged(Assembly src)
            =>  src.Structs().Tagged<CmdAttribute>();

        public static Type[] tagged(Assembly[] src)
            =>  src.Structs().Tagged<CmdAttribute>();

        public static CmdTypeInfo describe(Type src)
            => new CmdTypeInfo(identify(src), src, fields(src));

        public static Index<CmdTypeInfo> discover(Assembly[] src)
            => tagged(src).Select(describe).Sort();

        public static ReadOnlySeq<ApiCmdRow> rows(ReadOnlySpan<CmdTypeInfo> src)
        {
            var count = src.Select(x => x.FieldCount).Sum();
            var dst = alloc<ApiCmdRow>(count);
            var k=0u;
            for(var i=0; i<src.Length; i++)
            {
                var type = Require.notnull(skip(src,i));
                var instance = Require.notnull(Activator.CreateInstance(type.Source));
                var values = ClrFields.values(instance, type.Fields.Select(x => x.Source));
                for(var j=0; j<type.FieldCount; j++,k++)
                {
                    ref var row = ref seek(dst,k);
                    ref readonly var field = ref type.Fields[j];
                    row.CmdName = type.CmdName;
                    row.FieldIndex = field.Index;
                    row.CmdType = type.Source.DisplayName();
                    row.FieldName = field.Source.Name;
                    row.Expression = field.Expr;
                    row.DataType = field.Source.FieldType.DisplayName();
                    row.DefaultValue = values[field.Source.Name].Value?.ToString() ?? EmptyString;
                }

            }
            return dst;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public class Env
    {
        public static EnvVar<T> var<T>(EnvVarKind kind, string name, Func<string,T> parser)
            where T : IEquatable<T>
        {
            var dst = EnvVar<T>.Empty;
            var value = Environment.GetEnvironmentVariable(name, (EnvironmentVariableTarget)kind);
            if(nonempty(value))
                dst = new(name,parser(value));
            return dst;
        }

        public static string format(IVarValue var)
            => format(var, Chars.Eq);

        public static string format(IVarValue var, char assign)
            => string.Format("{0}{1}{2}", var.VarName, assign, var.VarValue);

        public static string format(VarContextKind vck, IVarValue var)
            => format(vck,var, Chars.Eq);

        public static string format(VarContextKind vck, IVarValue var, char assign)
            => string.Format("{0}{1}{2}", format(vck, var.VarName), assign, var.VarValue);

        static string format(VarContextKind vck, string name)
            => string.Format(RP.pattern(vck), name);

        public static ExecToken emit(WfEmit emitter, EnvVarKind kind, FolderPath dst)
        {
            var vars = EnvVars.Empty;
            var token = ExecToken.Empty;
            switch(kind)
            {
                case EnvVarKind.Machine:
                    vars = machine();
                break;
                case EnvVarKind.Process:
                    vars = process();
                break;
                case EnvVarKind.User:
                    vars = user();
                break;
            }

            if(vars.IsNonEmpty)
            {
                vars.Iter(v => emitter.Write(v.Format()));
                token = emit(emitter, vars, kind, dst);
            }
            return token;
        }

        static ExecToken emit(IWfChannel channel, EnvVars src, EnvVarKind kind, FolderPath dst)
        {
            var name =  $"{ExecutingPart.Name}.{EnumRender.format(kind)}";
            var table = dst + FS.file($"{name}.settings",FileKind.Csv);
            var env = dst + FS.file($"{name}", FileKind.Cfg);
            using var writer = env.AsciWriter();
            for(var i=0; i<src.Count; i++)
                writer.WriteLine(src[i].Format());
            return Tables.emit(channel, records(src, name).View, table, ASCI);
        }

        // static ExecToken emit<T>(IWfChannel channel, ReadOnlySpan<T> src, FilePath dst, TextEncodingKind encoding, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular, string delimiter = " | ")
        //     where T : struct
        // {
        //     var emitting = channel.EmittingTable<T>(dst);
        //     var formatter = RecordFormatters.create<T>(rowpad, fk, delimiter);
        //     using var writer = dst.Emitter(encoding);
        //     writer.WriteLine(formatter.FormatHeader());
        //     for(var i=0; i<src.Length; i++)            
        //         writer.WriteLine(formatter.Format(skip(src,i)));            
        //     return channel.EmittedTable(emitting, src.Length);
        // }

        public static EnvVars vars(EnvVarKind kind)
        {
            var dst = list<EnvVar>();
            foreach(DictionaryEntry kv in Environment.GetEnvironmentVariables((EnvironmentVariableTarget)kind))
                 dst.Add(new EnvVar(kind, kv.Key?.ToString() ?? EmptyString, kv.Value?.ToString() ?? EmptyString));
            return dst.ToArray().Sort();
        }

        public static EnvVars machine()
            => vars(EnvVarKind.Machine);

        public static EnvVars user()
            => vars(EnvVarKind.User);

        public static EnvVars process()
            => vars(EnvVarKind.Process);

        public static Index<EnvVarRow> records(EnvVars src, string name)
        {
            const char Sep = ';';
            var buffer = list<EnvVarRow>();
            var k=0u;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var v = ref src[i];
                var vName = v.VarName;
                var vValue = v.VarValue;

                if(v.Contains(Sep))
                {
                    var parts = text.split(vValue,Sep).Index();
                    for(var j=0; j<parts.Count; j++)
                    {
                        ref readonly var part = ref parts[j];
                        var dst = new EnvVarRow();
                        dst.Seq = k++;
                        dst.EnvName = name;
                        dst.VarName = vName;
                        dst.VarValue = part;
                        dst.Join = Sep.ToString();
                        buffer.Add(dst);
                    }
                }
                else
                {
                    var dst = new EnvVarRow();
                    dst.Seq = k++;
                    dst.EnvName = name;
                    dst.VarName = vName;
                    dst.VarValue = vValue;
                    dst.Join = EmptyString;
                    buffer.Add(dst);
                }
            }

            return buffer.ToIndex();
        }
    }
}
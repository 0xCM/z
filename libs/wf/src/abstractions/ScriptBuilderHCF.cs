//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [FlowCmdBuilder]
    public abstract class ScriptBuilder<H,C,F>
        where C : struct, IToolFlowCmd<C>
        where F : IFileFlowType<F>, new()
        where H : new()
    {
        public F Flow {get;} = new F();

        public CmdScript BuildCmdScript(C src)
        {
            var fvals = ClrFields.values(src,Fields);
            var count = fvals.Length;
            var dst = text.buffer();
            dst.Append(src.Actor.Name);
            foreach(var fval in fvals)
            {
                var field = fval.Field;
                var value = fval.Value;
                if(value is null)
                    continue;

                var type = field.FieldType;
                var tag = field.Tag<CmdArgAttribute>();
                if(tag.IsNone())
                    continue;

                var tagval = tag.Require();
                var expr = tagval.Expression ?? EmptyString;

                if(type == typeof(string))
                {
                    var x = value as string;
                    if(text.nonempty(x))
                    {
                        if(text.nonempty(expr))
                            dst.AppendFormat( " {0}", string.Format(expr,x));
                        else
                            dst.Append(x);
                    }
                }
                else if(type == typeof(bit))
                {
                    var x = value as bit?;
                    if(x.HasValue)
                    {
                        if(x.Value == 1 && text.nonempty(expr))
                            dst.AppendFormat(" {0}", expr);
                    }
                }
                else if(type == typeof(FS.FolderPath))
                {
                    var x = value as FS.FolderPath?;
                    if(x.HasValue)
                        dst.AppendFormat(" {0}", x.Value.Format(PathSeparator.BS, true));
                }
                else
                {
                    if(type == typeof(FS.FilePath))
                    {
                        var path = (FS.FilePath)value;
                        if(expr == "<src>" || expr == "<dst>" || text.empty(expr))
                            dst.AppendFormat(" {0}", path.Format(PathSeparator.BS, true));
                        else
                            dst.AppendFormat(" {0}", string.Format(expr, path.Format(PathSeparator.BS, true)));
                    }
                    else if(text.nonempty(expr))
                        dst.AppendFormat(" {0}", string.Format(expr,value));
                    else
                        dst.Append(string.Format(" {0}", value.ToString()));
                }
            }

            var spec = dst.Emit();
            dst.AppendLine("@echo off");
            dst.AppendLine(string.Format("set Spec={0}", spec));
            dst.AppendLine(string.Format("call %Spec%"));
            dst.AppendLine("if errorlevel 1 goto:eof");
            dst.AppendLine(string.Format("echo {0}:[{1} -- {2}]", src.Actor.Name, src.Source, src.Target));
            return new CmdScript(dst.Emit());
        }

        // public Index<CmdLine> BuildCmdLines(IProjectWsObsolete project, string scope, string cmdname)
        // {
        //     var ext = Flow.SourceKind.Ext();
        //     var files = project.SrcFiles(recurse:false).Where(f => f.Is(ext));
        //     var buffer = core.bag<CmdLine>();
        //     CmdLine Gen(FS.FilePath file)
        //     {
        //         var cmd= BuildCmd(project, scope, file);
        //         var script = BuildCmdScript(cmd);
        //         var scriptdir = project.Out(string.Format("{0}.scripts", scope));
        //         var spath =  scriptdir + FS.file(string.Format("{0}.{1}", file.FileName, cmdname), FS.Cmd);
        //         using var writer = spath.AsciWriter();
        //         var formatted = script.Format();
        //         writer.WriteLine(formatted);
        //         return new CmdLine(spath.Format(PathSeparator.BS));
        //     }

        //     iter(files, file => buffer.Add(Gen(file)), true);

        //     return buffer.Array();
        // }

        // public abstract C BuildCmd(IProjectWsObsolete project, string scope, FS.FilePath src);

        protected FS.FilePath GetTargetPath(IProjectWsObsolete project, string scope, FS.FilePath src)
            => project.Out(scope).Create() + src.FileName.ChangeExtension(Flow.TargetKind);

        static ScriptBuilder()
        {
            Fields = typeof(C).DeclaredInstanceFields();
        }

        static Index<FieldInfo> Fields;
    }
}
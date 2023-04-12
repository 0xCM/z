//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    using static sys;

    using CMake;

    public class CMakeTool : ToolService<CMakeTool>
    {
        class Flow : ToolFlow<Flow>
        {
            public Flow()
                : base("cmake")
            {}

        }

        class AppCmd : WfAppCmd<AppCmd>
        {

        }

        
        public CMakeTool()
        {

        }

        public override IToolFlow ToolFlow()
            => Flow.create(Channel);

        
        public CMakeCache ParseCache(FilePath src)
        {
            var lines = src.ReadLines(true);
            var usage = EmptyString;
            var type = EmptyString;
            var name = EmptyString;
            var vars = list<IVarAssignment>();

            foreach(var line in lines)
            {
                if(text.begins(line,"//"))
                {
                    var i = text.index(line, "//");
                    if(nonempty(usage))
                        usage += Chars.Space;

                    usage += text.trim(text.despace(text.remove(text.right(line, i + "//".Length - 1), "\\n")));
                }
                else if(text.contains(line, "="))
                {
                    if(Vars.parse(line, out var assigment))
                    {
                        if(nonempty(usage))
                        {
                            var def = assigment.Def.WithUsage(usage);
                            vars.Add(Vars.assign(def, assigment.Value));
                        }
                        else
                            vars.Add(assigment);
                    }
                    usage = EmptyString;
                    type = EmptyString;
                    name = EmptyString;
                }
            }
            return new CMakeCache(src, vars.Array());
        }

        public ReadOnlySeq<VarAssignment> ExtractVars(IDbArchive src)
        {
            
            var dst = src.Path("cmake.vars", FileKind.Cfg);
            var token = Tooling.redirect(Channel, 
                FS.path("cmake.exe"), 
                Cmd.args(Cmd.arg($"-B {src.Root}"), Cmd.arg("-LAH")),
                dst
                ).Result;

            var vars = list<VarAssignment>();
            if(dst.Exists)
            {
                var lines = dst.ReadLines(true);
                var usage = EmptyString;
                var type = EmptyString;
                var name = EmptyString;
                foreach(var line in lines)
                {
                    if(text.begins(line,"//"))
                    {
                        var i = text.index(line, "//");
                        usage = text.trim(text.right(line, i + "//".Length - 1));
                    }
                    else if(text.contains(line, "="))
                    {
                        var i = text.index(line, '=');
                        var decl = text.left(line,i);
                        var value = text.right(line,i);
                        var j = text.index(decl, ':');
                        type = j > 0 ? text.right(decl,j) : EmptyString;
                        name = j > 0 ? text.left(decl,j) : decl;
                        vars.Add(Vars.assign(Vars.var(name, type, usage), value));
                        usage = EmptyString;
                        type = EmptyString;
                        name = EmptyString;
                    }
                }

            }
            return vars.Array().Sort();
        }
        
        public void Execute(ExtractVarsCmd cmd)
        {
            var vars = ExtractVars(cmd.BuildRoot.DbArchive());
            iter(vars, v => Channel.Row(v));
        }
    }
}
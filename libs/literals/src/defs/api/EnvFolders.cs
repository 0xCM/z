//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider]
    public readonly struct EnvFolders
    {
        public const string dot = ".";

        public const string asm = nameof(asm);

        public const string bin = nameof(bin);

        public const string cmd = nameof(cmd);

        public const string builds = nameof(builds);

        public const string build = nameof(build);

        public const string cil = nameof(cil);

        public const string cildata = nameof(cil) + dot + data;

        public const string dotbuild = dot + build;

        public const string dotcmd = dot + cmd;

        public const string docs = nameof(docs);

        public const string lists = nameof(lists);

        public const string tables = nameof(tables);

        public const string sources = nameof(sources);

        public const string targets = nameof(targets);

        public const string stage = nameof(stage);

        public const string tools = nameof(tools);

        public const string tooling = nameof(tooling);

        public const string help = nameof(help);

        public const string jobs = nameof(jobs);

        public const string capture = nameof(capture);

        public const string logs = nameof(logs);

        public const string refs = nameof(refs);

        public const string refdata = nameof(refdata);

        public const string reports = nameof(reports);

        public const string events = nameof(events);

        public const string etl = nameof(etl);

        public const string queue = nameof(queue);

        public const string parsed = nameof(parsed);

        public const string il = nameof(il);

        public const string hex = nameof(hex);

        public const string extracts = nameof(extracts);

        public const string output = nameof(output);

        public const string dotout = dot + "out";

        public const string input = nameof(input);

        public const string qualified = "{0}" + dot + "{1}";

        public const string notebooks = nameof(notebooks);

        public const string indices = nameof(indices);

        public const string imm = nameof(imm);

        public const string tmp = nameof(tmp);

        public const string data = nameof(data);

        public const string dumps = nameof(dumps);

        public const string context = nameof(context);

        public const string source = nameof(source);

        public const string src = nameof(src);

        public const string commands = nameof(commands);

        public const string apps = nameof(apps);

        public const string tests = nameof(tests);

        public const string settings = nameof(settings);

        public const string z0 = nameof(z0);

        public const string cases = nameof(cases);

        public const string catalogs = nameof(catalogs);

        public const string dotnet = nameof(dotnet);

        public const string symbols = nameof(symbols);

        public const string @default = "default";

        public const string images = nameof(images);

        public const string steps = nameof(steps);

        public const string show = nameof(show);

        public const string external = nameof(external);

        public const string manuals = nameof(manuals);

        public const string current = nameof(current);

        public const string codegen = nameof(codegen);

        public const string labs = nameof(labs);

        public const string models = nameof(models);

        public const string obj = nameof(obj);

        public const string exe = nameof(exe);

        public const string cpp = nameof(cpp);

        public const string scripts = nameof(scripts);

        public const string datasets = nameof(datasets);

        public const string imported = nameof(imported);

        public const string bitfields = nameof(bitfields);

        public const string common = nameof(common);
    }
}
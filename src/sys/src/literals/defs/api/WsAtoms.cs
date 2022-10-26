//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider(ws)]
    public readonly struct WsAtoms
    {
        const string dot = ".";

        public const string admin = dot + "admin";

        public const string output = dot + "out";

        public const string asm = nameof(asm);

        public const string api = nameof(api);

        public const string assets = nameof(assets);

        public const string bin = nameof(bin);

        public const string c = nameof(c);

        public const string cpp = nameof(cpp);

        public const string cs = nameof(cs);

        public const string control = nameof(control);

        public const string config = nameof(config);

        public const string data = nameof(data);

        public const string dis = nameof(dis);

        public const string docs = nameof(docs);

        public const string dumps = nameof(dumps);

        public const string exe = nameof(exe);

        public const string gen = nameof(gen);

        public const string hex = nameof(hex);

        public const string imports = nameof(imports);

        public const string inventory = nameof(inventory);

        public const string intel = nameof(intel);

        public const string intelxed = intel + dot + xed;

        public const string lang = nameof(lang);

        public const string list = nameof(list);

        public const string lists = nameof(lists);

        public const string logs = nameof(logs);

        public const string llvm = nameof(llvm);

        public const string ll = nameof(ll);

        public const string machine = nameof(machine);

        public const string msil = nameof(msil);

        public const string obj = nameof(obj);

        public const string projects = nameof(projects);

        public const string queries = nameof(queries);

        public const string scripts = nameof(scripts);

        public const string samples = nameof(samples);

        public const string settings = nameof(settings);

        public const string src = nameof(src);

        public const string tools = nameof(tools);

        public const string tokens = nameof(tokens);

        public const string tables = nameof(tables);

        public const string sources = nameof(sources);

        public const string sym = nameof(sym);

        public const string win = nameof(win);

        public const string wsl = nameof(wsl);

        public const string xed = nameof(xed);

        public const string envdb = nameof(envdb);

        public const string objhex = obj + dot + hex;
    }
}
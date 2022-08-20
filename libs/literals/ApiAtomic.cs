//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider(api)]
    public readonly struct ApiAtomic
    {
        const string Dot = ".";

        public const string Dash = "-";

        public const string Slash = "/";

        public const string d0 ="0";

        public const string d1 ="1";

        public const string d2 ="2";

        public const string d3 ="3";

        public const string d4 ="4";

        public const string d5 = "5";

        public const string d6 = "6";

        public const string d7 = "7";

        public const string d8 = "8";

        public const string d9 = "9";

        public const string app = nameof(app);

        public const string x32 = nameof(x32);

        public const string x64 = nameof(x64);

        public const string alg = nameof(alg);

        public const string asm = nameof(asm);

        public const string bc = nameof(bc);

        public const string bv = nameof(bv);

        public const string dot = nameof(dot);

        public const string kvp = nameof(kvp);

        public const string log = nameof(log);

        public const string release = nameof(release);

        public const string reloc = nameof(reloc);

        public const string syn = nameof(syn);

        public const string net = nameof(net);

        public const string qualified = "{0}.{1}";

        public const string @default = "default";

        public const string csv = nameof(csv);

        public const string projects = nameof(projects);

        public const string gen = nameof(gen);

        public const string env = nameof(env);

        public const string control = nameof(control);

        public const string contracts = nameof(contracts);

        public const string imports = nameof(imports);

        public const string impl = nameof(impl);
        public const string api = nameof(api);

        public const string bin = nameof(bin);

        public const string cmd = nameof(cmd);

        public const string coff = nameof(coff);

        public const string txt = nameof(txt);

        public const string xml = nameof(xml);

        public const string zip = nameof(zip);

        public const string headers = nameof(headers);

        public const string header = nameof(header);

        public const string builds = nameof(builds);

        public const string build = nameof(build);

        public const string cil = nameof(cil);

        public const string docs = nameof(docs);

        public const string classes = nameof(classes);

        public const string lists = nameof(lists);

        public const string lib = nameof(lib);

        public const string mc = nameof(mc);

        public const string stage = nameof(stage);

        public const string sources = nameof(sources);

        public const string tables = nameof(tables);

        public const string targets = nameof(targets);

        public const string tools = nameof(tools);

        public const string toolset = nameof(toolset);

        public const string status = nameof(status);

        public const string tooling = nameof(tooling);

        public const string help = nameof(help);

        public const string hex = nameof(hex);

        public const string jobs = nameof(jobs);

        public const string map = nameof(map);

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

        public const string tar = nameof(tar);

        public const string gz = nameof(gz);

        public const string extracts = nameof(extracts);

        public const string xed = nameof(xed);

        public const string output = nameof(output);

        public const string dotout = Dot + "out";

        public const string digits = nameof(digits);

        public const string props = nameof(props);

        public const string @decimal = nameof(@decimal);

        public const string binary = nameof(binary);

        public const string octal = nameof(octal);

        public const string input = nameof(input);

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

        public const string current = nameof(current);

        public const string codegen = nameof(codegen);

        public const string dotnet = nameof(dotnet);

        public const string symbols = nameof(symbols);

        public const string limits = nameof(limits);

        public const string images = nameof(images);

        public const string steps = nameof(steps);

        public const string show = nameof(show);

        public const string external = nameof(external);

        public const string manuals = nameof(manuals);

        public const string models = nameof(models);

        public const string labs = nameof(labs);

        public const string obj = nameof(obj);

        public const string exe = nameof(exe);

        public const string cpp = nameof(cpp);

        public const string scripts = nameof(scripts);

        public const string datasets = nameof(datasets);

        public const string imported = nameof(imported);

        public const string bitfields = nameof(bitfields);

        public const string toolbase = nameof(toolbase);

        public const string toolsets = nameof(toolsets);

        public const string common = nameof(common);

        public const string modules = nameof(modules);

        public const string sdm = nameof(sdm);

        public const string intel = nameof(intel);

        public const string config = nameof(config);

        public const string polybits = "polybits";

        public const string detail = nameof(detail);

        public const string enc = nameof(enc);

        public const string mlir = nameof(mlir);

        public const string mir = nameof(mir);

        public const string ll = nameof(ll);

        public const string c = nameof(c);

        public const string cs = nameof(cs);

        public const string csproj = nameof(csproj);

        public const string cfg = nameof(cfg);

        public const string h = nameof(h);

        public const string dat = nameof(dat);

        public const string def = nameof(def);

        public const string dll = nameof(dll);

        public const string deps = nameof(deps);

        public const string dmp = nameof(dmp);

        public const string error = nameof(error);

        public const string lang = nameof(lang);

        public const string i = nameof(i);

        public const string ii = nameof(ii);

        public const string idx = nameof(idx);

        public const string list = nameof(list);

        public const string md = nameof(md);

        public const string pdb = nameof(pdb);

        public const string o = nameof(o);

        public const string obi = nameof(obi);

        public const string ops = nameof(ops);

        public const string sln = nameof(sln);

        public const string ico = nameof(ico);

        public const string bmp = nameof(bmp);
        public const string svg = nameof(svg);

        public const string bitmap = nameof(bitmap);

        public const string sorted = nameof(sorted);

        public const string ps1 = nameof(ps1);

        public const string s = nameof(s);

        public const string sh = nameof(sh);

        public const string statements = nameof(statements);

        public const string sym = nameof(sym);

        public const string sql = nameof(sql);

        public const string summary = nameof(summary);

        public const string semantic = nameof(semantic);

        public const string admin = nameof(admin);

        public const string inventory = nameof(inventory);

        public const string tok = nameof(tok);

        public const string yaml = nameof(yaml);

        public const string bat = nameof(bat);

        public const string bits = nameof(bits);

        public const string inc = nameof(inc);

        public const string include = nameof(include);

        public const string includes = nameof(includes);

        public const string td = nameof(td);

        public const string win = nameof(win);

        public const string ws = nameof(ws);

        public const string xpack = nameof(xpack);

        public const string json = nameof(json);

        public const string xarray = nameof(xarray);

        public const string machine = nameof(machine);

        public const string msil = nameof(msil);

        public const string located = nameof(located);

        public const string queries = nameof(queries);

        public const string tokens = nameof(tokens);

        public const string wsl = nameof(wsl);

        public const string samples = nameof(samples);

        public const string unicode = nameof(unicode);

        public const string utf8 = nameof(utf8);

        public const string utf16 = nameof(utf16);

        public const string asci7 = nameof(asci7);

        public const string llvm = nameof(llvm);

        public const string dev = nameof(dev);

        public const string vars = nameof(vars);

        public const string views = nameof(views);

        public const string records = nameof(records);

        public const string files = nameof(files);

        public const string kinds = nameof(kinds);

        public const string numeric = nameof(numeric);

        public const string bitmasks = nameof(bitmasks);

        public const string perms =  nameof(perms);

        public const string blends = nameof(blends);

        public const string pow2 = nameof(pow2);

        public const string toml = nameof(toml);

        public const string chars = nameof(chars);

        public const string clr = nameof(clr);

        public const string comments = nameof(comments);

        public const string arrangements = nameof(arrangements);

        public const string dis = nameof(dis);

        public const string exports = nameof(exports);

        public const string loadconfig = nameof(loadconfig);

        public const string impl_map = impl + Dot + map;
        public const string disasm = dis + Dot + asm;

        public const string located_hex = located + Dot + hex;

        public const string ildat = il + Dot + csv;

        public const string decimal_digits = @decimal + Dot + digits;

        public const string hex_digits = digits + Dot + hex;

        public const string binary_digits = digits + Dot + binary;

        public const string octal_digits =  octal + Dot + digits;

        public const string api_classes = api + Dot + classes;

        public const string api_contracts = api + Dot + contracts;

        public const string deps_list = deps + Dot + list;

        public const string api_kinds = api + Dot + kinds;

        public const string llvm_mc = llvm + Dot + mc;

        public const string net60 = net + Dot + d6 + Dot + d0;

        public const string net50 = net + Dot + d5 + Dot + d0;

        public const string ildata = il + Dot + csv;

        public const string asmcsv = asm + Dot + csv;

        public const string asmsrc = asm + Dot + src;

        public const string djson = deps + Dot + json;

        public const string dotbuild = Dot + build;

        public const string dotcmd = Dot + cmd;

        public const string cjson = config + Dot + json;

        public const string cildata = nameof(cil) + Dot + data;

        public const string coffheader = coff + Dot + header;

        public const string coffreloc = coff + Dot + reloc;

        public const string coffexports = coff + Dot + exports;

        public const string encasm = enc + Dot + asm;

        public const string hexdat = hex + Dot + dat;

        public const string llasm = ll + Dot + asm;

        public const string llbc = ll + Dot + bc;

        public const string mcasm = mc + Dot + asm;

        public const string opsasm = ops + Dot + asm;

        public const string objasm = obj + Dot + asm;

        public const string objyaml = obj + Dot + yaml;

        public const string objhex = obj + Dot + hex;

        public const string pcsv = CharText.p + Dot + csv;

        public const string sjson = settings + Dot + json;

        public const string synasm = syn + Dot + asm;

        public const string synasmlog = syn + Dot + asm + Dot + log;

        public const string wslogs = ws + Slash + logs;

        public const string win_x64 = win + Dash + x64;

        public const string deps_json = deps + Dot + json;

        public const string xcsv = CharText.x + Dot + csv;

        public const string xeddisasm = xed + Dot + "disasm";

        public const string xeddisasm_raw = xeddisasm + Dot + txt;

        public const string xeddisasm_summary = xeddisasm + Dot + summary + Dot + csv;

        public const string xeddisasm_semantic = xeddisasm + Dot + semantic + Dot + txt;

        public const string xeddisasm_detail = xeddisasm + Dot + detail;

        public const string yamltok = yaml + Dot + tok;

        public const string cmdkvp = cmd + Dot + kvp;
    }
}
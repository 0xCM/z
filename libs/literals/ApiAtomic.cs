//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = System.String;

    [LiteralProvider(api)]
    public readonly struct ApiAtomic
    {
        const string Dot = ".";

        internal const string text = nameof(text);

        public const S Dash = "-";

        public const S Slash = "/";

        public const S d0 ="0";

        public const S d1 ="1";

        public const S d2 ="2";

        public const S d3 ="3";

        public const S d4 ="4";

        public const S d5 = "5";

        public const S d6 = "6";

        public const S d7 = "7";

        public const S d8 = "8";

        public const S d9 = "9";

        public const S app = nameof(app);

        public const S x32 = nameof(x32);

        public const S x64 = nameof(x64);

        public const S alg = nameof(alg);

        public const S asm = nameof(asm);

        public const S bc = nameof(bc);

        public const S bv = nameof(bv);

        public const S dot = nameof(dot);

        public const S kvp = nameof(kvp);

        public const S db = nameof(db);

        public const S log = nameof(log);

        public const S release = nameof(release);

        public const S reloc = nameof(reloc);

        public const S syn = nameof(syn);

        public const S net = nameof(net);

        public const S qualified = "{0}.{1}";

        public const S @default = "default";

        public const S csv = nameof(csv);

        public const S projects = nameof(projects);

        public const S gen = nameof(gen);

        public const S env = nameof(env);

        public const S control = nameof(control);

        public const S contracts = nameof(contracts);

        public const S imports = nameof(imports);

        public const S impl = nameof(impl);
        public const S api = nameof(api);

        public const S bin = nameof(bin);

        public const S cmd = nameof(cmd);

        public const S coff = nameof(coff);

        public const S txt = nameof(txt);

        public const S xml = nameof(xml);

        public const S zip = nameof(zip);

        public const S headers = nameof(headers);

        public const S header = nameof(header);

        public const S builds = nameof(builds);

        public const S build = nameof(build);

        public const S cil = nameof(cil);

        public const S docs = nameof(docs);

        public const S classes = nameof(classes);

        public const S lists = nameof(lists);

        public const S lib = nameof(lib);

        public const S mc = nameof(mc);

        public const S stage = nameof(stage);

        public const S sources = nameof(sources);

        public const S tables = nameof(tables);

        public const S targets = nameof(targets);

        public const S tools = nameof(tools);

        public const S toolset = nameof(toolset);

        public const S status = nameof(status);

        public const S tooling = nameof(tooling);

        public const S help = nameof(help);

        public const S hex = nameof(hex);

        public const S jobs = nameof(jobs);

        public const S map = nameof(map);

        public const S capture = nameof(capture);

        public const S logs = nameof(logs);

        public const S refs = nameof(refs);

        public const S refdata = nameof(refdata);

        public const S reports = nameof(reports);

        public const S events = nameof(events);

        public const S etl = nameof(etl);

        public const S queue = nameof(queue);

        public const S parsed = nameof(parsed);

        public const S il = nameof(il);

        public const S tar = nameof(tar);

        public const S gz = nameof(gz);

        public const S extracts = nameof(extracts);

        public const S xed = nameof(xed);

        public const S output = nameof(output);

        public const S dotout = Dot + "out";

        public const S digits = nameof(digits);

        public const S props = nameof(props);

        public const S @decimal = nameof(@decimal);

        public const S binary = nameof(binary);

        public const S octal = nameof(octal);

        public const S input = nameof(input);

        public const S imm = nameof(imm);

        public const S tmp = nameof(tmp);

        public const S data = nameof(data);

        public const S dumps = nameof(dumps);

        public const S context = nameof(context);

        public const S source = nameof(source);

        public const S src = nameof(src);

        public const S commands = nameof(commands);

        public const S apps = nameof(apps);

        public const S tests = nameof(tests);

        public const S settings = nameof(settings);

        public const S z0 = nameof(z0);

        public const S cases = nameof(cases);

        public const S catalogs = nameof(catalogs);

        public const S current = nameof(current);

        public const S codegen = nameof(codegen);

        public const S dotnet = nameof(dotnet);

        public const S symbols = nameof(symbols);

        public const S limits = nameof(limits);

        public const S images = nameof(images);

        public const S steps = nameof(steps);

        public const S show = nameof(show);

        public const S external = nameof(external);

        public const S manuals = nameof(manuals);

        public const S models = nameof(models);

        public const S labs = nameof(labs);

        public const S obj = nameof(obj);

        public const S exe = nameof(exe);

        public const S cpp = nameof(cpp);

        public const S scripts = nameof(scripts);

        public const S datasets = nameof(datasets);

        public const S imported = nameof(imported);

        public const S bitfields = nameof(bitfields);

        public const S toolbase = nameof(toolbase);

        public const S toolsets = nameof(toolsets);

        public const S common = nameof(common);

        public const S modules = nameof(modules);

        public const S sdm = nameof(sdm);

        public const S intel = nameof(intel);

        public const S config = nameof(config);

        public const S polybits = "polybits";

        public const S detail = nameof(detail);

        public const S enc = nameof(enc);

        public const S mlir = nameof(mlir);

        public const S mir = nameof(mir);

        public const S ll = nameof(ll);

        public const S c = nameof(c);

        public const S cs = nameof(cs);

        public const S csproj = nameof(csproj);

        public const S cfg = nameof(cfg);

        public const S h = nameof(h);

        public const S dat = nameof(dat);

        public const S def = nameof(def);

        public const S dll = nameof(dll);

        public const S deps = nameof(deps);

        public const S dmp = nameof(dmp);

        public const S error = nameof(error);

        public const S lang = nameof(lang);

        public const S i = nameof(i);

        public const S ii = nameof(ii);

        public const S idx = nameof(idx);

        public const S list = nameof(list);

        public const S md = nameof(md);

        public const S pdb = nameof(pdb);

        public const S o = nameof(o);

        public const S obi = nameof(obi);

        public const S ops = nameof(ops);

        public const S sln = nameof(sln);

        public const S ico = nameof(ico);

        public const S bmp = nameof(bmp);
        public const S svg = nameof(svg);

        public const S bitmap = nameof(bitmap);

        public const S sorted = nameof(sorted);

        public const S ps1 = nameof(ps1);

        public const S s = nameof(s);

        public const S sh = nameof(sh);

        public const S statements = nameof(statements);

        public const S sym = nameof(sym);

        public const S sql = nameof(sql);

        public const S summary = nameof(summary);

        public const S semantic = nameof(semantic);

        public const S admin = nameof(admin);

        public const S inventory = nameof(inventory);

        public const S tok = nameof(tok);

        public const S yaml = nameof(yaml);

        public const S bat = nameof(bat);

        public const S bits = nameof(bits);

        public const S inc = nameof(inc);

        public const S include = nameof(include);

        public const S includes = nameof(includes);

        public const S td = nameof(td);

        public const S win = nameof(win);

        public const S interop = nameof(interop);

        public const S ws = nameof(ws);

        public const S xpack = nameof(xpack);

        public const S json = nameof(json);

        public const S xarray = nameof(xarray);

        public const S machine = nameof(machine);

        public const S msil = nameof(msil);

        public const S sized = nameof(sized);
        public const S located = nameof(located);

        public const S queries = nameof(queries);

        public const S tokens = nameof(tokens);

        public const S wsl = nameof(wsl);

        public const S samples = nameof(samples);

        public const S unicode = nameof(unicode);

        public const S utf8 = nameof(utf8);

        public const S utf16 = nameof(utf16);

        public const S asci7 = nameof(asci7);

        public const S llvm = nameof(llvm);

        public const S dev = nameof(dev);

        public const S vars = nameof(vars);

        public const S views = nameof(views);

        public const S records = nameof(records);

        public const S files = nameof(files);

        public const S kinds = nameof(kinds);

        public const S numeric = nameof(numeric);

        public const S bitmasks = nameof(bitmasks);

        public const S perms =  nameof(perms);

        public const S blends = nameof(blends);

        public const S pow2 = nameof(pow2);

        public const S toml = nameof(toml);

        public const S chars = nameof(chars);

        public const S clr = nameof(clr);

        public const S comments = nameof(comments);

        public const S arrangements = nameof(arrangements);

        public const S dis = nameof(dis);

        public const S exports = nameof(exports);

        public const S loadconfig = nameof(loadconfig);

        public const S impl_map = impl + Dot + map;
        public const S disasm = dis + Dot + asm;

        public const S located_hex = located + Dot + hex;

        public const S ildat = il + Dot + csv;

        public const S decimal_digits = @decimal + Dot + digits;

        public const S hex_digits = digits + Dot + hex;

        public const S binary_digits = digits + Dot + binary;

        public const S octal_digits =  octal + Dot + digits;

        public const S api_classes = api + Dot + classes;

        public const S api_contracts = api + Dot + contracts;

        public const S deps_list = deps + Dot + list;

        public const S api_kinds = api + Dot + kinds;

        public const S llvm_mc = llvm + Dot + mc;

        public const S net60 = net + Dot + d6 + Dot + d0;

        public const S net50 = net + Dot + d5 + Dot + d0;

        public const S ildata = il + Dot + csv;

        public const S asmcsv = asm + Dot + csv;

        public const S asmsrc = asm + Dot + src;

        public const S djson = deps + Dot + json;

        public const S dotbuild = Dot + build;

        public const S dotcmd = Dot + cmd;

        public const S cjson = config + Dot + json;

        public const S cildata = nameof(cil) + Dot + data;

        public const S coffheader = coff + Dot + header;

        public const S coffreloc = coff + Dot + reloc;

        public const S coffexports = coff + Dot + exports;

        public const S encasm = enc + Dot + asm;

        public const S hexdat = hex + Dot + dat;

        public const S llasm = ll + Dot + asm;

        public const S llbc = ll + Dot + bc;

        public const S mcasm = mc + Dot + asm;

        public const S opsasm = ops + Dot + asm;

        public const S objasm = obj + Dot + asm;

        public const S objyaml = obj + Dot + yaml;

        public const S objhex = obj + Dot + hex;

        public const S pcsv = CharText.p + Dot + csv;

        public const S sjson = settings + Dot + json;

        public const S synasm = syn + Dot + asm;

        public const S synasmlog = syn + Dot + asm + Dot + log;

        public const S wslogs = ws + Slash + logs;

        public const S win_x64 = win + Dash + x64;

        public const S deps_json = deps + Dot + json;

        public const S xcsv = CharText.x + Dot + csv;

        public const S xeddisasm = xed + Dot + "disasm";

        public const S xeddisasm_raw = xeddisasm + Dot + txt;

        public const S xeddisasm_summary = xeddisasm + Dot + summary + Dot + csv;

        public const S xeddisasm_semantic = xeddisasm + Dot + semantic + Dot + txt;

        public const S xeddisasm_detail = xeddisasm + Dot + detail;

        public const S yamltok = yaml + Dot + tok;

        public const S cmdkvp = cmd + Dot + kvp;
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Z0.CsKeywords;

    [LiteralProvider(api)]
    public readonly struct ApiNameParts
    {
        public const string api = nameof(api);

        public const string asm = nameof(asm);

        public const string bits = nameof(bits);

        public const string blocks = nameof(blocks);

        public const string bitfield = nameof(bitfield);

        public const string bitfields = nameof(bitfields);

        public const string bytes = nameof(bytes);

        public const string chars = nameof(chars);

        public const string @const = Const;

        public const string @char = "char";

        public const string cmd = nameof(cmd);

        public const string core = nameof(core);

        public const string csv = nameof(csv);

        public const string dot = ".";

        public const string dash = "-";

        public const string data = nameof(data);

        public const string delegates = nameof(delegates);

        public const string dynamic = nameof(dynamic);

        public const string expressions = nameof(expressions);

        public const string extensions = nameof(extensions);

        public const string grids = nameof(grids);

        public const string identity = nameof(identity);

        public const string formatters = nameof(formatters);

        public const string functions = nameof(functions);

        public const string fields = nameof(fields);

        public const string hex = nameof(hex);

        public const string stores = nameof(stores);

        public const string kinds = nameof(kinds);

        public const string lang = nameof(lang);

        public const string logic = nameof(logic);

        public const string maps = nameof(maps);

        public const string memory = nameof(memory);

        public const string options = nameof(options);

        public const string operators = nameof(operators);

        public const string operands = nameof(operands);

        public const string projectors = nameof(projectors);

        public const string primal = nameof(primal);

        public const string rows = nameof(rows);

        public const string parts = nameof(parts);

        public const string parser = nameof(parser);

        public const string resources = nameof(resources);

        public const string sfunc = nameof(sfunc);

        public const string stream = nameof(stream);

        public const string surrogates = nameof(surrogates);

        public const string store = nameof(store);

        public const string source = nameof(source);

        public const string sources = nameof(sources);

        public const string services = nameof(services);

        public const string specs = nameof(specs);

        public const string symbolic = nameof(symbolic);

        public const string scalar = nameof(scalar);

        public const string query = nameof(query);

        public const string text = nameof(text);

        public const string tables = nameof(tables);

        public const string wf = nameof(wf);

        public const string u1 = nameof(u1);

        public const string u2 = nameof(u2);

        public const string u3 = nameof(u3);

        public const string u4 = nameof(u4);

        public const string u5 = nameof(u5);

        public const string u6 = nameof(u6);

        public const string u7 = nameof(u7);

        public const string u8 = nameof(u8);

        public const string u16 = nameof(u16);

        public const string u32 = nameof(u32);

        public const string u64 = nameof(u64);

        public const string octets = nameof(octets);

        public const string cells = nameof(cells);

        public const string buffers = nameof(buffers);

        public const string catalogs = nameof(catalogs);

        public const string clr = nameof(clr);

        public const string runtime = nameof(runtime);

        public const string records = nameof(records);

        public const string type = nameof(type);

        public const string property = nameof(property);

        public const string field = nameof(field);

        public const string method = nameof(method);

        public const string types = nameof(types);

        public const string assembly = nameof(assembly);

        public const string literal = nameof(literal);

        public const string primitives = nameof(primitives);

        public const string datatypes = nameof(datatypes);

        public const string encoders = nameof(encoders);

        public const string archives = nameof(archives);

        public const string msg = nameof(msg);

        public const string errors = nameof(errors);

        public const string artifacts = nameof(artifacts);

        public const string db = nameof(db);

        public const string files = nameof(files);

        public const string sigs = nameof(sigs);

        public const string shell = nameof(shell);

        public const string events = nameof(events);

        public const string app = nameof(app);

        public const string identify = nameof(identify);

        public const string lookups = nameof(lookups);

        public const string enums = nameof(enums);

        public const string refs = nameof(refs);

        public const string tools = nameof(tools);

        public const string strings = nameof(strings);

        public const string reader = nameof(reader);

        public const string workflow = nameof(workflow);

        public const string symbols = nameof(symbols);

        public const string part = nameof(part);

        public const string literals = nameof(literals);

        public const string scalars = nameof(scalars);

        public const string tuples = nameof(tuples);

        public const string hosts = nameof(hosts);

        public const string digits= nameof(digits);

        public const string asci = nameof(asci);

        public const string permutations = nameof(permutations);

        public const string bitlogic = bits + dot + logic;

        public const string copy = nameof(copy);

        public const string view = nameof(view);

        public const string typed = nameof(typed);

        public const string pointers = nameof(pointers);

        public const string relations = nameof(relations);

        public const string workers = nameof(workers);

        public const string paths = nameof(paths);

        public const string parsers = nameof(parsers);

        public const string cases = nameof(cases);

        public const string states = nameof(states);

        public const string unmanaged = nameof(unmanaged);

        public const string segments = nameof(segments);

        public const string logs = nameof(logs);

        public const string vex = nameof(vex);

        public const string numeric = nameof(numeric);

        public const string arrays = nameof(arrays);

        public const string widths = nameof(widths);

        public const string ops = nameof(ops);

        public const string control = nameof(control);

        public const string tests = nameof(tests);

        public const string test = nameof(test);

        public const string reflector = nameof(reflector);

        public const string spans = nameof(spans);

        public const string models = nameof(models);

        public const string collective = nameof(collective);

        public const string indexed = nameof(indexed);

        public const string slots = nameof(slots);

        public const string fp = nameof(fp);

        public const string reflex = nameof(reflex);

        public const string seq = nameof(seq);

        public const string linq = nameof(linq);

        public const string external = nameof(external);

        public const string system = nameof(system);

        public const string emit = nameof(emit);

        public const string opcodes = nameof(opcodes);

        public const string reflection = nameof(reflection);

        public const string builder = nameof(builder);

        public const string handles = nameof(handles);

        public const string reflect = nameof(reflect);

        public const string metadata = nameof(metadata);

        public const string listings = nameof(listings);

        public const string member = nameof(member);

        public const string identities = nameof(identities);

        public const string svc = nameof(svc);

        public const string utf8 = nameof(utf8);

        public const string n256 = nameof(n256);

        public const string cache = nameof(cache);

        public const string sets = nameof(sets);

        public const string grid = nameof(grid);

        public const string metrics = nameof(metrics);

        public const string jit = nameof(jit);

        public const string codes = nameof(codes);

        public const string io = nameof(io);

        public const string machines = nameof(machines);

        public const string registers = nameof(registers);

        public const string syntax = nameof(syntax);

        public const string parse = nameof(parse);

        public const string patterns = nameof(patterns);

        public const string json = nameof(json);

        public const string binary = nameof(binary);

        public const string unary = nameof(unary);

        public const string ternary = nameof(ternary);

        public const string close = nameof(close);

        public const string partition = nameof(partition);

        public const string generic = nameof(generic);

        public const string math = nameof(math);

        public const string checks = nameof(checks);

        public const string structured = nameof(structured);

        public const string algorithms = nameof(algorithms);

        public const string factories = nameof(factories);

        public const string cs = nameof(cs);

        public const string render = nameof(render);

        public const string cil = nameof(cil);

        public const string rules = nameof(rules);

        public const string fs = nameof(fs);

        public const string map = nameof(map);

        public const string flow = nameof(flow);

        public const string flows= nameof(flows);

        public const string links = nameof(links);

        public const string nodes = nameof(nodes);

        public const string scripts = nameof(scripts);

        public const string init = nameof(init);

        public const string format = nameof(format);

        public const string calls = nameof(calls);

        public const string router = nameof(router);

        public const string routes = nameof(routes);

        public const string actions = nameof(actions);

        public const string operations = nameof(operations);

        public const string unsigned = nameof(unsigned);

        public const string integers = nameof(integers);

        public const string ui = unsigned + dot + integers;

        public const string vectors = nameof(vectors);

        public const string fx = nameof(fx);

        public const string n16 = nameof(n16);

        public const string x8 = nameof(x8);

        public const string check = nameof(check);

        public const string outcomes = nameof(outcomes);

        public const string semantic = nameof(semantic);

        public const string archive = nameof(archive);
    }
}
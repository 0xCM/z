//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static Markdown;
    using static sys;

    partial class XedChecks
    {
        [CmdOp("xed/db/check")]
        void CheckMemDb()
        {
            CheckMemDb((32,32));
            CheckMemDb((12,12));
            CheckMemDb((8,8));
            CheckMemDb((256,256));

            var size = 1073741824ul;
            var mb = size/1024;
            var db = Xed.XedDb.Store;

            var src = XedDb.InstDumpFile();
            var data = src.View();
            var token = db.Store(data);
        }

        void CheckMemDb(Dim2<uint> shape)
        {
            var r = shape.I;
            var c = shape.J;
            var m = (uint)(r*c);
            var grid = MemDb.grid<byte>(shape);
            ref readonly var rows = ref grid.Rows;
            for(var i=0u; i<r; i++)
            {
                for(var j=0u; j<c; j++)
                    rows[i,j] = (byte)math.mod((i*c + j), r) ;
            }

            var cols = rows.Columns();
            var rDst = text.emitter();
            var cDst = text.emitter();

            for(var i=0u; i<r; i++)
            {
                for(var j=0u; j<c; j++)
                {
                    rDst.AppendFormat("{0:X2} | ", rows[i,j]);
                    cDst.AppendFormat("{0:X2} | ", cols[i,j]);
                }

                rDst.AppendLine();
                cDst.AppendLine();
            }

            var linear = Points.multilinear(shape);
            var lDst = text.emitter();
            Points.render(linear, lDst);

            var scope = "memdb";
            var suffix = $"{r}x{c}";
            FileEmit(lDst.Emit(), linear.Count, AppDb.Logs().Targets(scope).Path($"{scope}.linear.{suffix}", FileKind.Csv));
            FileEmit(rDst.Emit(), m, AppDb.Logs().Targets(scope).Path($"{scope}.rows.{suffix}", FileKind.Txt), TextEncodingKind.Asci);
            FileEmit(cDst.Emit(), m, AppDb.Logs().Targets(scope).Path($"{scope}.cols.{suffix}", FileKind.Txt), TextEncodingKind.Asci);
        }

        public void CheckRules()
        {
           CheckRuleNames();
           CheckInstDefs();
        }

        void CheckInstDefs()
        {
            var a = "0x83 MOD[mm] MOD!=3 REG[0b010] RM[nnn] MODRM() SIMM8() LOCK=0";
            InstParser.parse(a, out var body);
            var dst = text.emitter();
            for(var i=0; i<body.CellCount; i++)
            {
                ref readonly var cell = ref body[i];
                if(i != 0)
                    dst.Append(Chars.Space);
                dst.Append(cell.Format());
            }
            Write(dst.Emit());
        }

        static void collect(in CellTable src, out HashSet<FieldKind> left, out HashSet<FieldKind> right)
        {
            ref readonly var rows = ref src.Rows;
            left = new();
            right = new();
            for(var i=0; i<rows.Count; i++)
            {
                ref readonly var row = ref rows[i];
                var antecedants = row.Antecedants();
                for(var j=0; j<antecedants.Length; j++)
                {
                    ref readonly var antecedant = ref skip(antecedants,j);
                    if(antecedant.Field != 0)
                        left.Include(antecedant.Field);
                }

                var consequents = row.Consequents();
                for(var j=0; j<consequents.Length; j++)
                {
                    ref readonly var consequent = ref skip(consequents,j);
                    if(consequent.Field != 0)
                        right.Include(consequent.Field);
                }
            }
        }

        SectionHeader header(RuleCaller target)
        {
            var rule = target.ToRule();
            return new(3,rule.Format());
        }

        void Emit(Index<NontermCall> calls)
        {
            var dst = text.buffer();
            var source = RuleCaller.Empty;
            for(var i=0; i<calls.Count; i++)
            {
                ref readonly var call = ref calls[i];
                if(source.IsEmpty)
                {
                    source = call.Source;
                    dst.AppendLine(header(source));
                    dst.AppendLine();
                }

                if(source != call.Source)
                {
                    dst.AppendLine();
                    source = call.Source;
                    dst.AppendLine(header(source));
                    dst.AppendLine();
                }

                dst.AppendLine(XedPaths.MarkdownLink(call.Target));
            }

            FileEmit(dst.Emit(), calls.Count, XedPaths.DbTarget("rules.tables.deps", FileKind.Md));
        }

        void CheckRuleNames()
        {
            const uint RuleCount = RuleNames.MaxCount;
            var src = Symbols.index<RuleName>();
            var names = src.Kinds;
            for(var i=0; i<names.Length; i++)
            {
                var name = names[i];
                if((ushort)name != i)
                    Errors.Throw(name);
            }
            Require.equal(RuleCount, (uint)names.Length);

            var dst = RuleNames.init(names);
            var buffer = alloc<RuleName>(RuleCount);
            var count = Require.equal(dst.Members(buffer), (uint)names.Length);

            for(var i=0; i<count; i++)
            {
                ref readonly var name = ref skip(names,i);
                if(!dst.Contains(name))
                    Errors.Throw($"{name} is missing");
            }

            var smaller = slice(names,100,150);
            dst.Clear();
            dst.Include(smaller);
            for(var i=0; i<RuleNames.MaxCount; i++)
            {
                var min = skip(smaller,0);
                var max = skip(smaller,smaller.Length - 1);
                var kind = (RuleName)i;
                if(kind != 0)
                {
                    if(kind >= min & kind<= max)
                        Require.invariant(dst.Contains(kind));
                    else
                        Require.invariant(!dst.Contains(kind));
                }
            }
        }
    }
}
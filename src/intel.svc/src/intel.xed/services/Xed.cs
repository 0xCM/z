//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;    
    using static XedModels;
    using static XedRules;

    public partial class Xed : WfSvc<Xed>
    {
        public static Index<FieldUsage> fields(CellTables src)
        {
            var buffer = sys.bag<FieldUsage>();
            iter(src.View, table => collect(table,buffer),true);
            return buffer.Index().Sort();
        }

        static void collect(in CellTable src, ConcurrentBag<FieldUsage> dst)
        {
            ref readonly var rows = ref src.Rows;
            var usage = hashset<FieldUsage>();
            var sig = src.Sig;
            for(var i=0; i<rows.Count; i++)
            {
                ref readonly var row = ref rows[i];
                var antecedants = row.Antecedants();
                for(var j=0; j<antecedants.Length; j++)
                {
                    ref readonly var antecedant = ref skip(antecedants,j);
                    if(antecedant.Field != 0)
                        usage.Add(FieldUsage.left(sig, antecedant.Field));
                }

                var consequents = row.Consequents();
                for(var j=0; j<consequents.Length; j++)
                {
                    ref readonly var consequent = ref skip(consequents,j);
                    if(consequent.Field != 0)
                        usage.Add(FieldUsage.right(sig, consequent.Field));
                }
            }

            iter(usage, u => dst.Add(u));
        }
         
        public static Index<RuleTableBlock> blocks(RuleTableKind kind)
        {
            var src = XedPaths.Service.RuleSource(kind);
            var lines = src.ReadNumberedLines();
            var offsets = list<LineNumber>();
            var names = list<string>();
            for(var i=0u; i<lines.Count; i++)
            {
                ref readonly var line = ref lines[i];
                var data = text.trim(text.despace(line.Content));
                if(text.empty(data) || text.begins(data, Chars.Hash))
                    continue;

                var j = text.index(data,Chars.Hash);
                var content = (j > 0 ? text.left(data,j) : data).Trim();
                if(text.ends(content,"()::"))
                {
                    var k = text.index(content, Chars.LParen);
                    var name = text.left(content,k);
                    names.Add(name.Remove("xed_reg_enum_t").Trim());
                    offsets.Add(line.LineNumber);
                }
            }

            var dst = alloc<RuleTableBlock>(names.Count);
            var pos = 0;
            var view = lines.View;
            for(var i=0; i<names.Count; i++)
            {
                var name = names[i];
                var i0 = offsets[i];
                ref var target = ref seek(dst,i);
                if(i < names.Count - 1)
                {
                    var i1 = offsets[i+1];
                    var seg = sys.segment(view, i0, i1 - 1);
                    var parts = list<TextLine>();
                    for(var j=0; j<seg.Length; j++)
                    {
                        ref readonly var line = ref skip(seg,j);
                        var part = text.trim(text.despace(line.Content));
                        if(text.empty(part) || text.begins(part,Chars.Hash) || text.ends(part, "::") || text.ends(part, "()") || text.begins(part, "SEQUENCE "))
                            continue;

                        var k = text.index(part,Chars.Hash);
                        if(k>0)
                            parts.Add((line.LineNumber,text.left(part,k)));
                        else
                            parts.Add((line.LineNumber,part));
                    }
                    target = new RuleTableBlock(kind, name, i0, parts.ToArray());
                }
                else
                {
                    var seg = sys.slice(view, i0);
                    var parts = list<TextLine>();
                    for(var j=0; j<seg.Length; j++)
                    {
                        ref readonly var line = ref skip(seg,j);
                        var part = text.trim(text.despace(line.Content));
                        if(text.empty(part) || text.begins(part,Chars.Hash))
                            continue;
                        parts.Add((line.LineNumber,part));
                    }
                    target = new RuleTableBlock(kind, name, i0, parts.ToArray());
                }
            }

            return dst.Sort();
        }
         
        public static void chips(Action<ChipMap> dst)
            => dst(CalcChipMap());

        static ChipMap CalcChipMap()
        {
            var kinds = Symbols.index<InstIsaKind>();
            var src = XedPaths.Service.ChipMapSource();
            var chip = ChipCode.INVALID;
            var chips = dict<ChipCode,ChipIsaKinds>();
            using var reader = src.LineReader(TextEncodingKind.Asci);
            while(reader.Next(out var line))
            {
                if(line.StartsWith(Chars.Hash))
                    continue;

                var i = line.Index(Chars.Colon);
                if(i != -1)
                {
                    var name = line.Left(i).Trim();
                    if(blank(name))
                        continue;

                    if(XedParsers.parse(name, out chip))
                    {
                        if(!chips.TryAdd(chip, new ChipIsaKinds(chip)))
                            Errors.Throw(Msg.DuplicateChipCode.Format(chip));
                    }
                    else
                        Errors.Throw(Msg.ChipCodeNotFound.Format(name));
                }
                else
                {
                    var isaKinds = line.Content.SplitClean(Chars.Tab).Trim().Select(x => Enums.parse<InstIsaKind>(x,0)).Where(x => x != 0).Array();
                    chips[chip].Add(isaKinds);
                    if(chips.TryGetValue(chip, out var entry))
                        entry.Add(isaKinds);
                }
            }
            var codes = Symbols.index<ChipCode>();
            var buffer = dict<ChipCode,InstIsaKinds>();
            for(var i=0; i<codes.Count; i++)
            {
                var code = codes[i].Kind;
                if(chips.TryGetValue(code, out var entry))
                    buffer[code] = entry.Kinds;
                else
                    buffer[code] = XedModels.InstIsaKinds.Empty;
            }
            return new ChipMap(buffer);
        }
    }
}
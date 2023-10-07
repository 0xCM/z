//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static sys;

public class XedZ
{
    public sealed class BlockDomain : Dictionary<string,HashSet<RuleAttribute>>
    {
        public readonly Dictionary<XedFormType,FormRules> Rules = new();

        public string Format()
        {
            var dst = text.emitter();
            foreach(var name in Keys.Array().Sort())
            {
                switch(name)
                {
                    case BlockFieldNames.opcode_base10:
                    case BlockFieldNames.comment:
                        break;
                    default:
                    {
                        var values = this[name].Map(x => x.Value).Sort();
                        dst.AppendLine($"{name}:["); 
                        foreach(var value in values)
                        {
                            dst.AppendLine($"    {value},");
                        }
                        dst.AppendLine("],");

                    }
                    break;
                }
            }
            return dst.Emit();
        }
    }

    public static BlockDomain domain(XedRuleBlocks src)
    {
        var imports = src.Imports;
        var domain = new BlockDomain();
        var counter = 0u;
        iter(imports, import => {            
            var block = src.FormBlocks[import.Form];
            if(parse(import.Form, block, out FormRules rules))
            {
                domain.Rules.TryAdd(import.Form, rules);
                foreach(var rule in rules.Rules)
                {
                    if(rule is RuleAttribute a)
                    {
                        if(domain.TryGetValue(a.Name, out var _values))
                            _values.Add(a);
                        else
                            domain[a.Name] = hashset(a);
                    }
                }
            }

            if(block.Count != rules.Rules.Count)
                @throw("block.Count != _rules.Rules.Count");
        });

        return domain;        
    }

    public static bool parse(string src, out AsmOpCodeClass dst)
    {
        dst = src switch {
            "evex" => AsmOpCodeClass.Evex,
            "vex" => AsmOpCodeClass.Vex,
            "xop" => AsmOpCodeClass.Xop,
            _ => AsmOpCodeClass.Legacy
        };
        return true;
    }
    
    public static bool parse(XedInstForm form, List<string> lines, out FormRules dst)
    {
        dst = new(form);
        foreach(var line in lines)
        {
            var i = text.index(line, Chars.Colon);
            if(i>=0)
            {
                var name = text.left(line,i);
                var value = text.trim(text.right(line,i));
                switch(name)
                {
                    case BlockFieldNames.pattern:
                    case BlockFieldNames.operands:
                    {
                        var parts = text.trim(text.split(value, Chars.Space));
                        dst.Rules.Add(new Vector(name,parts));
                    }                    
                    break;
                    case BlockFieldNames.flags:
                    {
                        var m = text.index(value,Chars.LBracket);
                        var n = text.index(value,Chars.RBracket);
                        if(m > 0 && n > m)
                        {
                            var parts = text.trim(text.split(text.inside(value,m,n),Chars.Space));
                            dst.Rules.Add(new List(name,parts));
                        }
                    }
                    break;
                    case BlockFieldNames.attributes:
                        dst.Rules.Add(new List(name,text.trim(text.split(value, Chars.Space))));
                    break;
                    default:
                    {
                        if(nonempty(value))
                        {

                            if(value[0] == Chars.LBracket && value[value.Length - 1] == Chars.RBracket)
                                dst.Rules.Add(new List(name,text.trim(text.split(text.inside(value,0, value.Length - 1), Chars.Comma))));
                            else
                                dst.Rules.Add(new RuleAttribute(name,value));
                        }
                        else
                        {
                            dst.Rules.Add(new RuleAttribute(name,EmptyString));
                        }        
                    }
                    break;
                }
            }
        }
        
        return true;
    }

    public abstract class FormRule
    {
        public readonly string Name;

        protected FormRule(string name)
        {
            Name = name;
        }

        public abstract string Format();

        public override string ToString()
            => Format();
    }

    public class RuleAttribute : FormRule, IEquatable<RuleAttribute>, IComparable<RuleAttribute>
    {
        public readonly string Value;

        public RuleAttribute(string name, string value)
            : base(name)
        {
            Value = value;
        }

        public Hash32 Hash
        {
            get => hash(Name) | hash(Value);
        }
        
        public override int GetHashCode()
            => Hash;

        public override string Format()
            => $"{Name}: {Value}";

        public override string ToString()
            => Format();

        public int CompareTo(RuleAttribute src)
        {
            var result = Name.CompareTo(src.Name);
            if(result == 0)
                result = Value.CompareTo(src.Value);
            return result;
        }

        public bool Equals(RuleAttribute src)
            => Name == src.Name && Value == src.Value;

        public override bool Equals(object src)
            => src is RuleAttribute x && Equals(x);
    }

    public abstract class Sequence : FormRule
    {
        public readonly List<string> Terms = new();

        protected Sequence(string name, params string[] terms)
            : base(name)
        {
            Terms.AddRange(terms);
        }

        protected abstract Fence<char> Boundary {get;}

        public override string Format()
        {
            var dst = text.emitter();
            dst.Append($"{Name}: {Boundary.Left}");
            for(var i=0; i<Terms.Count; i++)
            {
                if(i != 0)
                    dst.Append(", ");
                dst.Append($"{Terms[i]}");
            }
            dst.Append(Boundary.Right);

            return dst.Emit();
        }
    }

    public class Vector : Sequence
    {
        public Vector(string name)
            : base(name)
        {
        }        

        public Vector(string name, string[] terms)
            : base(name, terms)
        {
        }

        protected override Fence<char> Boundary => ('<', '>');
    }
    
    public class List : Sequence
    {
        public List(string name, string[] terms)
            : base(name, terms)
        {
        }        
        
        protected override Fence<char> Boundary => ('[', ']');
    }

    public record FormRules
    {
        public readonly XedInstForm Form;

        public readonly List<FormRule> Rules;

        public FormRules(XedInstForm form)
        {
            Form = form;
            Rules = new();
        }
    }

    public readonly record struct Attribute
    {
        public readonly InstBlockField Field;

        public readonly string Value;

        public Attribute(InstBlockField name, string value)
        {
            Field = name;
            Value = value;
        }

        public bool IsNonEmpty
        {
            get => Field != 0 || nonempty(Value);
        }
        public static Attribute Empty => new(default,EmptyString);
    }

    public static bool parse(string src, out Attribute dst)
    {
        var i = text.index(src,Chars.Colon);
        if(i > 0)
        {
            var name = text.trim(text.left(src,i));
            var value = text.trim(text.right(src,i));
            XedParsers.parse(name, out InstBlockField field);
            dst = new(field, value);
        }
        else
            dst = Attribute.Empty;
        return dst.IsNonEmpty;
    }

    public static XedRuleBlocks rules(FilePath path)
    {
        using var src = MemoryFiles.map(path);
        var stats = AsciLines.stats(src.Bytes, 400000);
        var dst = new XedRuleBlocks();
        var ds = new BlockImportDatasets();
        var lines = Lines.lines(src);
        CalcBlockLines(lines, ds);
        CalcDatasets(lines, ds);
        dst.Stats = stats.ToArray();
        dst.BlockLines = ds.BlockLines;
        dst.LineMap = ds.MappedForms;
        dst.Imports = ds.BlockImports.Index().Sort().Resequence();
        var fds = forms(ds);
        dst.FormBlocks = fds.Descriptions;
        dst.FormHeaders = fds.Headers;
        dst.Forms = fds.Sorted;
        return dst;
    }

    public static void emit(IWfChannel channel, XedRuleBlocks src)
    {
        exec(true,
            () => EmitRecords(channel,src),
            () => EmitBlockDetail(channel, src),
            () => EmitLineMap(channel, src),
            () => EmitStats(channel, src.Stats));
    }

    static void EmitStats(IWfChannel channel, ReadOnlySpan<LineStats> src)
        => Emit(channel, src);

    static void EmitLineMap(IWfChannel channel, XedRuleBlocks src)
        => EmitLineMap(channel, src.LineMap);

    static void Emit(IWfChannel channel, ReadOnlySpan<LineStats> src)
        => AsciLines.emit(src, XedPaths.Imports().Path("xed.instblocks.stats", FileKind.Csv));

    static void EmitRecords(IWfChannel channel, XedRuleBlocks src)
    {
        channel.TableEmit(src.Imports, XedPaths.Imports().Table<InstBlockImport>());
        var file = FS.file($"{CsvTables.filename<InstBlockImport>().WithoutExtension.Format()}.duplicates", FS.Csv);
        channel.TableEmit(src.Duplicates, XedPaths.Imports().Path(file));
    }

    static void EmitBlockDetail(IWfChannel channel, XedRuleBlocks src)
    {
        var path = XedPaths.Imports().Path("xed.instblocks.detail", FileKind.Txt);
        var emitter = text.emitter();
        var forms = src.Forms.Keys;
        var count = forms.Length;
        for(var i=0; i<count; i++)
        {
            ref readonly var form = ref skip(forms,i);
            if(form.IsEmpty)
                continue;

            emitter.AppendLine(src.Header(form));
            emitter.WriteLine(RP.PageBreak120);
            foreach(var line in src.Description(form))
                emitter.AppendLine(line);
            emitter.WriteLine();
        }
        channel.FileEmit(emitter.Emit(), count, path);
    }

    static void EmitLineMap(IWfChannel channel, LineMap<InstBlockLineSpec> data)
    {
        const string Pattern = "{0,-6} | {1,-12} | {2,-12} | {3,-12} | {4,-12} | {5,-6} | {6,-64} | {7}";
        var dst = XedPaths.Imports().Table<InstBlockLineSpec>();
        var formatter = CsvTables.formatter<InstBlockLineSpec>();
        var emitting = channel.EmittingTable<InstBlockLineSpec>(dst);
        using var writer = dst.AsciWriter();
        writer.WriteLine(formatter.FormatHeader());
        for(var i=0u; i<data.IntervalCount; i++)
            writer.WriteLine(formatter.Format(data[i].Id));
        channel.EmittedTable(emitting, data.IntervalCount);
    }

    static FormImportDatasets forms(BlockImportDatasets src, bool pll = true)
    {
        var dst = new FormImportDatasets();
        var keys = src.FormData.Keys.Index().Sort();
        var forms = dict<XedInstForm,uint>();
        for(var i=0u; i<keys.Count; i++)
            forms[keys[i]] = i;
        dst.Sorted = forms;
        iter(keys, form => dst.Include(form, src), pll);
        return dst;
    }

    static bool split(string src, out string name, out string value)
    {
        var result = false;
        var i = text.index(src,Chars.Colon);
        if(i > 0)
        {
            name = text.trim(text.left(src,i));
            value = text.trim(text.right(src,i));
            result = true;
        }
        else
        {
            name = EmptyString;
            value = EmptyString;
        }
        return result;
    }

    public static void BlockLines(FilePath path, Action<InstBlockLineSpec> dst)
    {
        using var src = MemoryFiles.map(path);
        BlockLines(Lines.lines(src), dst);        
    }

    static void BlockLines(ReadOnlySpan<string> src, Action<InstBlockLineSpec> dst)
    {
        const string FirstItemMarker = "amd_3dnow_opcode:";
        const string LastItemMarker = "EOSZ_LIST:";
        const string Pattern = "{0,-6} | {1,-6} | {2,-6} | {3,-6} | {4,-64}";
        const string IFormMarker = "iform:";
        var fields = InstBlockLineSpec.Empty;
        var buffer = list<LineInterval<InstBlockLineSpec>>();
        var form = XedInstForm.Empty;
        var name = EmptyString;
        var value = EmptyString;
        var field = InstBlockField.amd_3dnow_opcode;
        var counter = 0u;
        var min = 0u;
        var seq = 0u;

        for(var i=0u; i<src.Length; i++)
        {
            var line = text.trim(skip(src,i));
            counter += (uint)line.Length;
            if(split(line, out name, out value))
            {
                if(XedParsers.parse(name, out field))
                    fields.Fields[field] = bit.On;
            }
            if(text.begins(line,FirstItemMarker))
                fields.MinLine = i;
            else if(text.begins(line, LastItemMarker))
            {
                fields.MaxLine = i;
                fields.MinChar = min;
                fields.MaxChar = counter;
                fields.Seq = seq++;
                fields.LineCount = fields.MaxLine - fields.MinLine + 1;
                fields.Lines = slice(src,fields.MinLine, fields.LineCount).ToArray();
                dst(fields);
                fields = InstBlockLineSpec.Empty;
                min = counter+1;
            }
            else
            {
                var j = text.index(line,IFormMarker);
                if(j >= 0)
                    XedParsers.parse(value, out fields.Form);
            }
        }
    }

    static void CalcBlockLines(ReadOnlySpan<string> src, BlockImportDatasets dst)
    {
        const string FirstItemMarker = "amd_3dnow_opcode:";
        const string LastItemMarker = "EOSZ_LIST:";
        const string Pattern = "{0,-6} | {1,-6} | {2,-6} | {3,-6} | {4,-64}";
        const string IFormMarker = "iform:";
        var fields = InstBlockLineSpec.Empty;
        var buffer = list<LineInterval<InstBlockLineSpec>>();
        var form = XedInstForm.Empty;
        var name = EmptyString;
        var value = EmptyString;
        var field = InstBlockField.amd_3dnow_opcode;
        var counter = 0u;
        var min = 0u;
        var seq = 0u;

        for(var i=0u; i<src.Length; i++)
        {
            var line = text.trim(skip(src,i));
            counter += (uint)line.Length;
            if(split(line, out name, out value))
            {
                if(XedParsers.parse(name, out field))
                    fields.Fields[field] = bit.On;
            }
            if(text.begins(line,FirstItemMarker))
                fields.MinLine = i;
            else if(text.begins(line, LastItemMarker))
            {
                fields.MaxLine = i;
                fields.MinChar = min;
                fields.MaxChar = counter;
                fields.Seq = seq++;
                fields.LineCount = fields.MaxLine - fields.MinLine + 1;
                dst.BlockLines.Add(fields);
                buffer.Add(new LineInterval<InstBlockLineSpec>(fields, fields.MinLine, fields.MaxLine));
                fields = InstBlockLineSpec.Empty;
                min = counter+1;
            }
            else
            {
                var j = text.index(line,IFormMarker);
                if(j >= 0)
                    XedParsers.parse(value, out fields.Form);
            }
        }

        dst.MappedForms = buffer.ToArray();
    }
    
    static void absorb(Attribute src, ref InstBlockImport dst)
    {
        switch(src.Field)
        {
            
            case InstBlockField.iclass:
                XedParsers.parse(src.Value, out dst.Class);
            break;
            case InstBlockField.opcode:
                HexParser.parse(src.Value, out dst.OpCodeValue);
            break;
            case InstBlockField.space:
                parse(src.Value, out dst.OpCodeClass);
            break;
            case InstBlockField.map:
                DataParser.parse(src.Value, out dst.OpCodeMap);
            break;

            case InstBlockField.pattern:
            {
                try
                {
                    XedInstParser.parse(src.Value, out dst.Pattern);
                    dst.Pattern = new (XedCells.sort(dst.Pattern.Cells));
                    XedPatterns.mode(dst.Pattern, out dst.Mode);
                }
                catch(Exception e)
                {
                    term.warn(e.Message);
                }
            }
            break;
        }
    }
    
    static void CalcDatasets(ReadOnlySpan<string> src, BlockImportDatasets dst)
    {
        var map = dst.MappedForms;
        var k=0u;
        for(var i=0u; i<map.IntervalCount; i++)
        {
            ref readonly var range = ref map[i];
            var spec = range.Id;
            var form = spec.Form;
            var import = InstBlockImport.Empty;
            import.Form = form;
            import.Seq = i;
            var lines = list<string>();
            for(var m =0; m<range.LineCount; m++)
            {
                ref readonly var line = ref skip(src,k++);
                lines.Add(line);

                parse(line, out Attribute attrib);
                absorb(attrib, ref import);
            }
            import.OpCodeKind = AsmOpCodes.kind(import.OpCodeClass, import.OpCodeMap);
            dst.BlockImports.Add(import);
            dst.FormData.TryAdd(form, lines);
        }
    }

    public class XedRuleBlocks
    {
        public ReadOnlySeq<LineStats> Stats = sys.empty<LineStats>();

        public SortedLookup<XedInstForm,uint> Forms = dict<XedInstForm,uint>();

        public Index<InstBlockImport> Imports = sys.empty<InstBlockImport>();

        public Index<InstBlockImport> Duplicates = sys.empty<InstBlockImport>();

        public InstBlockLines BlockLines = new();

        public LineMap<InstBlockLineSpec> LineMap = new();

        public ConcurrentDictionary<XedInstForm,List<string>> FormBlocks = new();

        public ConcurrentDictionary<XedInstForm,string> FormHeaders = new();

        public XedRuleBlocks()
        {

        }

        public List<string> Description(XedInstForm form)
            => FormBlocks[form];

        public string Header(XedInstForm form)
            => FormHeaders[form];

        public static XedRuleBlocks Empty => new();
    }

    class FormImportDatasets
    {
        public ConcurrentDictionary<XedInstForm,List<string>> Descriptions = new();

        public ConcurrentDictionary<XedInstForm,string> Headers = new();

        public SortedLookup<XedInstForm,uint> Sorted;

        public void Include(XedInstForm form, BlockImportDatasets src)
        {
            if(form.IsNonEmpty)
            {
                var line = src.BlockLines[form];
                var dst = InstBlockImport.Empty;
                var content = src.FormData[form];
                var seq = Sorted[form];
                Descriptions[form] = content;
                Headers[form] = string.Format("{0,-64} | {1:D5} | {2:D2} | {3:D6} | {4:D6}", form, seq, line.LineCount, line.MinLine, line.MaxLine);
            }
        }
    }

    class BlockImportDatasets
    {
        public LineMap<InstBlockLineSpec> MappedForms = new();

        public InstBlockLines BlockLines = new();

        public ConcurrentBag<InstBlockImport> BlockImports = new();

        public ConcurrentDictionary<XedInstForm,List<string>> FormData = new();
     }
}

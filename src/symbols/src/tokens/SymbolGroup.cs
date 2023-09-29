//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

using static sys;

public class SymbolGroup
{
    public readonly string GroupName;

    readonly Type[] _SymbolTypes;

    public readonly Type ClassType;        

    readonly Dictionary<Type,SymIndex> _IndexLookup = new();

    readonly Dictionary<Type,string> _ClassName = new();

    uint Seq;

    public SymbolGroup(Type classifier, Type[] symtypes)
    {
        ClassType = classifier;
        _SymbolTypes = symtypes;
        var indices = Z0.Symbols.indices(_SymbolTypes);
        foreach(var index in indices)
            _IndexLookup[index.RuntimeType] = index;
        foreach(var type in _SymbolTypes)
            _ClassName[type] = type.Tag<TokenKindAttribute>().MapValueOrElse(a => a.Kind.ToString(), () => EmptyString);
        GroupName = classifier.Tag<LiteralProviderAttribute>().MapValueOrDefault(a => a.Group, classifier.Name);
    }

    public SymbolGroup(Type classifier, Type group)
        : this(classifier, group.GetNestedTypes().Enums())
    {
    }

    public IEnumerable<Type> SymbolTypes => _SymbolTypes;

    IEnumerable<Symbol> Symbols(Type type)
    {
        var index = _IndexLookup[type];
        for(var j=0u; j<index.Count; j++)
        {
            var symbol = index[j];
            yield return new Symbol{
                Seq = Seq++,
                Ordinal = j,
                Value = symbol.Value,
                GroupName = GroupName,
                GroupClass = _ClassName[type],
                Identifier = symbol.Name,
                Expresson = symbol.Expr.Format()
            };
        }
    }

    Partition GroupPartition(Type type)
    {
        var members = Symbols(type).ToSeq();
        return new Partition{
            LiteralType = type.Name,
            GroupName = members.First.GroupName,
            GroupClass = members.First.GroupClass,
            Symbols = members
        };
    }

    public IEnumerable<Partition> Partitions()
    {
        Seq = 0;
        return from t in _SymbolTypes
             select GroupPartition(t);
    }

    public record struct Symbol : ISequential<Symbol>, IComparable<Symbol>
    {
        public uint Seq;

        public uint Ordinal;

        public ulong Value;

        public string GroupName;

        public string GroupClass;

        public string Identifier;

        public string Expresson;

        uint ISequential.Seq {get => Seq; set => Seq = value; }

        public int CompareTo(Symbol src)
        {
            var result = GroupName.CompareTo(src.GroupName);
            if(result == 0)
            {
                result = GroupClass.CompareTo(src.GroupClass);
                if(result == 0)
                    result = Ordinal.CompareTo(src.Ordinal);
            }
            return result;
        }
    }

    public record struct Partition
    {
        public string GroupName;

        public string LiteralType;

        public string GroupClass;            

        public ReadOnlySeq<Symbol> Symbols;
    }

    public void EmitTokens(ITextEmitter dst)
    {
        const string MemberPattern = "{0}:{1},";
        var indent = 0u;
        var emitter = text.emitter();
        EmitTypeLiterals(ref indent, emitter);
        EmitMembers(ref indent, emitter);
    }

    public void EmitTypeLiterals(ref uint indent, ITextEmitter dst)
    {
        var names = list<string>();
        foreach(var g in Partitions())
        {
            dst.IndentLine(indent, $"export type {g.GroupClass} =");
            names.Add(g.GroupClass);
            indent+=4;
            foreach(var member in g.Symbols)
            {
                dst.IndentLineFormat(indent, "| \"{0}\"", member.Expresson);
            }
            indent-=4;
            dst.AppendLine();
        }

        dst.IndentLineFormat(indent, $"export type Token = ");
        indent+=4;
        foreach(var name in names)
        {
            dst.IndentLineFormat(indent, "| {0}", name);
        }
        indent-=4;
    }
    
    public void EmitMembers(ref uint indent, ITextEmitter dst)
    {
        const string MemberValuePattern = "{0}:{1},";
        const string QuotedMemberPattern = "{0}:\"{1}\",";
        var types = SymbolTypes;
        dst.IndentLineFormat(indent, "{0}", "export const tokens = [");
        indent+=4;
        foreach(var g in Partitions())
        {
            foreach(var member in g.Symbols)
            {
                dst.IndentLine(indent, Chars.LBrace);
                indent+=4;
                dst.IndentLineFormat(indent, MemberValuePattern, nameof(member.Ordinal), member.Ordinal);
                dst.IndentLineFormat(indent, QuotedMemberPattern, nameof(member.GroupName), member.GroupName);
                dst.IndentLineFormat(indent, QuotedMemberPattern, nameof(member.GroupClass), member.GroupClass);
                dst.IndentLineFormat(indent, QuotedMemberPattern, nameof(member.Identifier), member.Identifier);
                dst.IndentLineFormat(indent, QuotedMemberPattern, nameof(member.Expresson), member.Expresson);
                indent-=4;
                dst.IndentLineFormat(indent, "{0},", Chars.RBrace);
            }
        }

        indent-=4;
        dst.IndentLineFormat(indent, "{0}", "]");
    }
}

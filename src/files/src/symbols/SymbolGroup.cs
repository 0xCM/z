//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

using static sys;

public class SymbolGroup
{
    public readonly Type GroupType;

    public readonly string GroupName;

    readonly Type[] _SymbolTypes;

    public readonly Type ClassType;        

    readonly Dictionary<Type,SymIndex> _IndexLookup = new();

    readonly Dictionary<Type,string> _ClassName = new();

    public SymbolGroup(Type group, Type classifier)
    {
        ClassType = classifier;
        GroupType = group;
        _SymbolTypes = group.GetNestedTypes().Enums();
        var indices = Z0.Symbols.indices(_SymbolTypes);
        foreach(var index in indices)
            _IndexLookup[index.RuntimeType] = index;
        foreach(var type in _SymbolTypes)
            _ClassName[type] = type.Tag<TokenKindAttribute>().MapValueOrElse(a => a.Kind.ToString(), () => EmptyString);
        GroupName = group.Tag<LiteralProviderAttribute>().MapValueOrElse(a => a.Group, () => EmptyString);
    }

    public IEnumerable<Type> SymbolTypes => _SymbolTypes;

    public IEnumerable<Symbol> Symbols(Type type)
    {
        var index = _IndexLookup[type];
        for(var j=0u; j<index.Count; j++)
        {
            var symbol = index[j];
            yield return new Symbol{
                Ordinal = j,
                GroupName = GroupName,
                GroupClass = _ClassName[type],
                Identifier = symbol.Name,
                Expresson = symbol.Expr.Format()
            };
        }
    }

    public Partition GroupPartition(Type type)
    {
        var members = Symbols(type).ToSeq();
        return new Partition{
            GroupType = GroupType.Name,
            LiteralType = type.Name,
            GroupName = members.First.GroupName,
            GroupClass = members.First.GroupClass,
            Symbols = members
        };
    }

    public IEnumerable<Partition> Partitions()
        => from t in _SymbolTypes  select GroupPartition(t);

    public IEnumerable<Symbol> Literals()
        => from type in _SymbolTypes
            from member in Symbols(type)
            select member;

    public record struct Symbol
    {
        public uint Ordinal;

        public string GroupName;

        public string GroupClass;

        public string Identifier;

        public string Expresson;
    }

    public record struct Partition
    {
        public string GroupType;

        public string GroupName;

        public string LiteralType;

        public string GroupClass;            

        public ReadOnlySeq<Symbol> Symbols;
    }

    /*
export const Hex16Symbols:Array<Hex16> = ['0F38', '0F3A']

export const Hex16:Record<string,Hex16> = {
"0F38":'0F38',
'0F3A':'0F3A'
}


    */
    public void ExportTokens(IWfChannel channel, IDbArchive dst)
    {
        const string MemberPattern = "{0}:{1},";
        var indent = 0u;
        var emitter = text.emitter();
        EmitTypeLiterals(ref indent, emitter);
        EmitMembers(ref indent, emitter);
        channel.FileEmit(emitter.Emit(), dst.Path(GroupName, FS.ext("ts")));
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

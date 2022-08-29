//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class SymbolNames<K>
        where K : unmanaged, Enum
    {
        readonly ReadOnlySeq<FieldInfo> Fields;

        readonly ConcurrentDictionary<K,string> Expressions;

        readonly ConcurrentDictionary<K,string> Names;

        readonly ConcurrentDictionary<string,K> ExprKinds;

        readonly ConcurrentDictionary<string,K> NameKinds;

        readonly ReadOnlySeq<K> FieldKind;

        readonly ReadOnlySeq<ulong> FieldValues;

        public readonly ClrIntegerKind SymValueKind;

        protected SymbolNames()
        {
            Fields = typeof(K).LiteralFields().ToSeq();
            var count = Fields.Length;
            Expressions = new (1,count);
            Names = new (1,count);
            ExprKinds = new (1,count);
            NameKinds = new (1,count);
            FieldKind = sys.alloc<K>(count);
            FieldValues = sys.alloc<ulong>(count);
            
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref Fields[i];
                var symbol = SymbolAttribute.symbol(field);
                var value = field.GetRawConstantValue();                
            }

        }

    }
    public abstract class SymbolNames<S,K> : SymbolNames<K>
        where S : SymbolNames<S,K>, new()
        where K : unmanaged, Enum
    {


    }

    [ApiHost]
    public class PartNames
    {
        public static IReadOnlyDictionary<PartId,PartName> names()
            => _Instance.PartIdToPartName;

        [Parser]
        public static bool parse(string expr, out PartName dst)
        {
            dst = PartName.Empty;
            if(_Instance.PartExprToPartId.TryGetValue(expr, out PartId id))
                _Instance.PartIdToPartName.TryGetValue(id, out dst);
            return dst.IsNonEmpty;
        }

        static string env(string name) 
            => Environment.GetEnvironmentVariable(name) ?? EmptyString;

        [Op]
        public static string format(PartId part)
        {
            var dst = EmptyString;
            var lookup = names();
            var name = PartName.Empty;
            if(lookup.TryGetValue(part, out name))
                dst = name.Format();
            else
                dst = part.ToString().ToLower();
            return dst;
        }

        [MethodImpl(Inline)]
        public static PartId owner(Type src)
            => PartIdAttribute.id(src.Assembly);

        [MethodImpl(Inline)]
        public static PartName name(Type src)
        {
            var id = owner(src);
            return new PartName(id, format(name(id)));
        }

        static PartName name(PartId part)
        {
            var lookup = names();
            if(lookup.TryGetValue(part, out var name))
                return name;
            else
                return new PartName(part, part.ToString().ToLower());
        }

        static PartNames _Instance;

        readonly ConcurrentDictionary<PartId,PartName> PartIdToPartName;

        readonly ConcurrentDictionary<string,PartId> PartExprToPartId;

        static PartNames()
        {
            _Instance = new PartNames();
        }

        PartNames()
        {
            var fields = typeof(PartId).LiteralFields();
            PartIdToPartName = new ConcurrentDictionary<PartId,PartName>();
            PartExprToPartId = new ConcurrentDictionary<string,PartId>();
            foreach(var f in fields)
            {
                var id = (PartId)f.GetRawConstantValue();
                var symbol = SymbolAttribute.symbol(f);
                var name = new PartName(id, symbol);
                PartIdToPartName.TryAdd(id,name);
                PartExprToPartId.TryAdd(symbol,id);
            }
        }
    }
}
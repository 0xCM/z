//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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

        [MethodImpl(Inline), Op]
        public static bool external(PartId src)
            => src >= PartId.Extern00;

        static string env(string name) 
            => Environment.GetEnvironmentVariable(name) ?? EmptyString;

        [Op]
        public static string format(PartId part)
        {
            var dst = EmptyString;
            var lookup = names();
            var name = PartName.Empty;
            if(external(part))
            {
                name = new PartName(part, env(part.ToString()));
                dst = name.Format();
            }
            else
            {
                if(lookup.TryGetValue(part, out name))
                    dst = name.Format();
                else
                    dst = part.ToString().ToLower();
            }
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
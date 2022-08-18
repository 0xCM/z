//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    public static class NativeNaturals
    {
        static readonly ConcurrentDictionary<ulong,Type> index
            = new ConcurrentDictionary<ulong, Type>();

        static NativeNaturals()
        {
            var types = typeof(N0).Assembly.GetTypes().Where(t => t.Reifies<INativeNatural>()).ToArray();
            for(var i=0; i<types.Length; i++)
            {
                var t = types[i];
                var value = (ulong)t.Field("Value").GetRawConstantValue();
                index.TryAdd(value,t);
            }
        }

        [MethodImpl(Inline)]
        public static Option<Type> FindType(ulong value)
        {
            if(index.TryGetValue(value, out var t))
                return t;
            else
                return Option.none<Type>();
        }

        public static IEnumerable<Type> Individuals(params ulong[] values)
        {
            foreach(var value in values)
                if(index.TryGetValue(value, out var t))
                    yield return t;
        }

        public static IEnumerable<Type> Powers2(ulong min, ulong max)
        {
            var current = min;
            if(index.TryGetValue(current, out var t) && current <= max)
            {
                yield return t;
                current *= 2;
            }
        }

        public static IEnumerable<Type> FindTypes(NatClosureKind kind, params ulong[] values)
        {
            switch(kind)
            {
                case NatClosureKind.Individuals:
                    return Individuals(values);

                case NatClosureKind.Powers2:
                {
                    if(values.Length == 2)
                        return Powers2(values[0], values[1]);
                }
                break;
            }
            return new Type[]{};
        }
    }
}
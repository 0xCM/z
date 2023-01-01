//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class JsonTypes 
    {
        public static ReadOnlySpan<IJsonType> Types => Lookup.Values;

        static readonly ConstLookup<@string,IJsonType> Lookup;

        static IJsonType factory(Type src)
            => (IJsonType)Activator.CreateInstance(src);

        static JsonTypes()
        {
            Lookup = typeof(JsonTypes).GetNestedTypes().Concrete().Select(factory).Select(x => (x.Name,x)).ToConstLookup();
        }
    }        
}
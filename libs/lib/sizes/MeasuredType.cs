//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct MeasuredType : IComparable<MeasuredType>
    {
        public static Index<MeasuredType> symbolic(Assembly src, string group)
        {
            var x = src.Enums().TypeTags<SymSourceAttribute>().Storage.Where(x => x.Right.SymGroup == group).ToIndex();
            return x.Select(x => new MeasuredType(x.Left, Sizes.measure(x.Left))).Sort();
        }

        public readonly Type Definition;

        public readonly DataSize Size;

        [MethodImpl(Inline)]
        public MeasuredType(Type type, DataSize size)
        {
            Definition = type;
            Size = size;
        }

        public int CompareTo(MeasuredType src)
            => Definition.Name.CompareTo(src.Definition.Name);
    }
}
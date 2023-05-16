//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct MeasuredType : IComparable<MeasuredType>
    {        
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
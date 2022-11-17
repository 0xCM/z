//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly record struct DataType : IDataType<DataType>
    {
        public readonly Type Definition;

        public readonly DataSize Size;

        [MethodImpl(Inline)]
        public DataType(Type def, DataSize size)
        {
            Definition = def;
            Size = size;
        }

        public @string Name
        {
            [MethodImpl(Inline)]
            get => Definition?.DisplayName() ?? EmptyString;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Definition is null;
        }

        public Assembly Assembly
        {
            [MethodImpl(Inline)]
            get => Definition.Assembly;
        }

        public PartName Part
        {
            [MethodImpl(Inline)]
            get => Assembly.PartName();
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(Definition.AssemblyQualifiedName);
        }

        public int CompareTo(DataType src)
        {
            var result = Name.CompareTo(src.Name);
            if(result == 0)
                Part.Format().CompareTo(src.Part.Format());
            return result;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(DataType src)
            => Definition.Equals(src.Definition);
    }
}
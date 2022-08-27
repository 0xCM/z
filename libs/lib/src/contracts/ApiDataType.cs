//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly record struct ApiDataType : IDataType<ApiDataType>
    {
        public readonly Type Definition;

        public readonly DataSize Size;

        [MethodImpl(Inline)]
        public ApiDataType(Type def, DataSize size)
        {
            Definition = def;
            Size = size;
        }

        public Name Name
        {
            [MethodImpl(Inline)]
            get => Definition?.DisplayName() ?? asci64.Null;
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

        public PartId Part
        {
            [MethodImpl(Inline)]
            get => Assembly.Id();
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(Definition.AssemblyQualifiedName);
        }

        public int CompareTo(ApiDataType src)
        {
            var result = Name.CompareTo(src.Name);
            if(result == 0)
                Part.Format().CompareTo(src.Part.Format());
            return result;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(ApiDataType src)
            => Definition.Equals(src.Definition);
    }
}
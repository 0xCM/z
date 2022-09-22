//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct DbDataType : IDataType<DbDataType>, IKeyed<uint>
    {
        /// <summary>
        /// Specifies a surrogate key
        /// </summary>
        public readonly uint Key;

        /// <summary>
        /// Specifies the name of the domain type
        /// </summary>
        public readonly Name Name;

        /// <summary>
        /// Specifies the name of a system-defined primitive with which the defined type is isomorphic
        /// </summary>
        public readonly Name Primitive;

        /// <summary>
        /// Specifies the physical/logical type size
        /// </summary>
        public readonly DataSize Size;

        /// <summary>
        /// Specifies whether the type refines a system or user-defined type
        /// </summary>
        public readonly bit Refines;

        /// <summary>
        /// Specifies the name, if any, the type refines
        /// </summary>
        public readonly Name Refinement;

        [MethodImpl(Inline)]
        public DbDataType(uint seq, Name name, Name prim, DataSize size, bit refines, Name refinement)
        {
            Key = seq;
            Primitive = prim;
            Name = name;
            Size = size;
            Refines = refines;
            Refinement = refinement;
        }

        public bool IsEmpty 
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }
        
        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (Hash32)Key | Name.Hash | Primitive.Hash | Size.Hash | Refines.Hash | Refinement.Hash;
        }

        uint IKeyed<uint>.Key 
            => Key;

        [MethodImpl(Inline)]
        public int CompareTo(DbDataType src)
            => Key.CompareTo(src.Key);
    }
    
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a nonparametric enum dataset entry
    /// </summary>
    public struct EnumDatasetEntry
    {
        /// <summary>
        /// The artifact identifier of the defining literal
        /// </summary>
        public EcmaToken Id;

        /// <summary>
        /// The defining <see cref='Enum'/> id
        /// </summary>
        public EcmaToken EnumId;

        /// <summary>
        /// The 0-based declaration order of the defining literal
        /// </summary>
        public uint Index;

        /// <summary>
        /// The refined primitive value
        /// </summary>
        public ulong ScalarValue;

        /// <summary>
        /// The literal name
        /// </summary>
        public string Name;

        /// <summary>
        /// The description, if available
        /// </summary>
        public string Description;

        [MethodImpl(Inline)]
        public EnumDatasetEntry(EcmaToken id, EcmaToken enumId, uint index, string name, ulong scalar, string description)
        {
            Id = id;
            EnumId = enumId;
            Index = index;
            Name = name;
            ScalarValue = scalar;
            Description = description;
        }
    }
}
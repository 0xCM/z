//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a nonparametric enum dataset entry
    /// </summary>
    public struct EnumDatasetEntry
    {
        /// <summary>
        /// The artifact identifier of the defining literal
        /// </summary>
        public CliToken Id;

        /// <summary>
        /// The defining <see cref='Enum'/> id
        /// </summary>
        public CliToken EnumId;

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
        public NameOld Name;

        /// <summary>
        /// The description, if available
        /// </summary>
        public string Description;

        [MethodImpl(Inline)]
        public EnumDatasetEntry(CliToken id, CliToken enumId, uint index, NameOld name, ulong scalar, string description)
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
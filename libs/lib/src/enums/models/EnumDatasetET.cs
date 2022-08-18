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
    /// Covers a collection of tables that, together, describe a parametrically-predicated enum
    /// </summary>
    /// <typeparam name="E">The enum type</typeparam>
    /// <typeparam name="T">The refined primitive type</typeparam>
    public struct EnumDataset<E,T>
        where E : unmanaged, Enum
        where T : unmanaged
    {
        public CliToken Token {get;}

        public string Description {get;}

        public ClrEnumKind EnumKind {get;}

        public int EntryCount {get;}

        public CliToken[] Tokens {get;}

        public uint[] Indices {get;}

        public string[] Names {get;}

        public E[] Literals {get;}

        public T[] Scalars {get;}

        public string[] Descriptions {get;}

        public EnumDatasetEntry<E,T> this[int i]
        {
            [MethodImpl(Inline)]
            get => Entry(i);
        }

        [MethodImpl(Inline)]
        public EnumDatasetEntry<E,T> Entry(int i)
            => new EnumDatasetEntry<E,T>(Tokens[i], Token, Indices[i], Names[i], Literals[i], Scalars[i], Descriptions[i]);

        [MethodImpl(Inline)]
        public EnumDataset(CliToken token, string description, ClrEnumKind type, CliToken[] tokens,
            uint[] indices, string[] names, E[] literals, T[] scalars, string[] descriptions)
        {
            Token = token;
            EnumKind = type;
            EntryCount = tokens.Length;
            Description = description;
            Tokens = tokens;
            Indices = indices;
            Literals = literals;
            Scalars = scalars;
            Names = names;
            Descriptions = descriptions;
        }
    }
}
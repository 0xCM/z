//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Characterizes anything that can be uniquely identified by an operation identity and
    /// </summary>
    /// <typeparam name="T">The type of identified thing</typeparam>
    [Free]
    public interface IApiOpIndex<T>
    {
        /// <summary>
        /// The number of indexed items
        /// </summary>
        int EntryCount {get;}

        /// <summary>
        /// The item keys
        /// </summary>
        IEnumerable<OpIdentity> Keys {get;}

        /// <summary>
        /// Duplicate keys found the source that were rejected from the index
        /// </summary>
        IReadOnlyList<OpIdentity> DuplicateKeys {get;}

        /// <summary>
        /// Looks up the index item and blows up if item does not exist
        /// </summary>
        T this[OpIdentity id] {get;}

        /// <summary>
        /// A server version of the lookup indexer that returns an optional value, thus allowing
        /// for the possibility that the id doesn't identify anything in the index
        /// </summary>
        /// <param name="id"></param>
        bool Lookup(OpIdentity id, out T value);

        /// <summary>
        /// Enumerates the key/value index pairs
        /// </summary>
        IEnumerable<(OpIdentity, T)> Enumerated {get;}
    }
}
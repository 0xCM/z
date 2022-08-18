//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[Flags]
public enum ApiProviderKind : ushort
{
    None,

    /// <summary>
    /// Indicates a classical or domain-specific value type that organizes data by some principle
    /// </summary>
    DataStructure = 1,

    DataType = 2,

    Stateless = 4,

    DataSummary = 8,
}

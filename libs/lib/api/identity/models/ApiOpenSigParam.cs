//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents a type parameter in a generic artifact definition
    /// </summary>
    public sealed record class ApiOpenSigParam : IOpenSigParam
    {
        public readonly ushort Position;

        public readonly string Name;

        [MethodImpl(Inline)]
        public ApiOpenSigParam(ushort position, string name)
        {
            Position = position;
            Name = name;
        }

        ushort ISigTypeParam.Position
            => Position;

        string ISigTypeParam.Name
            => Name;
    }
}
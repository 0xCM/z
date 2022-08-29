//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents a type parameter in a generic artifact definition
    /// </summary>
    public sealed record class ApiClosedSigParam : IClosedSigParam
    {
        public readonly ushort Position;

        public readonly string Name;

        public readonly ApiTypeSig Closure;

        [MethodImpl(Inline)]
        public ApiClosedSigParam(ushort position, string name, ApiTypeSig closure)
        {
            Position = position;
            Name = name;
            Closure = closure;
        }

        ushort ISigTypeParam.Position
            => Position;

        string ISigTypeParam.Name
            => Name;
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents either a closed or open type parameter
    /// </summary>
    public sealed record class ApiSigTypeParam : ISigTypeParam
    {
        public readonly ushort Position;

        public readonly string Name;

        public readonly ApiTypeSig Closure;

        [MethodImpl(Inline)]
        public ApiSigTypeParam(ushort pos, string name)
        {
            Position = pos;
            Name = name;
            Closure = ApiTypeSig.Empty;
        }

        [MethodImpl(Inline)]
        public ApiSigTypeParam(ushort pos, string name, ApiTypeSig closure)
        {
            Position = pos;
            Name = name;
            Closure = closure;
        }

        public bool IsClosed
        {
            [MethodImpl(Inline)]
            get => Closure.IsNonEmpty;
        }

        public bool IsOpen
        {
            [MethodImpl(Inline)]
            get => !IsClosed;
        }

        ushort ISigTypeParam.Position
            => Position;

        string ISigTypeParam.Name
            => Name;
    }
}
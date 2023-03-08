//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Vars;

    /// <summary>
    /// Defines a variable
    /// </summary>
    public class Var : IVar
    {
        public readonly @string Name;

        readonly Option<object> _Value;

        public readonly Type ValueType;

        public readonly char Prefix;

        public readonly Fence<char> Fence;

        [MethodImpl(Inline)]
        public Var(string name, Type type, object value, char? prefix = null, Fence<char>? fence=null)
        {
            Name = name;
            ValueType = type;
            _Value = value;
            Prefix = prefix ?? Chars.Dollar;
            Fence = fence ?? (Chars.LBrace,Chars.RBrace);
        }

        char IVar.Prefix
            => Prefix;

        Fence<char> IVar.Fence
            => Fence;

        public object Value()
            => _Value.Value;

        public bool HasValue
        {
            [MethodImpl(Inline)]
            get => _Value.IsSome();
        }

        @string IVar.Name
            => Name;

        bool IsPrefixed => Prefix != 0;

        bool IsFenced => Fence.Left != 0 && Fence.Right != 0;

        bool IsPrefixedFence => IsPrefixed && IsFenced;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();
    }
}
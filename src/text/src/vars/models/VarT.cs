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
    public class Var<T> : IVar<T>
        where T : IEquatable<T>, IComparable<T>
    {
        public readonly @string Name;

        readonly Option<T> _Value;

        public readonly Type VarType;

        public readonly char Prefix;

        public readonly Fence<char> Fence;

        [MethodImpl(Inline)]
        public Var(string name, T value, char? prefix = null, Fence<char>? fence=null)
        {
            Name = name;
            _Value = value;
            VarType = typeof(T);
            Prefix = prefix ?? Chars.Dollar;
            Fence = fence ?? (Chars.LBrace,Chars.RBrace);
        }

        [MethodImpl(Inline)]
        public Var(string name)
        {
            Name = name;
            _Value = Option.none<T>();
            VarType = typeof(T);
        }

        public T Value() => _Value.Value;
        
        public bool HasValue
        {
            [MethodImpl(Inline)]
            get => _Value.IsSome();
        }

        char IVar.Prefix
            => Prefix;

        Fence<char> IVar.Fence
            => Fence;

        @string IVar.Name
            => Name;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
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

        public override int GetHashCode()
            => Hash;

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Var(Var<T> src)
            => new Var(src.Name, typeof(T), src.Value());
    }
}
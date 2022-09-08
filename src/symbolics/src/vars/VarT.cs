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
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public class Var<T> : IVar<T>
        where T : IEquatable<T>, IComparable<T>
    {
        public readonly @string Name;

        readonly Func<T> Resolver;

        public readonly Type VarType;

        [MethodImpl(Inline)]
        public Var(Func<T> resolver)
        {
            Name = default;
            Resolver = resolver;
            VarType = typeof(T);
        }

        [MethodImpl(Inline)]
        public Var(string name, Func<T> resolver)
        {
            Name = name;
            Resolver = resolver;
            VarType = typeof(T);
        }

        public bool IsNamed
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

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

        public T Value
            => Resolver();

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Var(Var<T> src)
            => new Var(src.Name, typeof(T), () => src.Resolver());
    }
}
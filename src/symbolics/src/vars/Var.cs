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
    public class Var : IVar
    {
        public readonly @string Name;

        readonly Func<object> Resolver;

        public readonly Type ValueType;

        [MethodImpl(Inline)]
        public Var(Type type, Func<object> resolver)
        {
            Name = default;
            ValueType = type;
            Resolver = resolver;
        }

        [MethodImpl(Inline)]
        public Var(string name, Type type, Func<object> resolver)
        {
            Name = name;
            ValueType = type;
            Resolver = resolver;
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

        [MethodImpl(Inline)]
        public Value<object> Resolve()
            => new Value<object>(Resolver());

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();
    }
}
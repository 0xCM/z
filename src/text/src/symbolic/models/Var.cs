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

        public static string format(IVarValue var)
            => format(var, Chars.Eq);

        public static string format(IVarValue var, char assign)
            => string.Format("{0}{1}{2}", var.VarName, assign, var.VarValue);

        public static string format(VarContextKind vck, IVarValue var)
            => format(vck,var, Chars.Eq);

        public static string format(VarContextKind vck, IVarValue var, char assign)
            => string.Format("{0}{1}{2}", format(vck, var.VarName), assign, var.VarValue);

        static string format(VarContextKind vck, string name)
            => string.Format(RP.pattern(vck), name);

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
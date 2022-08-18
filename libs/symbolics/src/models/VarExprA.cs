//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Vars;

    public class VarExpr<T> : IVarExpr<T>
        where T : IEquatable<T>, IComparable<T>, new()
    {
        public readonly Name VarName;

        public readonly AsciFence Fence;

        public readonly AsciSymbol Prefix;

        T _Value;


        [MethodImpl(Inline)]
        public VarExpr(AsciSymbol prefix)
        {
            VarName = default;
            Prefix = prefix;
            Fence = AsciFence.Empty;
        }

        [MethodImpl(Inline)]
        public VarExpr(AsciFence fence)
        {
            VarName = default;
            Fence = fence;
            Prefix = AsciSymbol.Empty;
        }

        [MethodImpl(Inline)]
        public VarExpr(AsciSymbol prefix, AsciFence fence)
        {
            VarName = default;
            Prefix = prefix;
            Fence = fence;
        }

        [MethodImpl(Inline)]
        public VarExpr(Name name, AsciSymbol prefix)
        {
            VarName = name;
            Prefix = prefix;
            Fence = AsciFence.Empty;
        }

        [MethodImpl(Inline)]
        public VarExpr(Name name, AsciFence fence)
        {
            VarName = name;
            Fence = fence;
            Prefix = AsciSymbol.Empty;
        }

        [MethodImpl(Inline)]
        public VarExpr(Name name, AsciSymbol prefix, AsciFence fence)
        {
            VarName = name;
            Prefix = prefix;
            Fence = fence;
        }

        AsciFence IVarExpr.Fence
            => Fence;

        AsciSymbol IVarExpr.Prefix
            => Prefix;

        public bool IsNamed
        {
            [MethodImpl(Inline)]
            get => VarName.IsNonEmpty;
        }

        internal ref T VarValue
        {
            [MethodImpl(Inline)]
            get => ref _Value;
        }

        [MethodImpl(Inline)]
        public ref T Assign(in T src)
        {
            VarValue = src;
            return ref VarValue;
        }

        public string Format(bool name)
            => api.format(this,name);

        public string Format()
            => Format(false);

        public override string ToString()
            => Format();

        /// <summary>
        /// Indicates whether the variable is prefixed
        /// </summary>
        public bool IsPrefixed
            => Prefix != AsciNull.Literal;

        /// <summary>
        /// Indicates whether the variable is fenced
        /// </summary>
        public bool IsFenced
            => Fence.Left != AsciNull.Literal && Fence.Right != AsciNull.Literal;


    }
}
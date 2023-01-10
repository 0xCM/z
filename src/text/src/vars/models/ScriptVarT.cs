//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Vars;

    public record class ScriptVar<T> : IVarExpr
        where T : IEquatable<T>, IComparable<T>, new()
    {
        public readonly @string VarName;

        public readonly AsciFence Fence;

        public readonly AsciSymbol Prefix;

        T _Value;

        [MethodImpl(Inline)]
        public ScriptVar(AsciSymbol prefix, T? value = default)
        {
            _Value = value ?? new();
            VarName = default;
            Prefix = prefix;
            Fence = AsciFence.Empty;
        }

        [MethodImpl(Inline)]
        public ScriptVar(AsciFence fence, T? value = default)
        {
            _Value = value ?? new();
            VarName = default;
            Fence = fence;
            Prefix = AsciSymbol.Empty;
        }

        [MethodImpl(Inline)]
        public ScriptVar(AsciSymbol prefix, AsciFence fence, T? value = default)
        {
            _Value = value ?? new();
            VarName = default;
            Prefix = prefix;
            Fence = fence;
        }

        [MethodImpl(Inline)]
        public ScriptVar(string name, AsciSymbol prefix, T? value = default)
        {
            _Value = value ?? new();
            VarName = name;
            Prefix = prefix;
            Fence = AsciFence.Empty;
        }

        [MethodImpl(Inline)]
        public ScriptVar(string name, AsciFence fence, T? value = default)
        {
            _Value = value ?? new();
            VarName = name;
            Fence = fence;
            Prefix = AsciSymbol.Empty;
        }

        [MethodImpl(Inline)]
        public ScriptVar(string name, AsciSymbol prefix, AsciFence fence, T? value = default)
        {
            _Value = value ?? new();
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

        public ref readonly T VarValue
        {
            [MethodImpl(Inline)]
            get => ref _Value;
        }

        [MethodImpl(Inline)]
        public ref T Assign(in T src)
        {
            _Value = src;
            return ref _Value;
        }

        public virtual string Format(bool name)
            => api.format(this,name);

        public virtual string Format()
            => Format(false);

        public override string ToString()
            => Format();

        /// <summary>
        /// Indicates whether the variable is prefixed
        /// </summary>
        public bool IsPrefixed
            => Prefix != 0;

        /// <summary>
        /// Indicates whether the variable is fenced
        /// </summary>
        public bool IsFenced
            => Fence.Left != 0 && Fence.Right != 0;

        [MethodImpl(Inline)]
        public static implicit operator ScriptVar<T>(string name)
            => new ScriptVar<T>(name);

        [MethodImpl(Inline)]
        public static implicit operator ScriptVar(ScriptVar<T> src)
            => new ScriptVar(src.VarName, src.Prefix,src.Fence,$"{src.VarValue}");
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = ScriptVars;

    public record class ScriptVar<T> : IScriptVar
        where T : IEquatable<T>, IComparable<T>, new()
    {
        public readonly @string VarName;

        public readonly AsciFence Fence;

        public readonly AsciSymbol Prefix;

        T _Value;

        [MethodImpl(Inline)]
        public ScriptVar(string name, AsciSymbol prefix)
        {
            VarName = name;
            Prefix = prefix;
            Fence = AsciFence.Empty;
        }

        [MethodImpl(Inline)]
        public ScriptVar(string name, AsciFence fence)
        {
            VarName = name;
            Fence = fence;
            Prefix = AsciSymbol.Empty;
        }

        [MethodImpl(Inline)]
        public ScriptVar(string name, AsciSymbol prefix, AsciFence fence)
        {
            VarName = name;
            Prefix = prefix;
            Fence = fence;
        }

        AsciFence IScriptVar.Fence
            => Fence;

        AsciSymbol IScriptVar.Prefix
            => Prefix;

        public bool IsNamed
        {
            [MethodImpl(Inline)]
            get => VarName.IsNonEmpty;
        }

        public virtual string Format()
            => api.format(this);

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

        public bool IsPrefixedFence
        {
            [MethodImpl(Inline)]
            get => IsPrefixed && IsFenced;
        }

        [MethodImpl(Inline)]
        public static implicit operator ScriptVar<T>(string name)
            => new ScriptVar<T>(name);

        [MethodImpl(Inline)]
        public static implicit operator ScriptVar(ScriptVar<T> src)
            => new ScriptVar(src.VarName, src.Prefix,src.Fence);
    }
}
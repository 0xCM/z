//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Vars;

    public record class ScriptVar<T> : IScriptVar
        where T : IEquatable<T>, INullity, new()
    {
        public readonly @string VarName;

        public readonly AsciFence Fence;

        public readonly AsciSymbol Prefix;

        T _Value;

        [MethodImpl(Inline)]
        public ScriptVar(string name, AsciSymbol prefix, AsciFence fence, T value = default)
        {
            VarName = name;
            Prefix = prefix;
            Fence = fence;
            _Value = value;
        }

        AsciFence IScriptVar.Fence
            => Fence;

        AsciSymbol IScriptVar.Prefix
            => Prefix;

        [MethodImpl(Inline)]
        public bool Value(out T value)
        {
            if(IsResolved())
            {
                value = _Value;
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }

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

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => VarName.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => VarName.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => VarName.Hash;
        }

        [MethodImpl(Inline)]
        public void Resolve(in T src)
            => _Value = src;

        public virtual string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool IsResolved()
            => _Value?.IsNonEmpty ?? false;

        [MethodImpl(Inline)]
        public static implicit operator ScriptVar<T>(string name)
            => new ScriptVar<T>(name);

        [MethodImpl(Inline)]
        public static implicit operator ScriptVar(ScriptVar<T> src)
            => new ScriptVar(src.VarName, src.Prefix,src.Fence, src._Value?.ToString() ?? EmptyString);
    }
}
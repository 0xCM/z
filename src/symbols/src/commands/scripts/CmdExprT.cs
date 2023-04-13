//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class CmdExpr<T>  : CmdExpr, ISetting<T>
        where T : IEquatable<T>, INullity, new()
    {
        public readonly @string Name;

        public readonly T Value;

        public CmdExpr(string name, T value)
            : base($"set {name}=${value}")
        {
            Name = name;
            Value = value;
        }


        T ISetting<T>.Value 
            => Value;

        @string INamed.Name 
            => Name;

        public static implicit operator CmdSetExpr(CmdExpr<T> src)
            => new CmdSetExpr(src.Name, src.Value?.ToString() ?? EmptyString);
    }
}
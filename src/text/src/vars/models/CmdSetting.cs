//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class CmdSetting<T>  : CmdExpr, ISetting<T>
        where T : IEquatable<T>, INullity, new()
    {
        public readonly @string Name;

        public readonly T Value;

        public CmdSetting(string name, T value)
            : base($"set {name}=${value}")
        {
            Name = name;
            Value = value;
        }


        T ISetting<T>.Value 
            => Value;

        @string INamed.Name 
            => Name;

        public static implicit operator CmdSetting(CmdSetting<T> src)
            => new CmdSetting(src.Name, src.Value?.ToString() ?? EmptyString);
    }

    public record class CmdSetting : CmdSetting<@string>
    {
        public CmdSetting(string name, @string value)
            : base(name,value)
        {

        }        
   }
}
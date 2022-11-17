//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public record struct ToolCmdArg<T>
    {
        /// <summary>
        /// The argument name
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// The (required) argument value
        /// </summary>
        public readonly T Value;

        public readonly bool IsFlag;

        [MethodImpl(Inline)]
        public ToolCmdArg(string name, T value, bool flag = false)
        {
            Name = name;
            Value = value;
            IsFlag = flag;
        }

        [MethodImpl(Inline)]
        public static implicit operator ToolCmdArg<T>((string name, T value) src)
            => new ToolCmdArg<T>(src.name, src.value);
    }
}
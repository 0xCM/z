//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CmdArg<T>
    {
        public readonly uint Index;

        public readonly @string Name;

        public readonly T Value;

        [MethodImpl(Inline)]
        public CmdArg(uint index, T value)
        {
            Index = 0;
            Value = value;
            Name = value.ToString();
        }

        [MethodImpl(Inline)]
        public CmdArg(uint index, string name, T value)
        {
            Index = index;
            Name = name;
            Value = value;
        }


        [MethodImpl(Inline)]
        public static implicit operator CmdArg<T>((uint index, T value) src)
            => new CmdArg<T>(src.index, src.value);

        [MethodImpl(Inline)]
        public static implicit operator CmdArg<T>((int index, T value) src)
            => new CmdArg<T>((uint)src.index, src.value);

        [MethodImpl(Inline)]
        public static implicit operator CmdArg(CmdArg<T> src)
            => new CmdArg(src.Index, src.Name, src.Value.ToString());

        public static CmdArg<T> Empty
            => new CmdArg<T>(0, default(T));
    }
}
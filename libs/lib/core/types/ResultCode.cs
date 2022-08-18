//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ResultCode
    {
        public readonly uint Value;

        [MethodImpl(Inline)]
        public ResultCode(uint value)
        {
            Value = value;
        }

        public bool Ok
        {
            [MethodImpl(Inline)]
            get => Value == 0;
        }

        [MethodImpl(Inline)]
        public static implicit operator ResultCode(uint value)
            => new ResultCode(value);

        [MethodImpl(Inline)]
        public static bool operator true(ResultCode src)
            => src.Ok;

        [MethodImpl(Inline)]
        public static bool operator false(ResultCode src)
            => !src.Ok;
    }
}
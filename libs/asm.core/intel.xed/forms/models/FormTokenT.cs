//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedForms;

    public readonly record struct FormToken<T>
        where T : unmanaged
    {
        readonly ByteBlock16 Data;

        [MethodImpl(Inline)]
        public FormToken(ByteBlock16 data)
        {
            Data = data;
        }

        public T Value
        {
            [MethodImpl(Inline)]
            get => @as<T>(Data.First);
        }

        public FormTokenKind Kind
        {
            [MethodImpl(Inline)]
            get => (FormTokenKind)Data[15];
        }

        [MethodImpl(Inline)]
        public static implicit operator FormToken<T>(FormToken src)
            => new FormToken<T>(@as<FormToken,ByteBlock16>(src));
    }
}
//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedFormToken;

    public readonly record struct XedFormToken<T>
        where T : unmanaged
    {
        readonly ByteBlock16 Data;

        [MethodImpl(Inline)]
        public XedFormToken(ByteBlock16 data)
        {
            Data = data;
        }

        public T Value
        {
            [MethodImpl(Inline)]
            get => @as<T>(Data.First);
        }

        public TokenKind Kind
        {
            [MethodImpl(Inline)]
            get => (TokenKind )Data[15];
        }

        [MethodImpl(Inline)]
        public static implicit operator XedFormToken<T>(XedFormToken src)
            => new XedFormToken<T>(@as<XedFormToken,ByteBlock16>(src));
    }
}
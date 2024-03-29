//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    [DataWidth(Width)]
    public record struct XedInstForm : IDataType<XedInstForm>
    {
        public const byte Width = Hex14.Width;

        public readonly XedFormType Kind;

        [MethodImpl(Inline)]
        public XedInstForm(XedFormType src)
            => Kind = src;

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Kind != 0;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Kind == 0;
        }

        public Hash32 Hash 
            => (uint)Kind;
            
        [MethodImpl(Inline)]
        public bool Equals(XedInstForm src)
            => ((ushort)Kind).Equals((ushort)src.Kind);

        [MethodImpl(Inline)]
        public int CompareTo(XedInstForm src)
            => ((ushort)Kind).CompareTo((ushort)src.Kind);

        public override int GetHashCode()
            =>(int)Kind;

        public string Format()
            => Kind == 0 ? EmptyString :  Kind.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator XedInstForm(XedFormType src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator XedFormType(XedInstForm src)
            => src.Kind;

        [MethodImpl(Inline)]
        public static explicit operator ushort(XedInstForm src)
            => (ushort)src.Kind;

        [MethodImpl(Inline)]
        public static explicit operator XedInstForm(ushort src)
            => new ((XedFormType)src);

        public static XedInstForm Empty => default;    
    }
}


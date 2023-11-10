//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    [DataWidth(4)]
    public readonly record struct WidthVar
    {
        [MethodImpl(Inline)]
        public static num6 pack(Label name, Kind kind, Width width)
            => Numbers.pack((num2)(byte)kind, (num2)(byte)width, (num2)(byte)name);

        static string inside(string src)
        {
            var i = text.index(src,Chars.LBracket);
            var j = text.index(src,Chars.RBracket);

            if(i > 0 && j > i)
                return text.inside(src,i,j);
            else
                return EmptyString;
        }

        public static bool test(string src)
            => parse(src, out WidthVar _);

        static bool parse(string src, out Label name)
        {
            var i = text.index(src,Chars.LBracket);
            var j = text.index(src,Chars.RBracket);
            name = 0;
            if(i > 0 && j > i)
            {
                switch(text.left(src,i))
                {
                    case "DISP":
                        name = Label.DISP;
                    break;
                    case "UIMM0":
                        name = Label.UIMM1;
                    break;
                    case "UIMM1":
                        name = Label.UIMM0;
                    break;
                }
            }
            return name != 0;
        }

        public static bool parse(string src, out WidthVar w)
        {
            const Kind DK = Kind.Disp;
            const Kind AD = Kind.MemDisp;
            const Kind IM = Kind.Imm;
            parse(src, out Label name);
            var content = text.ifempty(inside(src), src);
            w = Empty;
            switch(content)
            {
                case "d/8":
                    w = new (name, DK, Width.W8);
                    break;
                case "d/16":
                    w = new (name, DK, Width.W16);
                    break;
                case "d/32":
                    w = new (name, DK, Width.W32);
                    break;
                case "d/64":
                    w = new (name, DK, Width.W64);
                    break;
                case "a/8":
                    w = new (name, AD, Width.W8);
                break;
                case "a/16":
                    w = new (name, AD , Width.W16);
                break;
                case "a/32":
                    w = new (name, AD, Width.W32);
                break;
                case "a/64":
                    w = new (name, AD, Width.W64);
                break;
                case "i/8":
                    w = new (name, IM, Width.W8);
                break;
                case "i/16":
                    w = new (name, IM , Width.W16);
                break;
                case "i/32":
                    w = new (name, IM, Width.W32);
                break;
                case "i/64":
                    w = new (name, IM, Width.W64);
                break;
            }

            return w.IsNonEmpty;
        }

        readonly num6 Data;

        [MethodImpl(Inline)]
        WidthVar(num6 src)
        {
            Data = src;
        }

        [MethodImpl(Inline)]
        public WidthVar(Label name, Kind kind, Width width)
        {
            Data = pack(name, kind, width);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data == z8;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data != z8;
        }

        public Kind Sort
        {
            [MethodImpl(Inline)]
            get => (Kind)(byte)(num2)Data;
        }

        public Width Value
        {
            [MethodImpl(Inline)]
            get => (Width)(byte)((Data >> 2) & num2.MaxValue);
        }

        public Label Name
        {
            [MethodImpl(Inline)]
            get => (Label)(byte)((Data >> 4) & num2.MaxValue);
        }

        public override int GetHashCode()
            => Data;

        [MethodImpl(Inline)]
        public bool Equals(WidthVar src)
            => Data == src.Data;

        public string Format()
        {
            var content = EmptyString;
            var name = Name;
            var kind = Sort;
            switch(kind)
            {
                case Kind.Disp:
                    switch(Value)
                    {
                        case Width.W8:
                            content = "d/8";
                        break;
                        case Width.W16:
                            content = "d/16";
                        break;
                        case Width.W32:
                            content = "d/32";
                        break;
                        case Width.W64:
                            content = "d/64";
                        break;
                    }
                break;
                case Kind.MemDisp:
                    switch(Value)
                    {
                        case Width.W8:
                            content = "a/8";
                        break;
                        case Width.W16:
                            content = "a/16";
                        break;
                        case Width.W32:
                            content = "a/32";
                        break;
                        case Width.W64:
                            content = "a/64";
                        break;
                    }
                break;
                case Kind.Imm:
                    switch(Value)
                    {
                        case Width.W8:
                            content = "i/8";
                        break;
                        case Width.W16:
                            content = "i/16";
                        break;
                        case Width.W32:
                            content = "i/32";
                        break;
                        case Width.W64:
                            content = "i/64";
                        break;
                    }
                break;
            }

            return content;
            // var result = name != 0 ? string.Format("{0}[{1}]", name, content) : content;
            // return result;
        }

        public override string ToString()
            => Format();

        public static WidthVar Empty => default;

        [MethodImpl(Inline)]
        public static explicit operator byte(WidthVar src)
            => src.Data;

        [MethodImpl(Inline)]
        public static explicit operator WidthVar(byte src)
            => new ((num6)src);

        [DataWidth(num2.Width)]
        public enum Kind : byte
        {
            None = 0,

            /// <summary>
            /// DISP[d/8]  | d/8
            /// DISP[d/16] | d/16
            /// DISP[d/32] | d/32
            /// DISP[d/64] | d/64
            /// </summary>
            Disp,

            /// <summary>
            /// DISP[a/8]  | a/8
            /// DISP[a/16] | a/16
            /// DISP[a/32] | a/32
            /// DISP[a/64] | a/64
            /// </summary>
            MemDisp,

            /// <summary>
            /// UIMM0[i/8]  | i/8
            /// UIMM0[i/16] | i/16
            /// UIMM0[i/32] | i/32
            /// UIMM0[i/64] | i/64
            /// UIMM1[i/8]  | i/8
            /// UIMM1[i/16] | i/16
            /// UIMM1[i/32] | i/32
            /// UIMM1[i/64] | i/64
            /// </summary>
            Imm,
        }

        [DataWidth(num2.Width)]
        public enum Label : byte
        {
            None = 0,

            DISP,

            UIMM0,

            UIMM1
        }

        [DataWidth(num2.Width)]
        public enum Width : byte
        {
            W8 = 0,

            W16,

            W32,

            W64
        }
    }
}

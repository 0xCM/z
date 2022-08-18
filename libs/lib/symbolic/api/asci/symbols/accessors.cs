//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore; 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using AC = AsciCode;

    partial struct AsciSymbols
    {
        /// <summary>
        /// The asci code for null
        /// </summary>
        public static AsciSymbol Null => AC.Null;

        /// <summary>
        /// Start of heading
        /// </summary>
        public static AsciSymbol SOH => AC.SOH;

        /// <summary>
        /// Start of text
        /// </summary>
        public static AsciSymbol SOT => AC.SOT;

        /// <summary>
        /// End of text
        /// </summary>
        public static AsciSymbol EOT => AC.EOT;

        /// <summary>
        /// End of transmission
        /// </summary>
        public static AsciSymbol EOTR => AC.EOTR;

        /// <summary>
        /// Enquiry
        /// </summary>
        public static AsciSymbol ENQ => AC.ENQ;

        /// <summary>
        /// Acknowledgement
        /// </summary>
        public static AsciSymbol ACK => AC.ACK;

        /// <summary>
        /// Hell's bells; asci code 7
        /// </summary>
        public static AsciSymbol Bell => AC.Bell;

        /// <summary>
        /// The backspace control symbol '\b'; asci code 8
        /// </summary>
        public static AsciSymbol BS => AC.BS;

        /// <summary>
        /// The tab character code 9
        /// </summary>
        public static AsciSymbol Tab => AC.Tab;

        /// <summary>
        /// The vertical tab
        /// </summary>
        public static AsciSymbol VTab => AC.VTab;

        /// <summary>
        /// The line-feed character code 10
        /// </summary>
        public static AsciSymbol NL => AC.NL;

        /// <summary>
        /// The form-feed control character
        /// </summary>
        public static AsciSymbol FF => AC.FF;

        /// <summary>
        /// The carriage-return character code 13
        /// </summary>
        public static AsciSymbol CR => AC.CR;

        /// <summary>
        /// The ' ' character code 32
        /// </summary>
        public static AsciSymbol Space => AC.Space;

        /// <summary>
        /// The '!' character code 33
        /// </summary>
        public static AsciSymbol Bang => AC.Bang;

        /// <summary>
        /// The '"' character code 34
        /// </summary>
        public static AsciSymbol Quote => AC.Quote;

        /// <summary>
        /// The '#' character code 35
        /// </summary>
        public static AsciSymbol Hash => AC.Hash;

        /// <summary>
        /// The '$' character code 36
        /// </summary>
        public static AsciSymbol Dollar => AC.Dollar;

        /// <summary>
        /// The '%' character code 37
        /// </summary>
        public static AsciSymbol Percent => AC.Percent;

        /// <summary>
        /// The '&' character code 38
        /// </summary>
        public static AsciSymbol Amp => AC.Amp;

        /// <summary>
        /// The ''' character code 39
        /// </summary>
        public static AsciSymbol SQuote => AC.SQuote;

        /// <summary>
        /// The '(' character code 40
        /// </summary>
        public static AsciSymbol LParen => AC.LParen;

        /// <summary>
        /// The ')' character code 41
        /// </summary>
        public static AsciSymbol RParen => AC.RParen;

        /// <summary>
        /// The '}' character code 41
        /// </summary>
        public static AsciSymbol RBrace => AC.RParen;

        /// <summary>
        /// The '*' character code 42
        /// </summary>
        public static AsciSymbol Star => AC.Mul;

        /// <summary>
        /// The '+' character code 43
        /// </summary>
        public static AsciSymbol Plus => AC.Plus;

        /// <summary>
        /// The ;' character code 44
        /// </summary>
        public static AsciSymbol Comma => AC.Comma;

        /// <summary>
        /// The '-' character code 45
        /// </summary>
        public static AsciSymbol Dash => AC.Dash;

        /// <summary>
        /// The '.' character code 46
        /// </summary>
        public static AsciSymbol Dot => AC.Dot;

        /// <summary>
        /// The '/' character code 47
        /// </summary>
        public static AsciSymbol FSlash => AC.FS;

        /// <summary>
        /// Specifies the asci code for the digit '0'
        /// </summary>
        public static AsciSymbol d0 => AC.d0;

        /// <summary>
        /// Specifies the asci code for the digit '1'
        /// </summary>
        public static AsciSymbol d1 => AC.d1;

        /// <summary>
        /// Specifies the asci code for the digit '2'
        /// </summary>
        public static AsciSymbol d2 => AC.d2;

        /// <summary>
        /// Specifies the asci code for the digit '3'
        /// </summary>
        public static AsciSymbol d3 => AC.d3;

        /// <summary>
        /// Specifies the asci code for the digit '4'
        /// </summary>
        public static AsciSymbol d4 => AC.d4;

        /// <summary>
        /// Specifies the asci code for the digit '5'
        /// </summary>
        public static AsciSymbol d5 => AC.d5;

        /// <summary>
        /// Specifies the asci code for the digit '6'
        /// </summary>
        public static AsciSymbol d6 => AC.d6;

        /// <summary>
        /// Specifies the asci code for the digit '7'
        /// </summary>
        public static AsciSymbol d7 => AC.d7;

        /// <summary>
        /// Specifies the asci code for the digit '8'
        /// </summary>
        public static AsciSymbol d8 => AC.d8;

        /// <summary>
        /// Specifies the asci code for the digit '9'
        /// </summary>
        public static AsciSymbol d9 => AC.d9;

        /// <summary>
        /// The 'a' symbol code 97
        /// </summary>
        public static AsciSymbol a => AC.a;

        /// <summary>
        /// The 'b' symbol code 98
        /// </summary>
        public static AsciSymbol b => AC.b;

        /// <summary>
        /// The 'c' symbol code 99
        /// </summary>
        public static AsciSymbol c => AC.c;

        /// <summary>
        /// The 'd' symbol code 100
        /// </summary>
        public static AsciSymbol d => AC.d;

        /// <summary>
        /// The 'e' symbol code 101
        /// </summary>
        public static AsciSymbol e => AC.e;

        /// <summary>
        /// The 'f' symbol code 102
        /// </summary>
        public static AsciSymbol f => AC.f;

        /// <summary>
        /// The 'g' symbol code 103
        /// </summary>
        public static AsciSymbol g => AC.g;

        /// <summary>
        /// The 'h' symbol code 104
        /// </summary>
        public static AsciSymbol h => AC.h;

        /// <summary>
        /// The 'i' symbol code 105
        /// </summary>
        public static AsciSymbol i => AC.i;

        /// <summary>
        /// The 'j' symbol code 106
        /// </summary>
        public static AsciSymbol j => AC.j;

        /// <summary>
        /// The 'k' symbol code 107
        /// </summary>
        public static AsciSymbol k => AC.k;

        /// <summary>
        /// The 'l' symbol code 108
        /// </summary>
        public static AsciSymbol l => AC.l;

        /// <summary>
        /// The 'm' symbol code 109
        /// </summary>
        public static AsciSymbol m => AC.m;

        /// <summary>
        /// The 'n' symbol code 110
        /// </summary>
        public static AsciSymbol n => AC.n;

        /// <summary>
        /// The 'o' symbol code 111
        /// </summary>
        public static AsciSymbol o => AC.o;

        /// <summary>
        /// The 'p' symbol code 112
        /// </summary>
        public static AsciSymbol p => AC.p;

        /// <summary>
        /// The 'q' symbol code 113
        /// </summary>
        public static AsciSymbol q => AC.q;

        /// <summary>
        /// The 'r' symbol code 114
        /// </summary>
        public static AsciSymbol r => AC.r;

        /// <summary>
        /// The 's' symbol code 115
        /// </summary>
        public static AsciSymbol s => AC.s;

        /// <summary>
        /// The 't' symbol code 116
        /// </summary>
        public static AsciSymbol t => AC.t;

        /// <summary>
        /// The 'u' symbol code 117
        /// </summary>
        public static AsciSymbol u => AC.u;

        /// <summary>
        /// The 'v' symbol code 118
        /// </summary>
        public static AsciSymbol v => AC.v;

        /// <summary>
        /// The 'w' symbol code 119
        /// </summary>
        public static AsciSymbol w => AC.w;

        /// <summary>
        /// The 'x' symbol code 120
        /// </summary>
        public static AsciSymbol x => AC.x;

        /// <summary>
        /// The 'y' symbol code 121
        /// </summary>
        public static AsciSymbol y => AC.y;

        /// <summary>
        /// The 'z' symbol code 122
        /// </summary>
        public static AsciSymbol z => AC.z;

        /// <summary>
        /// The 'A' symbol code 65
        /// </summary>
        public static AsciSymbol A => AC.A;

        /// <summary>
        /// The 'B' symbol code 66
        /// </summary>
        public static AsciSymbol B => AC.B;

        /// <summary>
        /// The 'C' symbol code 67
        /// </summary>
        public static AsciSymbol C => AC.C;

        /// <summary>
        /// The 'D' symbol code 68
        /// </summary>
        public static AsciSymbol D => AC.D;

        /// <summary>
        /// The 'E' symbol code 69
        /// </summary>
        public static AsciSymbol E => AC.E;

        /// <summary>
        /// The 'F' symbol code 70
        /// </summary>
        public static AsciSymbol F => AC.F;

        /// <summary>
        /// The 'G' symbol code 71
        /// </summary>
        public static AsciSymbol G => AC.G;

        /// <summary>
        /// The 'H' symbol code 72
        /// </summary>
        public static AsciSymbol H => AC.H;

        /// <summary>
        /// The 'I' symbol code 73
        /// </summary>
        public static AsciSymbol I => AC.I;

        /// <summary>
        /// The 'J' symbol code 74
        /// </summary>
        public static AsciSymbol J => AC.J;

        /// <summary>
        /// The 'K' symbol code 75
        /// </summary>
        public static AsciSymbol K => AC.K;

        /// <summary>
        /// The 'L' symbol code 76
        /// </summary>
        public static AsciSymbol L => AC.L;

        /// <summary>
        /// The 'M' symbol code 77
        /// </summary>
        public static AsciSymbol M => AC.M;

        /// <summary>
        /// The 'N' symbol code 78
        /// </summary>
        public static AsciSymbol N => AC.N;

        /// <summary>
        /// The 'O' symbol code 79
        /// </summary>
        public static AsciSymbol O => AC.O;

        /// <summary>
        /// The 'P' symbol code 80
        /// </summary>
        public static AsciSymbol P => AC.P;

        /// <summary>
        /// The 'Q' symbol code 81
        /// </summary>
        public static AsciSymbol Q => AC.Q;

        /// <summary>
        /// The 'R' symbol code 82
        /// </summary>
        public static AsciSymbol R => AC.R;

        /// <summary>
        /// The 'S' symbol code 83
        /// </summary>
        public static AsciSymbol S => AC.S;

        /// <summary>
        /// The 'T' symbol code 84
        /// </summary>
        public static AsciSymbol T => AC.T;

        /// <summary>
        /// The 'U' symbol code 85
        /// </summary>
        public static AsciSymbol U => AC.U;

        /// <summary>
        /// The 'V' symbol code 86
        /// </summary>
        public static AsciSymbol V => AC.V;

        /// <summary>
        /// The 'W' symbol code 87
        /// </summary>
        public static AsciSymbol W => AC.W;

        /// <summary>
        /// The 'X' symbol code 88
        /// </summary>
        public static AsciSymbol X => AC.X;

        /// <summary>
        /// The 'Y' symbol code 89
        /// </summary>
        public static AsciSymbol Y => AC.Y;

        /// <summary>
        /// The 'Z' symbol code 90
        /// </summary>
        public static AsciSymbol Z => AC.Z;

        /// <summary>
        /// The ':' character code 58
        /// </summary>
        public static AsciSymbol Colon => AC.Colon;

        /// <summary>
        /// The ;' character code 59
        /// </summary>
        public static AsciSymbol Semicolon => AC.Semicolon;

        /// <summary>
        /// The '@' character code 64
        /// </summary>
        public static AsciSymbol At => AC.At;

        /// <summary>
        /// The backslash character code 92
        /// </summary>
        public static AsciSymbol BSlash => AC.BS;

        /// <summary>
        /// The '^' character code 94
        /// </summary>
        public static AsciSymbol Caret => AC.Caret;

        /// <summary>
        /// The '=' character code 61
        /// </summary>
        public static AsciSymbol Eq => AC.Eq;

        /// <summary>
        /// The '>' character code 62
        /// </summary>
        public static AsciSymbol Gt => AC.Gt;

        /// <summary>
        /// The '{' character code 128
        /// </summary>
        public static AsciSymbol LBrace => AC.LBrace;

        /// <summary>
        /// The '[' character code 91
        /// </summary>
        public static AsciSymbol LBracket => AC.LBracket;

        /// <summary>
        /// The '<' character code 60
        /// </summary>
        public static AsciSymbol Lt => AC.Lt;

        /// <summary>
        /// The '|' character code 124
        /// </summary>
        public static AsciSymbol Pipe => AC.Pipe;

        /// <summary>
        /// The '?' character code 63
        /// </summary>
        public static AsciSymbol Question => AC.Question;

        /// <summary>
        /// The ']' character code 93
        /// </summary>
        public static AsciSymbol RBracket => AC.RBracket;

        /// <summary>
        /// The '~' character code 126
        /// </summary>
        public static AsciSymbol Tilde => AC.Tilde;

        /// <summary>
        /// The '~' character code 95
        /// </summary>
        public static AsciSymbol Underscore => AC.Underscore;
    }
}
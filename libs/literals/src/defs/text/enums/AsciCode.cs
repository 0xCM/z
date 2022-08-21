//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using AC = AsciCharSym;

    [CodeProvider(typeof(AC)), DataWidth(8)]
    public enum AsciCode : byte
    {
        /// <summary>
        /// The asci code for null
        /// </summary>
        Null = 0,

        /// <summary>
        /// Start of heading
        /// </summary>
        SOH = 1,

        /// <summary>
        /// Start of text
        /// </summary>
        SOT = 2,

        /// <summary>
        /// End of text
        /// </summary>
        EOT = 3,

        /// <summary>
        /// End of transmission
        /// </summary>
        EOTR = 4,

        /// <summary>
        /// Enquiry
        /// </summary>
        ENQ = 5,

        /// <summary>
        /// Acknowledgement
        /// </summary>
        ACK = 6,

        /// <summary>
        /// Hell's bells, asci code 7
        /// </summary>
        Bell = 7,

        /// <summary>
        /// The backspace control symbol '\b', asci code 8
        /// </summary>
        BS = (byte)'\b',

        /// <summary>
        /// The tab character code 9
        /// </summary>
        [Symbol(AC.Tab)]
        Tab = (byte)AC.Tab,

        /// <summary>
        /// The vertical tab
        /// </summary>
        [Symbol(AC.VTab)]
        VTab = (byte)AC.VTab,

        /// <summary>
        /// The new-line character code 10
        /// </summary>
        [Symbol(AC.NL)]
        NL = (byte)AC.NL,

        /// <summary>
        /// The form-feed control character
        /// </summary>
        FF = (byte)AC.FF,

        /// <summary>
        /// The carriage-return character code 13
        /// </summary>
        CR = (byte)AC.CR,

        /// <summary>
        /// The ' ' character code 32
        /// </summary>
        Space = (byte)AC.Space,

        /// <summary>
        /// The '!' character code 33
        /// </summary>
        Bang = (byte)AC.Bang,

        /// <summary>
        /// The '"' character code 34
        /// </summary>
        Quote = (byte)AC.DQuote,

        /// <summary>
        /// The '#' character code 35
        /// </summary>
        Hash = (byte)AC.Hash,

        /// <summary>
        /// The '$' character code 36
        /// </summary>
        Dollar = (byte)AC.Dollar,

        /// <summary>
        /// The '%' character code 37
        /// </summary>
        Percent = (byte)AC.Percent,

        /// <summary>
        /// The '&' character code 38
        /// </summary>
        Amp = (byte)AC.Amp,

        /// <summary>
        /// The ''' character code 39
        /// </summary>
        SQuote = (byte)AC.SQuote,

        /// <summary>
        /// The '(' character code 40
        /// </summary>
        LParen = (byte)AC.LParen,

        /// <summary>
        /// The ')' character code 41
        /// </summary>
        RParen = (byte)AC.RParen,

        /// <summary>
        /// The '}' character code 41
        /// </summary>
        RBrace = (byte)AC.RParen,

        /// <summary>
        /// The '*' character code 42
        /// </summary>
        Mul = (byte)AC.Mul,

        /// <summary>
        /// The '+' character code 43
        /// </summary>
        Plus = (byte)AC.Plus,

        /// <summary>
        /// The ,' character code 44
        /// </summary>
        Comma = (byte)AC.Comma,

        /// <summary>
        /// The '-' character code 45
        /// </summary>
        Dash = (byte)AC.Dash,

        /// <summary>
        /// The '.' character code 46
        /// </summary>
        Dot = (byte)AC.Dot,

        /// <summary>
        /// The '/' character code 47
        /// </summary>
        FS = (byte)AC.FS,

        /// <summary>
        /// The '0' character code 48
        /// </summary>
        d0 = (byte)AC.d0,

        /// <summary>
        /// The '1' character code 49
        /// </summary>
        d1 = (byte)AC.d1,

        /// <summary>
        /// The '2' character code 50
        /// </summary>
        d2 = (byte)AC.d2,

        /// <summary>
        /// The '3' character code 51
        /// </summary>
        d3 = (byte)AC.d3,

        /// <summary>
        /// The '4' character code 52
        /// </summary>
        d4 = (byte)AC.d4,

        /// <summary>
        /// The '5' character code 53
        /// </summary>
        d5 = (byte)AC.d5,

        /// <summary>
        /// The '6' character code 54
        /// </summary>
        d6 = (byte)AC.d6,

        /// <summary>
        /// The '7' character code 55
        /// </summary>
        d7 = (byte)AC.d7,

        /// <summary>
        /// The '8' character code 56
        /// </summary>
        d8 = (byte)AC.d8,

        /// <summary>
        /// The '9' character code 57
        /// </summary>
        d9 = (byte)AC.d9,

        /// <summary>
        /// The 'a' symbol code 97
        /// </summary>
        a = (byte)AC.a,

        /// <summary>
        /// The 'b' symbol code 98
        /// </summary>
        b = (byte)AC.b,

        /// <summary>
        /// The 'c' symbol code 99
        /// </summary>
        c = (byte)AC.c,

        /// <summary>
        /// The 'd' symbol code 100
        /// </summary>
        d = (byte)AC.d,

        /// <summary>
        /// The 'e' symbol code 101
        /// </summary>
        e = (byte)AC.e,

        /// <summary>
        /// The 'f' symbol code 102
        /// </summary>
        f = (byte)AC.f,

        /// <summary>
        /// The 'g' symbol code 103
        /// </summary>
        g = (byte)AC.g,

        /// <summary>
        /// The 'h' symbol code 104
        /// </summary>
        h = (byte)AC.h,

        /// <summary>
        /// The 'i' symbol code 105
        /// </summary>
        i = (byte)AC.i,

        /// <summary>
        /// The 'j' symbol code 106
        /// </summary>
        j = (byte)AC.j,

        /// <summary>
        /// The 'k' symbol code 107
        /// </summary>
        k = (byte)AC.k,

        /// <summary>
        /// The 'l' symbol code 108
        /// </summary>
        l = (byte)AC.l,

        /// <summary>
        /// The 'm' symbol code 109
        /// </summary>
        m = (byte)AC.m,

        /// <summary>
        /// The 'n' symbol code 110
        /// </summary>
        n = (byte)AC.n,

        /// <summary>
        /// The 'o' symbol code 111
        /// </summary>
        o = (byte)AC.o,

        /// <summary>
        /// The 'p' symbol code 112
        /// </summary>
        p = (byte)AC.p,

        /// <summary>
        /// The 'q' symbol code 113
        /// </summary>
        q = (byte)AC.q,

        /// <summary>
        /// The 'r' symbol code 114
        /// </summary>
        r = (byte)AC.r,

        /// <summary>
        /// The 's' symbol code 115
        /// </summary>
        s = (byte)AC.s,

        /// <summary>
        /// The 't' symbol code 116
        /// </summary>
        t = (byte)AC.t,

        /// <summary>
        /// The 'u' symbol code 117
        /// </summary>
        u = (byte)AC.u,

        /// <summary>
        /// The 'v' symbol code 118
        /// </summary>
        v = (byte)AC.v,

        /// <summary>
        /// The 'w' symbol code 119
        /// </summary>
        w = (byte)AC.w,

        /// <summary>
        /// The 'x' symbol code 120
        /// </summary>
        x = (byte)AC.x,

        /// <summary>
        /// The 'y' symbol code 121
        /// </summary>
        y = (byte)AC.y,

        /// <summary>
        /// The 'z' symbol code 122
        /// </summary>
        z = (byte)AC.z,

        /// <summary>
        /// The 'A' symbol code 65
        /// </summary>
        A = (byte)AC.A,

        /// <summary>
        /// The 'B' symbol code 66
        /// </summary>
        B = (byte)AC.B,

        /// <summary>
        /// The 'C' symbol code 67
        /// </summary>
        C = (byte)AC.C,

        /// <summary>
        /// The 'D' symbol code 68
        /// </summary>
        D = (byte)AC.D,

        /// <summary>
        /// The 'E' symbol code 69
        /// </summary>
        E = (byte)AC.E,

        /// <summary>
        /// The 'F' symbol code 70
        /// </summary>
        F = (byte)AC.F,

        /// <summary>
        /// The 'G' symbol code 71
        /// </summary>
        G = (byte)AC.G,

        /// <summary>
        /// The 'H' symbol code 72
        /// </summary>
        H = (byte)AC.H,

        /// <summary>
        /// The 'I' symbol code 73
        /// </summary>
        I = (byte)AC.I,

        /// <summary>
        /// The 'J' symbol code 74
        /// </summary>
        J = (byte)AC.J,

        /// <summary>
        /// The 'K' symbol code 75
        /// </summary>
        K = (byte)AC.K,

        /// <summary>
        /// The 'L' symbol code 76
        /// </summary>
        L = (byte)AC.L,

        /// <summary>
        /// The 'M' symbol code 77
        /// </summary>
        M = (byte)AC.M,

        /// <summary>
        /// The 'N' symbol code 78
        /// </summary>
        N = (byte)AC.N,

        /// <summary>
        /// The 'O' symbol code 79
        /// </summary>
        O = (byte)AC.O,

        /// <summary>
        /// The 'P' symbol code 80
        /// </summary>
        P = (byte)AC.P,

        /// <summary>
        /// The 'Q' symbol code 81
        /// </summary>
        Q = (byte)AC.Q,

        /// <summary>
        /// The 'R' symbol code 82
        /// </summary>
        R = (byte)AC.R,

        /// <summary>
        /// The 'S' symbol code 83
        /// </summary>
        S = (byte)AC.S,

        /// <summary>
        /// The 'T' symbol code 84
        /// </summary>
        T = (byte)AC.T,

        /// <summary>
        /// The 'U' symbol code 85
        /// </summary>
        U = (byte)AC.U,

        /// <summary>
        /// The 'V' symbol code 86
        /// </summary>
        V = (byte)AC.V,

        /// <summary>
        /// The 'W' symbol code 87
        /// </summary>
        W = (byte)AC.W,

        /// <summary>
        /// The 'X' symbol code 88
        /// </summary>
        X = (byte)AC.X,

        /// <summary>
        /// The 'Y' symbol code 89
        /// </summary>
        Y = (byte)AC.Y,

        /// <summary>
        /// The 'Z' symbol code 90
        /// </summary>
        Z = (byte)AC.Z,

        /// <summary>
        /// The ':' character code 58
        /// </summary>
        Colon = (byte)AC.Colon,

        /// <summary>
        /// The ,' character code 59
        /// </summary>
        Semicolon = (byte)AC.Semicolon,

        /// <summary>
        /// The '@' character code 64
        /// </summary>
        At = (byte)AC.At,

        /// <summary>
        /// The backslash character code 92
        /// </summary>
        BSlash = (byte)AC.BS,

        /// <summary>
        /// The '^' character code 94
        /// </summary>
        Caret = (byte)AC.Caret,

        /// <summary>
        /// The '=' character code 61
        /// </summary>
        Eq = (byte)AC.Eq,

        /// <summary>
        /// The '>' character code 62
        /// </summary>
        Gt = (byte)AC.GT,

        /// <summary>
        /// The '{' character code 128
        /// </summary>
        LBrace = (byte)AC.LBrace,

        /// <summary>
        /// The '[' character code 91
        /// </summary>
        LBracket = (byte)AC.LBracket,

        /// <summary>
        /// The '<' character code 60
        /// </summary>
        Lt = (byte)AC.LT,

        /// <summary>
        /// The '|' character code 124
        /// </summary>
        Pipe = (byte)AC.Pipe,

        /// <summary>
        /// The '?' character code 63
        /// </summary>
        Question = (byte)AC.Question,

        /// <summary>
        /// The ']' character code 93
        /// </summary>
        RBracket = (byte)AC.RBracket,

        /// <summary>
        /// The '~' character code 126
        /// </summary>
        Tilde = (byte)AC.Tilde,

        /// <summary>
        /// The '~' character code 95
        /// </summary>
        Underscore = (byte)AC.US,
    }
}
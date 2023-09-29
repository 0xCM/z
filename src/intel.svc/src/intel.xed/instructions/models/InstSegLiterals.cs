//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    public readonly struct InstSegLiterals
    {
        const string over = "/";

        const string sep = "_";

        public const string a = nameof(a);

        public const string b = nameof(b);

        public const string d = nameof(d);

        public const string i = nameof(i);

        public const string m = nameof(m);

        public const string n = nameof(n);

        public const string r = nameof(r);

        public const string s = nameof(s);

        public const string u = nameof(u);

        public const string w = nameof(w);

        public const string x = nameof(x);

        public const string z = nameof(z);

        public const string a8 = "a/8";

        public const string a16 = "a/16";

        public const string a32 = "a/32";

        public const string a64 = "a/64";

        public const string d8 = "d/8";

        public const string d16 = "d/16";

        public const string d32 = "d/32";

        public const string d64 = "d/64";

        public const string i8 = "i/8";

        public const string i16 = "i/16";

        public const string i32 = "i/32";

        public const string i64 = "i/64";

        public const string aaa = nameof(aaa);

        public const string bbb = nameof(bbb);

        public const string dd = nameof(dd);

        public const string ddd = nameof(ddd);

        public const string dddd = nameof(dddd);

        public const string iii = nameof(iii);

        public const string mm = nameof(mm);

        public const string nn = nameof(nn);

        public const string nnn = nameof(nnn);

        public const string rrr = nameof(rrr);

        public const string ss = nameof(ss);

        public const string ssss = nameof(ssss);

        public const string uuuu = nameof(uuuu);

        public const string ssss_uuuu = nameof(ssss_uuuu);

        public static Index<Paired<byte,string>> Index(){
            var k =z8;
            return new Paired<byte,string>[]{
            (k++,EmptyString),
            (k++, a), (k++,b), (k++,d), (k++,i), (k++,m), (k++,n), (k++,r), (k++,s), (k++,u), (k++, w), (k++,x), (k++,z),

            (k++, aaa),
            (k++, bbb),
            (k++, dd), (k++, ddd), (k++, dddd),
            (k++, iii),
            (k++, mm),
            (k++, nn),
            (k++, nnn),
            (k++, rrr),
            (k++, ss), (k++, ssss),
            (k++, uuuu),

            (k++, ssss_uuuu),

            (k++, d8), (k++, d16), (k++, d32), (k++, d64),
            (k++, a8), (k++, a16), (k++, a32), (k++, a64),
            (k++, i8), (k++, i16), (k++, i32), (k++, i64),
            };
        }
    }
}

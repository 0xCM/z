//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Chars;
    using static sys;

    public readonly struct AsmThumbprint : IComparable<AsmThumbprint>, IEquatable<AsmThumbprint>
    {
        public static SortedSpan<AsmThumbprint> distinct(ReadOnlySpan<HostAsmRecord> src)
        {
            var distinct = hashset<AsmThumbprint>();
            iter(src, s => distinct.Add(AsmThumbprint.define(s)));
            return distinct.Array().ToSortedSpan();
        }

        [MethodImpl(Inline),Op]
        public static AsmThumbprint define(AsmExpr statement, AsmSigInfo sig, TextBlock opcode, AsmHexCode encoded)
            => new AsmThumbprint(statement, sig, opcode, encoded);

        [MethodImpl(Inline),Op]
        public static AsmThumbprint define(AsmExpr statement, AsmFormInfo form, AsmHexCode encoded)
            => new AsmThumbprint(statement, form.Sig, form.OpCode, encoded);

        [MethodImpl(Inline),Op]
        public static AsmThumbprint define(in HostAsmRecord src)
            => define(src.Expression, src.Sig, src.OpCode, src.Encoded);

        public static string comment(in AsmThumbprint src)
            => new AsmInlineComment(AsmCommentMarker.Hash, string.Format("({0})<{1}>[{2}] => {3}", src.Sig, src.OpCode, src.Encoded.Size, src.Encoded.Format()));

        [Op]
        public static string format(in AsmThumbprint src)
            => string.Format("{0} {1}", src.Statement.FormatPadded(), comment(src));

        [Op]
        public static string bitstring(in AsmThumbprint src)
            => string.Format("{0} => {1}", format(src), src.Encoded.BitString);

        static Fence<char> SigFence => (LParen, RParen);

        static Fence<char> OpCodeFence => (Lt, Gt);

        const string Implication = " => ";

        public static Outcome parse(string src, out AsmThumbprint thumbprint)
        {
            thumbprint = AsmThumbprint.Empty;
            var result = Outcome.Success;
            var a = src.LeftOfFirst(Semicolon);
            Hex.parse16u(a.LeftOfFirst(Chars.Space), out var offset);
            AsmExpr statement = a.RightOfFirst(Semicolon);

            var parts = @readonly(src.RightOfFirst(Semicolon).SplitClean(Implication));
            if(parts.Length < 2)
                return (false, $"Could not partition {src} ");

            var A = skip(parts,0);
            var B = skip(parts,1).Trim();

            // For thumbprints that include a bitstring such as 0001 0000 0000 1111
            var C = parts.Length > 2 ? skip(parts,2) : EmptyString;
            if(Fenced.unfence(A, SigFence, out var sigexpr))
            {
                result = AsmSigInfo.parse(sigexpr, out var sig);
                if(result.Fail)
                    return (false, $"Could not parse sig expression from ${sigexpr}");

                if(Fenced.unfence(A, OpCodeFence, out var opcode))
                {
                    if(AsmHexApi.parse(B, out var encoded))
                    {
                        thumbprint = new AsmThumbprint(statement, sig, opcode, encoded);
                        return true;
                    }
                    else
                        return (false, "Could not parse the encoded bytes");
                }
                else
                    return (false, Msg.OpCodeFenceNotFound.Format(OpCodeFence));
            }
            else
                return (false, $"Could not locate the signature fence {SigFence}");
        }

        public AsmExpr Statement {get;}

        public AsmSigInfo Sig {get;}

        public TextBlock OpCode {get;}

        public AsmHexCode Encoded {get;}

        [MethodImpl(Inline), Op]
        public AsmThumbprint(AsmExpr statement, AsmSigInfo sig, TextBlock opcode, AsmHexCode encoded)
        {
            Statement = statement;
            Sig = sig;
            OpCode = opcode;
            Encoded = encoded;
        }

        public byte CodeSize
        {
            [MethodImpl(Inline)]
            get => Encoded.Size;
        }

        public int CompareTo(AsmThumbprint src)
            => cmp(this, src);

        public bool Equals(AsmThumbprint src)
            => eq(this, src);

        public override int GetHashCode()
            => Format().GetHashCode();
        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        public static AsmThumbprint Empty
        {
            [MethodImpl(Inline)]
            get => new AsmThumbprint(AsmExpr.Empty, AsmSigInfo.Empty, TextBlock.Empty, AsmHexCode.Empty);
        }

        [Op]
        static int cmp(in AsmThumbprint a, in AsmThumbprint b)
            => format(a).CompareTo(format(b));

        [Op]
        static bool eq(in AsmThumbprint a, in AsmThumbprint b)
            => format(a).Equals(format(b));
    }
}
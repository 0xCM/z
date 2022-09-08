//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    using K = AsmOcTokenKind;

    public class AsmOcDatasets
    {
        public static AsmOcDatasets load()
        {
            var dst = new AsmOcDatasets();
            dst.TokenKinds = Symbols.index<AsmOcTokenKind>();
            var src = AsmOcTokens.create();
            var types = src.TokenTypes;
            var tokenExpr = dict<uint,string>();
            var names = dict<uint,string>();
            var exprToken = dict<string,AsmOcToken>();
            var _tokens = alloc<AsmOcToken>(src.TokenCount);
            var _records = alloc<AsmToken>(src.TokenCount);
            dst.TypeKinds = src.TypeKinds;
            var k=0u;
            for(var i=0; i<types.Length; i++)
            {
                var kind = src.Kind(skip(types,i));
                var tokens = src.Tokens(skip(types,i));
                for(var j=0u; j<tokens.Count; j++, k++)
                {
                    ref readonly var token = ref tokens[j];
                    ref var record = ref seek(_records,k);

                    var sigop = new AsmOcToken(kind, (byte)token.Value);
                    seek(_tokens,k) = sigop;
                    tokenExpr[sigop.Id] = token.Expr.Text;
                    exprToken[token.Expr.Text] = sigop;
                    names[sigop.Id] = token.Name;
                    record.Seq = k;
                    record.Group = token.Group;
                    record.Index = j;
                    record.Kind = token.Type.Text;
                    record.Expr = token.Expr;
                    record.Value = token.Value;
                    record.Name = token.Name.Text;
                }
            }
            dst.Names = names;
            dst.Expressions = tokenExpr;
            dst.TokensByExpression = exprToken;
            dst._Tokens = _tokens;
            dst._Records = _records;
            return dst;
        }

        public ConstLookup<uint,string> Names {get; private set;}

        public ConstLookup<uint,string> Expressions {get; private set;}

        public ConstLookup<string,AsmOcToken> TokensByExpression {get; private set;}

        ReadOnlySeq<AsmOcToken> _Tokens;

        ReadOnlySeq<AsmToken> _Records;

        public ref readonly ReadOnlySeq<AsmToken> Records
        {
            [MethodImpl(Inline)]
            get => ref _Records;
        }

        public ref readonly ReadOnlySeq<AsmOcToken> Tokens
        {
            [MethodImpl(Inline)]
            get => ref _Tokens;
        }

        public ConstLookup<Type,K> TypeKinds {get; private set;}

        public Symbols<AsmOcTokenKind> TokenKinds {get; private set;}
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    using static sys;
    using static SyntaxKind;

    class SyntaxNodeParser
    {
        readonly IWfChannel Channel;

        public SyntaxNodeParser(IWfChannel channel)
        {
            Channel = channel;
        }

        void Parse(ClassDeclarationSyntax src)
        {            
            iter(src.ChildNodes(), ParseNode);
        }

        void Parse(StructDeclarationSyntax src)
        {
            iter(src.ChildNodes(), ParseNode);
        }

        void Parse(EnumDeclarationSyntax src)
        {
            iter(src.ChildNodes(), ParseNode);            
        }

        void Parse(UsingDirectiveSyntax src)
        {
            iter(src.ChildNodes(), ParseNode);
        }

        void Parse(FieldDeclarationSyntax src)
        {
            iter(src.ChildNodes(), ParseNode);
        }

        void Parse(PropertyDeclarationSyntax src)
        {
            iter(src.ChildNodes(), ParseNode);
        }

        void Parse(MethodDeclarationSyntax src)
        {
            iter(src.ChildNodes(), ParseNode);            
        }

        void Parse(EnumMemberDeclarationSyntax src)
        {
            iter(src.ChildNodes(), ParseNode);            
        }

        void Parse(MemberDeclarationSyntax src)
        {
            var kind = src.Kind();
            switch(kind)
            {
                case ClassDeclaration:
                    Parse(src as ClassDeclarationSyntax);
                break;
                case StructDeclaration:
                    Parse(src as StructDeclarationSyntax);
                break;
                case EnumDeclaration:
                    Parse(src as EnumDeclarationSyntax);
                break;
                
            }
            Channel.Row($"Member:{src.Kind()}");
        }

        void Parse(NamespaceDeclarationSyntax src)
        {
            iter(src.Members, Parse);
        }

        void Parse(ParameterListSyntax src)
        {
            iter(src.ChildNodes(), ParseNode);            
        }

        void Parse(IdentifierNameSyntax src)
        {
            Channel.Row(src);
        }

        void Parse(ParameterSyntax src)
        {
            iter(src.ChildNodes(), ParseNode);
        }

        void Parse(BlockSyntax src)
        {
            iter(src.ChildNodes(), ParseNode);
        }

        void Parse(ExpressionStatementSyntax src)
        {
            iter(src.ChildNodes(), ParseNode);
        }

        void Parse(CompilationUnitSyntax src)
        {
            iter(src.ChildNodes(), ParseNode);
        }

        void Parse(GlobalStatementSyntax src)
        {
            iter(src.ChildNodes(), ParseNode);
        }

        void Parse(LocalDeclarationStatementSyntax src)
        {
            iter(src.ChildNodes(), ParseNode);
        }

        void Parse(VariableDeclarationSyntax src)
        {
            iter(src.ChildNodes(), ParseNode);
        }

        void Parse(InitializerExpressionSyntax src)
        {
            iter(src.ChildNodes(), ParseNode);
        }

        void Parse(OmittedArraySizeExpressionSyntax src)
        {
            iter(src.ChildNodes(), ParseNode);
        }

        void Parse(PredefinedTypeSyntax src)
        {
            iter(src.ChildNodes(), ParseNode);
        }

        void Parse(VariableDeclaratorSyntax src)
        {
            iter(src.ChildNodes(), ParseNode);
        }

        void Parse(ArgumentSyntax src)
        {
            iter(src.ChildNodes(), ParseNode);
        }

        void Parse(BracketedArgumentListSyntax src)
        {
            iter(src.ChildNodes(), ParseNode);
        }

        void Parse(EqualsValueClauseSyntax src)
        {
            iter(src.ChildNodes(), ParseNode);
        }

        public void ParseNode(SyntaxNode src)
        {
            var kind = src.Kind();
            switch(kind)
            {
                case CompilationUnit:
                    Parse(src as CompilationUnitSyntax);
                    break;
                case Argument:
                    Parse(src as ArgumentSyntax);
                    break;
                case BracketedArgumentList:
                    Parse(src as BracketedArgumentListSyntax);
                    break;
                case EqualsValueClause:
                    Parse(src as EqualsValueClauseSyntax);
                    break;
                case PredefinedType:
                    Parse(src as PredefinedTypeSyntax);
                    break;
                case UsingDirective:
                    Parse(src as UsingDirectiveSyntax);
                break;
                case VariableDeclarator:
                    Parse(src as VariableDeclaratorSyntax);
                break;
                case GlobalStatement:
                    Parse(src as GlobalStatementSyntax);
                break;
                case LocalDeclarationStatement:
                    Parse(src as LocalDeclarationStatementSyntax);
                break;
                case NamespaceDeclaration:
                    Parse(src as NamespaceDeclarationSyntax);
                break;
                case VariableDeclaration:
                    Parse(src as VariableDeclarationSyntax);
                break;
                case PropertyDeclaration:
                    Parse(src as PropertyDeclarationSyntax);
                break;
                case MethodDeclaration:
                    Parse(src as MethodDeclarationSyntax);
                break;
                case FieldDeclaration:
                    Parse(src as FieldDeclarationSyntax);
                break;
                case EnumMemberDeclaration:
                    Parse(src as EnumMemberDeclarationSyntax);
                break;
                case ParameterList:
                    Parse(src as ParameterListSyntax);
                    break;
                case EnumDeclaration:
                    Parse(src as EnumDeclarationSyntax);
                    break;
                case StructDeclaration:
                    Parse(src as StructDeclarationSyntax);
                    break;
                case ClassDeclaration:
                    Parse(src as ClassDeclarationSyntax);
                    break;
                case IdentifierName:
                    Parse(src as IdentifierNameSyntax);
                    break;
                case Parameter:
                    Parse(src as ParameterSyntax);
                    break;
                case Block:
                    Parse(src as BlockSyntax);
                    break;
                case ExpressionStatement:
                    Parse(src as ExpressionStatementSyntax);
                    break;
                case NumericLiteralExpression:
                    Channel.Row($"{kind}:{src}");
                break;
                case CharacterLiteralExpression:
                    Channel.Row($"{kind}:{src}");
                break;
                case ArrayInitializerExpression:
                    Parse(src as InitializerExpressionSyntax);
                break;
                case OmittedArraySizeExpression:
                    Parse(src as OmittedArraySizeExpressionSyntax);
                break;
                default:
                    Channel.Row(kind);
                    break;
            }
        }
    }
}
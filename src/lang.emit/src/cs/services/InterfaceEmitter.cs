//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static CsModels;

    partial class CsLang
    {
        public class InterfaceEmitter : AppService<InterfaceEmitter>
        {
            readonly Symbols<ClrAccessKind> AccessKinds;

            readonly Symbols<ClrModifierKind> MethodModifiers;

            readonly Symbols<ClrParamModifierKind> ParamModifiers;

            public InterfaceEmitter()
            {
                AccessKinds = Symbols.index<ClrAccessKind>();
                MethodModifiers = Symbols.index<ClrModifierKind>();
                ParamModifiers = Symbols.index<ClrParamModifierKind>();
            }

            public void EmitContracts(ReadOnlySpan<FunctionContract> src, uint margin, ITextBuffer dst)
            {
                var count = src.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var contract = ref skip(src,i);
                    if(contract.Access != 0)
                    {
                        ref readonly var access = ref AccessKinds[contract.Access];
                        dst.IndentLineFormat(margin,"{0}", access.Expr);
                    }

                    if(contract.Modifier != 0)
                        dst.AppendFormat(" {0}", MethodModifiers[contract.Modifier].Expr);

                    dst.AppendFormat(" {0}(", contract.FunctionName);

                    var operands = contract.Operands;
                    var opcount = operands.Count;

                    for(var j=0; j<opcount; j++)
                    {
                        ref readonly var param = ref operands[j];
                        if(param.Modifier != 0)
                            dst.AppendFormat("{0} ", ParamModifiers[param.Modifier].Expr);

                        dst.AppendFormat("{0}", param.OperandType);
                        dst.AppendFormat(" {0}", param.OperandName);
                        if(j != opcount - 1)
                            dst.Append(", ");
                    }

                    dst.Append(")");

                    if(!contract.HasBody)
                        dst.Append(';');
                }
            }
        }
    }
}

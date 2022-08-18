//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct ApiSigs
    {
        public static void render(ApiOperandSig src, ITextEmitter dst)
        {
            if(returns(src))
                dst.Append(ReturnIndicator);
            else
                dst.Append(src.Name);
            dst.Append(Chars.Colon);
            render(src.Type, dst);
        }

        public static void render(ISigTypeParam src, ITextEmitter dst)
        {
            if(src.IsOpen)
                dst.Append(src.Name);
            else
                render(src.Closure, dst);
        }

        public static void render(ApiTypeSig src, ITextEmitter dst)
        {
            dst.Append(src.TypeName);
            if(src.IsParametric)
            {
                var count = src.ParameterCount;
                var parameters = src.Parameters.View;
                dst.Append(TypeParamOpen);
                for(var i=0; i<count; i++)
                {
                    render(skip(parameters,i), dst);
                    if(i != count - 1)
                        dst.Append(TypeParamSep);
                }

                dst.Append(TypeParamClose);
            }
        }

        public static void render(in ApiSig src, ITextEmitter dst)
        {
            var parts = src.Components.View;
            var count = parts.Length;
            for(var i=0; i<count; i++)
            {
                dst.Append(core.skip(parts,i).Name);
                if(i != count - 1)
                    dst.Append(Arrow);
            }
        }

        public static void render(ApiOperationSig src, ITextEmitter dst)
        {
            dst.Append(src.Name);
            dst.Append(OperandLead);
            var opcount = src.OperandCount;
            var operands = src.Operands.View;
            for(var i=0; i<opcount; i++)
            {
                ref readonly var operand = ref skip(operands,i);
                render(operand, dst);
                dst.Append(Arrow);
            }
            render(src.Return, dst);
        }


        const string ReturnIndicator = "@return";

        const string Arrow = " -> ";

        const string OperandLead = "::";

        const string TypeParamOpen = "{";

        const string TypeParamClose = "}";

        const string TypeParamSep = ", ";
    }
}
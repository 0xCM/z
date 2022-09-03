//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class FunctionType : IFunctionType
    {
        public Identifier Name {get;}

        public Index<TypeRef> Operands {get;}

        public TypeRef Return {get;}

        public KeyedValues<string,TypeParam> Parameters {get;}

        public FunctionType(Identifier name, KeyedValues<string,TypeParam> parameters, TypeRef[] ops, TypeRef ret)
        {
            Name = name;
            Operands = ops;
            Parameters = parameters;
            Return = ret;
        }

        public string Format()
            => TypeFormatter.format(this);
    }
}
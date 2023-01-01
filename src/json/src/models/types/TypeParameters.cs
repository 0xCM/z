//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonTypes 
    {
        public sealed class TypeParameters : Seq<TypeParameters,TypeParameter>
        {
            public TypeParameters()
            {

            }

            public TypeParameters(params TypeParameter[] src)
                : base(src)
            {

            }
            
        }
    }        
}
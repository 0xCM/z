//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        public interface IEncodingRule
        {
            byte RuleId {get;}

            EncodingClass Class {get;}
        }

        public interface IEncodingRule<T> : IEncodingRule
            where T : struct, IEncodingRule<T>
        {

        }

        public interface IEncodingRule<T,K> : IEncodingRule<T>
            where T : struct, IEncodingRule<T>
            where K : unmanaged
        {
            K Kind {get;}

            byte IEncodingRule.RuleId
                => core.bw8(Kind);
        }
    }
}
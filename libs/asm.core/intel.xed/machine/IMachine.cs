//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedOps
    {
        public interface IMachine : IDisposable
        {
            uint Id {get;}

            void Load(InstPattern src);

            void Reset();
        }
    }
}
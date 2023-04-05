//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct MethodDebugInfo
    {
        public ImmutableArray<string> Sig;

        public BinaryCode SequencePoints;
    }
}
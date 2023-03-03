//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaModels;

    partial class EcmaReader
    {
        public Module ReadModuleDef()
        {
            var src = MD.GetModuleDefinition();
            return new Module((ushort)src.Generation, src.Name, src.Mvid, src.GenerationId, src.BaseGenerationId);
        }
    }            
}
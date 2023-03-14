//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaTables;

    partial class EcmaReader
    {
        public Module ReadModuleRow()
        {
            var src = MD.GetModuleDefinition();
            return new Module((ushort)src.Generation, src.Name, src.Mvid, src.GenerationId, src.BaseGenerationId);
        }
    }            
}
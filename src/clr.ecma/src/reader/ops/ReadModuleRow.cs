//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Ecma;

    partial class EcmaReader
    {
        public ModuleRow ReadModuleRow()
        {
            var src = MD.GetModuleDefinition();
            return new ModuleRow((ushort)src.Generation, src.Name, src.Mvid, src.GenerationId, src.BaseGenerationId);
        }
    }            
}
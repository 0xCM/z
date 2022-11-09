//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    [ApiHost]
    public sealed class Roslyn : AppService<Roslyn>
    {
        [Op]
        public CaCompilation<CSharpCompilation> Compilation(string name, params MetadataReference[] refs)
            => CSharpCompilation.Create(name, references: refs);
    }
}
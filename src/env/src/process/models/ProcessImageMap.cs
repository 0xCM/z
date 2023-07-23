//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public record ProcessImageMap
{
    public readonly ProcessMemoryState MemoryState;

    /// <summary>
    /// Specfies the images mapped into the process
    /// </summary>
    public readonly ReadOnlySeq<ImageLocation> Images;

    public readonly ReadOnlySeq<ProcessModuleRef> Modules;

    [MethodImpl(Inline)]
    public ProcessImageMap(ProcessMemoryState state, ReadOnlySeq<ImageLocation> locations, ReadOnlySeq<ProcessModuleRef> modules)
    {
        MemoryState = state;
        Images = locations.Sort();
        Modules =  modules.Sort();
    }

    public string Format()
        => this.ToString();
}

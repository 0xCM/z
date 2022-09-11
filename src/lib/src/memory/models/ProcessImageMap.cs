//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class ProcessImageMap
    {
        public readonly ProcessMemoryState MemoryState;

        /// <summary>
        /// Specfies the images mapped into the process
        /// </summary>
        public readonly ReadOnlySeq<ImageLocation> Images;

        public readonly ReadOnlySeq<MemoryAddress> Addresses;

        public readonly ReadOnlySeq<ProcessModuleRow> Modules;

        [MethodImpl(Inline)]
        public ProcessImageMap(ProcessMemoryState state, ReadOnlySeq<ImageLocation> locations, ReadOnlySeq<MemoryAddress> addresses, ReadOnlySeq<ProcessModuleRow> modules)
        {
            MemoryState = state;
            Images = locations;
            Addresses = addresses;
            Modules = modules;
        }
    }
}
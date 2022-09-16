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
        public readonly DelimitedSeq<ImageLocation> Images;

        public readonly DelimitedSeq<MemoryAddress> Addresses;

        public readonly DelimitedSeq<ProcessModuleRow> Modules;

        [MethodImpl(Inline)]
        public ProcessImageMap(ProcessMemoryState state, ReadOnlySeq<ImageLocation> locations, ReadOnlySeq<MemoryAddress> addresses, ReadOnlySeq<ProcessModuleRow> modules)
        {
            MemoryState = state;
            Images = Delimiting.seq(locations, Chars.NL, RP.Embraced);
            Addresses = Delimiting.seq(addresses, Chars.Comma, RP.Embraced);
            Modules =  Delimiting.seq(modules, Chars.NL, RP.Embraced);
        }

        public string ImageName
        {
            [MethodImpl(Inline)]
            get => MemoryState.ImageName;
        }

        public ProcessId ProcessId
        {
            [MethodImpl(Inline)]
            get => MemoryState.ProcessId;
        }

        public string Format()
            => this.ToString();
    }
}
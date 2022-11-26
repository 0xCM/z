//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaTables;

    partial class PeReader
    {
        public static ReadOnlySeq<PeSectionHeader> headers(PEReader src)
        {
            var headers = src.PEHeaders;
            var pe = headers.PEHeader;
            var sections = src.PEHeaders.SectionHeaders.AsSpan();
            var count = sections.Length;
            var buffer = sys.alloc<PeSectionHeader>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var section = ref skip(sections,i);
                ref var dst = ref seek(buffer,i);
                dst.EntryPoint = (Address32)pe.AddressOfEntryPoint;
                dst.CodeBase = (Address32)pe.BaseOfCode;
                dst.GptRva = (Address32)pe.GlobalPointerTableDirectory.RelativeVirtualAddress;
                dst.GptSize = (ByteSize)pe.GlobalPointerTableDirectory.Size;
                dst.SectionFlags = section.SectionCharacteristics;
                dst.SectionName = section.Name;
                dst.RawDataAddress = (Address32)section.PointerToRawData;
                dst.RawDataSize = (uint)section.SizeOfRawData;
            }
            return buffer;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EcmaTables;

    partial class PeReader
    {
        [Op]
        public unsafe bool FindResource(string name, out ResourceSeg dst)
        {
            dst = default;
            var directory = ReadSectionData(ResourcesDirectory);
            var descriptions = CliReader().ReadResInfo();
            var count = descriptions.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var description = ref descriptions[i];
                if(description.Name.Equals(name))
                {
                    var blobReader = directory.GetReader((int)description.Offset, directory.Length - (int)description.Offset);
                    var length = blobReader.ReadUInt32();
                    MemoryAddress address = blobReader.CurrentPointer;
                    dst = new ResourceSeg(name, new MemorySeg(address,length));
                    return true;
                }
            }
            return false;
        }
    }
}
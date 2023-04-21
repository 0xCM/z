//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;

    public unsafe class PeReader : IDisposable
    {
        [Op]
        public static PeReader create(FilePath src)
            => new PeReader(src);

        PeReader(FilePath src)
        {
            Source = src;
            Stream = File.OpenRead(src.Name);
            PE = new PEReader(Stream);     
            Tables = PeTables.load(src, PE);
        }

        public readonly FilePath Source;

        readonly FileStream Stream;

        internal readonly PEReader PE;

        public readonly PeTables Tables;

        public MetadataReader MD
        {
            [MethodImpl(Inline)]
            get
            {
                if(_MD == null)
                    _MD = PE.GetMetadataReader();
                return _MD;
            }
        }

        [MethodImpl(Inline), Op]
        public ref MethodBodyBlock ReadMethodBody(Address32 address, ref MethodBodyBlock dst)
        {
            dst = PE.GetMethodBody((int)address);
            return ref dst;
        }

        MetadataReader _MD;

        MemorySeg _Image;

        public ref readonly MemorySeg GetImage()
        {
            if(_Image.IsEmpty)
                _Image = new (PE.GetEntireImage().Pointer, PE.GetEntireImage().Length);
            return ref _Image;            
        }

        public void Dispose()
        {
            PE?.Dispose();
            Stream?.Dispose();
        }

        public PEHeaders PeHeaders
        {
            [MethodImpl(Inline)]
            get => PE.PEHeaders;
        }

        public PEMemoryBlock ReadSectionData(PeDirectoryEntry src)
            => PE.GetSectionData((int)src.Rva);

        public ref readonly PeFileInfo PeInfo() 
            => ref Tables.PeInfo;

        /// <summary>
        /// Get the index in the image byte array corresponding to the RVA
        /// </summary>
        /// <param name="reader">PE reader representing the executable image to parse</param>
        /// <param name="rva">The relative virtual address</param>
        public int GetOffset(Address32 rva)
        {
            var index = PeHeaders.GetContainingSectionIndex((int)rva);
            var result = -1;
            if (index > 0)
            {
                var section = PE.PEHeaders.SectionHeaders[index];
                result = (int)(rva - (Address32)section.VirtualAddress + (Address32)section.PointerToRawData);
            }
            return result;
        }

        /// <summary>
        /// Determines whether the source image is r2r
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        /// <remarks>Taken from https://github.com/dotnet/runtime/blob/55e2378d86841ec766ee21d5e504d7724c39b53b/src/tasks/Crossgen2Tasks/PrepareForReadyToRunCompilation.cs</remarks>
        public bool IsReady2Run()
        {
            if (PeHeaders == null)
                return false;

            if (PeHeaders.CorHeader == null)
                return false;

            if ((PeHeaders.CorHeader.Flags & CorFlags.ILLibrary) == 0)
            {
                // This is likely a composite image, but those can't be re-r2r'd
                return false;
            }
            else
            {
                return PeHeaders.CorHeader.ManagedNativeHeaderDirectory.Size != 0;
            }
        }

        public MethodBodyBlock GetMethodBody(Address32 rva)
            => PE.GetMethodBody((int)rva);

        public ReadOnlySpan<MsilRow> ReadMsil()
        {
            var dst = list<MsilRow>();
            var types = MD.TypeDefinitions.ToArray();
            var typeCount = types.Length;
            for(var k=0u; k<typeCount; k++)
            {
                 var hType = skip(types, k);
                 var methods = MD.GetTypeDefinition(hType).GetMethods().Array();
                 var methodCount = methods.Length;
                 var definitions = map(methods, m=> MD.GetMethodDefinition(m));
                 for(var i=0u; i<methodCount; i++)
                 {
                    ref readonly var method = ref skip(methods,i);
                    ref readonly var definition = ref skip(definitions,i);
                    var rva = definition.RelativeVirtualAddress;
                    if(rva != 0)
                    {
                        var body = GetMethodBody(rva);
                        dst.Add(new MsilRow
                        {
                            MethodRva = (Address32)rva,
                            Token = EcmaTokens.token(method),
                            ImageName = Source.FileName.Format(),
                            BodySize = body.Size,
                            LocalInit = body.LocalVariablesInitialized,
                            MaxStack = body.MaxStack,
                            MethodName = MD.GetString(definition.Name),
                            Code = body.GetILBytes(),
                        });
                    }
                 }
            }
            return dst.ViewDeposited();
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;

    using I = System.Reflection.Metadata.Ecma335.TableIndex;

    public class PeReader : IDisposable
    {
        [Op]
        public static PeReader create(FilePath src)
            => new PeReader(src);

        public static bool create(FilePath src, out PeReader dst)
        {
            var stream = File.OpenRead(src.Name);
            try
            {                
                var reader = new PEReader(stream, PEStreamOptions.PrefetchMetadata);
                dst = new PeReader(src, stream, reader);
                return true;
            }
            catch(Exception)
            {
                stream.Dispose();
                dst = default;
                return false;
            }
        }

        public static void modules(IDbArchive src, Action<CoffModule> dst)
        {
            iter(src.Enumerate(true, FileKind.Exe, FileKind.Dll, FileKind.Obj, FileKind.Lib, FileKind.Sys), path => {
                using var reader = PeReader.create(path);
                dst(reader.ModuleInfo());
            }, true);
        }

        [MethodImpl(Inline), Op]
        public static PeDirectoryEntry directory(Address32 rva, uint size)
        {
            var dst = new PeDirectoryEntry();
            dst.Rva = rva;
            dst.Size = size;
            return dst;
        }

        public ReadOnlySeq<PeSectionHeader> SectionHeaders()
            => Tables.SectionHeaders;

        PeReader(FilePath src, FileStream stream, PEReader reader)
        {
            ModulePath = src;
            Stream = stream;
            PE = reader;
        }

        PeReader(FilePath src)
        {
            ModulePath = src;
            Stream = File.OpenRead(src.Name);
            PE = new PEReader(Stream);     
            Tables = PeTables.load(this);
        }

        public readonly FilePath ModulePath;

        readonly FileStream Stream;

        internal readonly PEReader PE;

        public readonly PeTables Tables;

        public ReadOnlySpan<EcmaConstInfo> Constants(ref uint counter)
        {
            var reader = MD;
            var count = ConstantCount();
            var dst = sys.span<EcmaConstInfo>(count);
            for(var i=1u; i<=count; i++)
            {
                var k = MetadataTokens.ConstantHandle((int)i);
                var entry = reader.GetConstant(k);
                var parent = (EcmaToken)MD.GetToken(entry.Parent);
                var blob = reader.GetBlobBytes(entry.Value);
                ref var target = ref seek(dst, i - 1u);
                target.Seq = counter++;
                target.ParentId = parent;
                target.Source = parent.Table.ToString();
                target.DataType = entry.TypeCode;
                target.Content = blob;
            }
            return dst;
        }

        [MethodImpl(Inline), Op]
        public int ConstantCount()
            => MD.GetTableRowCount(I.Constant);

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

        public void Dispose()
        {
            PE?.Dispose();
            Stream?.Dispose();
        }

        public CoffModule ModuleInfo()
            => new CoffModule(ModulePath, Tables.PeInfo, Tables.CoffHeader, Tables.CorHeader, Tables.SectionHeaders);

        public PEHeaders PeHeaders
        {
            [MethodImpl(Inline)]
            get => PE.PEHeaders;
        }

        public ReadOnlySpan<MemberReferenceHandle> MemberRefHandles
            => MD.MemberReferences.ToArray();

        public PEMemoryBlock ReadSectionData(PeDirectoryEntry src)
            => PE.GetSectionData((int)src.Rva);

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
                        var body = PE.GetMethodBody(rva);
                        dst.Add(new MsilRow
                        {
                            MethodRva = (Address32)rva,
                            Token = EcmaTokens.token(method),
                            ImageName = ModulePath.FileName.Format(),
                            BodySize = body.Size,
                            LocalInit = body.LocalVariablesInitialized,
                            MaxStack = body.MaxStack,
                            MethodName = Clr.membername(MD.GetString(definition.Name)),
                            Code = body.GetILBytes(),
                        });
                    }
                 }
            }
            return dst.ViewDeposited();
        }
    }
}
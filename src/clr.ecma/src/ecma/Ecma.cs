//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;
    using static Bytes;
    
    [ApiHost]
    public class Ecma : WfSvc<Ecma>
    {        
        public static ReadOnlySeq<EcmaRowStats> stats(AssemblyIndex src)
            => EcmaReader.stats(src.Distinct().Select(x => x.Path));

        public static MemberKey key(EcmaMethodDef src)
            => new (src.Assembly, src.Token, src.Namespace, src.DeclaringType, src.MethodName);

        public ReadOnlySeq<EcmaDependencySet> CalcDependencies(AssemblyIndex index, IDbArchive dst)
        {
            var deps = bag<EcmaDependencySet>();
            var managed = bag<ManagedDependency>();
            var native = bag<NativeDependency>();
            iter(index.Distinct(), entry => {
                using var file = Ecma.file(entry.Path);
                var set = CalcDependencies(file);
                managed.AddRange(set.ManagedDependencies);
                native.AddRange(set.NativeDependencies);
                deps.Add(set);                                
            },true);

            Channel.TableEmit(managed.Array().Sort(), dst.Nested("ecma", index.Source).Table<ManagedDependency>());
            Channel.TableEmit(native.Array().Sort(), dst.Nested("ecma", index.Source).Table<NativeDependency>());
            return deps.Array().Sort();
        }

        public EcmaDependencySet CalcDependencies(EcmaFile file)
        {
            var reader = Ecma.reader(file);
            var dst = new EcmaDependencySet();
            dst.SourcePath = file.Path;
            dst.SourceName = reader.AssemblyName();
            dst.SourceVersion = dst.SourceName.Version;
            dst.ManagedDependencies = CalcManagedDeps(file.Path, reader);
            dst.NativeDependencies = CalcNativeDeps(file.Path, reader);
            return dst;
        }

        public void EmitReports(AssemblyIndex index, IDbArchive dst)
        {
            Channel.TableEmit(index.Report(), dst.Nested("ecma", index.Source).Path("assemblies.index", FileKind.Csv));
            Channel.TableEmit(index.Distinct(), dst.Nested("ecma", index.Source).Path("assemblies.index.distinct", FileKind.Csv));
        }        

        ReadOnlySeq<NativeDependency> CalcNativeDeps(FilePath path, EcmaReader reader)
        {
            var native = reader.ModuleRefHandles();
            var count = native.Length;
            var dst = alloc<NativeDependency>(count);
            for(var i=0; i<native.Length; i++)
            {
                seek(dst,i) = CalcNativeDependency(path, reader, skip(native,i));
            }
            return dst;
        }

        ReadOnlySeq<ManagedDependency> CalcManagedDeps(FilePath path, EcmaReader reader)
        {
            var managed = reader.AssemblyRefHandles();
            var count = managed.Length;
            var dst = alloc<ManagedDependency>(count);
            var j=0u;
            for(var i=0; i<managed.Length; i++, j++)
                seek(dst,j) = CalcManagedDependency(path, reader, skip(managed,i));
            return dst;
        }

        ManagedDependency CalcManagedDependency(FilePath path, EcmaReader reader, AssemblyReferenceHandle handle)
        {
            var src = reader.MetadataReader.GetAssemblyReference(handle);            
            var dst = new ManagedDependency();
            dst.SourceName = reader.AssemblyName();
            dst.SourceVersion = dst.SourceName.Version;
            dst.SourceKeyToken = u64(reader.AssemblyName().GetPublicKeyToken());
            dst.TargetName = src.GetAssemblyName();
            dst.TargetVersion = src.Version;
            dst.TargetKeyToken = u64(reader.Blob(src.PublicKeyOrToken).View);
            return dst;
        }

        NativeDependency CalcNativeDependency(FilePath path, EcmaReader reader, ModuleReferenceHandle handle)
        {
            var src = reader.MetadataReader.GetModuleReference(handle);
            var dst = new NativeDependency();
            dst.SourceName = reader.AssemblyName();
            dst.SourceVersion = dst.SourceName.Version;
            dst.SourceKeyToken = u64(reader.AssemblyName().GetPublicKeyToken());
            dst.TargetName = reader.String(src.Name);
            return dst;
        }

        public static MetadataMemory memory(MemorySeg src, AssemblyKey assembly)  
            => new MetadataMemory(src, assembly);

        /// <summary>
        /// Loads an assembly + pdb
        /// </summary>
        /// <param name="image">The assembly path</param>
        /// <param name="pdb">The pdb path</param>
        [Op]
        public static Assembly assembly(FilePath image, FilePath pdb)
            => Assembly.Load(image.ReadBytes(), pdb.ReadBytes());

        public static EcmaMvid mvid(Assembly src)
            => Ecma.reader(src).Mvid();

        public static AssemblyKey key(Assembly src)
            => Ecma.reader(src).AssemblyKey();

        [Op]
        public static EcmaModuleInfo describe(Assembly src)
        {
            var dst = new EcmaModuleInfo();
            var adapted = Clr.adapt(src);
            dst.ImgPath = Ecma.location(src);
            Ecma.pdbpath(adapted, out dst.PdbPath);
            Ecma.xmlpath(adapted, out dst.XmlPath);
            dst.MetadatSize = (ByteSize)adapted.RawMetadata.Length;
            return dst;
        }

        public static IEnumerable<FilePath> valid(DbArchive src, FileKind kind)
            => from file in src.Enumerate(true, $"*.{kind.Ext()}") where valid(file) select file;                        

        [MethodImpl(Inline), Op]
        public unsafe static MetadataReaderProvider provider(Assembly src)
        {
            var metadata = ClrAssembly.metadata(src);
            return provider(metadata.BaseAddress.Pointer<byte>(), metadata.Size);
        }

        [MethodImpl(Inline), Op]
        public unsafe static MetadataReaderProvider provider(byte* pSrc, ByteSize size)
            => MetadataReaderProvider.FromMetadataImage(pSrc, size);

        [MethodImpl(Inline), Op]
        public static MetadataReaderProvider provider(Stream stream, MetadataStreamOptions options = MetadataStreamOptions.Default)
            => MetadataReaderProvider.FromMetadataStream(stream, options);

        [MethodImpl(Inline), Op]
        public unsafe static MetadataReaderProvider pdbProvider(byte* pSrc, ByteSize size)
            => MetadataReaderProvider.FromPortablePdbImage(pSrc, size);

        [MethodImpl(Inline), Op]
        public static MetadataReaderProvider pdbProvider(Stream src, MetadataStreamOptions options = MetadataStreamOptions.Default)
            => MetadataReaderProvider.FromPortablePdbStream(src, options);

        [Op]
        public static bool valid(FilePath src)
        {
            try
            {
                using var stream = File.OpenRead(src.Name);
                using var reader = new PEReader(stream);
                return reader.HasMetadata;
            }
            catch(Exception)
            {
                return false;
            }
        }

        [MethodImpl(Inline), Op]
        public static FilePath location(ClrAssembly src)
            => FS.path(src.Definition.Location);

        [Op]
        public static FileUri xmlpath(ClrAssembly src, out FileUri dst)
        {
            var candidate = FS.path(Path.ChangeExtension(src.Definition.Location, FS.Xml.Name));
            dst = candidate.Exists ? candidate : FilePath.Empty;
            return dst;
        }

        [Op]
        public static FileUri pdbpath(ClrAssembly src, out FileUri dst)
        {
            var candidate = FS.path(Path.ChangeExtension(src.Definition.Location, FS.Pdb.Name));
            dst = candidate.Exists ? candidate : FilePath.Empty;
            return dst;
        }

        public static AssemblyIndex index(IWfChannel channel, FolderPath root)
            => AssemblyIndex.create(channel, root.DbArchive());

        public static AssemblyIndex index(IWfChannel channel, IDbArchive root)
            => AssemblyIndex.create(channel, root);

        public static EcmaFile file(FilePath src)
            => EcmaFile.open(src);

        public static EcmaReader reader(EcmaFile src)
            => EcmaReader.create(src);
                    
        public static IEnumerable<EcmaTables.AssemblyRefRow> refs(FilePath src)
        {
            using var ecma = file(src);
            return ecma.EcmaReader().ReadAssemblyRefRows();            
        }

        public static ReadOnlySeq<EcmaTables.AssemblyRefRow> refs(Assembly src)
            => EcmaReader.create(src).ReadAssemblyRefRows();

        public static bool parse(string src, out EcmaToken dst)
        {
            var i = text.index(src, Chars.Colon);
            var outcome = Outcome.Empty;
            dst = EcmaToken.Empty;
            if(i != NotFound)
            {
                outcome = Hex.parse8u(src.LeftOfIndex(i), out var table);
                if(!outcome)
                    return outcome;

                outcome = Hex.parse32u(text.right(src,i), out var row);
                if(!outcome)
                    return outcome;

                dst = EcmaTokens.token((TableIndex)table, row);
                return true;
            }
            else
            {
                outcome = Hex.parse32u(src, out var token);
                if(!outcome)
                    return outcome;
                dst = token;
                return true;
            }
        }

        [MethodImpl(Inline), Op]
        public static Handle ecmahandle(EcmaHandleData src)
            => @as<EcmaHandleData,Handle>(src);

        [MethodImpl(Inline), Op]
        public Handle ecmahandle(EcmaToken src)
            => ecmahandle(new EcmaHandleData(src.Table, src.Row));

        [MethodImpl(Inline), Op]
        public static EcmaHandleData datahandle(Handle src)
            => @as<Handle,EcmaHandleData>(src);

        [Op]
        public static TableIndex? table(EntityHandle handle)
        {
            if(MetadataTokens.TryGetTableIndex(handle.Kind, out var table))
                return table;
            else
                return null;
        }

        [Op]
        public static TableIndex? table(Handle handle)
        {
            if(MetadataTokens.TryGetTableIndex(handle.Kind, out var table))
                return table;
            else
                return null;
        }

        ApiMd ApiMd => Wf.ApiMd();

        public void EmitMsil(IDbArchive dst)
            => EmitMsil(ApiMd.ApiHosts, dst);

        MsilSvc MsilSvc => Wf.MsilSvc();

        FilePath MsilPath(ApiHostUri src, IDbArchive dst)
            => dst.Path(ApiFiles.hostfile(src, FileKind.Il));

        public void EmitMsil(CollectedHost src, IDbArchive dst)
        {
            ref readonly var resolved = ref src.Resolved;
            if(resolved.IsNonEmpty)
            {
                var buffer = text.buffer();
                for(var j=0; j<resolved.Count; j++)   
                    MsilSvc.RenderCode(resolved[j].Msil, buffer);
                Channel.FileEmit(buffer.Emit(), resolved.Count, MsilPath(src.Host, dst), TextEncodingKind.Unicode);
            }
        }

        public void EmitMsil(ReadOnlySeq<IApiHost> src, IDbArchive dst)
        {
            var buffer = text.buffer();
            var k = 0u;
            var emitted = cdict<ApiHostUri,FilePath>();
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var host = ref src[i];
                var members = ClrJit.members(host, Channel);
                var count = members.Length;
                if(members.Count == 0)
                    continue;

                for(var j=0; j<members.Count; j++)
                {
                    MsilSvc.RenderCode(members[j].Msil, buffer);
                    k++;
                }

                var path = MsilPath(host.HostUri, dst);
                Channel.FileEmit(buffer.Emit(), members.Count, path, TextEncodingKind.Unicode);
                emitted[host.HostUri] = path;
            }
        }

        public void EmitMsil(IReadOnlyDictionary<Assembly,IApiHost[]> src, IDbArchive dst)
        {
            dst.Delete();
            var k = 0u;
            var emitted = cdict<ApiHostUri,FilePath>();
            
            iter(src, part => {
                
                var hosts = bag<IApiHost>();
                iter(part.Value, host => {
                    var members = ClrJit.members(host, Channel);
                    var buffer = text.buffer();

                    for(var j=0; j<members.Count; j++)
                        MsilSvc.RenderCode(members[j].Msil, buffer);

                    if(members.Count != 0)
                    {
                        var path = MsilPath(host.HostUri, dst);
                        Channel.FileEmit(buffer.Emit(), members.Count, path, TextEncodingKind.Unicode);
                        emitted.TryAdd(host.HostUri, path);
                    }
                });

            }, true);
        }


        public static EcmaReader reader(Assembly src)
            => EcmaReader.create(src);

        /// <summary>
        /// Defines a <see cref='EcmaDataSource'/> over a specified <see cref='Assembly'/>
        /// </summary>
        /// <param name="src">The origin</param>
        [Op]
        public static EcmaDataSource source(Assembly src)
            => new EcmaDataSource(src);

        /// <summary>
        /// Defines a <see cref='EcmaDataSource'/> over a specified <see cref='MetadataReader'/>
        /// </summary>
        /// <param name="src">The origin</param>
        [Op]
        public static EcmaDataSource source(MetadataReader src)
            => new EcmaDataSource(src);

        /// <summary>
        /// Defines a <see cref='EcmaDataSource'/> over a specified <see cref='MemorySeg'/>
        /// </summary>
        /// <param name="src">The origin</param>
        [Op]
        public static EcmaDataSource source(MemorySeg src)
            => new EcmaDataSource(src);

        /// <summary>
        /// Defines a <see cref='EcmaDataSource'/> over a specified <see cref='PEMemoryBlock'/>
        /// </summary>
        /// <param name="src">The origin</param>
        [Op]
        public static EcmaDataSource source(PEMemoryBlock src)
            => new EcmaDataSource(src);


        public static ReadOnlySpan<Sym<TableIndex>> TableKinds()
            => Symbols.index<TableIndex>().View;

        public static EcmaRowKeys keys<T>(ReadOnlySpan<T> handles)
            where T : unmanaged
        {
            var count = handles.Length;
            var buffer = alloc<EcmaRowKey>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {}
                //seek(dst,i) = new EcmaRowKey(kind, skip(handles,i));
            return buffer;
        }

        public static void visualize(FilePath src, FilePath dst)
            => Mdv.run(src.Name, dst.Name);

        /// <summary>
        /// Unpacks a compressed integer in blob storage and returns the number of bytes consumed
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The data target</param>
        /// <remarks>Algorithm taken from https://github.com/microsoft/winmd/src/impl/winmd_reader/signature.h</remarks>
        [MethodImpl(Inline), Op]
        public static byte unpack(in byte src, out uint dst)
        {
            dst = default;
            var length = z8;
            if((src & 0x80) == 0)
            {
                length = 1;
                dst = src;
            }
            else if((src & 0xC0) == 0x80)
            {
                length = 2;
                dst = sll(and(skip(src,0), 0x3f), 8);
                dst |= skip(src, 1);
            }
            else if((src & 0xE0) == 0xC0)
            {
                length = 4;
                dst = sll(and(skip(src,0), 0x1f), 24);
                dst |= sll(skip(src, 1), 16);
                dst |= sll(skip(src, 2), 8);
                dst |= skip(src, 3);
            }

            return length;
        }
   }

    partial class XTend
    {
        public static EcmaReader EcmaReader(this MappedAssembly src)
            => Z0.EcmaReader.create(src.BaseAddress, src.FileSize);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.SymbolStore;
    using Microsoft.DiaSymReader;
    using Microsoft.DiaSymReader.PortablePdb;
    using Microsoft.SymbolStore.KeyGenerators;
    using SOS;

    [ApiHost]
    public class PdbDocs
    {
        [Op]
        public static EcmaToken token(PdbMethod src)
        {
            HResult result = src.Source.GetToken(out var token);
            return result ? token : EcmaToken.Empty;
        }

        public static unsafe Outcome srclink(ISymUnmanagedReader5 src, out Span<byte> dst)
        {
            dst = default;
            try
            {
                HResult hr = src.GetSourceServerData(out var pData, out var size);
                if(hr)
                {
                    core.read(pData, size, out dst);
                    return true;
                }
                else
                {
                    size = 0;
                    return (false, hr.Format());
                }
            }
            catch(Exception e)
            {
                return e;
            }
        }

        /// <summary>
        /// Retrieves symbol server information
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="dst"></param>
        /// <remarks>
        /// Adapted from https://github.com/dotnet/symreader-converter/src/Microsoft.DiaSymReader.Converter/Utilities/SymReaderHelpers.cs
        /// </remarks>
        public unsafe static Outcome symserver(ISymUnmanagedReader reader, out Span<byte> dst)
        {
            dst = default;
            if (!(reader is ISymUnmanagedSourceServerModule srcsrv))
                return (false, string.Format("{0} does not support the required iterface", reader.GetType()));

            var pData = default(byte*);
            try
            {
                HResult result = srcsrv.GetSourceServerData(out var size, out pData);
                if(result)
                {
                    memory.read(pData, size, out dst);
                    return true;
                }
                else
                    return (false,result.Format());
            }
            catch(Exception e)
            {
                return e;
            }
            finally
            {
                if (pData != null)
                    Marshal.FreeCoTaskMem((IntPtr)pData);
            }
        }

        public static DirectorySymbolStore store(FolderPath src, IWfChannel channel)
            => new DirectorySymbolStore(tracer(channel), null, src.Name);

        public static SymbolStoreFile file(FilePath src)
            => new SymbolStoreFile(src.Stream(), src.FileName.Name);

        [MethodImpl(Inline)]
        public static ITracer tracer(IWfChannel channel)
            => new SymbolTracer(channel);

        public static KeyGenerator keygen(SymbolStoreFile src, IWfChannel channel)
            => new PortablePDBFileKeyGenerator(tracer(channel), src);

        public static ReadOnlySeq<SymbolStoreKey> keys(KeyGenerator src)
            => src.GetKeys(KeyTypeFlags.IdentityKey).Array();

        public static ReadOnlySeq<SymbolStoreKey> keys(SymbolStoreFile src, IWfChannel channel)
            => keys(keygen(src, channel)).Array();


        /// <summary>
        /// Loads a symbol source from specified binary data
        /// </summary>
        /// <param name="pe">The pe data</param>
        /// <param name="pdb">The pdb data</param>
        [Op]
        public static PdbSymbolSource source(ReadOnlySpan<byte> pe, ReadOnlySpan<byte> pdb)
            => new PdbSymbolSource(pe,pdb);

        /// <summary>
        /// Loads a <see cref='PdbSymbolSource'/> for specified pe and pdb paths
        /// </summary>
        /// <param name="pe">The pe file path</param>
        /// <param name="pdb">The pdb file path</param>
        [Op]
        public static PdbSymbolSource source(FilePath pe, FilePath pdb)
            => new PdbSymbolSource(pe, pdb);

        /// <summary>
        /// Loads a <see cref='PdbSymbolSource'/> for specified pe, assuming the existence of a colocated pdb
        /// </summary>
        /// <param name="pe">The pe file path</param>
        [Op]
        public static PdbSymbolSource source(FilePath pe)
            => new PdbSymbolSource(pe, pe.ChangeExtension(FS.Pdb));


        public static SymbolMetadata metadata(PdbSymbolSource source)
            => new SymbolMetadata(source);

        [Op]
        public static uint SeqPointCount(PdbMethod src)
        {
            HResult result = src.Source.GetSequencePointCount(out var count);
            return result ? (uint)count : 0;
        }

        public static PdbMethods methods(ISymUnmanagedReader5 reader, ISymUnmanagedDocument doc)
            => new PdbMethods(doc,reader.GetMethodsInDocument(doc));

        public static PdbReader reader(PdbSymbolSource src)
        {
            var reader = default(PdbReader);
            if(src.IsPortable)
                reader = new PdbReader(src, portable(src));
            else
                reader = new PdbReader(src, legacy(src));
            return reader;
        }

        public static PdbReader reader(FilePath pe, FilePath pdb)
        {
            if(!pe.Exists)
                Throw.sourced(FS.Msg.DoesNotExist.Format(pe));
            if(!pdb.Exists)
                Throw.sourced(FS.Msg.DoesNotExist.Format(pdb));
            return reader(source(pe, pdb));
        }

        static object importer(in PdbSymbolSource src)
            => SymUnmanagedReaderFactory.CreateSymReaderMetadataImport(metadata(src));

        static ISymUnmanagedReader5 portable(in PdbSymbolSource src)
            => (ISymUnmanagedReader5)new  SymBinder().GetReaderFromStream(src.PdbStream, importer(src));

        static ISymUnmanagedReader5 legacy(in PdbSymbolSource src)
            => SymUnmanagedReaderFactory.CreateReader<ISymUnmanagedReader5>(src.PdbStream, metadata(src));

        [MethodImpl(Inline), Op]        
        public static SymbolArchives symbols(FolderPath root)
            => SymbolArchives.create(root);

        [MethodImpl(Inline), Op]        
        public static Files pdbfiles(FolderPath src)
            => src.Files(FS.Pdb, true);

        [MethodImpl(Inline), Op]
        public static PdbMethod method(ISymUnmanagedMethod src)
            => new PdbMethod(src);

        [MethodImpl(Inline), Op]
        public static PdbSeqPoint point(SymUnmanagedSequencePoint src)
            => new PdbSeqPoint((uint)src.Offset,
                ((uint)src.StartLine, (uint)src.StartColumn),
                ((uint)src.EndLine, (uint)src.EndColumn));

        [MethodImpl(Inline), Op]
        public static PdbDocument doc(ISymUnmanagedDocument src)
            => new PdbDocument(src, src.GetName(), src.GetDocumentType());

        [MethodImpl(Inline), Op]
        public static HResult<PdbMethod> method(PdbReader reader, EcmaToken token)
        {
            HResult result = reader.Provider.GetMethod((int)token, out var accessor);
            if(result)
                return PdbDocs.method(accessor);
            else
                return result;
        }
    }
}
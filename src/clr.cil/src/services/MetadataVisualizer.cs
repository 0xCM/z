//-----------------------------------------------------------------------------
// Copyright   :  Microsoft/DotNet Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace System.Reflection.Metadata;

using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Globalization;

public class MetadataVisualizer
{
    readonly TextWriter _writer;

    readonly IReadOnlyList<MetadataReader> _readers;

    readonly MetadataAggregator _aggregator;

    // enc map for each delta reader
    readonly ImmutableArray<ImmutableArray<EntityHandle>> EncMaps;

    private MetadataReader _reader;

    readonly MetadataVisualizerOptions _options;

    readonly SignatureVisualizer _signatureVisualizer;

    readonly Dictionary<BlobHandle, BlobKind> _blobKinds = new Dictionary<BlobHandle, BlobKind>();

    private readonly ImmutableDictionary<EntityHandle, EntityHandle> _encAddedMemberToParentMap;

    MetadataVisualizer(TextWriter writer, IReadOnlyList<MetadataReader> readers, MetadataVisualizerOptions options = MetadataVisualizerOptions.None)
    {
        _writer = writer;
        _readers = readers;
        _options = options;
        _signatureVisualizer = new SignatureVisualizer(this);
        _encAddedMemberToParentMap = ImmutableDictionary<EntityHandle, EntityHandle>.Empty;
        if (readers.Count > 1)
        {
            var deltaReaders = new List<MetadataReader>(readers.Skip(1));
            _aggregator = new MetadataAggregator(readers[0], deltaReaders);
            EncMaps = ImmutableArray.CreateRange(deltaReaders.Select(reader => ImmutableArray.CreateRange(reader.GetEditAndContinueMapEntries())));
        }
    }

    public MetadataVisualizer(MetadataReader reader, TextWriter writer, MetadataVisualizerOptions options = MetadataVisualizerOptions.None)
        : this(writer, new[] {reader}, options)
    {
        _reader = reader;
    }

    public MetadataVisualizer(IReadOnlyList<MetadataReader> readers, TextWriter writer, MetadataVisualizerOptions options = MetadataVisualizerOptions.None)
        : this(writer, readers, options)
    {
    }

    public void VisualizeAllGenerations()
    {
        for (int i = 0; i<_readers.Count; i++)
        {
            _writer.WriteLine(">>>");
            _writer.WriteLine(string.Format(">>> Generation {0}:", i));
            _writer.WriteLine(">>>");
            _writer.WriteLine();

            Visualize(i);
        }
    }

    public void Visualize(int generation = -1)
    {
        _reader = (generation >= 0) ? _readers[generation] : _readers.Last();

        WriteModule();
        WriteTypeRef();
        WriteTypeDef();
        WriteField();
        WriteMethod();
        WriteParam();
        WriteMemberRef();
        WriteConstant();
        WriteCustomAttribute();
        WriteDeclSecurity();
        WriteStandAloneSig();
        WriteEvent();
        WriteProperty();
        WriteMethodImpl();
        WriteModuleRef();
        WriteTypeSpec();
        WriteEnCLog();
        WriteEnCMap();
        WriteAssembly();
        WriteAssemblyRef();
        WriteFile();
        WriteExportedType();
        WriteManifestResource();
        WriteGenericParam();
        WriteMethodSpec();
        WriteGenericParamConstraint();
        WriteDocument();
        WriteMethodDebugInformation();
        WriteLocalScope();
        WriteLocalVariable();
        WriteLocalConstant();
        WriteImportScope();
        WriteCustomDebugInformation();
        WriteUserStrings();
        WriteStrings();
        WriteBlobs();
        WriteGuids();
    }

    public void VisualizeHeaders()
    {
        _reader = _readers[0];

        _writer.WriteLine($"MetadataVersion: {_reader.MetadataVersion}");

        if (_reader.DebugMetadataHeader != null)
        {
            _writer.WriteLine("Id: " + BitConverter.ToString(_reader.DebugMetadataHeader.Id.ToArray()));
            if (!_reader.DebugMetadataHeader.EntryPoint.IsNil)
                _writer.WriteLine($"EntryPoint: {Token(() => _reader.DebugMetadataHeader.EntryPoint)}");
        }

        _writer.WriteLine();
    }

    bool IsDelta
        => _reader.GetTableRowCount(TableIndex.EncLog) > 0;

    Handle GetAggregateHandle(EntityHandle generationHandle, int generation)
    {
        var encMap = EncMaps[generation - 1];

        int start, count;
        if (!TryGetHandleRange(encMap, generationHandle.Kind, out start, out count))
        {
            throw new BadImageFormatException(string.Format("EncMap is missing record for {0:8X}.", MetadataTokens.GetToken(generationHandle)));
        }

        return encMap[start + MetadataTokens.GetRowNumber(generationHandle) - 1];
    }

    TEntity Get<TEntity>(Handle handle, Func<MetadataReader, Handle, TEntity> getter)
    {
        if (_aggregator != null)
        {
            int generation;
            var generationHandle = _aggregator.GetGenerationHandle(handle, out generation);
            return getter(_readers[generation], generationHandle);
        }
        else
        {
            return getter(this._reader, handle);
        }
    }

    public void WriteLine(string line)
    {
        _writer.WriteLine(line);
    }

    public string MethodSignature(BlobHandle signatureHandle)
        => Literal(signatureHandle, (r, h) => Signature(r, (BlobHandle)h, BlobKind.MethodSignature));

    public string StandaloneSignature(BlobHandle signatureHandle)
        => Literal(signatureHandle, (r, h) => Signature(r, (BlobHandle)h, BlobKind.StandAloneSignature));

    public string MemberReferenceSignature(BlobHandle signatureHandle)
        => Literal(signatureHandle, (r, h) => Signature(r, (BlobHandle)h, BlobKind.MemberRefSignature));

    public string MethodSpecificationSignature(BlobHandle signatureHandle)
        => Literal(signatureHandle, (r, h) => Signature(r, (BlobHandle)h, BlobKind.MethodSpec));

    public string TypeSpecificationSignature(BlobHandle signatureHandle)
        => Literal(signatureHandle, (r, h) => Signature(r, (BlobHandle)h, BlobKind.TypeSpec));

    public string FieldSignature(BlobHandle hSig)
        => FieldSignature(() => hSig);

    public string Literal(StringHandle handle)
        => Literal(handle, (r, h) => "'" + r.GetString((StringHandle)h) + "'");

    public string Literal(NamespaceDefinitionHandle handle)
        => Literal(handle, (r, h) => "'" + r.GetString((NamespaceDefinitionHandle)h) + "'");

    public string Literal(GuidHandle handle)
        => Literal(handle, (r, h) => "{" + r.GetGuid((GuidHandle)h) + "}");

    public string Literal(BlobHandle handle)
        => Literal(handle, (r, h) => BitConverter.ToString(r.GetBlobBytes((BlobHandle)h)));

    public string Token(Handle handle, bool displayTable = true)
    {
        if (handle.IsNil)
        {
            return "nil";
        }

        TableIndex table;
        if (displayTable && MetadataTokens.TryGetTableIndex(handle.Kind, out table))
        {
            return string.Format("0x{0:x8} ({1})", _reader.GetToken(handle), table);
        }
        else
        {
            return string.Format("0x{0:x8}", _reader.GetToken(handle));
        }
    }

    public string TokenList(InterfaceImplementationHandleCollection handles, bool displayTable = false)
    {
        if (handles.Count == 0)
            return "nil";

        return string.Join(", ", handles.Select(h => Token(h, displayTable)));
    }

    public void VisualizeMethodBody(MethodBodyBlock body, MethodDefinitionHandle generationHandle, int generation)
    {
        var handle = (MethodDefinitionHandle)GetAggregateHandle(generationHandle, generation);
        var method = GetMethod(handle);
        VisualizeMethodBody(body, method, handle);
    }

    public void VisualizeMethodBody(MethodDefinitionHandle methodHandle, Func<int, MethodBodyBlock> bodyProvider)
    {
        var method = GetMethod(methodHandle);

        if ((method.ImplAttributes & MethodImplAttributes.CodeTypeMask) != MethodImplAttributes.Managed)
        {
            _writer.WriteLine("native code");
            return;
        }

        var rva = method.RelativeVirtualAddress;
        if (rva == 0)
        {
            return;
        }

        var body = bodyProvider(rva);
        VisualizeMethodBody(body, method, methodHandle);
    }

    public string GetString(StringHandle handle) =>
        Literal(handle, (r, h) => r.GetString((StringHandle)h), noHeapReferences: true);

    public string GetString(UserStringHandle handle) =>
        Literal(handle, (r, h) => r.GetUserString((UserStringHandle)h), noHeapReferences: true);

    public string RowId(EntityHandle handle)
        => handle.IsNil ? "nil" : $"#{_reader.GetRowNumber(handle):x}";

    public MethodDefinition GetMethod(MethodDefinitionHandle handle)
    {
        return Get(handle, (reader, h) => reader.GetMethodDefinition((MethodDefinitionHandle)h));
    }

    public BlobHandle GetLocalSignature(StandaloneSignatureHandle handle)
    {
        return Get(handle, (reader, h) => reader.GetStandaloneSignature((StandaloneSignatureHandle)h).Signature);
    }

    public string QualifiedTypeDefinitionName(TypeDefinitionHandle handle)
    {
        var builder = new StringBuilder();
        Recurse(handle, isLastPart: true);
        return builder.ToString();

        void Recurse(TypeDefinitionHandle typeDefinitionHandle, bool isLastPart)
        {
            try
            {
                var generationDeclaringTypeDef = GetGenerationTypeDefinition(typeDefinitionHandle);
                var declaringTypeDefHandle = _reader.GetTypeDefinition(typeDefinitionHandle).GetDeclaringType();

                if (declaringTypeDefHandle.IsNil)
                {
                    if (!generationDeclaringTypeDef.Namespace.IsNil)
                    {
                        builder.Append(GetString(generationDeclaringTypeDef.Namespace)).Append('.');
                    }
                }
                else
                {
                    Recurse(declaringTypeDefHandle, isLastPart: false);
                }

                var name = GetString(generationDeclaringTypeDef.Name);
                builder.Append(name);
            }
            catch (BadImageFormatException)
            {
                builder.Append(BadMetadataStr);
            }

            if (!isLastPart)
            {
                builder.Append('.');
            }
        }
    }

    public string QualifiedMethodName(MethodDefinitionHandle handle, TypeDefinitionHandle scope = default)
        => QualifiedMemberName(
            handle,
            scope,
            entity => entity.Name,
            entity => entity.GetDeclaringType(),
            (reader, handle) => reader.GetMethodDefinition((MethodDefinitionHandle)handle));

    public string QualifiedFieldName(FieldDefinitionHandle handle, TypeDefinitionHandle scope = default)
        => QualifiedMemberName(
            handle,
            scope,
            entity => entity.Name,
            entity => entity.GetDeclaringType(),
            (reader, handle) => reader.GetFieldDefinition((FieldDefinitionHandle)handle));


    public string QualifiedMemberReferenceName(MemberReferenceHandle handle)
    {
        try
        {
            var memberReference = GetGenerationMemberReference(handle);
            return QualifiedName(memberReference.Parent) + "." + GetString(memberReference.Name);
        }
        catch (BadImageFormatException)
        {
            return BadMetadataStr;
        }
    }

    public string QualifiedTypeReferenceName(TypeReferenceHandle handle)
    {
        try
        {
            var typeReference = GetGenerationTypeDefinition(handle);
            return GetString(typeReference.Namespace) + "." + GetString(typeReference.Name);
        }
        catch (BadImageFormatException)
        {
            return BadMetadataStr;
        }
    }

    public string QualifiedMethodSpecificationName(MethodSpecificationHandle handle)
    {
        MethodSpecification methodSpecification;
        try
        {
            methodSpecification = GetGenerationMethodSpecification(handle);
        }
        catch (BadImageFormatException)
        {
            return BadMetadataStr;
        }

        string qualifiedName;
        try
        {
            qualifiedName = QualifiedName(methodSpecification.Method);
        }
        catch (BadImageFormatException)
        {
            qualifiedName = BadMetadataStr;
        }

        string typeArguments;
        try
        {
            typeArguments = GetGenerationEntity(methodSpecification.Signature, (reader, handle) => Signature(reader, (BlobHandle)handle, BlobKind.MethodSpec));
        }
        catch (BadImageFormatException)
        {
            typeArguments = BadMetadataStr;
        }

        return qualifiedName + "<" + typeArguments + ">";
    }

    public string QualifiedTypeSpecificationName(TypeSpecificationHandle handle)
    {
        TypeSpecification typeSpecification;
        try
        {
            typeSpecification = GetGenerationTypeSpecification(handle);
        }
        catch (BadImageFormatException)
        {
            return BadMetadataStr;
        }

        BlobHandle signature;
        try
        {
            signature = typeSpecification.Signature;
        }
        catch (BadImageFormatException)
        {
            return BadMetadataStr;
        }

        return GetGenerationEntity(signature, (reader, handle) => Signature(reader, (BlobHandle)handle, BlobKind.TypeSpec));
    }

    public string QualifiedName(EntityHandle handle, TypeDefinitionHandle scope = default)
        => handle.Kind switch
        {
            HandleKind.TypeDefinition => QualifiedTypeDefinitionName((TypeDefinitionHandle)handle),
            HandleKind.MethodDefinition => QualifiedMethodName((MethodDefinitionHandle)handle, scope),
            HandleKind.FieldDefinition => QualifiedFieldName((FieldDefinitionHandle)handle, scope),
            HandleKind.MemberReference => QualifiedMemberReferenceName((MemberReferenceHandle)handle),
            HandleKind.TypeReference => QualifiedTypeReferenceName((TypeReferenceHandle)handle),
            HandleKind.MethodSpecification => QualifiedMethodSpecificationName((MethodSpecificationHandle)handle),
            HandleKind.TypeSpecification => QualifiedTypeSpecificationName((TypeSpecificationHandle)handle),
            _ => null
        };

    public string VisualizeMethodBody(MethodBodyBlock body, MethodDefinitionHandle methodHandle)
    {
        var builder = new StringBuilder();
        var token = Token(methodHandle, displayTable: false);
        builder.AppendLine($"Method '{StringUtilities.EscapeNonPrintableCharacters(QualifiedMethodName(methodHandle))}' ({token})");

        if (!body.LocalSignature.IsNil)
        {
            builder.AppendLine($"  Locals: {StandaloneSignature(() => GetGenerationLocalSignature(body.LocalSignature).Signature)}");
        }

        var declaringTypeDefHandle = _encAddedMemberToParentMap.TryGetValue(methodHandle, out var parentHandle) ? 
            (TypeDefinitionHandle)parentHandle :
            GetGenerationMethodDefinition(methodHandle).GetDeclaringType();

        new ILVisualizer(this, scope: declaringTypeDefHandle).DumpMethod(
            builder,
            body.MaxStack,
            body.GetILContent().ToReadOnlySpan(),
            sys.empty<ILVisualizer.LocalInfo>(),
            sys.empty<ILVisualizer.HandlerSpan>());

        builder.AppendLine();

        var result = builder.ToString();
        _writer.Write(result);
        return result;
    }

    /// <summary>
    /// Returns entity definition that can be used to read its metadata.
    /// The entity is local to the generation that introduced it and can't be used to look up related entities such as declaring type, etc.
    /// since the metadata tables contain aggregate metadata tokens and not generation-relative ones, which is stored in the returned entity.
    /// </summary>
    TEntity GetGenerationEntity<TEntity>(Handle handle, Func<MetadataReader, Handle, TEntity> getter)
    {
        if (_aggregator != null)
        {
            var generationHandle = _aggregator.GetGenerationHandle(handle, out int generation);
            return getter(_readers[generation], generationHandle);
        }
        else
        {
            return getter(_reader, handle);
        }
    }

    static string GetValueChecked(Func<MetadataReader, Handle, string> getValue, MetadataReader reader, Handle handle)
    {
        try
        {
            return getValue(reader, handle);
        }
        catch (BadImageFormatException)
        {
            return BadMetadataStr;
        }
    }

    string Literal(Handle handle, Func<MetadataReader, Handle, string> getValue, bool noHeapReferences)
    {
        if (handle.IsNil)
        {
            return "nil";
        }

        if (_aggregator != null)
        {
            Handle generationHandle = _aggregator.GetGenerationHandle(handle, out int generation);

            var generationReader = _readers[generation];
            string value = GetValueChecked(getValue, generationReader, generationHandle);
            int offset = generationReader.GetHeapOffset(handle);
            int generationOffset = generationReader.GetHeapOffset(generationHandle);

            if (noHeapReferences)
            {
                return value;
            }
            else if (offset == generationOffset)
            {
                return $"{value} (#{offset:x})";
            }
            else
            {
                return $"{value} (#{offset:x}/{generation}:{generationOffset:x})";
            }
        }

        if (IsDelta)
        {
            // we can't resolve the literal without aggregate reader
            return $"#{_reader.GetHeapOffset(handle):x}";
        }

        int heapOffset = MetadataTokens.GetHeapOffset(handle);

        // virtual heap handles don't have offset:
        bool displayHeapOffset = !noHeapReferences && heapOffset >= 0;

        return GetValueChecked(getValue, _reader, handle) + (displayHeapOffset ? $" (#{heapOffset:x})" : "");
    }

    TypeDefinition GetGenerationTypeDefinition(TypeDefinitionHandle handle)
        => GetGenerationEntity(handle, (reader, handle) => reader.GetTypeDefinition((TypeDefinitionHandle)handle));

    MethodDefinition GetGenerationMethodDefinition(MethodDefinitionHandle handle)
        => GetGenerationEntity(handle, (reader, handle) => reader.GetMethodDefinition((MethodDefinitionHandle)handle));

    MemberReference GetGenerationMemberReference(MemberReferenceHandle handle)
        => GetGenerationEntity(handle, (reader, handle) => reader.GetMemberReference((MemberReferenceHandle)handle));

    TypeReference GetGenerationTypeDefinition(TypeReferenceHandle handle)
        => GetGenerationEntity(handle, (reader, handle) => reader.GetTypeReference((TypeReferenceHandle)handle));

    MethodSpecification GetGenerationMethodSpecification(MethodSpecificationHandle handle)
        => GetGenerationEntity(handle, (reader, handle) => reader.GetMethodSpecification((MethodSpecificationHandle)handle));

    TypeSpecification GetGenerationTypeSpecification(TypeSpecificationHandle handle)
        => GetGenerationEntity(handle, (reader, handle) => reader.GetTypeSpecification((TypeSpecificationHandle)handle));

    StandaloneSignature GetGenerationLocalSignature(StandaloneSignatureHandle handle)
        => GetGenerationEntity(handle, (reader, handle) => reader.GetStandaloneSignature((StandaloneSignatureHandle)handle));

    string QualifiedMemberName<TMemberEntity>(
        EntityHandle memberHandle,
        TypeDefinitionHandle scope,
        Func<TMemberEntity, StringHandle> nameGetter,
        Func<TMemberEntity, TypeDefinitionHandle> declaringTypeGetter,
        Func<MetadataReader, Handle, TMemberEntity> entityGetter)
    {
        try
        {
            var member = GetGenerationEntity(memberHandle, entityGetter);
            var declaringTypeDefHandle = _encAddedMemberToParentMap.TryGetValue(memberHandle, out var parentHandle) ? (TypeDefinitionHandle)parentHandle : declaringTypeGetter(member);

            var typeQualification = declaringTypeDefHandle != scope && !declaringTypeDefHandle.IsNil ? QualifiedTypeDefinitionName(declaringTypeDefHandle) + "." : "";
            var memberName = GetString(nameGetter(member));

            return typeQualification + memberName;
        }
        catch (BadImageFormatException)
        {
            return BadMetadataStr;
        }
    }

    public string TryDecodeCustomDebugInformation(CustomDebugInformation entry)
    {
        Guid kind;
        BlobReader blobReader;

        try
        {
            kind = _reader.GetGuid(entry.Kind);
            blobReader = _reader.GetBlobReader(entry.Value);
        }
        catch
        {
            // error is already reported
            return null;
        }

        if (kind == PortableCustomDebugInfoKinds.AsyncMethodSteppingInformationBlob)
        {
            return TryDecodeAsyncMethodSteppingInformation(blobReader);
        }

        if (kind == PortableCustomDebugInfoKinds.SourceLink)
        {
            return VisualizeSourceLink(blobReader);
        }

        if (kind == CompilationMetadataReferences)
        {
            return VisualizeCompilationMetadataReferences(blobReader);
        }

        if (kind == CompilationOptions)
        {
            return VisualizeCompilationOptions(blobReader);
        }

        if (kind == PortableCustomDebugInfoKinds.EmbeddedSource)
        {
            return VisualizeEmbeddedSource(blobReader);
        }

        return null;
    }

    private delegate TResult FuncRef<TArg, TResult>(ref TArg arg); 

    private static string TryRead<T>(ref BlobReader reader, ref bool error, FuncRef<BlobReader, T> read, Func<T, string> toString = null)
    {
        if (error)
        {
            return BadMetadataStr;
        }

        T value;
        try
        {
            value = read(ref reader);
        }
        catch (BadImageFormatException)
        {
            error = true;
            return BadMetadataStr;
        }

        return (toString != null) ? toString(value) : value.ToString();
    }


    private static string TryDecodeAsyncMethodSteppingInformation(BlobReader reader)
    {
        var builder = new StringBuilder();
        builder.AppendLine("{");

        bool error = false;
        var catchHandlerOffsetStr = TryRead(ref reader, ref error, (ref BlobReader reader) => reader.ReadUInt32(), value => (value == 0) ? null : $"0x{value - 1:X4}");
            
        if (catchHandlerOffsetStr != null)
        {
            builder.AppendLine($"  CatchHandlerOffset: {catchHandlerOffsetStr}");
        }

        if (error) goto onError;

        while (reader.RemainingBytes > 0)
        {
            var yieldOffsetStr = TryRead(ref reader, ref error, (ref BlobReader reader) => reader.ReadUInt32(), value => $"0x{value:X4}");
            var resumeOffsetStr = TryRead(ref reader, ref error, (ref BlobReader reader) => reader.ReadUInt32(), value => $"0x{value:X4}");
            var moveNextMethodRowIdStr = TryRead(ref reader, ref error, (ref BlobReader reader) => reader.ReadCompressedInteger(), value => $"0x06{value:X6}");

            builder.AppendLine($"  Yield: {yieldOffsetStr}, Resume: {resumeOffsetStr}, MoveNext: {moveNextMethodRowIdStr}");
            if (error) goto onError;
        }

        onError:

        if (error)
        {
            builder.AppendLine("  Remaining bytes: " + FormatBytes(reader.ReadBytes(reader.RemainingBytes)));
        }

        builder.AppendLine("}");
        return builder.ToString();
    }

    public static string FormatBytes(byte[] blob)
    {
        int length = blob.Length;
        string suffix = "";
        return BitConverter.ToString(blob, 0, length) + suffix;
    }

    public static string VisualizeEmbeddedSource(BlobReader reader)
    {
        var builder = new StringBuilder();
        builder.AppendLine(">>>");
        int format = -1;
        try { format = reader.ReadInt32(); } catch { };
        byte[] bytes = null;
        try { bytes = reader.ReadBytes(reader.RemainingBytes); } catch { };

        if (format > 0 && bytes != null)
        {
            try
            {
                using var compressedStream = new MemoryStream(bytes, writable: false);
                using var uncompressedStream = new MemoryStream();
                using var deflate = new DeflateStream(compressedStream, CompressionMode.Decompress);
                deflate.CopyTo(uncompressedStream);
                bytes = uncompressedStream.ToArray();
            }
            catch
            {
                bytes = null;
            };
        }

        if (format < 0 || bytes == null)
        {
            builder.AppendLine(BadMetadataStr);
        }
        else
        {
            builder.AppendLine(Encoding.UTF8.GetString(bytes));
            builder.AppendLine("<<< End of Embedded Source");
        }
        return builder.ToString();
    }

    public void VisualizeMethodBody(MethodBodyBlock body, MethodDefinition method, MethodDefinitionHandle methodHandle)
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendFormat("Method {0} (0x{1:X8})", Literal(() => method.Name), MetadataTokens.GetToken(methodHandle));
        builder.AppendLine();

        if (!body.LocalSignature.IsNil)
        {
            builder.AppendFormat("  Locals: {0}", StandaloneSignature(() => GetLocalSignature(body.LocalSignature)));
            builder.AppendLine();
        }

        ILVisualizer.service().DumpMethod(
            body.MaxStack,
            body.GetILContent().AsSpan(),
            builder);

        builder.AppendLine();

        _writer.Write(builder.ToString());
    }

    public void WriteModule()
    {
        if (_reader.DebugMetadataHeader != null)
        {
            return;
        }

        var def = _reader.GetModuleDefinition();
        var table = new TableBuilder(
            "Module (0x00):",
            "Gen",
            "Name",
            "Mvid",
            "EncId",
            "EncBaseId"
        );

        table.AddRow(
            ToString(() => def.Generation),
            Literal(() => def.Name),
            Literal(() => def.Mvid),
            Literal(() => def.GenerationId),
            Literal(() => def.BaseGenerationId));

        WriteTable(table);
    }

    public void WriteTypeRef()
    {
        var table = new TableBuilder(
            "TypeRef (0x01):",
            "Scope",
            "Name",
            "Namespace"
        );

        foreach (var handle in _reader.TypeReferences)
        {
            var entry = _reader.GetTypeReference(handle);

            table.AddRow(
                Token(() => entry.ResolutionScope),
                Literal(() => entry.Name),
                Literal(() => entry.Namespace)
            );
        }

        WriteTable(table);
    }

    public string TokenList(IReadOnlyCollection<EntityHandle> handles, bool displayTable = false)
    {
        if (handles.Count == 0)
        {
            return "nil";
        }

        return string.Join(", ", handles.Select(h => Token(() => h, displayTable)));
    }

    public void WriteTypeDef()
    {
        var table = new TableBuilder(
            "TypeDef (0x02):",
            "Name",
            "Namespace",
            "EnclosingType",
            "BaseType",
            "Interfaces",
            "Fields",
            "Methods",
            "Attributes",
            "ClassSize",
            "PackingSize"
        );

        foreach (var handle in _reader.TypeDefinitions)
        {
            var entry = _reader.GetTypeDefinition(handle);

            var layout = entry.GetLayout();

            // TODO: Visualize InterfaceImplementations
            var implementedInterfaces = entry.GetInterfaceImplementations().Select(h => _reader.GetInterfaceImplementation(h).Interface).ToArray();

            table.AddRow(
                Literal(() => entry.Name),
                Literal(() => entry.Namespace),
                Token(() => entry.GetDeclaringType()),
                Token(() => entry.BaseType),
                TokenList(implementedInterfaces),
                TokenRange(entry.GetFields(), h => h),
                TokenRange(entry.GetMethods(), h => h),
                EnumValue<int>(() => entry.Attributes),
                !layout.IsDefault ? layout.Size.ToString() : "n/a",
                !layout.IsDefault ? layout.PackingSize.ToString() : "n/a"
            );
        }

        WriteTable(table);
    }

    public void WriteField()
    {
        var table = new TableBuilder(
            "Field (0x04):",
            "Name",
            "Signature",
            "Attributes",
            "Marshalling",
            "Offset",
            "RVA"
        );

        foreach (var handle in _reader.FieldDefinitions)
        {
            var entry = _reader.GetFieldDefinition(handle);

            table.AddRow(
                Literal(() => entry.Name),
                FieldSignature(() => entry.Signature),
                EnumValue<int>(() => entry.Attributes),
                Literal(() => entry.GetMarshallingDescriptor(), BlobKind.Marshalling),
                ToString(() =>
                {
                    int offset = entry.GetOffset();
                    return offset >= 0 ? offset.ToString() : "n/a";
                }),
                ToString(() => entry.GetRelativeVirtualAddress())
            );
        }

        WriteTable(table);
    }

    public void WriteMethod()
    {
        var table = new TableBuilder(
            "Method (0x06, 0x1C):",
            "Name",
            "Signature",
            "RVA",
            "Parameters",
            "GenericParameters",
            "Attributes",
            "ImplAttributes",
            "ImportAttributes",
            "ImportName",
            "ImportModule"
        );

        foreach (var handle in _reader.MethodDefinitions)
        {
            var entry = _reader.GetMethodDefinition(handle);
            var import = entry.GetImport();

            table.AddRow(
                Literal(() => entry.Name),
                MethodSignature(() => entry.Signature),
                Int32Hex(() => entry.RelativeVirtualAddress),
                TokenRange(entry.GetParameters(), h => h),
                TokenRange(entry.GetGenericParameters(), h => h),
                EnumValue<int>(() => entry.Attributes),    // TODO: we need better visualizer than the default enum
                EnumValue<int>(() => entry.ImplAttributes),
                EnumValue<short>(() => import.Attributes),
                Literal(() => import.Name),
                Token(() => import.Module)
            );
        }

        WriteTable(table);
    }

    public void WriteParam()
    {
        var table = new TableBuilder(
            "Param (0x08):",
            "Name",
            "Seq#",
            "Attributes",
            "Marshalling"
        );

        for (int i = 1, count = _reader.GetTableRowCount(TableIndex.Param); i <= count; i++)
        {
            var entry = _reader.GetParameter(MetadataTokens.ParameterHandle(i));

            table.AddRow(
                Literal(() => entry.Name),
                ToString(() => entry.SequenceNumber),
                EnumValue<int>(() => entry.Attributes),
                Literal(() => entry.GetMarshallingDescriptor(), BlobKind.Marshalling)
            );
        }

        WriteTable(table);
    }

    public void WriteMemberRef()
    {
        var table = new TableBuilder(
            "MemberRef (0x0a):",
            "Parent",
            "Name",
            "Signature"
        );

        foreach (var handle in _reader.MemberReferences)
        {
            var entry = _reader.GetMemberReference(handle);

            table.AddRow(
                Token(() => entry.Parent),
                Literal(() => entry.Name),
                MemberReferenceSignature(() => entry.Signature)
            );
        }

        WriteTable(table);
    }

    public void WriteConstant()
    {
        var table = new TableBuilder(
            "Constant (0x0b):",
            "Parent",
            "Type",
            "Value"
        );

        for (int i = 1, count = _reader.GetTableRowCount(TableIndex.Constant); i <= count; i++)
        {
            var entry = _reader.GetConstant(MetadataTokens.ConstantHandle(i));

            table.AddRow(
                Token(() => entry.Parent),
                EnumValue<byte>(() => entry.TypeCode),
                Literal(() => entry.Value, BlobKind.ConstantValue)
            );
        }

        WriteTable(table);
    }

    public void WriteCustomAttribute()
    {
        var table = new TableBuilder(
            "CustomAttribute (0x0c):",
            "Parent",
            "Constructor",
            "Value"
        );

        foreach (var handle in _reader.CustomAttributes)
        {
            var entry = _reader.GetCustomAttribute(handle);

            table.AddRow(
                Token(() => entry.Parent),
                Token(() => entry.Constructor),
                Literal(() => entry.Value, BlobKind.CustomAttribute)
            );
        }

        WriteTable(table);
    }

    public void WriteDeclSecurity()
    {
        var table = new TableBuilder(
            "DeclSecurity (0x0e):",
            "Parent",
            "PermissionSet",
            "Action"
        );

        foreach (var handle in _reader.DeclarativeSecurityAttributes)
        {
            var entry = _reader.GetDeclarativeSecurityAttribute(handle);
            table.AddRow(
                Token(() => entry.Parent),
                Literal(() => entry.PermissionSet, BlobKind.PermissionSet),
                EnumValue<short>(() => entry.Action)
            );
        }

        WriteTable(table);
    }

    public void WriteStandAloneSig()
    {
        var table = new TableBuilder(
            "StandAloneSig (0x11):",
            "Signature"
        );

        for (int i = 1, count = _reader.GetTableRowCount(TableIndex.StandAloneSig); i <= count; i++)
        {
            var entry = _reader.GetStandaloneSignature(MetadataTokens.StandaloneSignatureHandle(i));
            table.AddRow(StandaloneSignature(() => entry.Signature));
        }

        WriteTable(table);
    }

    public void WriteEvent()
    {
        var table = new TableBuilder(
            "Event (0x12, 0x14, 0x18):",
            "Name",
            "Add",
            "Remove",
            "Fire",
            "Attributes"
        );

        foreach (var handle in _reader.EventDefinitions)
        {
            var entry = _reader.GetEventDefinition(handle);
            var accessors = entry.GetAccessors();

            table.AddRow(
                Literal(() => entry.Name),
                Token(() => accessors.Adder),
                Token(() => accessors.Remover),
                Token(() => accessors.Raiser),
                EnumValue<int>(() => entry.Attributes)
            );
        }

        WriteTable(table);
    }

    public void WriteProperty()
    {
        var table = new TableBuilder(
            "Property (0x15, 0x17, 0x18):",
            "Name",
            "Get",
            "Set",
            "Attributes"
        );

        foreach (var handle in _reader.PropertyDefinitions)
        {
            var entry = _reader.GetPropertyDefinition(handle);
            var accessors = entry.GetAccessors();

            table.AddRow(
                Literal(() => entry.Name),
                Token(() => accessors.Getter),
                Token(() => accessors.Setter),
                EnumValue<int>(() => entry.Attributes)
            );
        }

        WriteTable(table);
    }

    public void WriteMethodImpl()
    {
        var table = new TableBuilder(
            "MethodImpl (0x19):",
            "Type",
            "Body",
            "Declaration"
        );

        for (int i = 1, count = _reader.GetTableRowCount(TableIndex.MethodImpl); i <= count; i++)
        {
            var entry = _reader.GetMethodImplementation(MetadataTokens.MethodImplementationHandle(i));

            table.AddRow(
                Token(() => entry.Type),
                Token(() => entry.MethodBody),
                Token(() => entry.MethodDeclaration)
            );
        }

        WriteTable(table);
    }

    public void WriteModuleRef()
    {
        var table = new TableBuilder(
            "ModuleRef (0x1a):",
            "Name"
        );

        for (int i = 1, count = _reader.GetTableRowCount(TableIndex.ModuleRef); i <= count; i++)
        {
            var entry = _reader.GetModuleReference(MetadataTokens.ModuleReferenceHandle(i));
            table.AddRow(Literal(() => entry.Name));
        }

        WriteTable(table);
    }

    public void WriteTypeSpec()
    {
        var table = new TableBuilder(
            "TypeSpec (0x1b):",
            "Name");

        for (int i = 1, count = _reader.GetTableRowCount(TableIndex.TypeSpec); i <= count; i++)
        {
            var entry = _reader.GetTypeSpecification(MetadataTokens.TypeSpecificationHandle(i));
            table.AddRow(TypeSpecificationSignature(() => entry.Signature));
        }

        WriteTable(table);
    }

    public void WriteEnCLog()
    {
        var table = new TableBuilder(
            "EnC Log (0x1e):",
            "Entity",
            "Operation");

        foreach (var entry in _reader.GetEditAndContinueLogEntries())
        {
            table.AddRow(
                Token(() => entry.Handle),
                EnumValue<int>(() => entry.Operation));
        }

        WriteTable(table);
    }

    public void WriteEnCMap()
    {
        TableBuilder table;
        if (_aggregator != null)
        {
            table = new TableBuilder("EnC Map (0x1f):", "Entity", "Gen", "Row", "Edit");
        }
        else
        {
            table = new TableBuilder("EnC Map (0x1f):", "Entity");
        }

        foreach (var entry in _reader.GetEditAndContinueMapEntries())
        {
            if (_aggregator != null)
            {
                int generation;
                EntityHandle primary = (EntityHandle)_aggregator.GetGenerationHandle(entry, out generation);
                bool isUpdate = _readers[generation] != _reader;

                var primaryModule = _readers[generation].GetModuleDefinition();

                table.AddRow(
                    Token(() => entry),
                    ToString(() => primaryModule.Generation),
                    "0x" + MetadataTokens.GetRowNumber(primary).ToString("x6"),
                    isUpdate ? "update" : "add");
            }
            else
            {
                table.AddRow(Token(() => entry));
            }
        }

        WriteTable(table);
    }

    public void WriteAssembly()
    {
        if (!_reader.IsAssembly)
        {
            return;
        }

        var table = new TableBuilder(
            "Assembly (0x20):",
            "Name",
            "Version",
            "Culture",
            "PublicKey",
            "Flags",
            "HashAlgorithm"
        );

        var entry = _reader.GetAssemblyDefinition();

        table.AddRow(
            Literal(() => entry.Name),
            Version(() => entry.Version),
            Literal(() => entry.Culture),
            Literal(() => entry.PublicKey, BlobKind.Key),
            EnumValue<int>(() => entry.Flags),
            EnumValue<int>(() => entry.HashAlgorithm)
        );

        WriteTable(table);
    }

    public void WriteAssemblyRef()
    {
        var table = new TableBuilder(
            "AssemblyRef (0x23):",
            "Name",
            "Version",
            "Culture",
            "PublicKeyOrToken",
            "Flags"
        );

        foreach (var handle in _reader.AssemblyReferences)
        {
            var entry = _reader.GetAssemblyReference(handle);

            table.AddRow(
                Literal(() => entry.Name),
                Version(() => entry.Version),
                Literal(() => entry.Culture),
                Literal(() => entry.PublicKeyOrToken, BlobKind.Key),
                EnumValue<int>(() => entry.Flags)
            );
        }

        WriteTable(table);
    }

    public void WriteFile()
    {
        var table = new TableBuilder(
            "File (0x26):",
            "Name",
            "Metadata",
            "HashValue"
        );

        foreach (var handle in _reader.AssemblyFiles)
        {
            var entry = _reader.GetAssemblyFile(handle);

            table.AddRow(
                Literal(() => entry.Name),
                entry.ContainsMetadata ? "Yes" : "No",
                Literal(() => entry.HashValue, BlobKind.FileHash)
            );
        }

        WriteTable(table);
    }

    string FormatAwaits(BlobHandle handle)
    {
        var sb = new StringBuilder();
        var blobReader = _reader.GetBlobReader(handle);

        while (blobReader.RemainingBytes > 0)
        {
            if (blobReader.Offset > 0)
            {
                sb.Append(", ");
            }

            int value;
            sb.Append("(");
            sb.Append(blobReader.TryReadCompressedInteger(out value) ? value.ToString() : "?");
            sb.Append(", ");
            sb.Append(blobReader.TryReadCompressedInteger(out value) ? value.ToString() : "?");
            sb.Append(", ");
            sb.Append(blobReader.TryReadCompressedInteger(out value) ? Token(() => MetadataTokens.MethodDefinitionHandle(value)) : "?");
            sb.Append(')');
        }

        return sb.ToString();
    }

    public void WriteExportedType()
    {
        var table = new TableBuilder(
            "ExportedType (0x27):",
            "Name",
            "Namespace",
            "Attributes",
            "Implementation",
            "TypeDefinitionId"
        );

        const TypeAttributes TypeForwarder = (TypeAttributes)0x00200000;

        foreach (var handle in _reader.ExportedTypes)
        {
            var entry = _reader.GetExportedType(handle);

            table.AddRow(
                Literal(() => entry.Name),
                Literal(() => entry.Namespace),
                ToString(() => ((entry.Attributes & TypeForwarder) == TypeForwarder ? "TypeForwarder, " : "") + (entry.Attributes & ~TypeForwarder).ToString()),
                Token(() => entry.Implementation),
                Int32Hex(() => entry.GetTypeDefinitionId())
            );
        }

        WriteTable(table);
    }

    public void WriteManifestResource()
    {
        var table = new TableBuilder(
            "ManifestResource (0x28):",
            "Name",
            "Attributes",
            "Offset",
            "Implementation"
        );

        foreach (var handle in _reader.ManifestResources)
        {
            var entry = _reader.GetManifestResource(handle);

            table.AddRow(
                Literal(() => entry.Name),
                ToString(() => entry.Attributes),
                ToString(() => entry.Offset),
                Token(() => entry.Implementation)
            );
        }

        WriteTable(table);
    }

    public void WriteGenericParam()
    {
        var table = new TableBuilder(
            "GenericParam (0x2a):",
            "Name",
            "Seq#",
            "Attributes",
            "Parent",
            "TypeConstraints"
        );

        for (int i = 1, count = _reader.GetTableRowCount(TableIndex.GenericParam); i <= count; i++)
        {
            var entry = _reader.GetGenericParameter(MetadataTokens.GenericParameterHandle(i));

            table.AddRow(
                Literal(() => entry.Name),
                ToString(() => entry.Index),
                EnumValue<int>(() => entry.Attributes),
                Token(() => entry.Parent),
                TokenRange(entry.GetConstraints(), h => h)
            );
        }

        WriteTable(table);
    }

    public void WriteMethodSpec()
    {
        var table = new TableBuilder(
            "MethodSpec (0x2b):",
            "Method",
            "Signature"
        );

        for (int i = 1, count = _reader.GetTableRowCount(TableIndex.MethodSpec); i <= count; i++)
        {
            var entry = _reader.GetMethodSpecification(MetadataTokens.MethodSpecificationHandle(i));

            table.AddRow(
                Token(() => entry.Method),
                MethodSpecificationSignature(() => entry.Signature)
            );
        }

        WriteTable(table);
    }

    public void WriteGenericParamConstraint()
    {
        var table = new TableBuilder(
            "GenericParamConstraint (0x2c):",
            "Parent",
            "Type"
        );

        for (int i = 1, count = _reader.GetTableRowCount(TableIndex.GenericParamConstraint); i <= count; i++)
        {
            var entry = _reader.GetGenericParameterConstraint(MetadataTokens.GenericParameterConstraintHandle(i));
            table.AddRow(
                Token(() => entry.Parameter),
                Token(() => entry.Type)
            );
        }

        WriteTable(table);
    }

    public void WriteUserStrings()
    {
        int size = _reader.GetHeapSize(HeapIndex.UserString);
        if (size == 0)
            return;

        _writer.WriteLine(string.Format("#US (size = {0}):", size));
        var handle = MetadataTokens.UserStringHandle(0);
        do
        {
            string value = _reader.GetUserString(handle);
            _writer.WriteLine("  {0:x}: '{1}'", _reader.GetHeapOffset(handle), value);
            handle = _reader.GetNextHandle(handle);
        }
        while (!handle.IsNil);

        _writer.WriteLine();
    }

    public void WriteStrings()
    {
        int size = _reader.GetHeapSize(HeapIndex.String);
        if (size == 0)
            return;

        _writer.WriteLine(string.Format("#String (size = {0}):", size));
        var handle = MetadataTokens.StringHandle(0);
        do
        {
            string value = _reader.GetString(handle);
            _writer.WriteLine("  {0:x}: '{1}'", _reader.GetHeapOffset(handle), value);
            handle = _reader.GetNextHandle(handle);
        }
        while (!handle.IsNil);

        _writer.WriteLine();
    }

    public void WriteBlobs()
    {
        int size = _reader.GetHeapSize(HeapIndex.Blob);
        if (size == 0)
        {
            return;
        }

        _writer.WriteLine(string.Format("#Blob (size = {0}):", size));
        var handle = MetadataTokens.BlobHandle(0);
        do
        {
            byte[] value = _reader.GetBlobBytes(handle);
            _writer.WriteLine("  {0:x}: {1}", _reader.GetHeapOffset(handle), BitConverter.ToString(value));
            handle = _reader.GetNextHandle(handle);
        }
        while (!handle.IsNil);

        _writer.WriteLine();
    }

    public void WriteGuids()
    {
        int size = _reader.GetHeapSize(HeapIndex.Guid);
        if (size == 0)
        {
            return;
        }

        _writer.WriteLine(string.Format("#Guid (size = {0}):", size));
        int i = 1;
        while (i <= size / 16)
        {
            string value = _reader.GetGuid(MetadataTokens.GuidHandle(i)).ToString();
            _writer.WriteLine("  {0:x}: {{{1}}}", i, value);
            i++;
        }

        _writer.WriteLine();
    }

    public void WriteDocument()
    {
        var table = new TableBuilder(
            MakeTableName(TableIndex.Document),
            "Name",
            "Language",
            "HashAlgorithm",
            "Hash"
        );

        foreach (var handle in _reader.Documents)
        {
            var entry = _reader.GetDocument(handle);
            table.AddRow(
                DocumentName(() => entry.Name),
                Language(() => entry.Language),
                HashAlgorithm(() => entry.HashAlgorithm),
                Literal(() => entry.Hash, BlobKind.DocumentHash)
            );
        }

        WriteTable(table);
    }

    string Literal(Func<BlobHandle> getHandle, BlobKind kind) =>
        Literal(getHandle, kind, (r, h) => BitConverter.ToString(r.GetBlobBytes(h)));

    string DocumentName(Func<DocumentNameBlobHandle> getHandle) =>
        Literal(() => getHandle(), BlobKind.DocumentName, (r, h) => "'" + StringUtilities.EscapeNonPrintableCharacters(r.GetString((DocumentNameBlobHandle)h)) + "'");

    public void WriteMethodDebugInformation()
    {
        if (_reader.MethodDebugInformation.Count == 0)
        {
            return;
        }

        var table = new TableBuilder(MakeTableName(TableIndex.MethodDebugInformation), "IL");
        var detailsBuilder = new StringBuilder();

        foreach (var handle in _reader.MethodDebugInformation)
        {
            if (handle.IsNil)
            {
                continue;
            }

            var entry = _reader.GetMethodDebugInformation(handle);

            bool hasSingleDocument = false;
            bool hasSequencePoints = false;
            try
            {
                hasSingleDocument = !entry.Document.IsNil;
                hasSequencePoints = !entry.SequencePointsBlob.IsNil;
            }
            catch (BadImageFormatException)
            {
                hasSingleDocument = hasSequencePoints = false;
            }

            string details;

            if (hasSequencePoints)
            {
                _blobKinds[entry.SequencePointsBlob] = BlobKind.SequencePoints;

                detailsBuilder.Clear();
                detailsBuilder.AppendLine("{");

                bool addLineBreak = false;

                if (!TryGetValue(() => entry.GetStateMachineKickoffMethod(), out var kickoffMethod) || !kickoffMethod.IsNil)
                {
                    detailsBuilder.AppendLine($"  Kickoff Method: {(kickoffMethod.IsNil ? BadMetadataStr : Token(kickoffMethod))}");
                    addLineBreak = true;
                }

                if (!TryGetValue(() => entry.LocalSignature, out var localSignature) || !localSignature.IsNil)
                {
                    detailsBuilder.AppendLine($"  Locals: {(localSignature.IsNil ? BadMetadataStr : Token(localSignature))}");
                    addLineBreak = true;
                }

                if (hasSingleDocument)
                {
                    detailsBuilder.AppendLine($"  Document: {RowId(() => entry.Document)}");
                    addLineBreak = true;
                }

                if (addLineBreak)
                {
                    detailsBuilder.AppendLine();
                }

                try
                {
                    foreach (var sequencePoint in entry.GetSequencePoints())
                    {
                        detailsBuilder.Append("  ");
                        detailsBuilder.AppendLine(SequencePoint(sequencePoint, includeDocument: !hasSingleDocument));
                    }
                }
                catch (BadImageFormatException)
                {
                    detailsBuilder.AppendLine("  " + BadMetadataStr);
                }

                detailsBuilder.AppendLine("}");
                details = detailsBuilder.ToString();
            }
            else
            {
                details = null;
            }

            table.AddRowWithDetails(new[] { HeapOffset(() => entry.SequencePointsBlob) }, details);
        }

        WriteTable(table);
    }

    string TokenRange<THandle>(IReadOnlyCollection<THandle> handles, Func<THandle, Handle> conversion)
    {
        var genericHandles = handles.Select(conversion);
        return (handles.Count == 0) ? "nil" : Token(genericHandles.First(), displayTable: false) + "-" + Token(genericHandles.Last(), displayTable: false);
    }

    public static string GetCustomDebugInformationKind(Guid guid)
    {
        if (guid == PortableCustomDebugInfoKinds.AsyncMethodSteppingInformationBlob) return "Async Method Stepping Information";
        if (guid == PortableCustomDebugInfoKinds.StateMachineHoistedLocalScopes) return "State Machine Hoisted Local Scopes";
        if (guid == PortableCustomDebugInfoKinds.DynamicLocalVariables) return "Dynamic Local Variables";
        if (guid == PortableCustomDebugInfoKinds.TupleElementNames) return "Tuple Element Names";
        if (guid == PortableCustomDebugInfoKinds.DefaultNamespace) return "Default Namespace";
        if (guid == PortableCustomDebugInfoKinds.EncLocalSlotMap) return "EnC Local Slot Map";
        if (guid == PortableCustomDebugInfoKinds.EncLambdaAndClosureMap) return "EnC Lambda and Closure Map";
        if (guid == PortableCustomDebugInfoKinds.EmbeddedSource) return "Embedded Source";
        if (guid == PortableCustomDebugInfoKinds.SourceLink) return "Source Link";
        if (guid == CompilationMetadataReferences) return "Compilation Metadata References";
        if (guid == CompilationOptions) return "Compilation Options";

        return "{" + guid + "}";
    }

    public void WriteLocalScope()
    {
        var table = new TableBuilder(
            MakeTableName(TableIndex.LocalScope),
            "Method",
            "ImportScope",
            "Variables",
            "Constants",
            "StartOffset",
            "Length"
        );

        foreach (var handle in _reader.LocalScopes)
        {
            var entry = _reader.GetLocalScope(handle);

            table.AddRow(
                Token(() => entry.Method),
                Token(() => entry.ImportScope),
                TokenRange(entry.GetLocalVariables(), h => h),
                TokenRange(entry.GetLocalConstants(), h => h),
                Int32Hex(() => entry.StartOffset, digits: 4),
                Int32(() => entry.Length)
            );
        }

        WriteTable(table);
    }

    public void WriteLocalVariable()
    {
        var table = new TableBuilder(
            MakeTableName(TableIndex.LocalVariable),
            "Name",
            "Index",
            "Attributes"
        );

        foreach (var handle in _reader.LocalVariables)
        {
            var entry = _reader.GetLocalVariable(handle);

            table.AddRow(
                Literal(() => entry.Name),
                Int32(() => entry.Index),
                EnumValue<int>(() => entry.Attributes)
            );
        }

        WriteTable(table);
    }

    static string EnumValue<TIntegral>(Func<object> getValue)
        where TIntegral : IEquatable<TIntegral>
    {
        object value;

        try
        {
            value = getValue();
        }
        catch (BadImageFormatException)
        {
            return BadMetadataStr;
        }

        TIntegral integralValue = (TIntegral)value;
        if (integralValue.Equals(default))
        {
            return "0";
        }

        return $"0x{integralValue:x8} ({value})";
    }


    public void WriteLocalConstant()
    {
        var table = new TableBuilder(
            MakeTableName(TableIndex.LocalConstant),
            "Name",
            "Signature"
        );

        foreach (var handle in _reader.LocalConstants)
        {
            var entry = _reader.GetLocalConstant(handle);

            table.AddRow(
                Literal(() => entry.Name),
                Literal(() => entry.Signature, BlobKind.LocalConstantSignature, (r, h) => FormatLocalConstant(r, (BlobHandle)h))
            );
        }

        WriteTable(table);
    }

    public static bool IsPrimitiveType(SignatureTypeCode typeCode)
    {
        switch (typeCode)
        {
            case SignatureTypeCode.Boolean:
            case SignatureTypeCode.Char:
            case SignatureTypeCode.SByte:
            case SignatureTypeCode.Byte:
            case SignatureTypeCode.Int16:
            case SignatureTypeCode.UInt16:
            case SignatureTypeCode.Int32:
            case SignatureTypeCode.UInt32:
            case SignatureTypeCode.Int64:
            case SignatureTypeCode.UInt64:
            case SignatureTypeCode.Single:
            case SignatureTypeCode.Double:
            case SignatureTypeCode.String:
                return true;

            default:
                return false;
        }
    }

    public SignatureTypeCode ReadConstantTypeCode(ref BlobReader sigReader, List<string> modifiers)
    {
        while (true)
        {
            var s = sigReader.ReadSignatureTypeCode();
            if (s == SignatureTypeCode.OptionalModifier || s == SignatureTypeCode.RequiredModifier)
            {
                var type = sigReader.ReadTypeHandle();
                modifiers.Add((s == SignatureTypeCode.RequiredModifier ? "modreq" : "modopt") + "(" + Token(() => type) + ")");
            }
            else
            {
                return s;
            }
        }
    }

    public string FormatLocalConstant(MetadataReader reader, BlobHandle signature)
    {
        var sigReader = reader.GetBlobReader(signature);

        var modifiers = new List<string>();

        SignatureTypeCode typeCode = ReadConstantTypeCode(ref sigReader, modifiers);

        Handle typeHandle = default;
        object value;
        if (IsPrimitiveType(typeCode))
        {
            if (typeCode == SignatureTypeCode.String)
            {
                if (sigReader.RemainingBytes == 1)
                {
                    value = (sigReader.ReadByte() == 0xff) ? "null" : BadMetadataStr;
                }
                else if (sigReader.RemainingBytes % 2 != 0)
                {
                    value = BadMetadataStr;
                }
                else
                {
                    value = "'" + StringUtilities.EscapeNonPrintableCharacters(sigReader.ReadUTF16(sigReader.RemainingBytes)) + "'";
                }
            }
            else
            {
                object rawValue = sigReader.ReadConstant((ConstantTypeCode)typeCode);
                if (rawValue is char c)
                {
                    value = "'" + StringUtilities.EscapeNonPrintableCharacters(c.ToString()) + "'";
                }
                else
                {
                    value = string.Format(CultureInfo.InvariantCulture, "{0}", rawValue);
                }
            }

            if (sigReader.RemainingBytes > 0)
            {
                typeHandle = sigReader.ReadTypeHandle();
            }
        }
        else if (typeCode == SignatureTypeCode.TypeHandle)
        {
            typeHandle = sigReader.ReadTypeHandle();
            value = (sigReader.RemainingBytes > 0) ? BitConverter.ToString(sigReader.ReadBytes(sigReader.RemainingBytes)) : "default";
        }
        else
        {
            value = (typeCode == SignatureTypeCode.Object) ? "null" : $"<bad type code: {typeCode}>";
        }

        return string.Format("{0} [{1}{2}]",
            value,
                string.Join(" ", modifiers),
            typeHandle.IsNil ? typeCode.ToString() : Token(() => typeHandle));
    }

    public string Token(Func<Handle> getHandle, bool displayTable = true)
        => ToString(getHandle, displayTable, Token);

    void WriteTable(TableBuilder table)
    {
        if (table.RowCount > 0)
        {
            table.WriteTo(_writer);
            _writer.WriteLine();
        }
    }

    public void WriteImportScope()
    {
        var table = new TableBuilder(
            MakeTableName(TableIndex.ImportScope),
            "Parent",
            "Imports"
        );

        foreach (var handle in _reader.ImportScopes)
        {
            var entry = _reader.GetImportScope(handle);

            _blobKinds[entry.ImportsBlob] = BlobKind.Imports;

            table.AddRow(
                Token(() => entry.Parent),
                FormatImports(entry)
            );
        }

        WriteTable(table);
    }

    public string SequencePoint(SequencePoint sequencePoint, bool includeDocument = true)
    {
        string range = sequencePoint.IsHidden ?
            "<hidden>" : $"({sequencePoint.StartLine}, {sequencePoint.StartColumn}) - ({sequencePoint.EndLine}, {sequencePoint.EndColumn})" + (includeDocument ? $" [{RowId(() => sequencePoint.Document)}]" : "");
        return $"IL_{sequencePoint.Offset:X4}: " + range;
    }

    bool NoHeapReferences
        => (_options & MetadataVisualizerOptions.NoHeapReferences) != 0;

    static readonly Guid s_CSharpGuid = new Guid("3f5162f8-07c6-11d3-9053-00c04fa302a1");

    static readonly Guid s_visualBasicGuid = new Guid("3a12d0b8-c26c-11d0-b442-00a0244a1dd2");

    static readonly Guid s_FSharpGuid = new Guid("ab4f38c9-b6e6-43ba-be3b-58080b2ccce3");

    string Int32(Func<int> getValue)
        => ToString(getValue, value => value.ToString());

    string Int32Hex(Func<int> getValue, int digits = 8)
        => ToString(getValue, value => "0x" + value.ToString("X" + digits));

    string HeapOffset(Func<Handle> getHandle)
        => ToString(getHandle, HeapOffset);

    string HeapOffset(Handle handle)
        => handle.IsNil ? "nil" : NoHeapReferences ? "" : $"#{_reader.GetHeapOffset(handle):x}";

    string RowId(Func<EntityHandle> getHandle)
        => ToString(getHandle, RowId);

    public static string GetLanguage(Guid guid)
    {
        if (guid == s_CSharpGuid)
            return "C#";

        if (guid == s_visualBasicGuid)
            return "Visual Basic";

        if (guid == s_FSharpGuid)
            return "F#";

        return "{" + guid + "}";
    }

    string ToString<TValue>(Func<TValue> getValue)
    {
        try
        {
            return getValue().ToString();
        }
        catch (BadImageFormatException)
        {
            return BadMetadataStr;
        }
    }

    public static string GetHashAlgorithm(Guid guid)
    {
        if (guid == s_sha1Guid)
            return "SHA-1";

        if (guid == s_sha256Guid)
            return "SHA-256";

        return "{" + guid + "}";
    }

    string FormatImports(ImportScope scope)
    {
        if (scope.ImportsBlob.IsNil)
        {
            return "nil";
        }

        var sb = new StringBuilder();

        foreach (var import in scope.GetImports())
        {
            if (sb.Length > 0)
            {
                sb.Append(", ");
            }

            switch (import.Kind)
            {
                case ImportDefinitionKind.ImportNamespace:
                    sb.AppendFormat("{0}", LiteralUtf8Blob(() => import.TargetNamespace, BlobKind.ImportNamespace));
                    break;

                case ImportDefinitionKind.ImportAssemblyNamespace:
                    sb.AppendFormat("{0}::{1}",
                        Token(() => import.TargetAssembly),
                        LiteralUtf8Blob(() => import.TargetNamespace, BlobKind.ImportNamespace));
                    break;

                case ImportDefinitionKind.ImportType:
                    sb.AppendFormat("{0}", Token(() => import.TargetType));
                    break;

                case ImportDefinitionKind.ImportXmlNamespace:
                    sb.AppendFormat("<{0} = {1}>",
                        LiteralUtf8Blob(() => import.Alias, BlobKind.ImportAlias),
                        LiteralUtf8Blob(() => import.TargetNamespace, BlobKind.ImportNamespace));
                    break;

                case ImportDefinitionKind.ImportAssemblyReferenceAlias:
                    sb.AppendFormat("Extern Alias {0}",
                        LiteralUtf8Blob(() => import.Alias, BlobKind.ImportAlias));
                    break;

                case ImportDefinitionKind.AliasAssemblyReference:
                    sb.AppendFormat("{0} = {1}",
                        LiteralUtf8Blob(() => import.Alias, BlobKind.ImportAlias),
                        Token(() => import.TargetAssembly));
                    break;

                case ImportDefinitionKind.AliasNamespace:
                    sb.AppendFormat("{0} = {1}",
                        LiteralUtf8Blob(() => import.Alias, BlobKind.ImportAlias),
                        LiteralUtf8Blob(() => import.TargetNamespace, BlobKind.ImportNamespace));
                    break;

                case ImportDefinitionKind.AliasAssemblyNamespace:
                    sb.AppendFormat("{0} = {1}::{2}",
                        LiteralUtf8Blob(() => import.Alias, BlobKind.ImportAlias),
                        Token(() => import.TargetAssembly),
                        LiteralUtf8Blob(() => import.TargetNamespace, BlobKind.ImportNamespace));
                    break;

                case ImportDefinitionKind.AliasType:
                    sb.AppendFormat("{0} = {1}",
                        LiteralUtf8Blob(() => import.Alias, BlobKind.ImportAlias),
                        Token(() => import.TargetType));
                    break;
            }
        }

        return sb.ToString();
    }


    public void WriteCustomDebugInformation()
    {
        const int BlobSizeLimit = 32;

        var table = new TableBuilder(
            MakeTableName(TableIndex.CustomDebugInformation),
            "Parent",
            "Kind",
            "Value"
        );

        foreach (var handle in _reader.CustomDebugInformation)
        {
            var entry = _reader.GetCustomDebugInformation(handle);

            table.AddRowWithDetails(
                fields: new[]
                {
                    Token(() => entry.Parent),
                    CustomDebugInformationKind(() => entry.Kind),
                    Literal(() => entry.Value, BlobKind.CustomDebugInformation, (r, h) =>
                    {
                        var blob = r.GetBlobBytes(h);
                        int length = blob.Length;
                        string suffix = "";

                        if (blob.Length > BlobSizeLimit)
                        {
                            length = BlobSizeLimit;
                            suffix = "-...";
                        }

                        return BitConverter.ToString(blob, 0, length) + suffix;
                    })
                },
                details: TryDecodeCustomDebugInformation(entry)
            );
        }

        WriteTable(table);
    }

    // public string TryDecodeCustomDebugInformation(CustomDebugInformation entry)
    // {
    //     Guid kind;
    //     BlobReader blobReader;

    //     try
    //     {
    //         kind = _reader.GetGuid(entry.Kind);
    //         blobReader = _reader.GetBlobReader(entry.Value);
    //     }
    //     catch
    //     {
    //         // error is already reported
    //         return null;
    //     }

    //     if (kind == PortableCustomDebugInfoKinds.SourceLink)
    //     {
    //         return VisualizeSourceLink(blobReader);
    //     }

    //     if (kind == CompilationMetadataReferences)
    //     {
    //         return VisualizeCompilationMetadataReferences(blobReader);
    //     }

    //     if (kind == CompilationOptions)
    //     {
    //         return VisualizeCompilationOptions(blobReader);
    //     }

    //     return null;
    // }

    [Flags]
    enum MetadataReferenceFlags
    {
        Assembly = 1,

        EmbedInteropTypes = 1 << 1,
    }

    public static string VisualizeCompilationMetadataReferences(BlobReader reader)
    {
        var table = new TableBuilder(
            title: null,
            "FileName",
            "Aliases",
            "Flags",
            "TimeStamp",
            "FileSize",
            "MVID")
        {
            HorizontalSeparatorChar = '-',
            Indent = "  ",
            FirstRowNumber = 0,
        };

        while (reader.RemainingBytes > 0)
        {
            var fileName = TryReadUtf8NullTerminated(ref reader);
            var aliases = TryReadUtf8NullTerminated(ref reader);

            string flags = null;
            string timeStamp = null;
            string fileSize = null;
            string mvid = null;

            try { flags = ((MetadataReferenceFlags)reader.ReadByte()).ToString(); } catch { }
            try { timeStamp = $"0x{reader.ReadUInt32():X8}"; } catch { }
            try { fileSize = $"0x{reader.ReadUInt32():X8}"; } catch { }
            try { mvid = reader.ReadGuid().ToString(); } catch { }

            table.AddRow(
                (fileName != null) ? $"'{fileName}'" : BadMetadataStr,
                (aliases != null) ? $"'{string.Join("', '", aliases.Split(','))}'" : BadMetadataStr,
                flags ?? BadMetadataStr,
                timeStamp ?? BadMetadataStr,
                fileSize ?? BadMetadataStr,
                mvid ?? BadMetadataStr
            );
        }

        var builder = new StringBuilder();
        builder.AppendLine("{");
        table.WriteTo(new StringWriter(builder));
        builder.AppendLine("}");
        return builder.ToString();
    }

    static string TryReadUtf8NullTerminated(ref BlobReader reader)
    {
        var terminatorIndex = reader.IndexOf(0);
        if (terminatorIndex == -1)
        {
            return null;
        }

        var value = reader.ReadUTF8(terminatorIndex);
        _ = reader.ReadByte();
        return value;
    }

    static string VisualizeCompilationOptions(BlobReader reader)
    {
        var builder = new StringBuilder();
        builder.AppendLine("{");

        while (reader.RemainingBytes > 0)
        {
            var key = TryReadUtf8NullTerminated(ref reader);
            if (key == null)
            {
                builder.AppendLine(BadMetadataStr);
                break;
            }

            builder.Append($"  {key}: ");

            var value = TryReadUtf8NullTerminated(ref reader);
            if (value == null)
            {
                builder.AppendLine(BadMetadataStr);
                break;
            }

            builder.AppendLine(value);
        }

        builder.AppendLine("}");
        return builder.ToString();
    }

    static string VisualizeSourceLink(BlobReader reader)
        => reader.ReadUTF8(reader.RemainingBytes);

    string Literal(Func<StringHandle> getHandle)
        => Literal(() => getHandle(), (r, h) => "'" + StringUtilities.EscapeNonPrintableCharacters(r.GetString((StringHandle)h)) + "'");

    string Literal(Func<NamespaceDefinitionHandle> getHandle)
        => Literal(() => getHandle(), (r, h) => "'" + StringUtilities.EscapeNonPrintableCharacters(r.GetString((NamespaceDefinitionHandle)h)) + "'");

    string Literal(Func<GuidHandle> getHandle) =>
        Literal(() => getHandle(), (r, h) => "{" + r.GetGuid((GuidHandle)h) + "}");

    string Version(Func<Version> getVersion)
        => ToString(getVersion, version => version.Major + "." + version.Minor + "." + version.Build + "." + version.Revision);

    string Literal(Func<BlobHandle> getHandle, BlobKind kind, Func<MetadataReader, BlobHandle, string> getValue)
    {
        BlobHandle handle;
        try
        {
            handle = getHandle();
        }
        catch (BadImageFormatException)
        {
            return BadMetadataStr;
        }

        if (!handle.IsNil && kind != BlobKind.None)
            _blobKinds[handle] = kind;

        return Literal(handle, (r, h) => getValue(r, (BlobHandle)h));

    }

    string LiteralUtf8Blob(Func<BlobHandle> getHandle, BlobKind kind)
    {
        return Literal(getHandle, kind, (r, h) =>
        {
            var bytes = r.GetBlobBytes(h);
            return "'" + Encoding.UTF8.GetString(bytes, 0, bytes.Length) + "'";
        });
    }

    string Language(Func<GuidHandle> getHandle)
        => Literal(() => getHandle(), (r, h) => GetLanguage(r.GetGuid((GuidHandle)h)));

    string HashAlgorithm(Func<GuidHandle> getHandle)
        => Literal(() => getHandle(), (r, h) => GetHashAlgorithm(r.GetGuid((GuidHandle)h)));

    string CustomDebugInformationKind(Func<GuidHandle> getHandle)
        => Literal(() => getHandle(), (r, h) => GetCustomDebugInformationKind(r.GetGuid((GuidHandle)h)));

    string Literal(Func<Handle> getHandle, Func<MetadataReader, Handle, string> getValue)
    {
        Handle handle;
        try
        {
            handle = getHandle();
        }
        catch (BadImageFormatException)
        {
            return BadMetadataStr;
        }

        return Literal(handle, getValue);
    }

    string Literal(Handle handle, Func<MetadataReader, Handle, string> getValue)
    {
        if (handle.IsNil)
            return "nil";

        if (_aggregator != null)
        {
            int generation;
            Handle generationHandle = _aggregator.GetGenerationHandle(handle, out generation);

            var generationReader = _readers[generation];
            string value = getValue(generationReader, generationHandle);
            int offset = generationReader.GetHeapOffset(handle);
            int generationOffset = generationReader.GetHeapOffset(generationHandle);

            if (offset == generationOffset)
            {
                return string.Format("{0} (#{1:x})", value, offset);
            }
            else
            {
                return string.Format("{0} (#{1:x}/{2:x})", value, offset, generationOffset);
            }
        }

        if (IsDelta)
        {
            // we can't resolve the literal without aggregate reader
            return string.Format("#{0:x}", _reader.GetHeapOffset(handle));
        }

        return string.Format("{1:x} (#{0:x})", _reader.GetHeapOffset(handle), getValue(_reader, handle));
    }

    static readonly Guid s_sha1Guid = new Guid("ff1816ec-aa5e-4d10-87f7-6f4963833460");

    static readonly Guid s_sha256Guid = new Guid("8829d00f-11b8-4213-878b-770e8597ac16");

    public static readonly Guid CompilationMetadataReferences = new Guid("7E4D4708-096E-4C5C-AEDA-CB10BA6A740D");

    public static readonly Guid CompilationOptions = new Guid("B5FEEC05-8CD0-4A83-96DA-466284BB4BD8");

    static string ToString<TValue>(Func<TValue> getValue, Func<TValue, string> valueToString)
    {
        try
        {
            return valueToString(getValue());
        }
        catch (BadImageFormatException)
        {
            return BadMetadataStr;
        }
    }

    static string ToString<TValue, TArg>(Func<TValue> getValue, TArg arg, Func<TValue, TArg, string> valueToString)
    {
        try
        {
            return valueToString(getValue(), arg);
        }
        catch (BadImageFormatException)
        {
            return BadMetadataStr;
        }
    }

    const string BadMetadataStr = "<bad metadata>";

    static bool TryGetValue<T>(Func<T> getValue, out T result)
    {
        try
        {
            result = getValue();
            return true;
        }
        catch (BadImageFormatException)
        {
            result = default;
            return false;
        }
    }

    static bool TryGetHandleRange(ImmutableArray<EntityHandle> handles, HandleKind handleKind, out int start, out int count)
    {
        TableIndex tableIndex;
        MetadataTokens.TryGetTableIndex(handleKind, out tableIndex);

        int mapIndex = ImmutableArray.BinarySearch<EntityHandle>(handles, MetadataTokens.EntityHandle(tableIndex, 0), TokenTypeComparer.Instance);
        if (mapIndex < 0)
        {
            start = 0;
            count = 0;
            return false;
        }

        int s = mapIndex;
        while (s >= 0 && handles[s].Kind == handleKind)
            s--;

        int e = mapIndex;
        while (e < handles.Length && handles[e].Kind == handleKind)
            e++;

        start = s + 1;
        count = e - start;
        return true;
    }

    string MakeTableName(TableIndex index)
        => $"{index} (index: 0x{(byte)index:X2}, size: {_reader.GetTableRowCount(index) * _reader.GetTableRowSize(index)}): ";

    string FieldSignature(Func<BlobHandle> getHandle)
        => Literal(getHandle, BlobKind.FieldSignature, (r, h) => Signature(r, h, BlobKind.FieldSignature));

    string MethodSignature(Func<BlobHandle> getHandle)
        => Literal(getHandle, BlobKind.MethodSignature, (r, h) => Signature(r, h, BlobKind.MethodSignature));

    string StandaloneSignature(Func<BlobHandle> getHandle) =>
        Literal(getHandle, BlobKind.StandAloneSignature, (r, h) => Signature(r, h, BlobKind.StandAloneSignature));

    string MemberReferenceSignature(Func<BlobHandle> getHandle) =>
        Literal(getHandle, BlobKind.MemberRefSignature, (r, h) => Signature(r, h, BlobKind.MemberRefSignature));

    string MethodSpecificationSignature(Func<BlobHandle> getHandle) =>
        Literal(getHandle, BlobKind.MethodSpec, (r, h) => Signature(r, h, BlobKind.MethodSpec));

    string TypeSpecificationSignature(Func<BlobHandle> getHandle) =>
        Literal(getHandle, BlobKind.TypeSpec, (r, h) => Signature(r, h, BlobKind.TypeSpec));

    string Signature(MetadataReader reader, BlobHandle signatureHandle, BlobKind kind)
    {
        try
        {
            var sigReader = reader.GetBlobReader(signatureHandle);
            var decoder = new SignatureDecoder<string, object>(_signatureVisualizer, reader, genericContext: null);
            switch (kind)
            {
                case BlobKind.FieldSignature:
                    return decoder.DecodeFieldSignature(ref sigReader);

                case BlobKind.MethodSignature:
                    return MethodSignature(decoder.DecodeMethodSignature(ref sigReader));

                case BlobKind.StandAloneSignature:
                    return string.Join(", ", decoder.DecodeLocalSignature(ref sigReader));

                case BlobKind.MemberRefSignature:
                    var header = sigReader.ReadSignatureHeader();
                    sigReader.Offset = 0;
                    switch (header.Kind)
                    {
                        case SignatureKind.Field:
                            return decoder.DecodeFieldSignature(ref sigReader);

                        case SignatureKind.Method:
                            return MethodSignature(decoder.DecodeMethodSignature(ref sigReader));
                    }

                    throw new BadImageFormatException();

                case BlobKind.MethodSpec:
                    return string.Join(", ", decoder.DecodeMethodSpecificationSignature(ref sigReader));

                case BlobKind.TypeSpec:
                    return decoder.DecodeType(ref sigReader, allowTypeSpecifications: false);

                default:
                    throw ExceptionUtilities.UnexpectedValue(kind);
            }
        }
        catch (BadImageFormatException)
        {
            return $"<bad signature: {BitConverter.ToString(reader.GetBlobBytes(signatureHandle))}>";
        }
    }

    static string MethodSignature(MethodSignature<string> signature)
    {
        var builder = new StringBuilder();
        builder.Append(signature.ReturnType);
        builder.Append(' ');
        builder.Append('(');

        for (int i = 0; i < signature.ParameterTypes.Length; i++)
        {
            if (i > 0)
            {
                builder.Append(", ");

                if (i == signature.RequiredParameterCount)
                {
                    builder.Append("... ");
                }
            }

            builder.Append(signature.ParameterTypes[i]);
        }

        builder.Append(')');
        return builder.ToString();
    }

    // Test implementation of ISignatureTypeProvider<TType, TGenericContext> that uses strings in ilasm syntax as TType.
    // A real provider in any sort of perf constraints would not want to allocate strings freely like this, but it keeps test code simple.
    internal sealed class SignatureVisualizer : ISignatureTypeProvider<string, object>
    {
        private readonly MetadataVisualizer _visualizer;

        public SignatureVisualizer(MetadataVisualizer visualizer)
        {
            _visualizer = visualizer;
        }

        public string GetPrimitiveType(PrimitiveTypeCode typeCode)
        {
            switch (typeCode)
            {
                case PrimitiveTypeCode.Boolean: return "bool";
                case PrimitiveTypeCode.Byte: return "uint8";
                case PrimitiveTypeCode.Char: return "char";
                case PrimitiveTypeCode.Double: return "float64";
                case PrimitiveTypeCode.Int16: return "int16";
                case PrimitiveTypeCode.Int32: return "int32";
                case PrimitiveTypeCode.Int64: return "int64";
                case PrimitiveTypeCode.IntPtr: return "native int";
                case PrimitiveTypeCode.Object: return "object";
                case PrimitiveTypeCode.SByte: return "int8";
                case PrimitiveTypeCode.Single: return "float32";
                case PrimitiveTypeCode.String: return "string";
                case PrimitiveTypeCode.TypedReference: return "typedref";
                case PrimitiveTypeCode.UInt16: return "uint16";
                case PrimitiveTypeCode.UInt32: return "uint32";
                case PrimitiveTypeCode.UInt64: return "uint64";
                case PrimitiveTypeCode.UIntPtr: return "native uint";
                case PrimitiveTypeCode.Void: return "void";
                default: return "<bad metadata>";
            }
        }

        string RowId(EntityHandle handle)
            => _visualizer.RowId(handle);

        public string GetTypeFromDefinition(MetadataReader reader, TypeDefinitionHandle handle, byte rawTypeKind = 0)
            => $"typedef{RowId(handle)}";

        public string GetTypeFromReference(MetadataReader reader, TypeReferenceHandle handle, byte rawTypeKind = 0) =>
            $"typeref{RowId(handle)}";

        public string GetTypeFromSpecification(MetadataReader reader, object genericContext, TypeSpecificationHandle handle, byte rawTypeKind = 0) =>
            $"typespec{RowId(handle)}";

        public string GetSZArrayType(string elementType)
            => elementType + "[]";

        public string GetPointerType(string elementType)
            => elementType + "*";

        public string GetByReferenceType(string elementType)
            => elementType + "&";

        public string GetGenericMethodParameter(object genericContext, int index)
            => "!!" + index;

        public string GetGenericTypeParameter(object genericContext, int index)
            => "!" + index;

        public string GetPinnedType(string elementType)
            => elementType + " pinned";

        public string GetGenericInstantiation(string genericType, ImmutableArray<string> typeArguments)
            => genericType + "<" + string.Join(",", typeArguments) + ">";

        public string GetModifiedType(string modifierType, string unmodifiedType, bool isRequired) =>
            unmodifiedType + (isRequired ? " modreq(" : " modopt(") + modifierType + ")";

        public string GetArrayType(string elementType, ArrayShape shape)
        {
            var builder = new StringBuilder();

            builder.Append(elementType);
            builder.Append('[');

            for (int i = 0; i < shape.Rank; i++)
            {
                int lowerBound = 0;

                if (i < shape.LowerBounds.Length)
                {
                    lowerBound = shape.LowerBounds[i];
                    builder.Append(lowerBound);
                }

                builder.Append("...");

                if (i < shape.Sizes.Length)
                {
                    builder.Append(lowerBound + shape.Sizes[i] - 1);
                }

                if (i < shape.Rank - 1)
                {
                    builder.Append(',');
                }
            }

            builder.Append(']');
            return builder.ToString();
        }

        public string GetFunctionPointerType(MethodSignature<string> signature)
            => $"methodptr({MethodSignature(signature)})";
    }

    public virtual string VisualizeLocalType(object type)
        => string.Format(CultureInfo.InvariantCulture, "0x{0:X8}", type);

    sealed class TokenTypeComparer : IComparer<EntityHandle>
    {
        public static readonly TokenTypeComparer Instance = new TokenTypeComparer();

        public int Compare(EntityHandle x, EntityHandle y)
        {
            return x.Kind.CompareTo(y.Kind);
        }
    }

    enum BlobKind
    {
        None,
        Key,
        FileHash,

        MethodSignature,

        FieldSignature,

        MemberRefSignature,

        StandAloneSignature,

        TypeSpec,

        MethodSpec,

        ConstantValue,

        Marshalling,

        PermissionSet,
        CustomAttribute,

        DocumentName,
        DocumentHash,
        SequencePoints,
        Imports,
        ImportAlias,
        ImportNamespace,
        LocalConstantSignature,
        CustomDebugInformation,

        Count
    }

    sealed class TableBuilder
    {
        readonly string _title;

        readonly string[] _header;

        readonly List<(string[] fields, string details)> _rows;

        public char HorizontalSeparatorChar = '=';

        public string Indent = "";

        public int FirstRowNumber = 1;

        public TableBuilder(string title, params string[] header)
        {
            _rows = new List<(string[] fields, string details)>();
            _title = title;
            _header = header;
        }

        public int RowCount
            => _rows.Count;

        public void AddRow(params string[] fields)
            => AddRowWithDetails(fields, details: null);

        public void AddRowWithDetails(string[] fields, string details)
        {
            Debug.Assert(_header.Length == fields.Length);
            _rows.Add((fields, details));
        }

        public void WriteTo(TextWriter writer)
        {
            if (_rows.Count == 0)
            {
                return;
            }

            if (_title != null)
            {
                writer.Write(Indent);
                writer.WriteLine(_title);
            }

            string columnSeparator = "  ";
            var columnWidths = new int[_rows.First().fields.Length];

            void updateColumnWidths( string[] fields)
            {
                for (int i = 0; i < fields.Length; i++)
                {
                    columnWidths[i] = Math.Max(columnWidths[i], fields[i].Length + columnSeparator.Length);
                }
            }

            updateColumnWidths(_header);

            foreach (var (fields, _) in _rows)
            {
                updateColumnWidths(fields);
            }

            void writeRow(string[] fields)
            {
                for (int i = 0; i < fields.Length; i++)
                {
                    var field = fields[i];

                    writer.Write(field);
                    writer.Write(new string(' ', columnWidths[i] - field.Length));
                }
            }

            // header:
            var rowNumberWidth = (FirstRowNumber + _rows.Count - 1).ToString("x").Length;
            var tableWidth = Math.Max(_title?.Length ?? 0, columnWidths.Sum() + columnWidths.Length);
            var horizontalSeparator = new string(HorizontalSeparatorChar, tableWidth);

            writer.Write(Indent);
            writer.WriteLine(horizontalSeparator);

            writer.Write(Indent);
            writer.Write(new string(' ', rowNumberWidth + 2));

            writeRow(_header);

            writer.WriteLine();
            writer.Write(Indent);
            writer.WriteLine(horizontalSeparator);

            // rows:
            int rowNumber = FirstRowNumber;
            foreach (var (fields, details) in _rows)
            {
                string rowNumberStr = rowNumber.ToString("x");
                writer.Write(Indent);
                writer.Write(new string(' ', rowNumberWidth - rowNumberStr.Length));
                writer.Write(rowNumberStr);
                writer.Write(": ");

                writeRow(fields);
                writer.WriteLine();

                if (details != null)
                {
                    writer.Write(Indent);
                    writer.Write(details);
                }

                rowNumber++;
            }
        }
    }
}

internal static class StringUtilities
{
    internal static string EscapeNonPrintableCharacters(string str)
    {
        StringBuilder sb = new StringBuilder();

        foreach (char c in str)
        {
            bool escape;
            switch (CharUnicodeInfo.GetUnicodeCategory(c))
            {
                case UnicodeCategory.Control:
                case UnicodeCategory.OtherNotAssigned:
                case UnicodeCategory.ParagraphSeparator:
                case UnicodeCategory.Surrogate:
                    escape = true;
                    break;

                default:
                    escape = c >= 0xFFFC;
                    break;
            }

            if (escape)
            {
                sb.AppendFormat("\\u{0:X4}", (int)c);
            }
            else
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }
}

public static class ExceptionUtilities
{
    public static Exception UnexpectedValue(object o)
    {
        string output = string.Format("Unexpected value '{0}' of type '{1}'", o, (o != null) ? o.GetType().FullName : "<unknown>");
        Debug.Assert(false, output);

        // We do not throw from here because we don't want all Watson reports to be bucketed to this call.
        return new InvalidOperationException(output);
    }

    public static Exception Unreachable
    {
        get { return new InvalidOperationException("This program location is thought to be unreachable."); }
    }
}

internal static class PortableCustomDebugInfoKinds
{
    public static readonly Guid AsyncMethodSteppingInformationBlob = new Guid("54FD2AC5-E925-401A-9C2A-F94F171072F8");

    public static readonly Guid StateMachineHoistedLocalScopes = new Guid("6DA9A61E-F8C7-4874-BE62-68BC5630DF71");

    public static readonly Guid DynamicLocalVariables = new Guid("83C563C4-B4F3-47D5-B824-BA5441477EA8");

    public static readonly Guid TupleElementNames = new Guid("ED9FDF71-8879-4747-8ED3-FE5EDE3CE710");

    public static readonly Guid DefaultNamespace = new Guid("58b2eab6-209f-4e4e-a22c-b2d0f910c782");

    public static readonly Guid EncLocalSlotMap = new Guid("755F52A8-91C5-45BE-B4B8-209571E552BD");

    public static readonly Guid EncLambdaAndClosureMap = new Guid("A643004C-0240-496F-A783-30D64F4979DE");

    public static readonly Guid SourceLink = new Guid("CC110556-A091-4D38-9FEC-25AB9A351A6A");

    public static readonly Guid EmbeddedSource = new Guid("0E8A571B-6926-466E-B4AD-8AB04611F5FE");
}

internal static class Hash
{
    /// <summary>
    /// This is how VB Anonymous Types combine hash values for fields.
    /// PERF: Do not use with enum types because that involves multiple
    /// unnecessary boxing operations.  Unfortunately, we can't constrain
    /// T to "non-enum", so we'll use a more restrictive constraint.
    /// </summary>
    internal static int Combine<T>(T newKeyPart, int currentKey) where T : class
    {
        int hash = unchecked(currentKey * (int)0xA5555529);

        if (newKeyPart != null)
        {
            return unchecked(hash + newKeyPart.GetHashCode());
        }

        return hash;
    }
}

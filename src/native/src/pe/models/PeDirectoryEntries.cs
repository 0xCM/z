//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack =1), Record(TableName)]
    public record struct PeDirectoryEntries
    {
        const string TableName = "pe.directories";

        /// <summary>
        /// The location/size of the export directory
        /// </summary>
        public PeDirectoryEntry ExportTable;

        /// <summary>
        /// The location/size of the import directory
        /// </summary>
        public PeDirectoryEntry ImportTable;

        /// <summary>
        /// The location/size of the resource directory
        /// </summary>
        public PeDirectoryEntry ResourceTable;

        /// <summary>
        /// The location/size of the exception directory
        /// </summary>
        public PeDirectoryEntry ExceptionTable;

        /// <summary>
        /// The location/size of the certificate directory
        /// </summary>
        public PeDirectoryEntry CertificateTable;

        /// <summary>
        /// The location/size of the relocation directory
        /// </summary>
        public PeDirectoryEntry RelocationTable;

        /// <summary>
        /// The location/size of the load debug directory
        /// </summary>
        public PeDirectoryEntry DebugTable;

        /// <summary>
        /// Reserved
        /// </summary>
        PeDirectoryEntry Architecture;

        /// <summary>
        /// The location/size of the global pointer directory
        /// </summary>
        public PeDirectoryEntry GlobalPointerTable;

        /// <summary>
        /// The location/size of the tls directory
        /// </summary>
        public PeDirectoryEntry TlsTable;

        /// <summary>
        /// The location/size of the load config directory
        /// </summary>
        public PeDirectoryEntry LoadConfigTable;

        /// <summary>
        /// The location/size of the bound import directory
        /// </summary>
        public PeDirectoryEntry BoundImportTable;

        /// <summary>
        /// The location/size of the import address directory
        /// </summary>
        public PeDirectoryEntry ImportAddressTable;

        /// <summary>
        /// The location/size of the import address directory
        /// </summary>
        public PeDirectoryEntry DelayImportTable;

        /// <summary>
        /// The location/size of the clr cor header
        /// </summary>
        public PeDirectoryEntry CorHeader;
        
        PeDirectoryEntry Reserved;
    }
}
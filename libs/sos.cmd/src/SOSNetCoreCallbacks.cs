// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace SOS
{
    using System;
    using System.Runtime.InteropServices;

    using static SOSCallbackDelegates;
    using static SymbolReader;

    public readonly struct SOSCallbackDelegates
    {
        public delegate bool InitializeSymbolStore(bool logging, bool msdl, bool symweb, string tempDirectory,
            string symbolServerPath, string authToken, int timeoutInMintues, string symbolCachePath,
            string symbolDirectoryPath, string windowsSymbolPath);

        public delegate void DisplaySymbolStore(WriteLine writeLine);

        public delegate void DisableSymbolStore();

        public delegate void LoadNativeSymbols(SymbolFileCallback callback, IntPtr parameter, RuntimeConfiguration config,
            string moduleFilePath, ulong address, int size, ReadMemoryDelegate readMemory);

        public delegate void LoadNativeSymbolsFromIndex(SymbolFileCallback callback, IntPtr parameter, RuntimeConfiguration config,
            string moduleFilePath, bool specialKeys, int moduleIndexSize, IntPtr moduleIndex);

        public delegate IntPtr LoadSymbolsForModule(string assemblyPath, bool isFileLayout, ulong loadedPeAddress, int loadedPeSize,
            ulong inMemoryPdbAddress, int inMemoryPdbSize, ReadMemoryDelegate readMemory);

        public delegate void Dispose(IntPtr symbolReaderHandle);

        public delegate bool ResolveSequencePoint(IntPtr symbolReaderHandle, string filePath, int lineNumber, out int methodToken, out int ilOffset);

        public delegate bool GetLineByILOffset(IntPtr symbolReaderHandle, int methodToken, long ilOffset, out int lineNumber, out IntPtr fileName);

        public delegate bool GetLocalVariableName(IntPtr symbolReaderHandle, int methodToken, int localIndex, out IntPtr localVarName);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        public delegate ulong GetExpression([In, MarshalAs(UnmanagedType.LPStr)] string expression);

        public delegate int GetMetadataLocator(
            [MarshalAs(UnmanagedType.LPWStr)] string imagePath,
            uint imageTimestamp,
            uint imageSize,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 16)] byte[] mvid,
            uint mdRva,
            uint flags,
            uint bufferSize,
            IntPtr buffer,
            IntPtr dataSize);

        public delegate int GetICorDebugMetadataLocator([MarshalAs(UnmanagedType.LPWStr)] string imagePath,
            uint imageTimestamp, uint imageSize, uint pathBufferSize, IntPtr pPathBufferSize, IntPtr pPathBuffer);
    }

    /// <summary>
    /// Symbol service callback table
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SOSNetCoreCallbacks
    {
        public static SOSNetCoreCallbacks create() => new SOSNetCoreCallbacks {
            InitializeSymbolStoreDelegate = SymbolReader.InitializeSymbolStore,
            DisplaySymbolStoreDelegate = SymbolReader.DisplaySymbolStore,
            DisableSymbolStoreDelegate = SymbolReader.DisableSymbolStore,
            LoadNativeSymbolsDelegate = SymbolReader.LoadNativeSymbols,
            LoadNativeSymbolsFromIndexDelegate = SymbolReader.LoadNativeSymbolsFromIndex,
            LoadSymbolsForModuleDelegate = SymbolReader.LoadSymbolsForModule,
            DisposeDelegate = SymbolReader.Dispose,
            ResolveSequencePointDelegate = SymbolReader.ResolveSequencePoint,
            GetLineByILOffsetDelegate = SymbolReader.GetLineByILOffset,
            GetLocalVariableNameDelegate = SymbolReader.GetLocalVariableName,
            GetMetadataLocatorDelegate = MetadataHelper.GetMetadataLocator,
            GetExpressionDelegate = SymbolReader.GetExpression,
            GetICorDebugMetadataLocatorDelegate = MetadataHelper.GetICorDebugMetadataLocator
        };

        public InitializeSymbolStore InitializeSymbolStoreDelegate;

        public DisplaySymbolStore DisplaySymbolStoreDelegate;

        public DisableSymbolStore DisableSymbolStoreDelegate;

        public LoadNativeSymbols LoadNativeSymbolsDelegate;

        public LoadNativeSymbolsFromIndex LoadNativeSymbolsFromIndexDelegate;

        public LoadSymbolsForModule LoadSymbolsForModuleDelegate;

        public Dispose DisposeDelegate;

        public ResolveSequencePoint ResolveSequencePointDelegate;

        public GetLineByILOffset GetLineByILOffsetDelegate;

        public GetLocalVariableName GetLocalVariableNameDelegate;

        public GetMetadataLocator GetMetadataLocatorDelegate;

        public GetExpression GetExpressionDelegate;

        public GetICorDebugMetadataLocator GetICorDebugMetadataLocatorDelegate;
    }
}
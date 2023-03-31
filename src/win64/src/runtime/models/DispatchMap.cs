// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Internal.Runtime
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DispatchMap
    {
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct DispatchMapEntry
        {
            public ushort _usInterfaceIndex;

            public ushort _usInterfaceMethodSlot;

            public ushort _usImplMethodSlot;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct StaticDispatchMapEntry
        {
            // Do not put any other fields before this one. We need StaticDispatchMapEntry* be castable to DispatchMapEntry*.
            public DispatchMapEntry _entry;

            public ushort _usContextMapSource;
        }

        ushort _standardEntryCount; // Implementations on the class
        
        ushort _defaultEntryCount; // Default implementations
        
        ushort _standardStaticEntryCount; // Implementations on the class (static virtuals)
        
        ushort _defaultStaticEntryCount; // Default implementations (static virtuals)
        
        DispatchMapEntry _dispatchMap; // at least one entry if any interfaces defined

        public uint NumStandardEntries
        {
            get
            {
                return _standardEntryCount;
            }
            set
            {
                _standardEntryCount = checked((ushort)value);
            }
        }

        public uint NumDefaultEntries
        {
            get
            {
                return _defaultEntryCount;
            }
            set
            {
                _defaultEntryCount = checked((ushort)value);
            }
        }

        public uint NumStandardStaticEntries
        {
            get
            {
                return _standardStaticEntryCount;
            }
            set
            {
                _standardStaticEntryCount = checked((ushort)value);
            }
        }

        public uint NumDefaultStaticEntries
        {
            get
            {
                return _defaultStaticEntryCount;
            }
            set
            {
                _defaultStaticEntryCount = checked((ushort)value);
            }
        }

        public int Size
        {
            get
            {
                return sizeof(ushort) + sizeof(ushort) + sizeof(ushort) + sizeof(ushort)
                    + sizeof(DispatchMapEntry) * ((int)_standardEntryCount + (int)_defaultEntryCount)
                    + sizeof(StaticDispatchMapEntry) * ((int)_standardStaticEntryCount + (int)_defaultStaticEntryCount);
            }
        }

        public DispatchMapEntry* GetEntry(int index)
        {
            Debug.Assert(index <= _defaultEntryCount + _standardEntryCount);
            return (DispatchMapEntry*)Unsafe.AsPointer(ref Unsafe.Add(ref _dispatchMap, index));
        }

        public DispatchMapEntry* GetStaticEntry(int index)
        {
            Debug.Assert(index <= _defaultStaticEntryCount + _standardStaticEntryCount);
            return (DispatchMapEntry*)(((StaticDispatchMapEntry*)Unsafe.AsPointer(ref Unsafe.Add(ref _dispatchMap, _standardEntryCount + _defaultEntryCount))) + index);
        }
    }
}
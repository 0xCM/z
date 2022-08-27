//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/microsoft/perfview
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Text;

    using Windows;

    /// <summary>
    /// A MemoryNode represents a set of memory regions in a process.   MemoryNodes can have children and thus
    /// form trees.   Node also have names,
    /// </summary>
    public class MemoryNode
    {
        const string RootName = "[ROOT]";

        public string Name;

        public List<MemoryNode> Children;

        public MemoryNode Parent;

        MEMORY_BASIC_INFORMATION BasicInfo;

        public ulong End
            => Address + Size;

        public ulong Address
            => BasicInfo.BaseAddress;

        public ulong AllocAddress
            => BasicInfo.AllocationBase;

        public ulong Size
            => BasicInfo.RegionSize;

        public PageProtection Protection
            => BasicInfo.Protect;

        public MemState MemState
            => BasicInfo.State;

        public MemType MemType
            => BasicInfo.Type;

        public static MemoryNode snapshot()
            => snapshot(Process.GetCurrentProcess().Id);

        /// <summary>
        /// This is the main entry point into the MemoryNode class.  Basically giving a process ID return
        /// a MemoryNode that represents the roll-up of all memory in the process.
        /// </summary>
        public static unsafe MemoryNode snapshot(int processID)
        {
            var root = Root();
            var process = Process.GetProcessById(processID);
            var name = new StringBuilder(260);
            const ulong MaxAddress = long.MaxValue;
            ulong address = 0;
            var liberated = new List<IntPtr>();
            do
            {
                var child = new MemoryNode();
                var result = NativeMethods.VirtualQueryEx(process.Handle, (IntPtr)address, out child.BasicInfo, (uint)Marshal.SizeOf(child.BasicInfo));
                if (result == 0)
                    break;

                address = child.BasicInfo.BaseAddress + child.BasicInfo.RegionSize;

                if(NativeMethods.liberate(process.Handle, (IntPtr)address, child.BasicInfo.RegionSize))
                    liberated.Add((IntPtr)address);

                if(child.BasicInfo.Type == MemType.Image || child.BasicInfo.Type == MemType.Mapped)
                {
                    name.Clear();
                    var ret = NativeMethods.GetMappedFileName(process.Handle, (IntPtr)address, name, name.Capacity);
                    if (ret != 0)
                        child.Name = name.ToString();
                    else
                        Debug.WriteLine("Error, GetMappedFileName failed.");
                }
                root.Insert(child);
            } while (address <= MaxAddress);

            GC.KeepAlive(process);

            return root;
        }

        bool IsRoot => Name == RootName;

        public override string ToString()
        {
            var sw = new StringWriter();
            ToCsv(sw);
            return sw.ToString();
        }

        public MemoryRangeInfo[] Describe()
        {
            var dst = new List<MemoryRangeInfo>();
            Describe(dst);
            return dst.ToArray();
        }

        void Describe(List<MemoryRangeInfo> dst)
        {
            if(!IsRoot)
            {
                if(MemType != 0 && Protection !=0)
                    dst.Add(new MemoryRangeInfo{
                        StartAddress = Address,
                        EndAddress = Address+Size -1,
                        Size = Size,
                        Type = MemType,
                        Protection = Protection,
                        State = MemState,
                        Owner = Name
                    });
            }

            if(Children != null)
            {
                foreach (var child in Children)
                    child.Describe(dst);
            }
        }

        public void ToCsv(TextWriter writer)
        {
            const string Header = "StartAddress | EndAddress | Size | Type | Protection | State | Entity";
            const string Format= "{0,-16:x} | {1,-16:x} | {2,-8:x} | {3,-16} | {4,-24} | {5,-16} | {6}";
            if(IsRoot)
                writer.WriteLine(Header);

            writer.WriteLine(string.Format(Format,  Address, Address+Size -1, Size, MemType,  Protection, MemState, Name));
            if (Children != null)
            {
                foreach (var child in Children)
                    child.ToCsv(writer);
            }
        }

        MemoryNode() { }

        void Insert(MemoryNode newNode)
        {
            Debug.Assert(Address <= newNode.Address && newNode.End <= End);
            if (Children == null)
            {
                Children = new List<MemoryNode>();
            }

            // Search backwards for efficiency.
            for (int i = Children.Count; 0 < i;)
            {
                var child = Children[--i];
                if (child.Address <= newNode.Address && newNode.End <= child.End)
                {
                    child.Insert(newNode);
                    return;
                }
            }
            Children.Add(newNode);
            newNode.Parent = this;
        }

        static MemoryNode Root()
        {
            var ret = new MemoryNode();
            ret.BasicInfo.RegionSize = (ulong)unchecked(new IntPtr((long)ulong.MaxValue));
            ret.Name = "[ROOT]";
            return ret;
        }

        class NativeMethods
        {
            /// <summary>
            /// Enables an executable memory segment
            /// </summary>
            /// <param name="pMem">The leading cell pointer</param>
            /// <param name="length">The length of the segment, in bytes</param>
            public static bool liberate(IntPtr pProc, IntPtr pMem, ulong length)
            {
                if (!VirtualProtectEx(pProc, pMem, (UIntPtr)length, PageProtection.ExecuteReadWrite, out PageProtection _))
                    return false;
                else
                    return true;
            }

            /// <summary>
            /// Enables an executable memory segment
            /// </summary>
            /// <param name="pMem">The leading cell pointer</param>
            /// <param name="length">The length of the segment, in bytes</param>
            public static bool liberate(IntPtr pProc, IntPtr pMem, ulong length, out PageProtection prior)
            {
                if (!VirtualProtectEx(pProc, pMem, (UIntPtr)length, PageProtection.ExecuteReadWrite, out prior))
                    return false;
                else
                    return true;
            }

            [DllImport("psapi.dll", SetLastError = true), Free]
            public static extern unsafe bool QueryWorkingSet(IntPtr hProcess, WORKING_SET_INFORMATION* workingSetInfo, int workingSetInfoSize);

            [DllImport("psapi.dll", SetLastError = true), Free]
            public static extern int GetMappedFileName(IntPtr hProcess, IntPtr address, StringBuilder lpFileName, int nSize);

            [DllImport("kernel32.dll", SetLastError = true), Free]
            public static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, uint dwLength);

            [DllImport("kernel32.dll"), Free]
            public static extern bool VirtualProtectEx(IntPtr hProc, IntPtr pCode, UIntPtr codelen, PageProtection flags, out PageProtection oldFlags);
        }
   }
}
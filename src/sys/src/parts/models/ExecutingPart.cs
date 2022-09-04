//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics;

    public class ExecutingPart
    {
        public static ref readonly Assembly Assembly => ref _Component;

        //public static ref readonly PartId Id => ref _Id;

        public static ref readonly PartName Name => ref _Name;

        public static Process Process => Process.GetCurrentProcess();

        static PartId _Id;

        static Assembly _Component;

        static PartName _Name;

        static ExecutingPart()
        {
            _Component = Assembly.GetEntryAssembly();
            _Id = PartIdAttribute.id(_Component);
            _Name = PartIdAttribute.name(_Component);
        }
    }
}
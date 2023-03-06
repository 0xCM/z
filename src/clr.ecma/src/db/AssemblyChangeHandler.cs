//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class AssemblyChangeReceiver : Channeled<AssemblyChangeReceiver>, IFileChangeReceiver
    {
        public void Deposit(FileChangeEvent src)
        {
            
        }
    }
}
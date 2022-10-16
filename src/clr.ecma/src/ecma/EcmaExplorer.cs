//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class EcmaExplorer : IDisposable
    {
        public static EcmaExplorer create(EcmaFile src)
            => new EcmaExplorer(src);

        readonly EcmaFile File;
        
        public EcmaExplorer(EcmaFile src)
        {
            File = src;
            
        }

        void IDisposable.Dispose()
        {
            File.Dispose();
        }
    }
}
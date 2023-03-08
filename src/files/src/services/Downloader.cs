//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Net;
    
    #pragma warning disable SYSLIB0014

    public class Downloader : Channeled<Downloader>
    {
        public Task<ExecToken> DownloadFile(Uri src, FilePath dst)
        {
            ExecToken Run()
            {
                var running = Channel.Running($"Downloading {src} to {dst}");
                dst.CreateParentIfMissing();
                var request = HttpWebRequest.Create(src);
                var response = request.GetResponse();
                using (var writer = dst.BinaryWriter())
                {
                    var buffer = new byte[Pow2.T14];
                    var remainder = response.ContentLength;
                    while (remainder > 0)
                    {
                        var written = response.GetResponseStream().Read(buffer, 0, buffer.Length);
                        if (written == 0)
                            break;
                        writer.Write(buffer, 0, written);
                        remainder -= written;
                    }
                }
                return Channel.Ran(running, $"Downloaded {src} to {dst}");
            }
            return sys.start(Run);
        }    
    }
}
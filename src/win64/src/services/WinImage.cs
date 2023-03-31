//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
     [Free, ApiHost]
     public partial class WinImage
     {
          static ConcurrentDictionary<string,INativeImage> Cache = new();

          [Op]
          public static Kernel32 kernel32()
               => (Kernel32)Cache.GetOrAdd(nameof(Kernel32), _ => (Kernel32)Kernel32Image.load());

          [Op]
          public static Func<FilePath,ImageHandle> loader()
               => kernel32().LoadLibrary;

          [Op]
          public static NtDll ntdll()
               => (NtDll)Cache.GetOrAdd(nameof(NtDll), _ => NtDll.load());

          [Op]
          public static PsApi psapi()
               => (PsApi)Cache.GetOrAdd(nameof(PsApi), _ => PsApi.load());
     }
}

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

          public static T load<T>()
               where T : NativeImage<T>, new()
                    => NativeImage<T>.load(SystemDll<T>());
          [Op]
          public static Kernel32 kernel32()
               => (Kernel32)Cache.GetOrAdd(nameof(Kernel32), _ => Kernel32.load());

          [Op]
          public static NtDll ntdll()
               => (NtDll)Cache.GetOrAdd(nameof(NtDll), _ => NtDll.load());

          [Op]
          public static PsApi psapi()
               => (PsApi)Cache.GetOrAdd(nameof(PsApi), _ => PsApi.load());

          static FilePath SystemDll<T>()
               where T : INativeImage
                    => FS.dir("C:/windows/system32") + FS.file(typeof(T).Name,FileKind.Dll);

     }
}

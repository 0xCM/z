//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class EnvDb : IEnvDb<EnvDb>
    {
        public static IEnvDb Service => Instance;

        public EnvDb()
        {

        }

        static EnvDb()
        {
            Root = AppSettings.Default.EnvDb();
            Instance = new();
        }

        static readonly DbArchive Root;

        static readonly EnvDb Instance;
    }
}
// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using static Settings;
//     using static EnvNames;

//     public sealed record class AppEnv : AppEnv<AppEnv,FolderPath>
//     {
//         public static ref readonly AppEnv Cfg => ref Instance;
        
//         readonly AppSettings _Settings;

//         public AppEnv()
//         {
//             _Settings = AppSettings.Default;
//         }

//         public DbArchive DbRoot() 
//             => folder(_Settings.Setting(SettingNames.DbRoot));


//         static AppEnv Instance = new();        
//     }
// }
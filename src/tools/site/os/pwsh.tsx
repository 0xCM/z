import * as Core from "../core"

export type Name = 'pwsh'
export type Tool = Core.Tool<Name>

export function name() : Name {
    return 'pwsh'
}

export function tool(name:Name = 'pwsh') : Tool {
    return Core.tool(name)
}

export const Refs = [
    "https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_pwsh?view=powershell-7.2"
]

export const SyntaxExpr = 
`pwsh[.exe]
[[-File] <filePath> [args]]
[-Command { - | <script-block> [-args <arg-array>]
              | <string> [<CommandParameters>] } ]
[-ConfigurationName <string>]
[-CustomPipeName <string>]
[-EncodedCommand <Base64EncodedCommand>]
[-ExecutionPolicy <ExecutionPolicy>]
[-InputFormat {Text | XML}]
[-Interactive]
[-Login]
[-MTA]
[-NoExit]
[-NoLogo]
[-NonInteractive]
[-NoProfile]
[-OutputFormat {Text | XML}]
[-SettingsFile <SettingsFilePath>]
[-SSHServerMode]
[-STA]
[-Version]
[-WindowStyle <style>]
[-WorkingDirectory <directoryPath>]

pwsh[.exe] -h | -Help | -? | /?
`
$WsDir="$env:EnvRoot\dev\z0"
$WsPath="$WsDir\z0.code-workspace"
Start-Process $env:vscode -ArgumentList $WsPath -WorkingDirectory $WsDir

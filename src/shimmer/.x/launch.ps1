$WsId="tools.shell"
$WsKind="code-workspace"
$WsDir="$Env:Z0\libs\$WsId"
$WsPath="$WsDir\$WsId.$WsKind"
Start-Process $env:vscode -ArgumentList $WsPath -WorkingDirectory $WsDir
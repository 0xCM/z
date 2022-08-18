$WsRoot="."
$Target="$WsRoot"
Start-Process -UseNewEnvironment -FilePath $env:vscode -ArgumentList $Target -WorkingDirectory $WsRoot

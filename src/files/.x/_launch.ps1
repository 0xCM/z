$ProjectId="files"
$Area="libs"
$ProjectRoot="$env:SlnRoot\$Area\$ProjectId"
Start-Process -FilePath $env:vscode -ArgumentList "$ProjectRoot\$ProjectId.code-workspace" -WorkingDirectory $ProjectRoot

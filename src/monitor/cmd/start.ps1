$ToolName="workers"
$ToolHome="F:\Drives\Y\tools\z0\$ToolName"
$ExePath="$ToolHome\$ToolName.exe"
$ToolArgs="d:/views/sdks"
Start-Process -UseNewEnvironment -FilePath $ExePath -WorkingDirectory $ToolHome -ArgumentList $ToolArgs

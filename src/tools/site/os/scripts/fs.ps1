$Location = Get-Location
$TableId="vhd-detail"
$Dst="$Location\data\$TableId.psv"
$Script="$Location\scripts\$TableId.ps1"
Invoke-Expression -Command $Script 1> $Dst 2>nul

$TableId="vhd-image"
$Dst="$Location\data\$TableId.psv"
$Script="$Location\scripts\$TableId.ps1"
Invoke-Expression -Command $Script 1> $Dst 2>nul






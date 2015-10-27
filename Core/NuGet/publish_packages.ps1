 param (
    [Parameter(Mandatory=$true)][string]$version,
	[bool]$skipUpload=$false
 )

$cache_dir = "publish_cache"

if( (Test-Path -Path $cache_dir)) {
	Remove-Item -Recurse -Force $cache_dir
}

New-Item $cache_dir -type directory

$nuspecs = Get-Childitem "." -Recurse | where {$_.extension -eq ".nuspec"}
foreach ($spec_path in $nuspecs) {
	nuget pack -OutputDirectory $cache_dir -Version $version $spec_path.FullName
}

if ($skipUpload){
	Exit
}

$packages = Get-Childitem $cache_dir | where {$_.extension -eq ".nupkg"}
foreach ($package in $packages) {
	nuget push $package.FullName
}

Write-Host "Publish completed!"

# $file = "release/wwwroot/index.html"
$file = "src/WebApp/wwwroot/index.html"

if (-not (Test-Path $file)) {
    Write-Error "Could not find: $($file)"
}
else {
    $content = (Get-Content $file)
    $newContent = $content -Replace '<base href="/" />', '<base href="/BlazorWasm-POC/" />'
    $newContent | Set-Content $file
}
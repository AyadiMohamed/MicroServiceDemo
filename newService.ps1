$serviceNameInput = $args[0]

# Find the solution file
$solutionFile = Get-ChildItem -Filter *.sln | Select-Object -First 1
if (-not $solutionFile) {
    Write-Host "Solution file (*.sln) not found in the current directory."
    exit 1
}

# Extract the solution name
$solutionName = [System.IO.Path]::GetFileNameWithoutExtension($solutionFile.Name)

# Set service name
$pascalCase = $serviceNameInput -split "_|%20" | ForEach-Object { $_.Substring(0,1).ToUpper() + $_.Substring(1) }
$service = $pascalCase -join "" + "Service"
$folder = $serviceNameInput.ToLower()

# Create the service
abp new "$solutionName.$service" -t module --no-ui -o services\$folder 

# Remove unnecessary files
Remove-Item -Recurse -Force (Get-ChildItem -Path "services\$folder" -Recurse -Include *.AuthServer)
Remove-Item -Recurse -Force (Get-ChildItem -Path "services\$folder" -Recurse -Include *.MongoDB.Tests)
Remove-Item -Recurse -Force (Get-ChildItem -Path "services\$folder" -Recurse -Include *.MongoDB)
Remove-Item -Recurse -Force (Get-ChildItem -Path "services\$folder" -Recurse -Include *.Host.Shared)
Remove-Item -Recurse -Force (Get-ChildItem -Path "services\$folder" -Recurse -Include *.Installer)

# Add project to the solution
dotnet sln ".\$solutionName.sln" add (Get-ChildItem -Path "services\$folder" -Recurse -Include *.csproj)

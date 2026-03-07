param(
    [Parameter(Mandatory = $true)]
    [int]$EpicNumber,

    [Parameter(Mandatory = $true)]
    [string]$EpicName,

    [Parameter(Mandatory = $true)]
    [string[]]$Stories
)

function Format-TwoDigits {
    param([int]$Number)
    return "{0:D2}" -f $Number
}

function Get-SafeName {
    param([string]$Name)
    return ($Name -replace '[^A-Za-z0-9]', '')
}

$epicNumberFormatted = Format-TwoDigits $EpicNumber
$safeEpicName = Get-SafeName $EpicName

$epicFolder = "Docs/Backlog/Epic$epicNumberFormatted"
$epicFileName = "Epic${epicNumberFormatted}_${safeEpicName}.md"
$epicFilePath = Join-Path $epicFolder $epicFileName

$issuesScriptPath = "Scripts/gh/create-issues.ps1"

# Create folder
New-Item -ItemType Directory -Path $epicFolder -Force | Out-Null

# Create epic file if missing
if (-not (Test-Path $epicFilePath)) {
    New-Item -ItemType File -Path $epicFilePath | Out-Null
}

# Ensure issue script exists
if (-not (Test-Path $issuesScriptPath)) {
    New-Item -ItemType File -Path $issuesScriptPath | Out-Null
}

# Build command block
$commandLines = @()
$commandLines += ""
$commandLines += "# Epic $EpicNumber"
$commandLines += "gh issue create ``"
$commandLines += "--title ""Epic $EpicNumber $EpicName"" ``"
$commandLines += "--label epic,gameplay ``"
$commandLines += "--body-file $epicFilePath"
$commandLines += ""

# Create story files and commands
for ($i = 0; $i -lt $Stories.Count; $i++) {
    $storyNumber = $i + 1
    $storyNumberFormatted = Format-TwoDigits $storyNumber
    $storyName = $Stories[$i]
    $safeStoryName = Get-SafeName $storyName

    $storyFileName = "Story${storyNumberFormatted}_${safeStoryName}.md"
    $storyFilePath = Join-Path $epicFolder $storyFileName

    if (-not (Test-Path $storyFilePath)) {
        New-Item -ItemType File -Path $storyFilePath | Out-Null
    }

    $storyLabel = "story,gameplay"

    $commandLines += "# Story $EpicNumber.$storyNumber"
    $commandLines += "gh issue create ``"
    $commandLines += "--title ""Story $EpicNumber.$storyNumber $storyName"" ``"
    $commandLines += "--label $storyLabel ``"
    $commandLines += "--body-file $storyFilePath"
    $commandLines += ""
}

# Prevent duplicate append by checking for Epic header
$existingContent = Get-Content $issuesScriptPath -Raw
$epicHeader = "# Epic $EpicNumber"

if ($existingContent -notmatch [regex]::Escape($epicHeader)) {
    Set-Content -Path $issuesScriptPath -Value ($commandLines -join [Environment]::NewLine)
    Write-Host "Epic structure created and issue commands appended."
} else {
    Write-Host "Epic structure created. Issue commands for Epic $EpicNumber already exist, so nothing was appended."
}

Write-Host "Folder: $epicFolder"
Write-Host "Epic file: $epicFileName"
Write-Host "Story files:"
for ($i = 0; $i -lt $Stories.Count; $i++) {
    $storyNumberFormatted = Format-TwoDigits ($i + 1)
    $safeStoryName = Get-SafeName $Stories[$i]
    Write-Host "  Story${storyNumberFormatted}_${safeStoryName}.md"
}
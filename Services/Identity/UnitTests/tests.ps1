$FOLDER = 'TestResults'
if(Test-Path -Path $FOLDER) {
    Remove-Item TestResults -Recurse
}
dotnet test /p:CollectCoverage=true `
/p:CoverletOutputFormat=lcov `
/p:CoverletOutput=./lcov.info . `
--logger html -r TestResults
$TEST_RESULT_FILES = Get-ChildItem -Path $FOLDER
$RESULT = $TEST_RESULT_FILES[0].FullName
Invoke-Item $RESULT

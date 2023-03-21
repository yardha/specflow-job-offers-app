cd Drivers

start msedgedriver.exe
timeout /T 5
cd ..
dotnet test
cd bin/Debug/net6.0
livingdoc test-assembly "CodeMonkeySpecflowSelenium.dll" -t "TestExecution.json" -o "../../../Report/Report.html"
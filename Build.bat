for /f "usebackq tokens=*" %%i in (`"%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere.exe" -latest -products * -requires Microsoft.Component.MSBuild -property installationPath`) do (  set VSDir=%%i)

"%VSDir%\MSBuild\15.0\Bin\MSBuild.exe" ServerBackend/ServerBackend.sln /p:Configuration=Release /t:Restore;Build
xcopy ServerBackend\BusinessLogic\bin\Release\net46\*.dll Game\Assets\Plugins\
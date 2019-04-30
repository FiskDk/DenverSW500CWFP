@echo off
set wsp=%cd%\Workspace
set mypath=%~dp0
set rootpath=%cd%
set apkpath=%wsp%\unsigned.apk
set keystorepath=%wsp%\com.denver.customwatchfacepatcher.keystore
set /p javapath=<java.path
set alias=com.denver.customwatchfacepatcher

set keypath=%rootpath%\Workspace%alias%.keystore
for /f "delims=" %%x in (java.path) do set javapath=%%x
cd %javapath%\bin
echo for the password input "patchmenow"
jarsigner -verbose -sigalg SHA1withRSA -digestalg SHA1 -keystore %keystorepath% %apkpath% %alias%
cd %rootpath%
echo heyy>done
exit
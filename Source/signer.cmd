@echo off
set wsp=%cd%\Workspace
set mypath=%~dp0
set rootpath=%cd%
set apkpath=%wsp%\cwfp-signed.apk
set keystorepath=%wsp%\signmeup.keystore
set /p javapath=<java.path
set alias=cwfp

set keypath=%rootpath%\Workspace%alias%.keystore
for /f "delims=" %%x in (java.path) do set javapath=%%x
cd %javapath%\bin
cd %rootpath%\android sdk\build-tools\28.0.3
echo for the password input "patchmenow" and press enter
apksigner sign --ks %keystorepath% --ks-key-alias %alias% %apkpath%
echo heyy>done
exit

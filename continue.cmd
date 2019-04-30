@echo off
delete done
set wsp=%cd%\Workspace
set mypath=%~dp0
set rootpath=%cd%
set apkpath=%wsp%\unsigned.apk
set alias=com.denver.customwatchfacepatcher

zipalign -v 4 %apkpath% %wsp%\%alias%-signed.apk
echo Done! you may now close this program, and install %alias%-signed.apk to your android device.
echo The %alias%-signed.apk file is located im %wsp%\%alias%-signed.apk
echo Thank you for using my product :p
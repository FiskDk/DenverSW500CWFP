@echo off
set img1=%1
set img2=%2
set img3=%3
set img4=%4
set img5=%5
if [%1]==[] set img1=0
if [%2]==[] set img2=0
if [%3]==[] set img3=0
if [%4]==[] set img4=0
if [%5]==[] set img5=0

if not [%img1%]==["0"] goto c2
echo No arguments specified, ending.
pause
exit
:c2
if not [%img2%]==["0"] goto c3
echo No arguments specified, ending.
pause
exit
:c3
if not [%img3%]==["0"] goto c4
echo No arguments specified, ending.
pause
:c4
if not [%img4%]==["0"] goto c5
echo No arguments specified, ending.
pause
exit
:c5
if not [%img5%]==["0"] goto c6
echo No arguments specified, ending.
pause
exit
:c6
if %img1%==0 echo img1 error & goto end
if %img2%==0 echo img2 error & goto end
if %img3%==0 echo img3 error & goto end
if %img4%==0 echo img4 error & goto end
if %img5%==0 echo img5 error & goto end
echo %img1% OK!
echo %img2% OK!
echo %img3% OK!
echo %img4% OK!
echo %img5% OK!
goto allok
:end
end
exit
quit
exit
:allok
set wsp=%cd%\Workspace
set wfp=Workspace\Fresh\assets\watchface\
wget --output-document=Workspace\fresh.apk http://download1590.mediafire.com/k9kfnbuueerg/jebaw2ckkrhrxg8/Denver+SW500.apk
7za x Workspace\fresh.apk -oWorkspace\Fresh
copy /Y %img1% Workspace\Fresh\assets\watchface\clockrendering0.png
copy /Y %img2% %wfp%colockbackground0.png
copy /Y %img3% %wfp%colockhour0.png
copy /Y %img4% %wfp%colockminute0.png
copy /Y %img5% %wfp%colocksecond0.png
echo Done, Patching up...
7za.exe a Workspace\unsigned.zip .\Workspace\Fresh\*
ren Workspace\unsigned.zip unsigned.apk
set mypath=%~dp0
set rootpath=%cd%
set apkpath=%wsp%\unsigned.apk
set keystorepath=%wsp%\com.denver.customwatchfacepatcher.keystore
set /p javapath=<java.path
set alias=com.denver.customwatchfacepatcher

set keypath=%rootpath%\Workspace%alias%.keystore
cd %rootpath%
start signer.cmd /WAIT
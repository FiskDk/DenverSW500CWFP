@echo off
:init
setlocal DisableDelayedExpansion
set "batchPath=%~0"
for %%k in (%0) do set batchName=%%~nk
set "vbsGetPrivileges=%temp%\OEgetPriv_%batchName%.vbs"
setlocal EnableDelayedExpansion

:checkPrivileges
NET FILE 1>NUL 2>NUL
if '%errorlevel%' == '0' ( goto gotPrivileges ) else ( goto getPrivileges )

:getPrivileges
if '%1'=='ELEV' (echo ELEV & shift /1 & goto gotPrivileges)
ECHO.
ECHO **************************************
ECHO Invoking UAC for Privilege Escalation
ECHO **************************************

ECHO Set UAC = CreateObject^("Shell.Application"^) > "%vbsGetPrivileges%"
ECHO args = "ELEV " >> "%vbsGetPrivileges%"
ECHO For Each strArg in WScript.Arguments >> "%vbsGetPrivileges%"
ECHO args = args ^& strArg ^& " "  >> "%vbsGetPrivileges%"
ECHO Next >> "%vbsGetPrivileges%"
ECHO UAC.ShellExecute "!batchPath!", args, "", "runas", 1 >> "%vbsGetPrivileges%"
"%SystemRoot%\System32\WScript.exe" "%vbsGetPrivileges%" %*
exit /B

:gotPrivileges
setlocal & pushd .
cd /d %~dp0
if '%1'=='ELEV' (del "%vbsGetPrivileges%" 1>nul 2>nul  &  shift /1)

::::::::::::::::::::::::::::
::START
::::::::::::::::::::::::::::
set wsp=C:\Users\tsjpl\Documents\Denver SW500 Custom Watchface Patcher\Workspace
set wfp=Workspace\Fresh\assets\watchface\
wget --output-document=Workspace\fresh.apk http://ge.tt/48DL4mv2
7za x Workspace\fresh.apk -oWorkspace\Fresh
echo Please paste path to your clockrendering.png (150 x 150) 32bit ( Or leave blank for default)
set /p cr=
IF not "%cr%"=="" (
copy /Y %cr% Workspace\Fresh\assets\watchface\clockrendering0.png
) ELSE (
echo No clockrendering was specified, Setting to default.
)
echo Please paste in path to your clockbackground.png (240 x 240) 32Bit (This cannot be blank)
set /p cbg=
copy /Y %cbg% %wfp%colockbackground0.png
echo Please paste in your path to your clockhour.png (240 x 240) Or leave blank for default
set /p ch=
IF not "%ch%"=="" (
copy /Y %ch% %wfp%colockhour0.png
) ELSE (
echo No clockhour was specified, Setting to default.
)
echo Please paste in your path to your clockminute.png (240 x 240) Or leave blank for default
set /p cm=
IF not "%cm%"=="" (
copy /Y %cm% %wfp%colockminute0.png
) ELSE (
echo No clockminute was specified, Setting to default.
)
echo Please paste in your path to your clocksecond.png (240 x 240) Or leave blank for default
set /p cs=
IF not "%cs%"=="" (
copy /Y %cs% %wfp%colocksecond0.png
) ELSE (
Echo No clocksecond was specified, Setting to default.
)
echo Done, Patching up...
7za.exe a Workspace\unsigned.zip .\Workspace\Fresh\*
ren Workspace\unsigned.zip unsigned.apk
set mypath=%~dp0
set apkpath=C:\Users\tsjpl\Documents\Denver_Custom_Watchface_Patcher\Workspace\unsigned.apk
set keystorepath=C:\Users\tsjpl\Documents\Denver_Custom_Watchface_Patcher\Workspace\customwatchfacepatcher.keystore
set alias=com.denver.customwatchfacepatcher

REM !!!REPLACE THIS PATH WITH THE PATH TO YOUR JARSIGNER!!!
cd C:\Program Files (x86)\Java\jdk1.8.0_192\bin
jarsigner -verbose -sigalg SHA1withRSA -digestalg SHA1 -keystore %keystorepath% %apkpath% %alias%

REM !!!REPLACE THIS PATH WITH THE PATH TO YOUR ZIPALIGN TOOL!!!
cd C:\Users\tsjpl\AppData\Local\Android\Sdk\build-tools\28.0.3
zipalign -v 4 %apkpath% %wsp%\%alias%-signed.apk
Done. Now you just need to install the apk. or click enter to install it automaticly if you have ADB enabled on your android device.
pause
Starting ADB Instalition process...
pause




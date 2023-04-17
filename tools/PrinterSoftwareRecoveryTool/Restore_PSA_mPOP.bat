@echo off

echo PrinterSoftwareRecoveryTool [Ver 1.0.0]

PrinterSoftwareRecoveryToolConsole /r /q /mPOP

if %ERRORLEVEL%==0 set message=Success.
if %ERRORLEVEL%==1 set message=Invalid arguments.
if %ERRORLEVEL%==2 set message=Driver package is not installed.
if %ERRORLEVEL%==3 set message=Restoring software is not needed.
if %ERRORLEVEL%==4 set message=Driver package is too old. Please update driver package by installer.(http://sp-support.star-m.jp/Default.aspx)
if %ERRORLEVEL%==5 set message=Restoring software is failed. Please try again.
if %ERRORLEVEL%==6 set message=Unknown error. Please try again.

echo %message%
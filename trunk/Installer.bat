CLS
@ECHO OFF

:: Set variables
SET batchPath=%~dp0

ECHO. Starting up...
IF NOT EXIST %TEMP%\RSBuild\NUL MD %TEMP%\RSBuild
CD %TEMP%\RSBuild
XCOPY "%batchPath%." /E /R /Y /Q /I
CLS
ECHO.

RSBUild

CD ..
RD /S /Q %TEMP%\RSBuild

ECHO.
ECHO.
SET /P e=Hit enter key to exit...
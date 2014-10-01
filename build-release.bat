@echo off

call python build-changeversion.py %1
if errorlevel 1 goto failed

call build.bat debug
if errorlevel 1 goto failed

git commit -am "Changing version to %1"
if errorlevel 1 goto failed

:failed
echo Failed release build
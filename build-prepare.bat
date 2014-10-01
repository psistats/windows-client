@echo off
call python build-removedev.py
if errorlevel 1 goto failed

git commit -am "Removing dev from version numbers"
call build.bat debug
if errorlevel 1 goto failed

call build.bat release
if errorlevel 1 goto failed

:failed
echo "[ERROR] Failed"
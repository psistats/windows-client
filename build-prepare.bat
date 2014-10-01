@echo off
call python build-removedev.py
if errorlevel 1 goto failed

git commit -am "Removing dev from version numbers"
if errorlevel 1 goto failed

git push
if errorlevel 1 goto failed

call build.bat debug
if errorlevel 1 goto failed

call build.bat release
if errorlevel 1 goto failed

goto:eof

:failed
echo "[ERROR] Failed"
goto:eof
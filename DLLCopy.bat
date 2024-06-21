echo %1
echo %2
echo %3

set filePath1=%1%2%3.dll
echo 01.%filePath1%

cd ../
set filePath2=%cd%\%3.dll
echo 02.%filePath2%

copy /y %filePath1% %filePath2%
# Vacscan.Net.MAUI

## Run on MacOS

From the terminal
```terminal
dotnet build Vacscan.Net.MAUI -t:Run -f net6.0-android

dotnet build Vacscan.Net.MAUI -t:Run -f net6.0-ios
dotnet build Vacscan.Net.MAUI -t:Run -f net6.0-ios /p:_DeviceName=:v2:udid=<DEVICE_UDID>

dotnet build Vacscan.Net.MAUI -t:Run -f net6.0-maccatalyst
```

## Run on Windows
1. Open in Visual Studio 2022
2. Make sure you have an android emulator created from the `Android Device Manager`. Sugested device: Pixel 3 XL / x86 / R 11.0 - API 30.
3. Start a debug session using the device you just created

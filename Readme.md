# Math Native

This is a native app closely inspired by Stomp Rocket Math <math.stomprocket.io>.
It is written in C# using Eto.Forms for GUI. It should run natively on Mac, Linux,
and Windows, using Cocoa, GTK, and WinForms, respectively.

**This is currently Alpha software and should not be expected to work flawlessly.
Please report bugs via. github issues.**

There will not be any official binary releases until this is at least in beta.

## Building

You should use Mono Develop or Visual Studio to build this project. While it is
possible to build with msbuid/xbuild it has not been tested.

## Running

On MacOS just download the app. You may be prompted to install the Mono runtime,
which is needed to run this software.

On Linux download the zip/tarball release and run the .exe with `mono`

On Windows download the zip release and run the .exe like you would any other
program.

## Known Errors

- App Doesn't start on MacOS, says it's corrupted
  - Right click the .app and open it's contents, then navigate to the actual
    binary and run that.

# StarPRNT SDK Windows Desktop C#

This package contains StarPRNT SDK for supporting to develop applications for Star printers.

## Scope

Please refer to the [StarPRNT SDK document](https://www.star-m.jp/starprntsdk-oml-windows_desktop.html) for supported OS, development environment, and supported printers.

## important

### Considerations when using mC-Label2

| Printer                             | Paper Size            | DPI                   |
| ----------------------------------- | --------------------- | --------------------- |
| mC-Label2                           | 2 inch (576 dots)     | 300dpi                |
| mC-Print2, mPOP, etc                | 2 inch (384 dots)     | 203dpi                |
| mC-Label3, mC-Print3, TSP100IV, etc | 3 inch (576 dots)     | 203dpi                |

Due to the differences in DPI above, the sample code based on a "3-inch (576 dots)" paper size will print on a 2-inch paper size in mC-Label2.

## Note

1. Please note the following points when replacing 'StarIOPort.dll' or 'StarIO.dll' included in SDK for Windows Desktop UI(Ver2.2 or earlier) to 'StarIOPort.dll' or 'StarIO.dll' included in this package.

    - If the following environment is not satisfied, can not build the application.

        |                |                           |
        |----------------|---------------------------|
        |OS              |Windows7, 8/8.1, 10        |
        |Visual Studio   |Visual Studio 2008 or later|
        |Target framework|.Net Framework 3.5 or later|

    - If using SDK for mobile printer, need to change the arguments of 'GetPort' method.

        Please refer to StarPRNT SDK Document included in this package and reset the arguments of 'GetPort' method.
        After that, please check the operation of application.

2. If mC-Sound was connected after the printer power was turned ON, melody speaker API does not work properly.

    Please turn on the printer after connecting mC-Sound to it.

3. Change the behavior of `ReleasePort` method

   Beginning from StarIO.dll V2.6.0 (StarPRNT SDK V5.11.0), the ReleasePort method behavior has been changed as shown below.

    - V2.5.0 and before:  
    In the case of calling GetPort method multiple times before calling ReleasePort method, the port is released by calling ReleasePort method the same number of times as the GetPort method was called.

    - V2.6.0 and later:  
    The port is always released when ReleasePort method is called.

## Copyright

Copyright 2017-2025 Star Micronics Co., Ltd. All rights reserved.
************************************************************
      StarPRNT SDK Ver 5.16.0 20230331
         Readme_En.txt             Star Micronics Co., Ltd.
************************************************************

    1. Overview
    2. Changes
    3. Contents
    4. Scope
    5. Notes
    6. Copyright
    7. Release History

===========================
 1. Overview
===========================

    This package contains StarPRNT SDK for supporting to develop applications for Star printers.
    Please refer to the document(documents/UsersManual.url) for details.

===========================
 2. Changes
===========================

    [StarIO]
        - Added features
            * Added mC-Label3.
        - Added new Bluetooth module information for SM-S230i, SM-T300i, SM-T300 and SM-T400i.

    [StarIOExtension]
        - Added features
            * Added mC-Label3.

===========================
 3. Contents
===========================

    StarPRNT_WindowsDesktop_SDK_V5_16_0_20230331
    |- Readme_En.txt                                // Release Notes (English)
    |- Readme_Jp.txt                                // Release Notes (Japanese)
    |- Changelog_En.txt                             // Changelog (English)
    |- Changelog_Jp.txt                             // Changelog (Japanese)
    |- SoftwareLicenseAgreement_En.pdf              // Software License Agreement (English)
    |- SoftwareLicenseAgreement_Jp.pdf              // Software License Agreement (Japanese)
    |
    +- documents
    |  +- UsersManual.url                           // Link to StarPRNT SDK document
    |
    +- software
    |  |- examples
    |  |   |- 0_StarPRNT                            // Sample program for printing and searching function  (Ver 5.16.0)
    |  |   |- 1_StarIODeviceSetting                 // Sample program for SteadyLAN settings (Ver 1.0.0)
    |  |
    |  |- libs                                      // Not strong named libraries
    |  |   |- StarIOPort_x86.dll                    // StarIOPort_x86.dll          (Ver 2.9.0 for 32 bit application)
    |  |   |- StarIOPort_x64.dll                    // StarIOPort_x64.dll          (Ver 2.9.0 for 64 bit application)
    |  |   |- GenerateBarcode_x86.dll               // GenerateBarcode_x86.dll     (Ver 1.0.0 for 32 bit application)
    |  |   |- GenerateBarcode_x64.dll               // GenerateBarcode_x64.dll     (Ver 1.0.0 for 64 bit application)
    |  |   |- StarIO.dll                            // StarIO.dll                  (Ver 2.9.0)
    |  |   |- StarIOExtension.dll                   // StarIOExtension.dll         (Ver 1.8.0)
    |  |   +- StarIODeviceSetting.dll               // StarIODeviceSetting.dll     (Ver 1.0.0)
    |  |
    |  +- libs_strong_named                         // Strong named libraries
    |      |- StarIOPort_x86.dll                    // StarIOPort_x86.dll          (Ver 2.9.0 for 32 bit application)
    |      |- StarIOPort_x64.dll                    // StarIOPort_x64.dll          (Ver 2.9.0 for 64 bit application)
    |      |- GenerateBarcode_x86.dll               // GenerateBarcode_x86.dll     (Ver 1.0.0 for 32 bit application)
    |      |- GenerateBarcode_x64.dll               // GenerateBarcode_x64.dll     (Ver 1.0.0 for 64 bit application)
    |      |- StarIO.dll                            // StarIO.dll                  (Ver 2.9.0)
    |      +- StarIOExtension.dll                   // StarIOExtension.dll         (Ver 1.8.0)
    |
    +- tools
        |- PrinterSoftwareRecoveryTool              // Tools for updating software for driver package (Ver 1.0.0)
        +- StarSoundConverter                       // Tools for converting sound format for melody speaker (Ver 1.0.0)

===========================
 4. Scope
===========================

    Please refer to UsersManual.url for supported OS, development environment, and supported printers.

===========================
 5. Notes
===========================

    1. Please note the following points when replacing 'StarIOPort.dll' or 'StarIO.dll' included in SDK for Windows Desktop UI(Ver2.2 or earlier)
        to 'StarIOPort.dll' or 'StarIO.dll' included in this package.

        - If the following environment is not satisfied, can not build the application.
            OS                       : Windows7, 8/8.1, 10
            Visual Studio            : Visual Studio 2008 or later
            Target framework         : .Net Framework 3.5 or later

        - If using SDK for mobile printer, need to change the arguments of 'GetPort' method.
            Please refer to StarPRNT SDK Document included in this package and
            reset the arguments of 'GetPort' method.
            After that, please check the operation of application.

    2. If mC-Sound was connected after the printer power was turned ON, melody speaker API does not work properly.
        Please turn on the printer after connecting mC-Sound to it.

    3. Change the behavior of ReleasePort method
        - Beginning from StarIO.dll V2.6.0 (StarPRNT SDK V5.11.0), the ReleasePort method behavior has been changed as shown below.
            V2.5.0 and before:
                In the case of calling GetPort method multiple times before calling ReleasePort method,
                the port is released by calling ReleasePort method the same number of times as the GetPort method was called.
            V2.6.0 and later:
                The port is always released when ReleasePort method is called.

===========================
 6. Copyright
===========================

    Copyright 2017-2022 Star Micronics Co., Ltd. All rights reserved.

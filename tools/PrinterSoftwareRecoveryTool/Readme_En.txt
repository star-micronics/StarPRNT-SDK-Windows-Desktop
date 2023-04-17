************************************************************
      Printer Software Recovery Tool Ver 1.0.0
         Readme_En.txt             Star Micronics Co., Ltd.
************************************************************

 1. Overview
 2. Scope
 3. How to use
 4. How to use console application (for developper)
 5. Notes
 6. Copyright
 7. Release History

===========================
 1. Overview
===========================

  This software is for updating software enclosed in following driver packages.

    StarPRNT Intelligence
    StarPRNT Intelligence for mPOP
    StarPRNT Intelligence for Portable
    StarPRNT Intelligence for BSC10
    StarPRNT Intelligence for BSC10BR
    StarPRNT Intelligence for TSP043

===========================
 2. Scope
===========================

  Work with these version of driver packages.

    StarPRNT Intelligencea                  Version 3.0 to 3.4
    StarPRNT Intelligence for mPOP          Version 1.0 to 1.5
    StarPRNT Intelligence for Portable      Version 2.0 to 2.2
    StarPRNT Intelligence for BSC10         Version 2.0 to 2.1
    StarPRNT Intelligence for BSC10BR       Version 2.0 to 2.1
    StarPRNT Intelligence for TSP043        Version 2.0 to 2.1
    
====================================================
 3. How to use
====================================================

  ÅEWhen use "PrinterSoftwareRecoveryTool.exe"
    - After launch application, please select the printer driver to update software.
      Click "update" button then start updating software.  
    - If you want to restore software to before updating version, 
      please select the printer driver and click "Restore" button.
     
  ÅEWhen use batch file
    - If you launch batch, corresponding software is updated or restored.
      Correspondence of batch file and driver package is following.
  
    Software update batch files
        StarPRNT Intelligence               Å®  Update_PSA_Legacy.bat
        StarPRNT Intelligence for mPOP      Å®  Update_PSA_mPOP.bat
        StarPRNT Intelligence for Portable  Å®  Update_PSA_Portable.bat
        StarPRNT Intelligence for BSC10     Å®  Update_PSA_BSC10.bat
        StarPRNT Intelligence for BSC10BR   Å®  Update_PSA_BSC10BR.bat
        StarPRNT Intelligence for TSP043    Å®  Update_PSA_TSP043.bat
  
     Software restore batch files
        StarPRNT Intelligence               Å®  Revert_PSA_Legacy.bat
        StarPRNT Intelligence for mPOP      Å®  Revert_PSA_mPOP.bat
        StarPRNT Intelligence for Portable  Å®  Revert_PSA_Portable.bat
        StarPRNT Intelligence for BSC10     Å®  Revert_PSA_BSC10.bat
        StarPRNT Intelligence for BSC10BR   Å®  Revert_PSA_BSC10BR.bat
        StarPRNT Intelligence for TSP043    Å®  Revert_PSA_TSP043.bat
     
     
  Coution : If "backup" folder located in same folder the application is changed, 
            it is impossible to restore software.
            Please do not change contents of "backup" folder.
            
====================================================
 4. How to use console application (for developper)
====================================================

  "PrinterSoftwareRecoveryToolConsole.exe" is console application.
  You can use arguments to specify method of update or restore software.
  If you launch "PrinterSoftwareRecoveryToolConsole.exe" without arguments,
  description of arguments is shown on console.
  
  The application execution result can be judged by checking content of "ERRORLEVEL".
  Correspondence of "ERRORLEVEL" and execution result is following.
  
    %ERRORLEVEL%==0 Updating(or Restoring) software is succeeded.
    %ERRORLEVEL%==1 Invalid argument is specified.
    %ERRORLEVEL%==2 Driver package is not installed.
    %ERRORLEVEL%==3 Updating(or Restoring) software is not needed.
                    (Software is already updated or restored.)
    %ERRORLEVEL%==4 Installed driver package is too old.(refer "2. Scope")
    %ERRORLEVEL%==5 Updating(or Restoring) software is failed.
    %ERRORLEVEL%==6 Occuring unknown error.
  
  The example of usage of arguments or "ERRORLEVEL" are in each batch file.

===========================
 5. Notes
===========================

  When using this application, please stop all applications included in target driver package.
  
  After using this application, please restart Windows.
  
  When updating driver package with this application applied,
  can not update to following version or earlier driver package.
  
    StarPRNT Intelligencea                  Version 3.4 or earlier
    StarPRNT Intelligence for mPOP          Version 1.5 or earlier
    StarPRNT Intelligence for Portable      Version 2.2 or earlier
    StarPRNT Intelligence for BSC10         Version 2.1 or earlier
    StarPRNT Intelligence for BSC10BR       Version 2.1 or earlier
    StarPRNT Intelligence for TSP043        Version 2.1 or earlier

===========================
 6. Copyright
===========================

  Copyright 2017 Star Micronics Co., Ltd. All rights reserved.

===========================
 7. Release Notes
===========================

  10/10/2017    Ver. 1.0.0  First Release

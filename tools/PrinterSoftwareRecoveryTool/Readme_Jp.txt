************************************************************
      Printer Software Recovery Tool Ver 1.0.0
         Readme_Jp.txt                  スター精密（株）
************************************************************

 1. 概要
 2. 適用
 3. 使用方法
 4. コンソールアプリケーション使用方法 (開発者向け)
 5. 注意事項
 6. 著作権
 7. 変更履歴

====================================================
 1. 概要
====================================================

  本ソフトウェアは、以下ドライバパッケージに同梱されるソフトウェアのアップデートを行います。
  
    StarPRNT Intelligence
    StarPRNT Intelligence for mPOP
    StarPRNT Intelligence for Portable
    StarPRNT Intelligence for BSC10
    StarPRNT Intelligence for BSC10BR
    StarPRNT Intelligence for TSP043

====================================================
 2. 適用
====================================================
    
  対応するドライバパッケージのバージョンについては以下になります。
  
    StarPRNT Intelligencea                  バージョン 3.0 ～ 3.4
    StarPRNT Intelligence for mPOP          バージョン 1.0 ～ 1.5
    StarPRNT Intelligence for Portable      バージョン 2.0 ～ 2.2
    StarPRNT Intelligence for BSC10         バージョン 2.0 ～ 2.1
    StarPRNT Intelligence for BSC10BR       バージョン 2.0 ～ 2.1
    StarPRNT Intelligence for TSP043        バージョン 2.0 ～ 2.1
   
====================================================
 3. 使用方法
====================================================

  ・"PrinterSoftwareRecoveryTool.exe"をご利用される場合
    - アプリケーションを起動後、アプリケーション上で対応するプリンタドライバにチェックを入れ、
      "Update"ボタンをクリックすることで、対応するソフトウェアがアップデートされます。     
    - アップデート後に、ソフトウェアをアップデート前の状態に戻す場合は、
      アプリケーションを起動後、アプリケーション上で対応するプリンタドライバにチェックを入れ、
      "Restore"ボタンをクリックすることで、対応するソフトウェアがアップデート前の状態に戻ります。
     
  ・バッチファイルをご利用される場合
    - バッチファイルを実行することで、対応するソフトウェアのアップデートまたは復元を行います。
      各ドライバパッケージとソフトウェアアップデートおよび復元用バッチファイルの対応は以下になります。
  
    ソフトウェアアップデートバッチファイル
        StarPRNT Intelligence               →  Update_PSA_Legacy.bat
        StarPRNT Intelligence for mPOP      →  Update_PSA_mPOP.bat
        StarPRNT Intelligence for Portable  →  Update_PSA_Portable.bat
        StarPRNT Intelligence for BSC10     →  Update_PSA_BSC10.bat
        StarPRNT Intelligence for BSC10BR   →  Update_PSA_BSC10BR.bat
        StarPRNT Intelligence for TSP043    →  Update_PSA_TSP043.bat
  
     ソフトウェア復元バッチファイル
        StarPRNT Intelligence               →  Restore_PSA_Legacy.bat
        StarPRNT Intelligence for mPOP      →  Restore_PSA_mPOP.bat
        StarPRNT Intelligence for Portable  →  Restore_PSA_Portable.bat
        StarPRNT Intelligence for BSC10     →  Restore_PSA_BSC10.bat
        StarPRNT Intelligence for BSC10BR   →  Restore_PSA_BSC10BR.bat
        StarPRNT Intelligence for TSP043    →  Restore_PSA_TSP043.bat
     
     
  注意 : アプリケーションと同一フォルダ内にできる"backup"フォルダの内容を変更すると、
         ソフトウェアの復元ができなくなります。
         "backup"フォルダの内容を変更しないでください。

====================================================
 4. コンソールアプリケーション使用方法 (開発者向け)
====================================================

  "PrinterSoftwareRecoveryToolConsole.exe"はコンソールアプリケーションです。
  引数の内容でソフトウェアのアップデートおよび復元方法を指定することができます。
  指定できる引数および内容は、"PrinterSoftwareRecoveryToolConsole.exe"を引数なしで実行することで、
  コンソール上に表示されますのでご確認ください。
  
  アプリケーションの実行結果は、アプリケーション実行直後に"ERRORLEVEL"の内容を確認することで判別することができます。
  "ERRORLEVEL"と実行結果の対応は以下になります。
  
    %ERRORLEVEL%==0 ソフトウェアアップデート(or 復元)に成功。
    %ERRORLEVEL%==1 不正な引数を指定。
    %ERRORLEVEL%==2 ドライバパッケージがインストールされていない。
    %ERRORLEVEL%==3 ソフトウェアアップデート(or 復元)が不要 (すでにアップデート or 復元済み)。
    %ERRORLEVEL%==4 本アプリケーションが対応するバージョン以前("2. 適用" 参照)の
                    ドライバパッケージがインストールされている。
    %ERRORLEVEL%==5 ソフトウェアアップデート(or 復元)に失敗。
    %ERRORLEVEL%==6 原因不明のエラーが発生。
  
  PrinterSoftwareRecoveryToolConsoleの引数指定および"ERRORLEVEL"による結果処理の例は、
  各バッチファイルの内容をご参照ください。
  
====================================================
 5. 注意事項
====================================================

  本アプリケーションをご利用される場合は、
  アップデート(or 復元)対象となるドライバパッケージに関するアプリケーションを全て停止させてからご利用ください。
  
  本アプリケーションご利用後は、一度Windowsの再起動を行ってください。
  
  本アプリケーション適用済みドライバパッケージのアップデートを行う場合、
  以下のバージョン以前のドライバパッケージにアップデートすることはできません。
  
    StarPRNT Intelligencea                  バージョン 3.4以前
    StarPRNT Intelligence for mPOP          バージョン 1.5以前
    StarPRNT Intelligence for Portable      バージョン 2.2以前
    StarPRNT Intelligence for BSC10         バージョン 2.1以前
    StarPRNT Intelligence for BSC10BR       バージョン 2.1以前
    StarPRNT Intelligence for TSP043        バージョン 2.1以前

====================================================
 6. 著作権
====================================================

  スター精密（株）Copyright 2017

====================================================
 7. 変更履歴
====================================================

  2017/10/10    Ver. 1.0.0  初版リリース

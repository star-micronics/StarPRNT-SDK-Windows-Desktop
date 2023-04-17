************************************************************
      StarPRNT SDK Ver 5.16.0 20230331
         Readme_Jp.txt                  スター精密（株）
************************************************************

    1. 概要
    2. 変更点
    3. 内容
    4. 適用
    5. 注意事項
    6. 著作権

==============================
 1. 概要
==============================

    本パッケージはStarプリンタを使用するアプリケーションの開発を容易にするためのSDKです。
    詳細な説明は、ドキュメント(documents/UsersManual.url)を参照ください。

==============================
 2. 変更点
==============================

    [StarIO]
        - 機能追加
            * mC-Label3に対応
        - SM-S210i, SM-T300i, SM-T300, SM-T400iのBluetoothモジュール情報を新規追加

    [StarIOExtension]
        - 機能追加
            * mC-Label3に対応

==============================
 3. 内容
==============================

    StarPRNT_WindowsDesktop_SDK_V5.16.0_20230331
    |- Readme_En.txt                                // リリースノート (英語)
    |- Readme_Jp.txt                                // リリースノート (日本語)
    |- Changelog_En.txt                             // 変更履歴 (英語)
    |- Changelog_Jp.txt                             // 変更履歴 (日本語)
    |- SoftwareLicenseAgreement_En.pdf              // ソフトウエア使用許諾書 (英語)
    |- SoftwareLicenseAgreement_Jp.pdf              // ソフトウエア使用許諾書 (日本語)
    |
    +- documents
    |  +- UsersManual.url                           // StarPRNT SDK ドキュメントへのリンク
    |
    +- software
    |  |- examples
    |  |   |- 0_StarPRNT                            // 印刷やプリンターの検索などのサンプルプログラム  (Ver 5.16.0)
    |  |   +- 1_StarIODeviceSetting                 // SteadyLAN設定サンプルプログラム (Ver 1.0.0)
    |  |
    |  |- libs                                      // 厳密な名前なしライブラリ
    |  |   |- StarIOPort_x86.dll                    // StarIOPort_x86.dll          (Ver 2.9.0 32bitアプリケーション用)
    |  |   |- StarIOPort_x64.dll                    // StarIOPort_x64.dll          (Ver 2.9.0 64bitアプリケーション用)
    |  |   |- GenerateBarcode_x86.dll               // GenerateBarcode_x86.dll     (Ver 1.0.0 32bitアプリケーション用)
    |  |   |- GenerateBarcode_x64.dll               // GenerateBarcode_x64.dll     (Ver 1.0.0 64bitアプリケーション用)
    |  |   |- StarIO.dll                            // StarIO.dll                  (Ver 2.9.0)
    |  |   |- StarIOExtension.dll                   // StarIOExtension.dll         (Ver 1.8.0)
    |  |   +- StarIODeviceSetting.dll               // StarIODeviceSetting.dll     (Ver 1.0.0)
    |  |
    |  +- libs_strong_named                         // 厳密な名前付きライブラリ
    |      |- StarIOPort_x86.dll                    // StarIOPort_x86.dll          (Ver 2.9.0 32bitアプリケーション用)
    |      |- StarIOPort_x64.dll                    // StarIOPort_x64.dll          (Ver 2.9.0 64bitアプリケーション用)
    |      |- GenerateBarcode_x86.dll               // GenerateBarcode_x86.dll     (Ver 1.0.0 32bitアプリケーション用)
    |      |- GenerateBarcode_x64.dll               // GenerateBarcode_x64.dll     (Ver 1.0.0 64bitアプリケーション用)
    |      |- StarIO.dll                            // StarIO.dll                  (Ver 2.9.0)
    |      +- StarIOExtension.dll                   // StarIOExtension.dll         (Ver 1.8.0)
    |
    +- tools
        |- PrinterSoftwareRecoveryTool              // プリンタドライバソフトウェアアップデート用ツール (Ver 1.0.0)
        +- StarSoundConverter                       // メロディスピーカー向け音声変換ツール (Ver 1.0.0)

==============================
 4. 適用
==============================

    対応OS・開発環境・対応プリンターについては、
    ドキュメント(documents/UsersManual.url)を参照ください。

==============================
 5. 注意事項
==============================

    1. Ver2.2以前のWindows Desktop UI用SDK同梱の'StarIOPort.dll'または'StarIO.dll'を
        本パッケージ同梱のものに差し替える場合は以下の点にご注意ください。

        - 以下の環境を満たしていない場合はアプリケーションがビルドできません。
            OS                       : Windows7, 8/8.1, 10
            Visual Studio            : Visual Studio 2008以降
            ターゲットフレームワーク : .Net Framework 3.5以上

        - モバイルプリンタ用SDKをご利用されていた場合、'GetPort'メソッドの引数を変更する必要があります。
        お手数ですが、本パッケージ同梱のStarPRNT SDKドキュメントをご参照の上、
        'GetPort'メソッドの引数を再設定し、動作確認を行ってください。

    2. プリンターの電源をONした後にプリンターにmC-Soundを接続した場合、メロディスピーカーのAPIは正常に動作しません。
        プリンターにmC-Soundを接続した後にプリンターの電源をONしてください。

    3. ReleasePortメソッドの挙動の変更
        - StarIO.dll V2.6.0 (StarPRNT SDK V5.11.0)より、ReleasePortメソッドの挙動を変更しました。
            V2.5.0以前:
                ReleasePortメソッドを呼ぶ前にGetPortメソッドを複数回呼んだ場合は、
                GetPortメソッドを呼んだ回数分ReleasePortメソッドを呼ぶことでポートがクローズされる。
            V2.6.0以降:
                ReleasePortメソッドを呼んだ場合は、GetPortメソッドを呼んだ回数に関わらず必ずポートがクローズされる。

==============================
 6. 著作権
==============================

    スター精密（株）Copyright 2017-2022
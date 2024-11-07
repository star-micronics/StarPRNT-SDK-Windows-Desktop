# StarPRNT SDK Windows Desktop C#

本パッケージはStarプリンタを使用するアプリケーションの開発を容易にするためのSDKです。

## 適用

対応OS・開発環境・対応プリンターについては、[StarPRNT SDKの開発者向けドキュメント](https://www.star-m.jp/starprntsdk-oml-windows_desktop.html)を参照ください。

## 注意事項

1. Ver2.2以前のWindows Desktop UI用SDK同梱の'StarIOPort.dll'または'StarIO.dll'を本パッケージ同梱のものに差し替える場合は以下の点にご注意ください。

    - 以下の環境を満たしていない場合はアプリケーションがビルドできません。

        |                |                           |
        |----------------|---------------------------|
        |OS              |Windows7, 8/8.1, 10        |
        |Visual Studio   |Visual Studio 2008以降     |
        |Target framework|.Net Framework 3.5以上     |

    - モバイルプリンタ用SDKをご利用されていた場合、'GetPort'メソッドの引数を変更する必要があります。
  
        お手数ですが、本パッケージ同梱のStarPRNT SDKドキュメントをご参照の上、'GetPort'メソッドの引数を再設定し、動作確認を行ってください。

2. プリンターの電源をONした後にプリンターにmC-Soundを接続した場合、メロディスピーカーのAPIは正常に動作しません。

   プリンターにmC-Soundを接続した後にプリンターの電源をONしてください。

3. ReleasePortメソッドの挙動の変更

    StarIO.dll V2.6.0 (StarPRNT SDK V5.11.0)より、`ReleasePort`メソッドの挙動を変更しました。

    - V2.5.0以前:
    ReleasePortメソッドを呼ぶ前にGetPortメソッドを複数回呼んだ場合は、GetPortメソッドを呼んだ回数分ReleasePortメソッドを呼ぶことでポートがクローズされる。

    - V2.6.0以降:
    ReleasePortメソッドを呼んだ場合は、GetPortメソッドを呼んだ回数に関わらず必ずポートがクローズされる。

## 著作権

スター精密（株）Copyright 2017-2024

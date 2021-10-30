# TJAPlayer3-f
最終更新日:2021/10/31(S2ilys)

このReadmeはTJAPlayer3-fのReadmeを基に作成いたしました。

## はじめに
このソフトウェアは、アーケード/家庭用ゲーム「太鼓の達人」シリーズ用、譜面ビューアーです。  
このソフトウェアは、S2ilys(Otinkomann)がTJAPlayer3-fというシミュレーターを改造したものです。  

* 太鼓さん次郎・TJAPlayer等で使われている.tjaファイル
* Koioto等に使われている.tcc .tcm .tciファイル

を読み込み、再生することができます。  
(すべての対応ファイルが読み込めるわけではありません。)  

**もともとはシミュレーターとして開発していましたが、現在は、譜面ビューアーとして開発を続行しています。**  
追記:シミュレーターとして使えるようにしました。


## 使用上の注意
* TJAPlayer3-fはオープンソースソフトウェアです。このソフトウェア・スキンはすべてMITライセンスに準拠します。
* プログラムの制作者(Mr-Ojii)は、TJAPlayer3-f本体(GitHubからのダウンロード)とデフォルトのスキンのサポートのみ行います。
* すべての環境で動作確認はできないので、動いたら運がいい、程度でお願いします。
* 常時60fpsを保てないPCでの動作は期待できません。
* 起動時にコンソールが出現しますが、気にしないでください。
* このプログラムを使用し発生した、いかなる不具合・損失に対しても、一切の責任を負いません。  
  このソフトウェアを使用する場合は、**全て自己責任**でお願いします。


## 動画、配信等でのご利用について
TJAPlayer3-fを動画共有サイトやライブ配信サービス、ウェブサイトやブログ等でご利用になられる場合、  
バンダイナムコエンターテインメント公式のものでないこと、他のソフトウェアと混同しないよう配慮をお願いいたします。  
また、タグ機能のあるサイトの場合、「TJAPlayer3-f」「TJAP3-f」といったタグを付けることで、  
他のソフトウェアとの誤解を防ぐとともに、関連動画として出やすくなるメリットがあるため、推奨します。 


## TJAPlayer3-fの改造・再配布(二次配布)を行う場合について
TJAPlayer3-f、デフォルトスキンはMITライセンスで制作されています。  
MITライセンスのルールのもと、改造・再配布を行うことは自由ですが、**全て自己責任**でお願いします。  
また、使用しているライブラリのライセンス上、**必ず**「Licenses」フォルダを同梱の上、改造・再配布をお願いします。  
外部スキンや、譜面パッケージを同梱する場合は、それぞれの制作者のルールや規約を守ってください。  
これらにTJAPlayer3-fのライセンスは適用されません。


## 質問をする前に
質問をする前に、

1. 調べる前に考える
2. 人に聞く前に調べる
3. 過去に同じような質問がなかったか調べる
4. 使用しているパソコンの環境、どういう動作をしたら不具合を起こしたかの過程等を添えて連絡する

この4つのルールを守っていただければ幸いです。どうかよろしくおねがいします。


## バグ報告のお願い
開発者:[@Mr_Ojii](https://twitter.com/Mr_Ojii)はC#を2020年3月16日に初めて触りました。  
この改造をしながら、C#を勉強しているため、相当な量のバグが含まれていると思われます。  
バグを見つけた場合、Discordサーバーまたは、GitHub Issuesで報告していただけると、自分の学習もはかどるのでよろしくお願いします。  
また、プログラムが落ちるようなエラーである場合、情報を開発者に送信するような仕様になっております。ご了承ください。



## 実装要望について
実装してほしいものがあればGitHubのIssuesまたはDiscord鯖まで。  
趣味程度の改造なので時間はかかりますが、実装要望があったものは、なるべく実装したいと考えています。  
趣味ですから、気分次第で実装をするので、バグ報告がなされても後回しにする可能性があります。すみません。


## 追加命令について
「About_additional_and_modified_functions.md」で説明いたします。


## SkinConfigについて
「About_SkinConfig.ini.txt」で説明いたします。


## 推奨動作環境
#### OS
* Windows 7以降のWindows (x86,x64)
* デスクトップ環境構築済みの Linux ディストリビューション 最新版 (x64)

#### CPU
* マルチスレッド対応

#### GPU
* OpenGL対応


## 実行方法
### Windows環境  
ダウンロード後、Zipファイルを解凍し、フォルダ内に入っているTJAPlayer3-f.exeを実行してください。

### Linux環境
各種パッケージマネージャー  
* apt  
  ```sh
  sudo apt install freeglut3-dev libgdiplus
  ```
* dnf
  ```sh
  dnf install freeglut-devel libgdiplus
  ```
* pacman
  ```sh
  pacman -S freeglut libgdiplus
  ```
で、必要なパッケージをインストールしておき、　　
(ここに記載がないパッケージマネージャーは自身で調べて、freeglut3とlibgdiplusをインストールしてください。)

TJAPlayer3-fのダウンロードごとに、Zipファイルを解凍し、  
TJAPlayer3-fが存在するディレクトリをカレントディレクトリとしたターミナルで  
```sh
chmod +x TJAPlayer3-f.AppImage
```

をしてから、TJAPlayer3-f.AppImageを実行してください。


## 開発環境(動作確認環境)
#### OS
* Windows 10(Ver.21H1) (x64)
* Linux Mint 20.2(Xfce) (x64)

#### Editor
* Visual Studio Community 2019
* Visual Studio Code
* Vim


## 開発体制について
masterブランチでほぼすべての開発を行います。  
(基本的なものはです。大規模なテスト実装などは、別のブランチに移行するかもしれません。)


## 開発状況
|バージョン |日付(JST) |                                        実装内容                                        |
|:---------:|:--------:|:---------------------------------------------------------------------------------------|
|Ver.1.5.8.0|2020-03-25|より本家っぽく。                                                                        |
|Ver.1.5.8.1|2020-04-16|王冠機能の搭載(かんたん～おに & Edit(実質裏鬼))                                         |
|Ver.1.5.8.2|2020-04-17|.NET Framework 4.0にフレームワークをアップデート                                        |
|Ver.1.5.8.3|2020-05-06|譜面分岐について・JPOSSCROLLの連打についての既知のバグを修正                            |
|Ver.1.5.9.0|2020-05-08|複数の文字コードに対応                                                                  |
|Ver.1.5.9.1|2020-05-09|WASAPI共有に対応                                                                        |
|Ver.1.5.9.2|2020-05-12|.NET Framework 4.8にフレームワークをアップデート                                        |
|Ver.1.5.9.3|2020-05-22|スコアが保存されないバグを修正 & songs.dbを軽量化                                       |
|Ver.1.6.0.0|2020-06-04|難易度選択画面＆メンテモード追加(タイトル画面でCtrl+Aを押しながら、演奏ゲームを選択)    |
|Ver.1.6.0.1|2020-06-07|Open Taiko Chartへの対応(β)                                                            |
|Ver.1.6.0.2|2020-06-15|片開き(仮)実装                                                                          |
|Ver.1.6.0.3|2020-07-11|特訓モード(仮)実装                                                                      |
|Ver.1.6.0.4|2020-08-30|音色機能の実装・演奏オプション表示方法の変更                                            |
|Ver.1.6.0.5|2020-09-03|FFmpeg APIを使用しての音声デコード機能を追加                                            |
|Ver.1.6.1.0|2020-09-13|FFmpeg APIを使用しての動画デコード機能を追加                                            |
|Ver.1.6.2.0|2020-10-06|.NET Core 3.1にフレームワークをアップデート                                             |
|Ver.1.6.3.0|2021-01-03|.NET 5にフレームワークをアップデート                                                    |
|Ver.1.6.4.0|2021-01-06|OpenGL描画に対応                                                                        |
|Ver.1.7.0.0|2021-03-16|Ubuntu系のLinux Distributionに対応                                                      |
|Ver.1.7.1.0|2021-03-22|描画バグの修正                                                                          |
|Ver.1.7.1.1|2021-03-31|スクリーンショットのバグを修正                                                          |
|Ver.1.7.1.2|2021-04-19|Linux環境でMidi入力ができない問題の修正                                                 |
|Ver.1.7.1.3|2021-04-22|動画再生時のメモリ使用量の変動が大きい問題の修正(また、動画再生時の負荷軽減)            |
|Ver.1.7.1.4|2021-05-12|メモリリークの修正 & エラー発生時の取得情報の追加                                       |
|Ver.1.7.1.5|2021-07-29|使用する.NET用 BASSラッパーをManagedBassに変更                                          |


## デフォルトスキンについて
一部画像は、TJAPlayer3のデフォルトスキンから流用しています。

スキンのサウンドについては徐々に自作にすり替えていきます。  
耳コピできないので、Domino & Softalk等で適当に作った音声類になると思います。

スキン作成ツール
* AviUtl
* Blender
* FFmpeg
* GIMP
* Domino
* Audacity
* SofTalk
* UTAU

&それぞれのソフトのプラグイン/スクリプトなど


## Discord Server
作っていいものかと思いながら、公開鯖を作ってみたかったので作ってしまいました。  
参加した場合、#readmeをご一読ください。よろしくお願いいたします。  
[https://discord.gg/Wg9bD5jTHZ](https://discord.gg/Wg9bD5jTHZ)


## ライセンス関係
Fork元より使用しているライブラリ
* [bass](https://www.un4seen.com/bass.html)
* FDK21(改造しているので、FDKとは呼べないライブラリと化しています)

以下のライブラリを追加いたしました。
* [ReadJEnc](https://github.com/hnx8/ReadJEnc)
* [Json.NET](https://www.newtonsoft.com/json)
* [FFmpeg.AutoGen](https://github.com/Ruslan-B/FFmpeg.AutoGen)
* [FFmpeg](https://ffmpeg.org/)
* [OpenTK](https://opentk.net/)
* [discord-rpc-csharp](https://github.com/Lachee/discord-rpc-csharp)
* [SixLabors.ImageSharp](https://github.com/SixLabors/ImageSharp)
* [SixLabors.ImageSharp.Drawing](https://github.com/SixLabors/ImageSharp.Drawing)
* [SixLabors.Fonts](https://github.com/SixLabors/Fonts)
* [M+ FONTS](https://osdn.net/projects/mplus-fonts/)
* [managed-midi](https://github.com/atsushieno/managed-midi)
* [ManagedBass](https://github.com/ManagedBass/Home)

また、フレームワークに[.NET](https://dotnet.microsoft.com/)を使用しています。

ライセンスは「Licenses」に追加いたしました。


## FFmpegについて
このリポジトリにはあらかじめFFmpegライブラリが同梱されています。  
同梱しているライブラリは
+ [FFmpeg-Builds-Win32](https://github.com/sudo-nautilus/FFmpeg-Builds-Win32)からのx86ライブラリ  
+ [FFmpeg-Builds](https://github.com/BtbN/FFmpeg-Builds)からのx64ライブラリ  

バージョンは4.4です。(2021/08/20現在)


## BASSについて
このリポジトリにはあらかじめBASSライブラリが同梱されています。  
バージョンは2.4.16.3です。(2021/08/17現在)


## 謝辞
このTJAPlayer3-fのもととなるソフトウェアを作成・メンテナンスしてきた中でも  
主要な方々に感謝の意を表し、お名前を上げさせていただきたいと思います。

- ＦＲＯＭ様
- yyagi様
- kairera0467様
- AioiLight様

また、他のTJAPlayer関係のソースコードを参考にさせていただいている箇所がございます。  
ありがとうございます。
追記:TCDNやTCC(同じ)からコードをめちゃパクってます申し訳ない。

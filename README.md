# TJAPlayer3-f

TJAPlayer3をForkして、趣味程度に改造してます。
改造者:[@Mr_Ojii](https://twitter.com/Mr_Ojii)はC#を2020年3月に初めて触りました。  
スパゲッティコードと化してますね。うん。たまに整理しましょうかね。

テキトーメンテモードも付けました。タイトル画面で、「Ctrl+A」を押しながら、演奏モードを選択すると、  
黒背景に文字が表示されている画面に行きますが、それが、メンテモード(仮)です。反応確認みたいな感じかな？Escで抜けれます。

実装してほしいものがあればGitHubのIssuesまたはDiscord鯖まで。  
趣味程度の改造なので、時間はかかりますが、実装要望があったものは、なるべく実装したいと考えています。

masterブランチでほぼすべての開発を行います。
(基本的なものはです。テスト実装などは、別のブランチに移行するかも。)

このプログラムを使用し発生した、いかなる不具合・損失に対しても、一切の責任を負いません。

## 追加命令について
Testフォルダ内の「[追加機能について.md](https://github.com/Mr-Ojii/TJAPlayer3-f/blob/master/Test/追加機能について.md)」で説明いたします。

## 推奨環境
Windows7以降  
まぁ、Windows10で動作確認をしているので、Windows10が一番安定してるかと...

## 開発状況(ログみたいなもん)
Ver.1.5.8.0 : より本家っぽく。

Ver.1.5.8.1 : 王冠機能の搭載(かんたん～おに & Edit(実質裏鬼))

Ver.1.5.8.2 : .NET Framework 4.0にフレームワークをアップデート

Ver.1.5.8.3 : 譜面分岐について・JPOSSCROLLの連打についての既知のバグを修正

Ver.1.5.9.0 : 複数の文字コードに対応

Ver.1.5.9.1 : WASAPI共有に対応

Ver.1.5.9.2 : .NET Framework 4.8にフレームワークをアップデート

Ver.1.5.9.3 : スコアが保存されないバグを修正 & songs.dbを軽量化

Ver.1.6.0.0 : 難易度選択画面を追加 & メンテモード追加(タイトル画面でCtrl+Aを押しながら、演奏ゲームを選択)

Ver.1.6.0.1 : Open Taiko Chartへの対応(β)

Ver.1.6.0.2 : 片開き(仮)実装

Ver.1.6.0.3 : 特訓モード(仮)実装

## Discord鯖
作っていいものかと思いながら、公開鯖を作ってみたかったので作ってしまった。  
バイナリを頒布するならここでします。(けど、ソースからのビルド推奨)  
私のモチベにもなるから、気軽に入ってね。  
[https://discord.gg/AkfUrMW](https://discord.gg/AkfUrMW)

## 開発環境
Windows 10(Ver.1909)  
VisualStudio Community 2019

## バグ報告のお願い
  
改造者:[@Mr_Ojii](https://twitter.com/Mr_Ojii)はC#を2020年3月に初めて触りました。  
この改造をしながら、C#を勉強しているため、結構バグを含んでいると思います。  
バグを見つけたら、TJAPlayer3-fから開かれたフォームまたは、Issuesで報告してもらえると、  
自分の勉強もはかどるのでよろしくお願いします。

## 謝辞
このTJAPlayer3-fのもととなるソフトウェアを作成・メンテナンスしてきた中でも  
有名な方々に感謝の意を表し、お名前を上げさせていただきたいと思います。

- FROM/yyagi様
- kairera0467様
- AioiLight様

また、他のTJAPlayer関係のソースコードを参考にさせてもらっている箇所があります。  
ありがとうございます。

## ライセンス関係
以下のライブラリを追加いたしました。
* ReadJEnc
* SharpDX
* Newtonsoft.Json

ライセンスは「Test/Licenses」に追加いたしました。

# 以下AioiLight様作成のReadmeです

> # TJAPlayer3
> DTXManiaをいじってtja再生プログラムにしちゃった[TJAPlayer2fPC](https://github.com/kairera0467/TJAP2fPC)をForkして本家風に改造したアレ。
>
> この改造者[@aioilight](https://twitter.com/aioilight)はプログラミングが大変苦手なので、スパゲッティコードと化していると思います...すみません
>
> このプログラムを使用した不具合・問題については責任を負いかねます。
>
> ## How 2 Build
> - VisualStudio 2017 & C# 7.3
> - VC++ toolset
> - SlimDX用の署名
>
> ## 実装状況いろいろ
> - [x] 小さいコンボ数
> - [x] 踊り子
> - [x] モブ
> - [x] BPMと同期した音符アニメーション
> - [x] ゴーゴータイム開始時の花火
> - [x] 連打時の数字アニメーション
> - [x] ランナー
> - [x] 10コンボごとのキャラクターアニメーション
> - [x] ぷちキャラ
> - [x] 段位認定（段位チャレンジ）
>
> ## ロードマップみたいな
>
> Ver.1.4.x : 拡張性の増加、サウンド周りの変更、読み込める命令の追加（9月中）
>
> Ver.1.5.x : 段位認定機能の追加（11、12月中）
>
> Ver.1.6.x : 多言語対応（未定）
>
> Ver.1.7.x : フレームワークのアップデート、ライブラリの更新（未定）
>
> Ver.1.8.x : さらなる安定化を目指して（未定）
>
> Ver.2.x : Direct3D11、12への対応、保守体制へ（未定）
>
> ## ライセンス関係
> Fork元より引用。
> 
> > 以下のライブラリを使用しています。
> > * bass
> > * Bass.Net
> > * DirectShowLib
> > * FDK21
> > * SlimDX
> > * xadec
> > * IPAフォント
> > * libogg
> > *libvorbis
> > 「実行時フォルダ/Licenses」に収録しています。
> > 
> > また、このプログラムはFROM氏の「DTXMania」を元に製作しています。

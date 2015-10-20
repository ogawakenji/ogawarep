

参照URL <http://codezine.jp/article/detail/1157>  
参照URL <http://blogs.msdn.com/b/nakama/archive/2008/09/18/part-1-wcf.aspx>  
参照URL <http://www.atmarkit.co.jp/ait/articles/0604/26/news118.html>



## WCFとはなにか？

WCFはMicrosoftが.NET Framework3.0から導入した  
クライアントと通信を行う際の新しいフレームワーク！  
・・・またフレームワークか orz  
いったいどんだけいろいろ覚えなければいけないのか・・・  

なぜ必要なのか？  
これまで存在したネットワーク分散サービスのフレームワーク  
* ASP.NET Web Services (ASMX) … ASP.NETを使用したXML Web Serviceのフレームワーク
* Web Service Enhancements (WSE) 拡張 … Webサービス拡張仕様（WS-*）をサポートするフレームワーク
* Microsoft メッセージキュー(MSMQ) … Microsoft Message Queuingを使用するフレームワーク
* .NET Remoting … .NETコンポーネント間で使用可能な通信方式

ASP.NET Web Servicesと.NET Remotingは使ったことがある。  
ASP.NET Web ServicesはWebサービス作って、サービスの参照設定すると  
かってにVSが上手いことメソッド作ってサーバーの処理を呼び出せる  

.NET Remotingは基盤の中で使っていたので結局仕組みはよくわからず...

今までも通信を行う方法はさまざまあった。  
↓  
通信のプロトコルが様々存在  
↓  
通信方式を変えたい！  
↓  
フレームワークに**互換性**がない・・・  
↓  
**全部書き換えだ!**  
↓
__orz__  

通信のテクノロジはどのフレームワークを採用するのか  
初期で決定し、以後は他のフレームワークへの移行を考慮せず  
特定のフレームワーク専用のコーディングを行うのが普通  

WCFを使うと
* *様々な通信プロトコルを扱う際のプログラミングモデルが統合されます。*このため、新しい通信プロトコルを利用したアプリケーションに開発する際の学習コストが低減されます。  
* _WS-* プロトコルへの対応が非常にスマートにできます。_  
* *同一の通信特性を持つ通信プロトコルであれば、簡単にリプレースできます。 *  



WCF…Windows Communication Foundation (Google翻訳→Windows通信基盤)




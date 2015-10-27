マークダウンとは？

段落  
1段落目

2段目

改行  
行末に2つのスペース

強調  
*強調*または_強調_  
**強い強調**または__強調__  

コード表示  
`Dim hoge as String = "1" `   

リスト
* List1
* List2
* List3

1. List4
2. List5
3. List6

見出し  
# H1見出し 
## H2見出し 
#### H4見出し

リンク
<http://example.com>

# IMEがWin8で変わった！
https://karuakun.wordpress.com/2014/01/31/windows-8%E3%81%A7imemode-katakanakatakanahalf%E3%81%8C%E6%9C%89%E5%8A%B9%E3%81%AB%E3%81%AA%E3%82%89%E3%81%AA%E3%81%84%E3%80%82/  
http://d.hatena.ne.jp/Yamaki/20140204/1391488849  
http://d.hatena.ne.jp/tkng/20100510/1273455264  
http://www.wankuma.com/seminar/20080712tokyo22/6.files/frame.htm  
http://nyaruru.hatenablog.com/entry/20070309/p1  
http://ja.nishimotz.com/text_services_framework  
http://hp.vector.co.jp/authors/VA050396/tech_01.html  

## SGMLでHTMLをパース  
パース後に子要素を検索してもヒットしない場合はXNameの指定が誤っている可能性

`Dim query = From q In xdoc.Descendants("td")`
`            Select q`

`Dim ns As XNamespace = "http://www.w3.org/1999/xhtml"`
`Dim query = From q In xdoc.Descendants(ns + "td")`
`            Select q`






# C＃のゲームでTwitterのツイート画面を開くやつ

## ツイート画面を開くURL

これがツイート画面を開くためのURL
```
http://twitter.com/intent/tweet
```

これがツイート画面を開くついでにテキストを入れるURL
```
http://twitter.com/intent/tweet?text=もじもじ
```

## ツイート画面にテキストを入れる処理

```
テストツイート
もじもじ
もじもじ

#Test
#もじもじ
```
↑こんな感じの内容を下記の処理の`投稿内容`の場所に入れると、`Uri.EscapeDataString`がエスケープ表現に変換してくれて、URLにつかえるようになる

```
string text = "投稿内容";
string str = Uri.EscapeDataString(text);
string tweetURL = $"http://twitter.com/intent/tweet?text={str}";
```

## 参考サイト
- https://qiita.com/bm0521/items/39ae81e2ba01c9d3e0bd
- https://nekojara.city/unity-imgur-twitter-share

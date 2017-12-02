ローカルDBで動かすには
AzureStorageEmulatorを動かす(インストールするだけでいい？VSを入れると勝手に入る？)
　・Windowアイコンを押して、AzureStorageEmulator　と入力
　　そうすると動き出す

local.settings.json に「"AzureWebJobsStorage": "UseDevelopmentStorage=true",」
の記述を入れる---　これは必要と思われる

AzureFunction にデプロイするには、
HttpTrigger(AuthorizationLevel.Anonymous, "post")

AuthorizationLevel.Function→AuthorizationLevel.Anonymous
こうしないとエラーがでる（認証エラー）

★AuthorizationLevel.Function　でもよい（というかこちらがよい）
ただし、その際はapiキーをリクエストパラメータにセットする必要
がある。
リクエストパラメータは、azureポータルで、その関数を選び、
「</> 関数の URL の取得」（右上）のリンクをクリックするとわかる


Advanced Rest clientの立ち上げ方
左下で、advancedと入力
advanced Rest Clientが表示されるのでそれを選ぶ

SQLデータベースのインポート
・ポータルでダッシュボードを選ぶ
・インポートするSQLデータベースを入れるSQL Serverを選ぶ
・データベースのインポートを選ぶ
・価格レベルでBASICを選ぶ
・Strage のところで、visualsamplenaba26a→azure-web-job→mySampleSQL***.bacpacを選ぶ
・データベース名を適当なものに変える
・パスワードを入れてOK


■gitの使い方
https://qiita.com/mountcedar/items/682743c95fd3b8fc274b
http://akiyoko.hatenablog.jp/entry/2014/12/02/000939
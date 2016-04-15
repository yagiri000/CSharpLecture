#C#講座資料 vol_1  

本資料は、C#講座向けに、やぎりが撮影したスクリーンショットの集合体です。  

##今回何をやるか  
以下の様な超高機能なメモ帳を作ります。  
![aaa](images_vol_1\sc0.png)  

##ツールボックス・プロパティーウィンドウ表示  
まずはフォームを配置・調整するための、ツールボックス・プロパティーウィンドウを表示します。  

* ツールボックスウィンドウ表示  
「表示」→「ツールボックス」  
または、[Ctrl+Alt+X]  

* プロパティーウィンドウ表示  
「表示」→「プロパティーウィンドウ」を押す  
または[F4]  
または[Alt+Enter]  

以下のスクショの画面右側に表示されているウィンドウが、ツールボックス・プロパティーウィンドウです。  
![aaa](images_vol_1\sc1.png)  



##プロジェクト作成  
ファイル→新規作成→プロジェクトから出てくるウィンドウから、
Visual C#→Windows フォームアプリケーションを選んでOKを押して作成  
![aaa](images_vol_1\sc00.png)  


##Hello, World!ボタンを作る  
「TextBox」と「Button」を生成し、ボタンが押されたらHello,World!がテキストボックスに追加されるようにします。  

1. 「ツールボックス」→「コモンコントロール」から、TextBoxをドラッグアンドドロップして生成します。
![aaa](images_vol_1\sc2.png)

1. 生成したテキストボックスを選択すると、「プロパティ」ウィンドウに各種パラメータが表示されます。  
複数行のテキストを打ち込みたいので、Multilineをtrueにします。  
Multilineをtrueにすると、縦に伸ばせるようになるので、伸ばします。  
	* 「アルファベット順」ボタンを押すと、アルファベット順に項目を表示できます。  
![aaa](images_vol_1\sc3.png)  

1. 「プロパティ」→「Name」から、コントロールの名前を変えることが出来ます。textBox1だと分かりづらいので、mainTextBoxとかわかりやすい名前に変えておきましょう。  
以下のすべてのサンプルコードでは、コントロールの名前がtextBox1とかのままなので、自分でつけた名前に適宜変えて下さい。  
![aaa](images_vol_1\rename.png)  

1. 「ツールボックス」→「コモンコントロール」から、Buttonをドラッグアンドドロップして生成します。  
![aaa](images_vol_1\sc4.png)  

1. ButtonのTextを「Hello, World!」に変更します。  
![aaa](images_vol_1\sc5.png)  

1. 生成されたbutton1をダブルクリックします。  
コード入力画面に飛ぶと思います。ここでボタンが押された時のイベント処理を設定することが出来ます。  

1. 以下の様なコードを書きます。  
![aaa](images_vol_1\sc6.png)  


1. Ctrl+F5で実行します。ボタンを押すとHello, World!という文字列がテキストボックスに追加されます。  
連打するとたのしいです。  
![aaa](images_vol_1\sc7.png)  


##Good Morning, Good nightボタンを作る  
ComboBoxを使う練習として、「Button」「ComboBox」を使い、選択した文字列を追加できるようにする。  
ComboBoxは、項目を選択できるコントロールである。  


1. 「ツールボックス」→「コモンコントロール」から、ComboBoxをドラッグアンドドロップして生成します。  
![aaa](images_vol_1\sc10.png)  

1. 「ツールボックス」→「コモンコントロール」から、Buttonをドラッグアンドドロップして生成します。  
1. さっき生成したButtonのTextを「Add」にします。  

1. ComboBoxに項目を追加していきます。  
生成したComboBoxを右クリック→「項目の編集」から、ComboBoxの項目を編集できます。  
以下のように項目を追加して下さい。  
![aaa](images_vol_1\sc11.png)  
![aaa](images_vol_1\sc12.png)  

1. さっき生成したButtonをダブルクリックして、Buttonが押された時のイベントの中身を書きます。以下の様にコードを書いて下さい。  

		
		textBox1.Text += comboBox1.Text;

1. Ctrl+F5で実行すると、以下のようになり、comboBoxからAddボタンを押した時に貼り付けられるTextを選択できます。  
![aaa](images_vol_1\sc12.png)  

1. ComboBoxではじめに表示されているテキストは、Textプロパティで変更できます。  


##クリップボードにコピー・貼り付け機能  
クリップボードにコピー、クリップボードから貼付ボタンを作ります。  
以下の様な2つのボタン（クリップボードにコピー、クリップボードから貼付）を作り、以下のコードを書くことで、クリップボードへのコピー・クリップボードからの貼付けが出来ます。  
ちなみに、テキストボックスに何も書いてない状態でコピーしようとするとエラーが出ます。    
![aaa](images_vol_1\sc20.png)  	

>クリップボードにコピー

        Clipboard.SetText(textBox1.Text);

>クリップボードから貼付

        textBox1.Text += Clipboard.GetText();


##置換機能  
1. 以下のようにTextBox2つとButton1つを生成してください。
![aaa](images_vol_1\sc30.png)  	

1. 生成したボタンをダブルクリックして以下のコードを書きます。  
Replace関数は、1番目の引数のテキストを2番目の引数のテキストにする関数です。  

		textBox1.Text = textBox1.Text.Replace(textBox2.Text, textBox3.Text);

	一応、今のコードはこんな感じです。
![aaa](images_vol_1\sc31.png)  	

1. デバック実行すると、文字列の置換機能が実装されています。  
![aaa](images_vol_1\sc32.png)  	


##ファイル保存機能  
テキストのセーブ機能とロード機能をつけます。
![aaa](images_vol_1\sc40.png)  	

1. 上記のようにSaveボタンとLoadボタンを作って下さい。  

1. ファイル操作のためのヘッダーみたいなやつを読み込みます。  
プログラムの一番上に、usingがたくさんあると思いますが、そこに以下のも追加します。  

		using System.IO;
		
![aaa](images_vol_1\sc41.png)  	

1. それぞれダブルクリックして、イベントを設定します。以下のコードをそれぞれ貼り付けて下さい。  

		//セーブ
        using (var sw = new StreamWriter("aaa.txt", false, Encoding.GetEncoding("shift_jis")))
        {
            sw.Write(textBox1.Text);
        }



		//ロード
        using (var sr = new StreamReader("aaa.txt", Encoding.GetEncoding("shift_jis")))
        {
            textBox1.Text = sr.ReadToEnd();
        }

1. ファイルのセーブ・ロード機能がつきました。Ctrl+F5で実行してみてください。  

1. プロジェクトのフォルダ\bin\Debugにaaa.txtが生成されていると思います。  
![aaa](images_vol_1\sc42.png)  	

##演習問題  
「FileOpenボタン」を追加し、超高機能メモ帳を完成させる。  
FileOpenボタンを押したら、以下の様なダイアログボックスを表示し、指定したテキストを開く機能を実装せよ。  

ヒント：  
C#の情報は大体ググると出てくるし、そこで出たコードをコピペすれば大体動く。  
今回は「ダイアログボックス ファイル　開く」あたりで検索してみよう。

![aaa](images_vol_1\sc50.png)  	

* 超高機能メモ帳の完成図  
![aaa](images_vol_1\sc0.png)  


#　C#講座資料 vol_5      
vol_5は、フォームアプリケーションを作るときによく使われるコンポーネントに関する資料です。    
  
##　よく使うコンポーネント    
* Button    
ボタン  

* TextBox    
テキストボックス  

* DataGridView  
エクセルみたいなやつ

* Label    
文字表示できるやつ  

* CheckBox    
チェックボックス  

* ComboBox    
リストで項目を選択するやつ  

* PicturBox    
画像を表示するやつ    

* TabControl    
ウェブブラウザの上の方みたいなやつ  

* HScrollBar, VScrollBar    
スクロールバー    

* MenuStrip  
[ファイル][編集][表示][プロジェクト]…みたいな画面上部にあるやつ  

* WebBrowser  
ウェブブラウザ  

* ContextMenuStrip  
いわゆる「右クリックメニュー」

* ToolTip  
マウスカーソルを合わせたときの補足説明ポップアップ  
ちょっとした説明に非常に便利

* RadioButton  
どれか一つしか選択できない丸いチェックボックス  
後述のPanelやGroupBoxと組み合わせると複数グループ設置できる  

* NumericUpDown  
数値を選択する  
上限下限を決められたり、上下キーで増減出来たり便利  


  
##　大抵はデザイナで作らず、コード内部で生成するコンポーネント    
* ファイル系  
	* OpenFileDialog    
	* SaveFileDialog    
	* FolderBrowserDialog  
* Timer    
一定時間ごとに処理を行う  


##　知っていると便利なもの
* BackgroundWorker  
普通にやるとフリーズするような重い処理を実行できる  
但し癖があるので使い方をきちんと把握していないと死ぬ

* NotifyIcon  
タスクトレイ(通知領域)にアイコンをつける  
バルーン通知などを飛ばせる  

* StatusStrip  
ステータスバー(ダイアログ下のほうによくある、ちょっとした情報を出すバー)


##　レイアウト系
* Panel  
ただのコンテナ  
RadioButtonをまとめるの等に使用する  

* SplitContainer  
ユーザーがサイズを変えられるセパレータつきのPanel  
(エクスプローラの左・下のペインのような)
レイアウトに結構使える  

* GroupBox  
名前が付けられるPanelのようなもの(RadioButton等と併用するとなおよい)

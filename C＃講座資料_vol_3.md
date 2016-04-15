#C#講座資料 vol_3  

vol_3は、C#のファイル操作に関する資料です。  
vol_3のプログラムは、コンソール上で動かすことを想定しています。  
（コンソール アプリケーションで作って下さい。）



##ファイル書き込み_StreamWriter  
文字列のファイル書き込みにはStreamWriterを使うと良い。  
以下の様なプログラムを書いて実行すると、「プロジェクトのフォルダ\bin\Debug」にaaa.txtが生成される。  
メモ帳で開くと、「hoge」と書かれていることが確認できる。   

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding enc = Encoding.GetEncoding("shift_jis");
            StreamWriter sw = new StreamWriter("aaa.txt", false, enc);
            sw.Write("hoge");
            sw.Close();
        }
    }
}
```

StreamWriterのコンストラクタ引数は以下。  

```cs
StreamWriter([ファイル名], [文字を追加or上書き], [エンコード])
```


##usingのもう一つの機能  
もう一つの機能というか、同じusingという単語でも全く別の機能である。  
以下のようにusingを使えば、usingブロックを抜けた時に自動的にStreamが破棄されるので、Closeを呼ばずにすみ便利。    
下の例では、varで型推論をし、Encoding.GetEncoding関数をコンストラクタ内に直接書いている。上と見比べてみよう。  

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sw = new StreamWriter("aaa.txt", false, Encoding.GetEncoding("shift_jis")))
            {
                sw.Write("hoge");
            }
        }
    }
}
```


##ファイル読み込み_StreamReader  

StreamReaderを使うと、ファイルを読み込むことが出来る。  
aaa.txtの中身をすべて表示する例。  

```cshrap
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sr = new StreamReader("aaa.txt", Encoding.GetEncoding("shift_jis")))
            {
                Console.Write(sr.ReadToEnd());
            }
        }
    }
}
```

##ファイルの存在を確認  
File.Exists関数を使うと、ファイルが有るかどうかを確認できる。  

```cs
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(File.Exists("aaa.txt"));
            Console.WriteLine(File.Exists("bbb.txt"));
        }
    }
}
```


##File.ReadLines関数  
txtファイル向けの関数。ファイルを行ごとに分け、その配列を返す。  

```cs
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string line in File.ReadLines("aaa.txt", Encoding.GetEncoding("shift_jis")))
            {
                Console.WriteLine(line);
            }
        }
    }
}
```

csvを読み込む例  

```cshrap
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string line in File.ReadLines("aaa.txt", Encoding.GetEncoding("shift_jis")))
            {
                foreach (string i in line.Split(','))
                {
                    Console.Write(i + "_");
                }
                Console.WriteLine();
            }
        }
    }
}
```

##現在基準としているフォルダの取得
System.IO.Directoryは、現在の基準としているフォルダの取得、フォルダ作成、フォルダの存在有無の確認、ファイル列挙を行える。  

Directory.GetCurrentDirectory()関数は、現在の基準としているフォルダを取得出来ます。  

```cs
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
        }
    }
}
```

Directory.CreateDirectory関数は、フォルダを作成することが出来ます。  
Directory.Exists関数は、フォルダが存在しているかを返す関数です。  

```cs
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Directory.CreateDirectory("bbb");
            Console.WriteLine(Directory.Exists("bbb"));
        }
    }
}
```


Directory.GetFiles関数は、指定されたパスのフォルダに存在するファイルの文字列の配列を返します。  

```cs
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var i in Directory.GetFiles(Directory.GetCurrentDirectory()))
            {
                Console.WriteLine(i);
            }
        }
    }
}
```


Directory.GetDirectories関数は、指定されたパスのフォルダに存在するフォルダの文字列の配列を返します。  

```cs
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var i in Directory.GetDirectories(Directory.GetCurrentDirectory()))
            {
                Console.WriteLine(i);
            }
        }
    }
}
```

##外部exe起動  
System.Diagnostics.Process関数は、外部のアプリケーションを起動する。  
今回はaaa.txtを開くが、関連付けされているメモ帳が自動で開くと思われる。  
exeファイルを引数を渡しながら開くことも可能。  

```cs
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Process.Start("aaa.txt");
        }
    }
}
```


WaitForExit()を使えば、F5のみの実行でも外部で起動したプロセスが終了するまで黒画面が消えるのを停止させることが出来る。  


```cs
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Process.Start("aaa.txt").WaitForExit();
        }
    }
}
```
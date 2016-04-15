#C#講座資料 vol_2  

vol_2は、C#の基本的な機能の紹介です。  
vol_2のプログラムは、コンソール上で動かすことを想定しています。  
（コンソール アプリケーションで作って下さい。）　　

##new  
int, doubleなどの基本型以外は、インスタンス作成の際にnewが必要。  
C#ではnewで確保した領域は使わなくなったら自動的に開放してくれる。  


```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Hoge
{
    public int x;
    public Hoge(int x)
    {
        this.x = x;
    }
}

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Hoge ins = new Hoge(100);
            Console.WriteLine(ins.x);
        }
    }
}
```

##クラス  
それぞれのメンバ、関数にpublicかprivateを書くことで属性を指定。書かなければprivateになる。  
以下のコードのpublicを消したらアクセス不可能になるのでエラーになる。  

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Hoge
{
    public int x;
    public Hoge(int x)
    {
        this.x = x;
    }
    public double func()
    {
        return 1.0;
    }
}

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Hoge ins = new Hoge(100);
            Console.WriteLine(ins.x);
            Console.WriteLine(ins.func());
        }
    }
}
```

##usingについて  
ファイル上部にusingが複数あるが、これによって名前空間を指定できる。  
以下で使用するStreamWriterは、System.IO名前空間内に属するので、使用するには  

```cs
System.IO.StreamWriter
```

と書けばいいが、毎回書くのは面倒なので、プログラム上部に

```cs
using System.IO;
```

と書くことで、プログラム内では

```cs
StreamWriter
```

と書くだけで済むようになる。  


##for, while, if
for, while, ifはC, Javaなどと同じ。  


##配列
配列は以下のように書く。

```cs
int[] array = new int[5];
```

0から9までの2乗の数を表示  

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            for (int i = 0; i < 10; i++)
            {
                array[i] = i * i;
            }

            foreach (var value in array)
            {
                Console.WriteLine(value);
            }
        }
    }
}
```

##var  
型推論。C++でいうところのauto。  

```cs
List<int> list = new List<int>();
```

上記を以下のように書ける。  

```cs
var list = new List<int>();
```

汎用的なコードがかけるので、積極的に使っていくべき。

##foreach  
for文の亜種。配列、リスト、ディクショナリなどの要素をはじめから最後まで順に処理する事が可能。  

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            for (int i = 0; i < 10; i++)
            {
                array[i] = i * i;
            }

            foreach (var value in array)
            {
                Console.WriteLine(value);
            }
        }
    }
}
```





##string
C++でいうところのstring。int,double型などの数値型との+演算子が使用可能など、多くの機能が追加されており使いやすくなっている。  


```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            string hoge = "aaa";
            Console.WriteLine(hoge);
            Console.WriteLine(hoge + 3.14);
        }
    }
}
```

中でもSplit, Replace, IndexOf, Contains, Insert関数は便利。  
Replace関数は、元の文字列を置換した文字列を返す関数で、元の文字列自体は置換処理が行われていないので注意。(Insert関数も同様)。  

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "aaa,bbb,ccc";
            string[] array = str.Split(',');
            
            foreach (var i in array)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("");

            string tmp = str.Replace(",", "AAA");
            Console.WriteLine(tmp);
            Console.WriteLine("");

            int pos = str.IndexOf("b");
            Console.WriteLine(pos);
            Console.WriteLine("");

            int pos2 = str.IndexOf("d");
            Console.WriteLine(pos2);
            Console.WriteLine("");

            bool isContain = str.Contains("aaa");
            Console.WriteLine(isContain);
            Console.WriteLine("");

            string tmp2 = str.Insert(4, "xxx");
            Console.WriteLine(tmp2);
            Console.WriteLine("");

        }
    }
}
```

##直でforeach

関数の返り値で配列が返ってきた時など、foreachに生で中に入れても使えます。  

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = "aaa,bbb,ccc";
            foreach (string i in data.Split(','))
            {
                Console.WriteLine(i);
            }
        }
    }
}
```


##List  
C#の配列は生成時に要素数が固定されるが、Listは要素数が可変な配列である。  
ジェネリクスで実装される可変長配列で、C++でいうところのvectorや、listに該当する。  
Addで要素を追加できる。  

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            foreach (var value in list)
            {
                Console.WriteLine(value);
            }
        }
    }
}
```

Countプロパティで要素数を得ることが出来る。  

```cs
using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }

            Console.WriteLine(list.Count);
        }
    }
}
```

##RemoveAll  
Listの要素は、RemoveAllでラムダ式を指定する削除が可能。  

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }
            
            foreach (var i in list)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            list.RemoveAll(i => i % 2 == 0);


            foreach (var i in list)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
```


##Dictionary  
ジェネリクスにより実現された、連想配列。C++でいうところのmap

```cpp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MyClass
{
    public int x;
    public MyClass(int x)
    {
        this.x = x;
    }
}

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            var dic = new Dictionary<string, MyClass>();
            dic.Add("aaa", new MyClass(100));
            dic.Add("bbb", new MyClass(200));
            dic.Add("ccc", new MyClass(300));
            dic.Add("ddd", new MyClass(400));

            //[]の中にキーを書くことで、要素にアクセスできる。
            Console.WriteLine(dic["bbb"].x);

            //一覧表示
            foreach (var i in dic)
            {
                Console.WriteLine(i.Key + " " + i.Value.x);
            }
        }
    }
}

```


##型変換  
double→intのような大きな型から小さな型への型変換には明示的なキャストが必要。  
(以下のコードの(int)を外すとエラー。)  

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            double aaa = 3.14;
            int bbb = (int)aaa;
        }
    }
}

```

##\#if, \#endif  
\#ifと\#endifで囲んだ区間内は、ifの後にtrueが続けば有効化、falseが続けば無効化される。  
同じソース内に複数の演習問題の解答を残しておきたい場合など、コメントアウトのように使うことが出来る。  

```cs
#if true

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("aaa");
        }
    }
}
#endif

#if false

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("bbb");
        }
    }
}
#endif

#if false

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ccc");
        }
    }
}
#endif
```


\#ifはtrue以外にもソースコード上に#defineで予め定義したシンボルを書いて判断させることも可能。

以下ののように書くとAと出力される。状況に応じて複数のデバッグモードを用意する時に使える。
\#defineの部分のみ書き換えればいいので複数個所のtrueとfalseを書き換える手間が省ける。

```cs
#define MODE_A

#if MODE_A

using System;

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("aaa");
        }
    }
}
#elif MODE_B

using System;

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("bbb");
        }
    }
}
#elif MODE_C

using System;

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("bbb");
        }
    }
}
#else

using System;

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ccc");
        }
    }
}
#endif
```


##\#region,\#endregion  
Visual Studioでは、\#region, \#endregionで囲んだ部分のコードは、たたむことが出来るようになる。  

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region hoge
namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {

            var list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i * i);
            }

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
        }
    }
}
#endregion
```


##ToString関数  
すべてのオブジェクトはtoStringメソッドを持ち、オブジェクトが文字列値として表されるべきときや、文字列が期待される構文で参照されたときに自動的に呼び出される。  

以下の例では、int型の変数をToStringメソッドを使って文字列に直している。  

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 123;
            int num2 = 456;

            string str = num1.ToString() + num2.ToString();

            Console.WriteLine(str);
        }
    }
}
```


ToStringメソッドを使えば書式を指定して出力することができる。  
以下の例では、小数点以下の桁数を指定して出力している。  

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = 3.14159;

            //普通に出力
            Console.WriteLine(num);

            //小数点以下の桁数を指定して出力
            Console.WriteLine(num.ToString("F3"));
        }
    }
}

```

##Parse関数  
(基本型).Parseで文字列を(基本型)に変換することが出来る。  
int.Parse(str)で文字列をintに変換可能。  

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            int hoge = 10;
            hoge += int.Parse("3");
            Console.WriteLine(hoge);
        }
    }
}
```


double.Parse(str)で文字列をdoubleに変換可能。  

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            double num;
            num = double.Parse("3.14");
            Console.WriteLine(num);
        }
    }
}
```

##Mathクラス  
Cos, Sinなど数学関連が入っている。

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Math.Sin(Math.PI / 4));
        }
    }
}
```

##参照渡し・値渡し  

C#では、基本型は値渡し、クラスは参照渡しである。  

基本型とは、int, float, double, string, boolなどである。  

以下の例では、関数に基本型であるstringを渡しているので、参照渡しとなっており、main内のstrは書き換えられず、```abc```と出力される。  


```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace csharp_console_test
{
    class Program
    {
        static void twi_string(string str)
        {
            str = str + str;
        }

        static void Main(string[] args)
        {
            string str = "abc";
            Program.twi_string(str);
            Console.WriteLine(str);
        }
    }
}
```


以下の例では、関数でクラスを参照渡ししているので、```abcabc```と出力される。  
（関数内で、main内の、obj本体が書き換えられる。）

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Hoge
{
    public string str;
    public Hoge(string str)
    {
        this.str = str;
    }
}

namespace csharp_console_test
{
    class Program
    {
        static void twi_string(Hoge obj)
        {
            obj.str = obj.str + obj.str;
        }

        static void Main(string[] args)
        {
            var obj = new Hoge("abc");
            twi_string(obj);
            Console.WriteLine(obj.str);
        }
    }
}


```


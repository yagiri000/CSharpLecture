#C#講座資料 vol_4  

vol_4は、C#のプロパティ・ラムダ式・LINQに関する資料です。  
vol_4のプログラムは、コンソール上で動かすことを想定しています。  
（コンソール アプリケーションで作って下さい。）

##プロパティ  
規模の大きいプログラミングを行うと、オブジェクトの値を取得したいが、外から変更できないようにしたい場合がある。  
そのようなときに、C++では、値をprivateにし、値を得るための関数を別に用意していたと思う。  
以下に例を示す。  
Func関数が何回呼ばれたかを保存するcountCallFunc変数は、外部から取得はしたいが、変更はされたくない。  
よって、countCallFuncはprivateにし、getter（取得する関数の総称）関数だけを用意した。  

```cs
using System;
using System.Collections.Generic;
using System.Text;

class Hoge
{
    public int countCallFunc;
    public Hoge()
    {
        this.countCallFunc = 0;
    }
    public void Func()
    {
        countCallFunc++;
    }
    public int getCountCallFunc()
    {
        return countCallFunc;
    }
}

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            var ins = new Hoge();
            
            for(int i = 0; i < 5; i++){
                ins.Func();
            }

            Console.WriteLine(ins.getCountCallFunc());
        }
    }
}
```

しかし、いちいちgetter関数を用意するのは面倒である。そのようなときに使用するのがプロパティである。
プロパティを使うことによって、外部からは変数と同じようにアクセスすることが出来、値の取得、設定の可能、不可能が設定できる変数を作ることが出来る。

```cs
using System;
using System.Collections.Generic;
using System.Text;

class Hoge
{
    public int countCallFunc;
    public Hoge()
    {
        this.countCallFunc = 0;
    }
    public void Func()
    {
        countCallFunc++;
    }
    public int CountCallFunc
    {
        get { return countCallFunc; }
    }
}

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            var ins = new Hoge();
            
            for(int i = 0; i < 5; i++){
                ins.Func();
            }

            Console.WriteLine(ins.CountCallFunc);
        }
    }
}
```

標準ライブラリのオブジェクトにもプロパティは使われている。  
例えば、ListのCountもプロパティである。  
プロパティによって、オブジェクト指向のカプセル化を実現することが出来る。  

「右クリック→リファクタ→フィールドのカプセル化」から自動生成することも出来る。  

* 書き方  

```cs
private int val;//クラスのメンバ変数
public int Val
{
    get { return val; }
    set { val = value; }//valueは予約語で、外から渡される変数
}
```


##ラムダ式  
ラムダ式を使用することで、名前の無い関数を作ることが出来る。  

動的配列の要素を削除するRemoveAll関数があるが、この関数は引数に「要素を削除するかどうかを判定する関数」をとる。  
「要素を削除するかどうかを判定する関数」は、他の場所で使うことはまずないと思われるし、定義と実際に使う場所が離れているとプログラムの見通しが悪くなる。  
よって、そのようなときにラムダ式を使用し、RemoveAll関数の引数内に直接関数を生成する。  

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
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            foreach (var i in list)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            list.RemoveAll(x => x % 2 == 0);

            foreach (var i in list)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
```

上の例の、

```cshrap
x => x % 2 == 0
```

という関数は、

```cshrap
bool compare(int x){
    return x % 2 == 0;
}
```

と同じである。  



##LINQ  
LINQとは、データベース操作を行うことが出来る機能のこと。

##LINQ_Where  
条件に合うもののみを返す。  

```cs
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new string[]{"sunday", "monday", "tuesday", "wednesday"};
            var list2 = list.Where(x => x.Contains("n"));
            foreach (var i in list2)
            {
                Console.WriteLine(i);
            }
        }
    }
}
```
  

##LINQ_Select  
Selectは、配列の中のクラスの特定のメンバのみの配列を作る事が出来ます。

```cs
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Vector3
{
    public double x;
    public double y;
    public double z;
    public Vector3(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Vector3>();
            for (int i = 0; i < 5; i++)
            {
                list.Add(new Vector3(10 - i, i, i * i));
            }

            foreach (var i in list)
            {
                Console.WriteLine(i.x + " " + i.y + " " + i.z);
            }
            Console.WriteLine();

            foreach (var i in list.Select( p => p.x))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

        }
    }
}
```
  

##LINQ_OrderBy  
OrderByは、クラスの中の特定のメンバを基準に並び替えた配列を返す。  

```cs
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Vector3
{
    public double x;
    public double y;
    public double z;
    public Vector3(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}

namespace csharp_console_test
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Vector3>();
            for (int i = 0; i < 5; i++)
            {
                list.Add(new Vector3(10 - i, i, i * i));
            }

            foreach (var i in list)
            {
                Console.WriteLine(i.x + " " + i.y + " " + i.z);
            }
            Console.WriteLine();

            foreach (var i in list.OrderBy(p => p.x))
            {
                Console.WriteLine(i.x + " " + i.y + " " + i.z);
            }
            Console.WriteLine();

            foreach (var i in list.OrderBy(p => p.y))
            {
                Console.WriteLine(i.x + " " + i.y + " " + i.z);
            }
            Console.WriteLine();

            foreach (var i in list.OrderBy(p => p.z))
            {
                Console.WriteLine(i.x + " " + i.y + " " + i.z);
            }
            Console.WriteLine();

        }
    }
}
```

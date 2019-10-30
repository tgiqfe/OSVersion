# OSVersion

## 使い方

自分のPCのOSバージョンを取得
```csharp
OSVersion thisPC = OSVersion.GetThisPC();
```

Windows 10 Ver. 1511 (November Update) と比較して、それより新しイバージョンかどうか  
&lbrack;OSVersion&rbrack;クラス同士の比較
```csharp
OSVersion os1511 = new OSVersion(1511);
if (thisPC > os1511)
{
    Console.WriteLine("このPCは、バージョン1511より新しいです。");
}
```

Windows 10 Ver. 1607 (Aniverssary Update) と比較して、それより新しイバージョンかどうか  
&lbrack;OSVersion&rbrack;クラスと、&lbrack;OSVersion&rbrack;クラスの定数との比較
```csharp
if (thisPC > OSVersion.v1607)
{
    Console.WriteLine("このPCは、バージョン1607より新しいです。");
}
```

&lbrack;OSVersion&rbrack;クラスとintとの比較
```csharp
if (thisPC != 1511)
{
    Console.WriteLine("このPCは、バージョン1703ではありません。");
}
```
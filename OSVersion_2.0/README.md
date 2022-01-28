# OSVersion2

## 取得

自分のPCのOSバージョンを取得
```csharp
OSInfo thisPC = OSVersion.GetCurrent();
```

指定したバージョンを取得  
```csharp
//  OSバージョンシリアルから
OSInfo v1607 = OSVersion.GetWindows(1607);

//  OSバージョン名から
OSInfo v1703 = OSVersion.GetWindows("1703");

//  OSバージョン名のその他の名前(コードネーム等)から
OSInfo v1709 = OSVersion.GetWindows("Fall Creators Update");
```

## 比較

Windows 10 Ver. 1511 (November Update) と比較して、それより新しいバージョンかどうか  
&lbrack;OSInfo&rbrack;インスタンス同士の比較
```csharp
OSInfo os1511 = OSVersion.GetWindows(1511);
if (thisPC > os1511)
{
    Console.WriteLine("このPCは、バージョン1511より新しいです。");
}
```

&lbrack;OSInfo&rbrack;インスタンスとintとの比較
```csharp
if (thisPC != 1511)
{
    Console.WriteLine("このPCは、バージョン1703ではありません。");
}
```


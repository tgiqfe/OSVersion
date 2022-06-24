# OSVersion

## 取得

```csharp
//  自分のPCのOSバージョンを取得
var winOS = WindowsFunctions.GetCurrent();

//	特定バージョンを取得
var v1903 = Windows10.Create1903();
```

## 比較

OSバージョン同士を比較
```csharp
var winOS = WindowsFunctions.GetCurrent();
var v1903 = Windows10.Create1903();
var v21H2 = Windows10.Create21H2();

Console.WriteLine($"winOS > v1903 = {winOS > v1903}");
Console.WriteLine($"winOS == v21H2 = {winOS == v21H2}");
```
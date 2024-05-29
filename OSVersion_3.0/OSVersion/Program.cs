using OSVersion;
using OSVersion.Lib.OSVersion;
using OSVersion.Lib.OSVersion.Windows;

//  実行中PCのOSバージョンを取得
var current = WindowsFunctions.GetCurrent();
Console.WriteLine(current);

//  バージョン指定
var v1903 = Windows10.Create1903();
var v21H2 = Windows10.Create21H2();
var winSV2012R2 = WindowsServer.Create2012R2();
var winSV2016 = WindowsServer.Create2016();

Console.WriteLine($"Current > v1903 = {current > v1903}");
Console.WriteLine($"Current == v21H2 = {current == v21H2}");
Console.WriteLine($"Current > winSV2016 = {current > winSV2016}");
Console.WriteLine($"Current <= winSV2016 = {current <= winSV2016}");

//  OSバージョン範囲を比較
bool ret = WindowsFunctions.WithinOS(current, "v1507~v21H2");
Console.WriteLine($"v1507~v21H2 => {ret}");

//  キーワードからOSを取得
var v1703 = WindowsFunctions.FromKeyword("Windows 10 v1703");
var v1709 = WindowsFunctions.FromKeyword("v1709");
Console.WriteLine(v1703);
Console.WriteLine(v1709);
Console.WriteLine($"v1703 < v1709 => {v1703 < v1709}");

Console.ReadLine();

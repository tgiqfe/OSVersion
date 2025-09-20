
using OSVersion;
using OSVersion.Versions;

var versions = OSVersions.Load();
var current = versions.GetCurrent();

//  Windows 11 23H2 のPCで実行した場合
string range1 = "Windows 10, Windows 11";   //  true
string range2 = "Windows 11~";              //  true
string range3 = "Windows 10~Windows 11";    //  false ※同バージョンで比較しないとダメ
string range4 = "~Windows 11";              //  true
string range5 = "Windows 10~, Windows 11~"; //  true
string range6 = "Windows 11 21H2~23H2";     //  true

Console.WriteLine(current);
Console.WriteLine("[" + versions.Within(range1, current).ToString() + "] " + range1);
Console.WriteLine("[" + versions.Within(range2, current).ToString() + "] " + range2);
Console.WriteLine("[" + versions.Within(range3, current).ToString() + "] " + range3);
Console.WriteLine("[" + versions.Within(range4, current).ToString() + "] " + range4);
Console.WriteLine("[" + versions.Within(range5, current).ToString() + "] " + range5);
Console.WriteLine("[" + versions.Within(range6, current).ToString() + "] " + range6);

Console.ReadLine();
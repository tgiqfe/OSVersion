using OSVersion;
using OSVersion.Lib;

var current = OSInfo.GetCurrent("Sample") as WindowsOS;

var v1903 = Windows10.Create1903();
var v21H2 = Windows10.Create21H2();

Console.WriteLine($"Current > v1903 = {current > v1903}");
Console.WriteLine($"Current == v21H2 = {current == v21H2}");

Console.ReadLine();

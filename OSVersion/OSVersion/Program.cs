using OSVersion;
using OSVersion.Lib.OSVersion;
using OSVersion.Lib.OSVersion.Windows;


var collection = OSCollection.Load("sample\\test.json");

var current = WindowsFunctions.GetCurrent(collection);


var v1903 = Windows10.Create1903();
var v21H2 = Windows10.Create21H2();
var winSV2012R2 = WindowsServer.Create2012R2();
var winSV2016 = WindowsServer.Create2016();

Console.WriteLine($"Current > v1903 = {current > v1903}");
Console.WriteLine($"Current == v21H2 = {current == v21H2}");
Console.WriteLine($"Current > winSV2016 = {current > winSV2016}");
Console.WriteLine($"Current <= winSV2016 = {current <= winSV2016}");


bool ret = WindowsFunctions.WithinOS(collection, current, "v1507~v21H2");

Console.WriteLine($"v1507~v21H2 => {ret}");



Console.ReadLine();

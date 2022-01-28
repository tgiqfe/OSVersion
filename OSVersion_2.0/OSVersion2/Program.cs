using OSVersion2.OS.Windows;
using OSVersion2.OS;

var _1903 = Windows10.Create1903(Edition.Home);
var _2004 = Windows10.Create2004(Edition.Home);

Console.WriteLine("イコール: {0}", _1903 == _2004);
Console.WriteLine("ノットイコール: {0}", _1903 != _2004);
Console.WriteLine("大なり: {0}", _1903 > _2004);
Console.WriteLine("小なり: {0}", _1903 < _2004);
Console.WriteLine("大なりイコール: {0}", _1903 >= _2004);
Console.WriteLine("小なりイコール: {0}", _1903 <= _2004);
Console.WriteLine("--------");

var thisOS = OSVersion.GetCurrent();
Console.WriteLine(thisOS);
Console.WriteLine("thisOS < v2004 : {0}", thisOS < 2004);
Console.WriteLine("--------");

OSInfoCollection collection = new OSInfoCollection();
collection.LoadDefault();
foreach (var osInfo in collection)
{
    Console.WriteLine(osInfo);
}

OSInfo _1507 = OSVersion.GetWindows(1507);
Console.WriteLine(_1507);
OSInfo _1703 = OSVersion.GetWindows("Creators Update");
Console.WriteLine(_1703);
OSInfo _1803 = OSVersion.GetWindows("1803");
Console.WriteLine(_1803);
OSInfo _2008R2 = OSVersion.GetWindowsServer("2008R2");
Console.WriteLine(_2008R2);
OSInfo _2019 = OSVersion.GetWindowsServer(1809);
Console.WriteLine(_2019);


Console.ReadLine();
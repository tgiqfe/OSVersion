
namespace OSVersion.Lib
{
    [Flags]
    internal enum OSFamily
    {
        None = 0,
        Windows = 1,
        Mac = 2,
        Linux = 4,
    }
}

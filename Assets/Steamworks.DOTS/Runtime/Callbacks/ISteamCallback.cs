
namespace Steamworks
{
    public interface ISteamCallback 
    {
        /// <summary>
        /// Gives us a generic way to get the CallbackId of structs
        /// </summary>
        CallbackType CallbackType { get; }
        int DataSize { get; }
    }
}
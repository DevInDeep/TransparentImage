using System;

namespace TransparentImage.Common
{
    public static class Utils
    {
        public static void TryExecute(Action action, Action<string> onError)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                onError(ex.Message);
            }
        }
    }
}

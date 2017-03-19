using System;

namespace Tehas.Utils.Except
{
    public class ReHouseException:Exception
    {
        public ReHouseException()
        {
        }

        public ReHouseException(string message) : base(message)
        {
        }

        public ReHouseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
namespace SquadGame.Api.Base.Exceptions
{
    public abstract class ExceptionBase : Exception
    {
        protected ExceptionBase(string message) : base(message)
        {
        }

        protected ExceptionBase(string message, object extraData) : base(message)
        {
            ExtraData = extraData;
        }

        protected ExceptionBase(string message, object extraData, Exception innerException) : base(message,
            innerException)
        {
            ExtraData = extraData;
        }

        //Any extra data that might be helpful for consumers (other systems, web UI etc)
        public object ExtraData { get; protected set; }

        public abstract int StatusCode { get; }
    }
}

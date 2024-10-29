namespace WebAPIHotelsBooking.Infrastructure.Exceptions
{
    public class UnsupportedRepositoryTypeException : Exception
    {
        public UnsupportedRepositoryTypeException(string typeName) 
            : base($"Unsupported repository type was used: '{typeName}'") { }
    }
}

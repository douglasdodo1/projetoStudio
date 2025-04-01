public class RepositoryException : Exception {
    public int StatusCode { get; set; }
    public RepositoryException(string message, int statusCode) : base(message) {
        StatusCode = statusCode;
    }
    public RepositoryException(string message, int statusCode ,Exception innerException) : base(message, innerException) {
        StatusCode = statusCode;
    }
}
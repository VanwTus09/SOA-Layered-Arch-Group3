namespace MovieSeries.CommonLayer
{
    public class ErrorHandler
    {
        public static string GetErrorMessage(Exception ex)
        {
            return ex.Message;
        }
    }
}

namespace KTPO4310.Shelehov.Lib.LogAn;

public class WebServiceFactory
{
    private static IWebService _webService;

    public static void SetManager(IWebService webService)
    {
        _webService = webService;
    }

    public static IWebService Create()
    {
        if (_webService != null)
        {
            return _webService;
        }
        return new WebService();
    }
}

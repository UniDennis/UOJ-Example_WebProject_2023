using IBMU2.UODOTNET;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UOJ_Example_WebProject_2023.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel>? _logger;

        //public IndexModel(ILogger<IndexModel> logger) => _logger = logger;


        private string strMessage = "";
        private string strResponse = "";

		private readonly UOJUniware ee = new();
        private UniSession? uniSession;


        public IndexModel() 
        {
            uniSession = ee.pSession;
        }

        public string Message<T>()
        { return strMessage; }

        public void SetMessage(string message) { strMessage = message; }

        //public UniSession UniSession { get => uniSession; }



        public void OnGet()
        {
            if( uniSession != null)
            {
                strMessage = "Seems to be connected.";
            }
            else
            {
                strMessage = "uniSession is null.";
            }
        }

        public string GetMessage()
        {
            return strMessage;
        }
		public string GetQueryResponse()
		{
			return strResponse;
		}

		private string iQuery(string query)
        {
            //
            // WARNING THIS IS UNSANITIZED INPUT DATA
            //
            // EXPECT SOMEONE TO BREAK EVERYTHING
            //
            // DO NOT EVER DO THIS ON A PUBLIC SYSTEM
            //
            // HECK!  DON'T EVEN DO IT ON A PRIVATE SYSTEM
            //
            if (query.Contains("!")) { return "Nyet!";  }


            if (uniSession != null)
            {
                UniCommand myCommand = uniSession.CreateUniCommand();
                myCommand.Command = query;
                myCommand.Execute();
                strResponse = myCommand.Response.ToString();
                return strResponse.Replace(Environment.NewLine, "<br />");
            }
            else
            {
                strResponse = "Unable to process query.";
                return strResponse;
            }

        }

        public void OnPost(string myQuery)
        {
			strResponse = iQuery(myQuery);
        }

    }
}
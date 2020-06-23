using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloASPDotNET.Controllers
{
    [Route("/helloworld/")]
    public class HelloController : Controller
    {
        //GET /<controller>/

        [HttpGet]
        public IActionResult Index()
        {
            string html = "<form method='post' action='/helloworld/'>" +
                              "<input type='text' name='name'/>" +
                              "<select id='languages'name='language'/>" +
                                "<option value='french'>French</>" +
                                "<option value='filipino'>Filipino</>" +
                                "<option value='japanese'>Japanese</>" +
                                "<option value='english'>English</>" +
                                "<option value='chamorro'>Chamorro</>" +
                              "</select>" +
                              "<input type='submit' value='Greet Me!'/>" +
                          "</form>";

            return Content(html, "text/html");
        }

        // POST
        [HttpGet("/welcome/{name?}")]
        [HttpPost]
        public IActionResult Welcome(string name="World", string language="english")
        {
            language = CreateMessage(language);
            return Content($"<h1>{language}, {name}! </h1>", "text/html");
        }

        public static string CreateMessage(string language)
        {
            var greetings = new Dictionary<string, string>
            {
                ["french"] = "Bonjuor",
                ["filipino"] = "Kamusta",
                ["japanese"] = "Konichiwa",
                ["english"] = "Hello",
                ["chamorro"] = "Hafa adai",
            };
            return greetings[language];
        }
    }
}

//      On 10.3.1 video "Controller with forms"

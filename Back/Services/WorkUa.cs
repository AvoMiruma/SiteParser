using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leaf.xNet;
using AngleSharp.Html;
using AngleSharp.Parser.Html;
using WorkParser.Entity;

namespace WorkParser.Back.Services
{
    public class WorkUa
    {
        /// <summary>
        /// Получить код сторінки
        /// </summary>
        public static string GetPage(string link)
        {
            var request = new HttpRequest();

            request.AddHeader(HttpHeader.AcceptLanguage, "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7,uk;q=0.6");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Cache-Control", "max-age=0");
            request.AddHeader("Host", "www.work.ua");
            request.AddHeader("Referer", link);
            request.AddHeader("Upgrade-Insecure-Requests", "1");
            request.AddHeader(HttpHeader.Accept, "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            request.KeepAlive = true;
            request.UserAgent = Http.ChromeUserAgent();

            string response = request.Get(link).ToString();
            return response;
        }

        /// <summary>
        /// Парс сторінки
        /// </summary>
        public static List<Vacancy> ParsPage(string responce)
        {
            var model = new List<Vacancy>();

            HtmlParser parser = new HtmlParser();
            var Doc = parser.Parse(responce);

            foreach (var temp in Doc.QuerySelectorAll("div.card.card-hover.card-visited.wordwrap.job-link"))
            {
                model.Add(new Vacancy 
                {
                    Position = temp.QuerySelector("a").TextContent,
                    Salary = temp.QuerySelector("b").TextContent,
                    Company = temp.QuerySelector("div.add-top-xs>span>b").TextContent,
                    Details = temp.QuerySelector("p.overflow.text-muted.add-top-sm.cut-bottom").TextContent
                });
            }

            return model;
        }

        /// <summary>
        /// Костиль для сортування вакансій
        /// </summary>
        public static List<Vacancy> Add(Vacancy vacancy)
        {
            var model = new List<Vacancy>();
            model.Add(vacancy);
            return model;
        }

    }
}

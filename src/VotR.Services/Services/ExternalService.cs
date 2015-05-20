using System.Collections.Generic;
using VotR.Services.Interfaces;
using System.Linq;
using VotR.Shared.Exceptions;
#if DNXCORE50
using System.Net.Http;
#else
using System.Net;
using System.Threading.Tasks;
using System.Xml;
#endif
using System.Xml.Linq;
using System.IO;
using System.Text;
using VotR.Shared.Helpers;
using VotR.Services.DataContracts;

namespace VotR.Services.Services
{
    public class ExternalService : IExternalService
    {
        public List<SystemBolagetArticle> GetArticlesFromSystemBolaget(string url)
        {
            string data = string.Empty;

            data = GetReponseFromService(url);

            if (string.IsNullOrWhiteSpace(data))
                return new List<SystemBolagetArticle>();

            var xml = XDocument.Parse(data);
            var articles = new List<SystemBolagetArticle>();

            var d = xml.Descendants();

            var lastUpdateOfFile = d.Elements("skapad-tid").First().Value;
            if (string.IsNullOrEmpty(lastUpdateOfFile))
            {
                throw new ServiceException("No last updated field was not found in XML file.");
            }

            var xmlArticles = d.Elements("artikel");

            articles.AddRange(xmlArticles.Select(a => new SystemBolagetArticle
            {
                ArtNr = a.Element("Artikelid").CheckIfElementIsNull<string>(),
                Name = a.Element("Namn").CheckIfElementIsNull<string>(),
                Name2 = a.Element("Namn2").CheckIfElementIsNull<string>(),
                PriceWithVat = a.Element("Prisinklmoms").CheckIfElementIsNull<string>(),
                SaleStart = a.Element("Saljstart").CheckIfElementIsNull<string>(),
                SaleStop = a.Element("Slutlev").CheckIfElementIsNull<string>(),
                ArticleGroup = a.Element("Varugrupp").CheckIfElementIsNull<string>(),
                PackageType = a.Element("Forpackning").CheckIfElementIsNull<string>(),
                Origin = a.Element("Ursprung").CheckIfElementIsNull<string>(),
                OriginCountry = a.Element("Usprungsland").CheckIfElementIsNull<string>(),
                Producer = a.Element("Producent").CheckIfElementIsNull<string>(),
                Supplier = a.Element("Leverantor").CheckIfElementIsNull<string>(),
                Vintage = a.Element("Argang").CheckIfElementIsNull<string>(),
                TestedVintage = a.Element("Provadargang").CheckIfElementIsNull<string>(),
                Alcohol = a.Element("Alkoholhalt").CheckIfElementIsNull<string>(),
                Range = a.Element("Sortiment").CheckIfElementIsNull<string>(),
                Ecologic = a.Element("Ekologisk").CheckIfElementIsNull<string>(),
                Koscher = a.Element("Koscher").CheckIfElementIsNull<string>(),
                DescriptionRaw = a.Element("RavarorBeskrivning").CheckIfElementIsNull<string>(),
            }));

            return articles;
        }

        public string GetReponseFromService(string url)
        {
            Stream stream = null;
#if DNXCORE50
            var client = new HttpClient();
            stream = client.GetStreamAsync(url).Result;
#else
            var client = WebRequest.Create(url);
            var response = client.GetResponse();
            stream = response.GetResponseStream();
#endif
            
            if (stream == null)
                return null;

            var reader = new StreamReader(stream);

            // Read the whole contents and return as a string  
            var s = reader.ReadToEnd();
            return s;
        }
    }
}

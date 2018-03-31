using EPiServer;
using EPiServer.Personalization.CMS.Model;
using EPiServer.Personalization.CMS.Recommendation;
using EPiServer.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using EPiServer.Web.Mvc.Html;
using EPiServer.Web.Routing;

namespace Episerver.Recommendations.SampleBlock
{
    public class RecommendationsController : ApiController
    {
        private IRecommendationService _recommendationService;
        
        // POST api/recommendations
        [HttpPost]
        [ActionName("getrecommendations")]
        public string GetRecommendations(ApiRecommendationReques request)
        {
            _recommendationService = ServiceLocator.Current.GetInstance<IRecommendationService>();

            var rRequest = new RecommendationRequest
            {
                siteId = request.siteId,
                context = new Context { contentId = request.contentId, languageId = request.languageId },
                numberOfRecommendations = request.numberOfRecommendations == 0 ? 3 : request.numberOfRecommendations
            };

            var context = Request.Properties["MS_HttpContext"] as HttpContextWrapper;

            var task = Task.Run<IEnumerable<RecommendationResult>>(async () => await _recommendationService.Get(context, rRequest));

            var recommendationResults = task.Result;
            var htmlResult = new StringBuilder();
            if (recommendationResults != null)
            {
                htmlResult.Append("<h2>Recommendations</h2>");
                htmlResult.Append("<ul>");
                var urlResolver = ServiceLocator.Current.GetInstance<IUrlResolver>();

                foreach (var result in recommendationResults)
                {
                    var friendlyUrl = urlResolver.GetUrl(result.Content.ContentLink);
                    htmlResult.Append($"<li><a onmouseup=\"Misc && Misc.setCookie('EPiServer_CMS_RecommendationId', '{result.RecommendationId}', 60);\" href=\"{friendlyUrl}\">{result.Content.Name}</a></li>");
                }
                htmlResult.Append("</ul>");
            }

            return htmlResult.ToString();
        }
    }

    public class ApiRecommendationReques
    {
        public string contentId { get; set; }
        public string siteId { get; set; }
        public string languageId { get; set; }
        public int numberOfRecommendations { get; set; }
    }
}

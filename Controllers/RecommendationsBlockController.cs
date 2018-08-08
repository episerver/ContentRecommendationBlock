using System.Web.Mvc;
using Episerver.Recommendations.SampleBlock.Model;
using EPiServer;
using EPiServer.Core;
using EPiServer.Personalization.CMS.Recommendation;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;

namespace Episerver.Recommendations.SampleBlock.Controllers
{
    public class RecommendationsBlockController : BlockController<RecommendationsBlock>
    {
        private readonly IPageRouteHelper _pageRouteHelper;
        private readonly IContentLoader _contentLoader;
        private readonly IRecommendationService _recommendationService;

        protected PageData CurrentPage
        {
            get
            {
                var pageRouteHelper = ServiceLocator.Current.GetInstance<IPageRouteHelper>();
                return pageRouteHelper.Page;
            }
        }

        public RecommendationsBlockController(IPageRouteHelper pageRouteHelper,
                            IContentLoader contentLoader,
                            IRecommendationService recommendationService)
        {
            _pageRouteHelper = pageRouteHelper;
            _contentLoader = contentLoader;
            _recommendationService = recommendationService;
        }

        // GET: RecommendationsBlock
        public override ActionResult Index(RecommendationsBlock currentContent)
        {
            var model = new RecommendationsBlockModel
            {
                ContentId = CurrentPage.ContentGuid.ToString(),
                SiteId = SiteDefinition.Current.Id.ToString(),
                LanguageId = CurrentPage.Language.Name,
                NumberOfRecommendations = currentContent.NumberOfRecommendations
            };
            
            return PartialView(model);
        }
    }
}
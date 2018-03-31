using System.Web.Mvc;
using EPiServer.Web.Routing;
using EPiServer;
using EPiServer.Web;
using EPiServer.Personalization.CMS.Recommendation;
using EPiServer.Web.Mvc;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using Episerver.Recommendations.SampleBlock.Model;

namespace Episerver.Recommendations.SampleBlock
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
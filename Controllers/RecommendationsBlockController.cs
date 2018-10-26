using System.Web.Mvc;
using Episerver.Recommendations.SampleBlock.Model;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;

namespace Episerver.Recommendations.SampleBlock.Controllers
{
    public class RecommendationsBlockController : BlockController<RecommendationsBlock>
    {
        protected PageData CurrentPage
        {
            get
            {
                var pageRouteHelper = ServiceLocator.Current.GetInstance<IPageRouteHelper>();
                return pageRouteHelper.Page;
            }
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
using EPiServer.ServiceLocation;
using EPiServer.Tracking.PageView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Episerver.Recommendations.SampleBlock.Services
{
    /// <summary>
    /// Tracks clicks on the recommended products.
    /// </summary>
    /// <remarks>This class uses cookie to store recommendation id.</remarks>
    [ServiceConfiguration(ServiceType = typeof(IRecommendationContext), Lifecycle = ServiceInstanceScope.Singleton)]
    public class RecommendationContext : IRecommendationContext
    {
        /// <summary>
        /// Gets the id of the recommendation that was clicked to initiate the current request.
        /// </summary>
        /// <param name="context">The current http context.</param>
        /// <returns>The recommendation id, or 0 if the current request was not initiated by clicking on a recommendation.</returns>
        public string GetCurrentRecommendationId(HttpContextBase context)
        {
            var recommendationCookieId = "EPiServer_CMS_RecommendationId";
            string recommendationId = HttpContext.Current.Request.Cookies[recommendationCookieId]?.Value;
         
                        
            var cookie = new HttpCookie(recommendationCookieId, null) { Expires = DateTime.Now.AddYears(-1) };
            HttpContext.Current.Response.Cookies.Add(cookie);
            HttpContext.Current.Request.Cookies.Remove(recommendationCookieId);

            return recommendationId;
        }
    }
}

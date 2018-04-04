using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Episerver.Recommendations.SampleBlock.Model
{
    public class RecommendationsBlockModel
    {
        public string SiteId { get; set; }
        public string ContentId { get; set; }
        public string LanguageId { get; set; }
        public int NumberOfRecommendations { get; set; }

    }
}

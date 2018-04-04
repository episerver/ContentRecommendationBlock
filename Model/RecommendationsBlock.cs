using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace Episerver.Recommendations.SampleBlock.Model
{
    [ContentType(DisplayName = "Recommendations list", GUID = "91C9388C-3C32-4FCF-9085-8A65330898DF", Description = "List of recommendation contents of the parent content.")]
    public class RecommendationsBlock : BlockData
    {
        [Display(Name = "Number of recommendations")]
        public virtual int NumberOfRecommendations { get; set; }
    }
}
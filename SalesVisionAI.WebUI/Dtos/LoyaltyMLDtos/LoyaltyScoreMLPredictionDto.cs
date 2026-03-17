using Microsoft.ML.Data;

namespace SalesVisionAI.WebUI.Dtos.LoyaltyMLDtos
{
    public class LoyaltyScoreMLPredictionDto
    {
        [ColumnName("Score")]
        public float LoyaltyScore { get; set; }
    }
}

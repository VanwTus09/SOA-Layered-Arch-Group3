using MovieSeries.CoreLayer.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MovieSeries.BusinessLayer
{
    public class RatingCalculator
    {
        public static decimal CalculateAverageRating(IEnumerable<Review> reviews)
        {
            if (reviews == null || !reviews.Any())
                return 0;
            return (decimal)reviews.Average(r => r.ReviewDate.Ticks);
        }
    }
}

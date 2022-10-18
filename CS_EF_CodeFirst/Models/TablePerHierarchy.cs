using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_CodeFirst.Models
{
    /// <summary>
    /// Base Type with General Attributes
    /// </summary>
    public abstract class ProductionUnit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
    }

    public class Movies : ProductionUnit
    {
        public string Category { get; set; }
        public int PlayDuration { get; set; }
        public double BoxOfficeCollection { get; set; }
    }

    public class WebSeries : ProductionUnit
    {
        public int Seasons { get; set; }
        public int EpisodPerSeason { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometey.Entities
{
    [Serializable]
    public class Culture:Base
    {
        public Culture() { }
    /// <summary>
    /// Конструктор с одним параметром
    /// </summary>
    /// <param name="Name"></param>
        public Culture(string Name)
        {
            this.Name = Name;
        }
      /// <summary>
      /// прайсовая цена
      /// </summary>
        public double Price { get; set; }
        public Analysis Analysis;
/// <summary>
/// количество товара
/// </summary>
        public double Count { get; set; }
        /// <summary>
        /// Id анализа
        /// </summary>
        private Guid analysisId;

        public Guid GetAnalysisId()
        {
            return analysisId;
        }

        public void SetAnalysisId(Analysis analysis)
        {
            analysisId = analysis.Id;
        }
    }
}

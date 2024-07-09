namespace RealEstate_Dapper_Api.Dtos.CategoryDtos
{
    /// <summary>
    /// DTO: Data Transfer Object. 
    /// Veri katmanı ile iş mantığı veya sunum katmanı arasında veri taşımak için kullanılan basit bir nesnedir.
    /// </summary>
    public class ResultCategoryDto
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
    }
}

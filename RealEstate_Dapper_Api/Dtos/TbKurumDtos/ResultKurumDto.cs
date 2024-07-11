namespace RealEstate_Dapper_Api.Dtos.TbKurumDtos
{
    /// <summary>
    /// DTO: Data Transfer Object. 
    /// Veri katmanı ile iş mantığı veya sunum katmanı arasında veri taşımak için kullanılan basit bir nesnedir.
    /// </summary>
    public class ResultKurumDto
    {
        public int KurumID { get; set; }
        public string KurumAdi { get; set; }
    }
}

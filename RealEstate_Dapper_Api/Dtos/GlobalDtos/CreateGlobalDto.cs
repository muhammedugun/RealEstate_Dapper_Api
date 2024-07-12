namespace RealEstate_Dapper_Api.Dtos.GlobalDtos
{
    public class CreateGlobalDto
    {
        public int GlobalID { get; set; }
        public string GlobalAdi { get; set; }
        public int GlobalTip { get; set; }
        public string Aciklama { get; set; }
        public int KurumID { get; set; }
    }
}

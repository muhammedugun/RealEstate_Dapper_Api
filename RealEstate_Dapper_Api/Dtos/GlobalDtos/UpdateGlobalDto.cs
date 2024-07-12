namespace RealEstate_Dapper_Api.Dtos
{
    public class UpdateGlobalDto
    {
        public int GlobalID { get; set; }
        public string GlobalAdi { get; set; }
        public int GlobalTip { get; set; }
        public string Aciklama { get; set; }
        public int KurumID { get; set; }
    }
}

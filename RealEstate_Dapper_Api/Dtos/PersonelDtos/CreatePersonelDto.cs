namespace RealEstate_Dapper_Api.Dtos.PersonelDtos
{
    public class CreatePersonelDto
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string PersonelAdi { get; set; }
        public int BirimID { get; set; }
        public int? KurumID { get; set; }
        public int? UnvanID { get; set; }
        public DateTime? SonGirisTarihi { get; set; }
        public bool? BoAdmin { get; set; }
        public bool? BoAktif { get; set; }
        public bool? BoKontrolMuhendisiMi { get; set; }
    }
}

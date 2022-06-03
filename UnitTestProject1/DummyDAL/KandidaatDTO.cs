namespace DataTransferObjects
{
    public class KandidaatDTO
    {
        public string KandidaatNaam { get; set; }
        public int KandidaatID { get; set; }

        public KandidaatDTO(string naam, int ID)
        {
            KandidaatNaam = naam;
            KandidaatID = ID;
        }
        public KandidaatDTO() { }
    }
}
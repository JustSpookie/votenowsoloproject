namespace DataTransferObjects
{
    public class VerkiezingDTO
    {
        public int VerkiezingID;
        public string VerkiezingNaam;
        public int UserID;


        public VerkiezingDTO(int verkiezingID, string verkiezingnaam)
        {
            VerkiezingID = verkiezingID;
            VerkiezingNaam = verkiezingnaam;
        }
        
        public VerkiezingDTO() { }
    }
}

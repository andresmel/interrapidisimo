namespace universidad.Models.Dtos
{
    public class responseApi
    {
        public int status { get; set; }

        public dynamic ?data { get; set; }
        public string ?mensaje { get; set; }
    }
}

namespace Company_telephone_directory.Models
{
    public class Division
    {
        public int id { get; set; }
        public string title { get; set; }
        public int parent_id { get; set; }

        public Division(int id, string title, int parent_id)
        {
            this.id = id;
            this.title = title;
            this.parent_id = parent_id;
        }
    }
}

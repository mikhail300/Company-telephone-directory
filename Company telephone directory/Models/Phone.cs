namespace Company_telephone_directory.Models
{
    public class Phone
    {
        public int id { set; get; }
        public string type { set; get; }
        public string number { set; get; }
        public int emploee_id { set; get; }

        public Phone(int id, string type, string number, int emploee_id)
        {
            this.id = id;
            this.type = type;
            this.number = number;
            this.emploee_id = emploee_id;
        }
    }
}

namespace Company_telephone_directory.Models
{
    public class Emploee
    {
        public int id { get; set; }

        public int division_id { get; set; }

        public string job_title { get; set; }

        public string full_name { get; set; }

        public Emploee(int id, int division_id, string job_title, string full_name)
        {
            this.id = id;
            this.division_id = division_id;
            this.job_title = job_title;
            this.full_name = full_name;
        }
    }


}

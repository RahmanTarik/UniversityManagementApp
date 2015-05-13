namespace UniversityManagementApp.Model
{
   public class Student
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string RegNo { set; get; }
        public string Address { set; get; }
       public int DepartmentId { get; set; }
    }
}

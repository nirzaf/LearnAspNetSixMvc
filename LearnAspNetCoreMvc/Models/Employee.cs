namespace LearnAspNetCoreMvc.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //it will generate the full name of eployee
        public string FullName => FirstName + ' ' + LastName;

        public Department Department { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}

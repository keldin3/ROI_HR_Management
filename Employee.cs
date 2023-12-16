using SQLite;

public class Employee
{
    [PrimaryKey, AutoIncrement]

    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string ContactNumber { get; set; }
    public string Department { get; set; }
    public DateTime EmployeeStartDate { get; set; }
}


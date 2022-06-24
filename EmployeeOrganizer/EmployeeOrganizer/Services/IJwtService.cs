namespace EmployeeOrganizer.Services
{
    public interface IJwtService
    {
        public string CreateToken(string name);
    }
}

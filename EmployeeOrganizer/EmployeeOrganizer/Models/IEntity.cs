namespace EmployeeOrganizer.Models
{
    public interface IEntity
    {
        long Id { get; set; }
        string Name { get; set; }
        public bool Active { get; set; }
    }
}

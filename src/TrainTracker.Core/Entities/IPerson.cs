using System.ComponentModel.DataAnnotations;

namespace TrainTracker.Core.Entities
{
    public interface IPerson
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        [EmailAddress]
        string Email { get; set; }
    }
}

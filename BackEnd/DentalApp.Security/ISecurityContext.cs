using DentalApp.Data.Model;

namespace DentalApp.Security
{
    public interface ISecurityContext
    {
        User User { get; }

        bool IsAdministrator { get; }
    }
}

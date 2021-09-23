using Microsoft.AspNetCore.Mvc.Filters;

namespace DentalApp.Helpers
{
    public interface IActionTransactionHelper
    {
        void BeginTransaction();

        void EndTransaction(ActionExecutedContext filterContext);

        void CloseSession();
    }
}

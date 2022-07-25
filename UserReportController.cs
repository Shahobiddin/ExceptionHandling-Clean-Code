using ErrorHandling.Task1.ThirdParty;
using System;

namespace ErrorHandling.Task1
{
    public class UserReportController
    {
        private UserReportBuilder reportBuilder;

        public UserReportController(UserReportBuilder reportBuilder)
        {
            this.reportBuilder = reportBuilder;
        }

        public string GetUserTotalOrderAmountView(string userId, IModel model)
        {
            string report = String.Empty;

            try
            {
                report = GetUserTotalOrderAmountReport(userId);
            }
            catch (UserDaoNullException e)
            {
                return GetTechnicalErrorResponse();
            }
            catch (UserNotFoundException e)
            {
                report = "WARNING: User ID doesn't exist.";
            }
            catch (OrderNotFountException e)
            {
                report = "WARNING: User have no submitted orders.";
            }
            catch (NegativeOrderTotalValueException e)
            {
                report = "ERROR: Wrong order amount.";
            }

            return GetSuccessResponse(model, report);
        }

        private static string GetSuccessResponse(IModel model, string report)
        {
            model.AddAttribute("userTotalMessage", report);

            return "userTotal";
        }
        private static bool IsTechnicalError(string report) => report == null;
       
        private static string GetTechnicalErrorResponse() => "technicalError";

        private string GetUserTotalOrderAmountReport(string userId) => $"User Total: {reportBuilder.GetTotalOrderAmount(userId)}$";
    }
}

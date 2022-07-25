using System;
using System.Collections.Generic;
using System.Linq;
using ErrorHandling.Task1.ThirdParty;

namespace ErrorHandling.Task1
{
    public class UserReportBuilder
    {
        private readonly IUserDao userDao;

        public UserReportBuilder(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        public double GetTotalOrderAmount(string userId)
        {
            ValidateUserDao(userDao);

            var user = GetValidUser(userId);

            var orders = GetValidOrders(user);

            return GetOrderTotalAmount(orders);
        }

        private IUser GetValidUser(string userId)
        {
            IUser user = userDao.GetUser(userId);

            ValidateUser(user);

            return user;
        }

        private IList<IOrder> GetValidOrders(IUser user)
        {
            IList<IOrder> orders = user.GetAllOrders();

            ValidateOrder(orders);

            return orders;
        }

        private double GetOrderTotalAmount(IList<IOrder> orders)
        {
            var submittedTotalAmounts = orders.Where(w => w.IsSubmitted()).Select(s => s.Total());

            return HasAnyNegativeTotalInSubmittedOrders(submittedTotalAmounts)
                ? throw new NegativeOrderTotalValueException()
                : submittedTotalAmounts.Sum();
        }

        private bool HasAnyNegativeTotalInSubmittedOrders(IEnumerable<double> totals) => totals.Any(total => total < 0);

        private void ValidateUserDao(IUserDao userDao)
        {
            if (userDao is null)
            {
                throw new UserDaoNullException();
            }
        }

        private static void ValidateUser(IUser user)
        {
            if (user == null)
            {
                throw new UserNotFoundException();
            }
        }

        private static void ValidateOrder(IList<IOrder> value)
        {
            if (value is null || value.Count == 0)
            {
                throw new OrderNotFountException();
            }
        }
    }
}

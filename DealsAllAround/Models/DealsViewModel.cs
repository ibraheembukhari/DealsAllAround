using System;
using System.Collections.Generic;
using DealsAllAround.DataAccess;

namespace DealsAllAround.Models
{
    public class DealsViewModel
    {
        private IDealsProvider dealsProvider = new DealsProvider();
        private IUserInfoProvider userInfoProvider = new UserInfoProvider();

        public List<Deal> GetAllData()
        {
            return dealsProvider.GetAllData();
        }

        public void GetDetails(Deal deal)
        {
            dealsProvider.GetDetails(deal);
        }

        public void UpdateData(Deal deal)
        {
            dealsProvider.UpdateData(deal);
        }

        public Deal GetDetailById(int id)
        {
            return dealsProvider.GetDetailById(id);
        }

        public void DeleteData(Deal deal)
        {
            dealsProvider.DeleteData(deal);
        }

        public void Registeration(User user)
        {
            userInfoProvider.Registeration(user);
        }
    }
}

 
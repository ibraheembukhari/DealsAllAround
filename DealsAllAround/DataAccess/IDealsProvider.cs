using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealsAllAround.Models;

namespace DealsAllAround.DataAccess
{
    public interface IDealsProvider
    {
        List<Deal> GetAllData();
        void GetDetails(Deal deal);
        void UpdateData(Deal deal);
        Deal GetDetailById(int id);
        void DeleteData(Deal deal);
    }
}

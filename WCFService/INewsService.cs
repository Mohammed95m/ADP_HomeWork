using ADP_HomeWork.DataBase.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFService
{
     
    [ServiceContract]
    public interface INewsService
    {
        [OperationContract]
        List<News> GetLast10();

        [OperationContract]
        News GetSimilar(string title, string Abstract);

        [OperationContract]
        List<News> GetBestPositive(int n);

        [OperationContract]
        List<News> GetBestNegative(int n);

        [OperationContract]
        bool AddRank(int ID, int Rank);
    }

    
  
}

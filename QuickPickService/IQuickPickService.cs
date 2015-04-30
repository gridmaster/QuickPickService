using System.ServiceModel;
using QuickPickService.Models;
using QuickPickService.Models.Requests;
using QuickPickService.Models.ViewModels;

namespace QuickPickService
{
    [ServiceContract]
    public interface IQuickPickService
    {
        [OperationContract]
        string QuickPicks(int max, int picks, int pbmax, string faves, int pbfave, int tix);

        [OperationContract]
        string GetPerson(int id);

        [OperationContract]
        Person InsertPerson(Person[] person);
  
        [OperationContract]
        Person UpdatePerson(int id, Person person);

        [OperationContract]
        void DeletePerson(int id);
    }
}

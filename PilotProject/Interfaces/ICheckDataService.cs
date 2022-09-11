namespace PilotProject.Interfaces
{
    internal interface ICheckDataService
    {
        bool IsValidName(string name);
        bool IsValidEmail(string email);
        bool IsValidPass(string pass);
        bool IsValidAddress(string address);
        bool IsUniqueNameInDB(string name);
    }
}
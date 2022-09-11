namespace PilotProject.Interfaces
{
    internal interface IFileService<T1, T2>
    {
        string ReadFile(T1 fileName);
        void WriteFile(T1 fileName, T2 jsonString);
    }
}
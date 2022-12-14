namespace PilotProject.Interfaces
{
    internal interface ISerializeService<T1>
    {
        Task ObjectToJsonAsync<T2>(T1 file, T2 obj);
        Task<T2> JsonToObjectAsync<T2>(T1 file);
    }
}
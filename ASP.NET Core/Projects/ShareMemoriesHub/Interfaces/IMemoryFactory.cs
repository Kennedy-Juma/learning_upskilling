using ShareMemoriesHub.Models.Memories;

namespace ShareMemoriesHub.Interfaces
{
    public interface IMemoryFactory
    {
        Task<object> CreateMemoryAsync(Memory memory);
        Task<object> DeleteMemoryAsync(string Id);
    }
}

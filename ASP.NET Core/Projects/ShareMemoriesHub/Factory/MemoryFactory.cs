using ShareMemoriesHub.Helpers.DBContext;
using ShareMemoriesHub.Interfaces;
using ShareMemoriesHub.Models.Memories;

namespace ShareMemoriesHub.Factory
{
    public class MemoryFactory : IMemoryFactory
    {
        private ILoggerUtil logger;
        private ApplicationDbContext context;
        public MemoryFactory(ILoggerUtil _logger, ApplicationDbContext _context)
        {
            logger = _logger;
            context = _context;
        }

        public async Task<object> CreateMemoryAsync(Memory memory)
        {
            bool isCreated;
            if (memory == null)
            {
                isCreated = false;
            }
            memory.Tag.MemoryId = memory.Id;
            memory.Image.MemoryId = memory?.Id;

            try
            {
                if(!String.IsNullOrEmpty(memory.Tag.Id))
                {
                    context.Memories.Add(memories.Tag);
                }

                context.Memories.Add(memory);
                context.Tags.Add(memory.Tag);
                //context.Images.Add(memory.Image);
                await context.SaveChangesAsync();
                isCreated = true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.InnerException.ToString());
                isCreated = false;

            }
            return isCreated;
        }
        public async Task<object> DeleteMemoryAsync(string Id)
        {
            bool isDeleted = false;
            try
            {
                var memoryToDelete = await context.Memories.FindAsync(Id);
                if (memoryToDelete == null)
                {
                    return isDeleted;
                }
                context.Memories.Remove(memoryToDelete);
                await context.SaveChangesAsync();
                isDeleted = true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.InnerException.ToString());
                isDeleted = false;
            }
            return isDeleted;
        }
    }
}

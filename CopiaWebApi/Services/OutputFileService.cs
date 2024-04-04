using CopiaWebApi.Db;
using CopiaWebApi.Entities;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CopiaWebApi.Services
{

    public class OutputFileService
    {
        private readonly PaybrijDbContext _dbContext;

        public OutputFileService(PaybrijDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ActionResult<IEnumerable<OutputFile>>> GetOutputFiles()
        {
            return await _dbContext.OutputFiles.ToListAsync();
        }

        public async Task<OutputFile?> GetOutputFile(int id)
        {
            return await _dbContext.OutputFiles.FindAsync(id);
        }

        public async Task PostOutputFile(OutputFile data)
        {
            await _dbContext.OutputFiles.AddAsync(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task PutOutputFile(OutputFile outputFile)
        {
            _dbContext.Entry(outputFile).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteOutputFile(int id)
        {
            var result = await GetOutputFile(id);
            if (result == null)
            {
                return;
            }
            _dbContext.OutputFiles.Remove(result); // no async for remove
            await _dbContext.SaveChangesAsync();
        }
    }
}

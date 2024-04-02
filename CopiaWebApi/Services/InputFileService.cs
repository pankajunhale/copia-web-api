using CopiaWebApi.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CopiaWebApi.Entities;

namespace CopiaWebApi.Services
{
    public class InputFileService
    {
        private readonly PaybrijDbContext _dbContext;
        public InputFileService(PaybrijDbContext context) {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<InputFile>>> GetInputFiles()
        {
            return await _dbContext.InputFiles.ToListAsync();
        }

        public async Task<InputFile?> GetInputFile(int id)
        {
            var inputFile = await _dbContext.InputFiles.FindAsync(id);
            return inputFile;
        }

        public async Task PutInputFile(int id, InputFile inputFile)
        {
            _dbContext.Entry(inputFile).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();            
        }

        public async Task PostInputFile(InputFile inputFile)
        {
            await _dbContext.InputFiles.AddAsync(inputFile);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteInputFile(int id)
        {
            var inputFile = await GetInputFile(id);
            if (inputFile == null)
            {
                return;
            }            
            _dbContext.InputFiles.Remove(inputFile);
            await _dbContext.SaveChangesAsync();
        }

    }
}

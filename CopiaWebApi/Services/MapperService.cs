using CopiaWebApi.Db;
using CopiaWebApi.Entities;
using CopiaWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CopiaWebApi.Services
{
    public class MapperService
    {
        private readonly PaybrijDbContext _dbContext;
        public MapperService(PaybrijDbContext context) { 
            _dbContext = context;
        }

        public async Task<IEnumerable<InputOutputMappingInfo>> GetAll()
        {
          //  var query2 = await (_dbContext.InputOutputMappers
          //.Join(_dbContext.InputFiles,
          //    emp => emp.InputFiles.Id,
          //    per => per.Id,
          //    (emp, per) => new InputOutputMappingInfo(per.Id, emp.Id, 1))
          //.ToListAsync());

            //    .Join(departments, teacher => teacher.ID, department => department.TeacherID,
            //(teacher, department) =>
            //new { DepartmentName = department.Name, TeacherName = $"{teacher.First} {teacher.Last}" });
            var q = await (from m in _dbContext.InputOutputMappers
                           join i in _dbContext.InputFiles on m.InputFileId equals i.Id
                           join o in _dbContext.OutputFiles on m.OutputFileId equals o.Id
                           select new InputOutputMappingInfo()
                           {
                               Id = m.Id,
                               InputFileModelId = m.InputFileId,
                               OutputFileModelId = m.OutputFileId,
                               HeaderName = i.Name,
                               TagName = o.TagName
                           }
                           ).ToListAsync();
            return q;
        }

        public async Task<InputOutputMapper?> GetInfoById(int id)
        {
            var result = await _dbContext.InputOutputMappers.FindAsync(id);
            return result;
        }

        public async Task Update(InputOutputMapper entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Create(InputOutputMapper entity)
        {
            await _dbContext.InputOutputMappers.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetInfoById(id);
            if (entity == null)
            {
                return;
            }
            _dbContext.InputOutputMappers.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}

using CopiaWebApi.Db;
using CopiaWebApi.Entities;
using CopiaWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace CopiaWebApi.Services
{
    public class MapperService
    {
        private readonly PaybrijDbContext _dbContext;
        public MapperService(PaybrijDbContext context)
        {
            _dbContext = context;
        }

        public async Task<List<InputOutputMappingInfo>> GetAll()
        {
            var query = await (from m in _dbContext.InputOutputMappers
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
            return query;
        }

        public async Task<InputOutputMappingInfo> GetInfoById(int id)
        {
            var query = await (from m in _dbContext.InputOutputMappers
                               join i in _dbContext.InputFiles on m.InputFileId equals i.Id
                               join o in _dbContext.OutputFiles on m.OutputFileId equals o.Id
                               where m.Id == id
                               select new InputOutputMappingInfo()
                               {
                                   Id = m.Id,
                                   InputFileModelId = m.InputFileId,
                                   OutputFileModelId = m.OutputFileId,
                                   HeaderName = i.Name,
                                   TagName = o.TagName
                               }
                          ).SingleAsync();
            return query;
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
            var entity = await _dbContext.InputOutputMappers.SingleOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return;
            }
            _dbContext.InputOutputMappers.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<string> ProcessAndGenerateBankXml()
        {
            var data = await this.ProcessInputFileAndGenerateData();
            string output = JsonConvert.SerializeObject(data);
            Console.WriteLine(output);
            var bankXml = new StringBuilder();
            bankXml.Append("<?xml version='1.0' encoding='UTF-8'?>");
            bankXml.AppendLine("<Document xmlns='urn:iso:std:iso:20022:tech:xsd:pain.001.001.03' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>");
            bankXml.AppendLine("<CstmrCdtTrfInitn>");
            // bind header data
            foreach (var item in data.InputFileRowData)
            {
                Console.WriteLine(JsonConvert.SerializeObject(item));
                var headerInfo = this.GetHeaderTemplate();
                bankXml.AppendLine(headerInfo);
            }
            // bind details data
            bankXml.AppendLine("</CstmrCdtTrfInitn>");
            Console.WriteLine(bankXml);
            return bankXml.ToString();
        }

        private List<InputFileDataModel> GenereateRowDataForInputFile(string[] fileHeader, string[] row)
        {
            var list = new List<InputFileDataModel>();
            for (int i = 0; i < fileHeader.Length; i++)
            {
                list.Add(new InputFileDataModel(i, fileHeader[i], row[i]));
            }
            return list;
        }

        private async Task<InputOutputFileProcessingInfo> ProcessInputFileAndGenerateData()
        {
            var obj = new InputOutputFileProcessingInfo();
            var accountNumber = 121212;//Convert.ToInt32(DateTime.Now.ToString("yyyyMMddTHHmmssfff")); 
            int noOfTrans = 10;

            // header
            string[] excelHeader = { "account_number", "no_of_transactions" }; // xl sheet row
            obj.InputFileHeaderData= excelHeader; //
            // rows // for
            string[] excelRow1 = { (accountNumber * 1).ToString(), (noOfTrans * accountNumber).ToString() };
            obj.InputFileRowData.Add(new InputFileRowInfo(this.GenereateRowDataForInputFile(excelHeader, excelRow1)));
            string[] excelRow2 = { (accountNumber * 2).ToString(), (noOfTrans * accountNumber).ToString() };
            obj.InputFileRowData.Add(new InputFileRowInfo(this.GenereateRowDataForInputFile(excelHeader, excelRow2)));
            string[] excelRow3 = { (accountNumber * 3).ToString(), (noOfTrans * accountNumber).ToString() };
            obj.InputFileRowData.Add(new InputFileRowInfo(this.GenereateRowDataForInputFile(excelHeader, excelRow3)));
            // mapper info
            obj.MappingInfo = await this.GetAll();            
            return obj;
        }

        private string FindOutputTagValueByName(string tag)
        {
            return tag;
        }

        private string GetHeaderTemplate()
        {
            string msgId = DateTime.Now.ToString("yyyyMMddTHHmmssfff");
            string creDtm = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss:fff"); 
            var headerXml = @"
                 <GrpHdr>
			        <MsgId>" + msgId + @"</MsgId>
			        <CreDtTm>" + creDtm + @"</CreDtTm>
                    <AccNum>" + this.FindOutputTagValueByName("AccNum") + @"</AccNum>
			        <Authstn>
				        <Cd>ILEV</Cd>
			        </Authstn>
			        <NumberOfTransactions>" + this.FindOutputTagValueByName("NumberOfTransactions") + @"</NumberOfTransactions>
			        <InitgPty>
				        <Id>
					        <OrgId>
						        <Othr>
							        <Id>" + msgId + @"</Id>
						        </Othr>
					        </OrgId>
				        </Id>
			        </InitgPty>
		        </GrpHdr>";
            return headerXml;
        }
    }
}

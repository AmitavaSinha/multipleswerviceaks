using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eFormProcessingService.Models.DB;
using Microsoft.AspNetCore.Cors;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace eFormProcessingService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("projectAllowSpecificOrigins")]
    public class StampSaleAndPurchaseOfPropertiesController : ControllerBase
    {
        private readonly iras_stampdutyDBContext _context;

        public StampSaleAndPurchaseOfPropertiesController(iras_stampdutyDBContext context)
        {
            _context = context;
        }

        // GET: api/StampSaleAndPurchaseOfProperties
        [HttpGet]
        [EnableCors("projectAllowSpecificOrigins")]
        public async Task<ActionResult<IEnumerable<StampSaleAndPurchaseOfProperty>>> GetStampSaleAndPurchaseOfProperty()
        {
            var o = _context.StampSaleAndPurchaseOfProperty.Include(a => a.VendorTransaction).Include(a => a.PropertyDetailsTransaction).Include(a => a.PartyPropertyDetailsTransaction).ToListAsync();

            return await o;

        }

        // GET: api/StampSaleAndPurchaseOfProperties/5
        [HttpGet("{id}")]
        [EnableCors("projectAllowSpecificOrigins")]
        public async Task<ActionResult<StampSaleAndPurchaseOfProperty>> GetStampSaleAndPurchaseOfProperty(int id)
        {
            //var stampSaleAndPurchaseOfProperty = await _context.StampSaleAndPurchaseOfProperty.FindAsync(id);
            var stampSaleAndPurchaseOfProperty = await _context.StampSaleAndPurchaseOfProperty.Include(a => a.VendorTransaction).Include(a => a.PropertyDetailsTransaction).Include(a => a.PartyPropertyDetailsTransaction).Where(a => a.Id == id).FirstOrDefaultAsync();
            if (stampSaleAndPurchaseOfProperty == null)
            {
                return NotFound();
            }

            return stampSaleAndPurchaseOfProperty;
        }

        // PUT: api/StampSaleAndPurchaseOfProperties/5
        [HttpPut("{id}")]
        [EnableCors("projectAllowSpecificOrigins")]
        public async Task<IActionResult> PutStampSaleAndPurchaseOfProperty(int id, StampSaleAndPurchaseOfProperty stampSaleAndPurchaseOfProperty)
        {
            if (id != stampSaleAndPurchaseOfProperty.Id)
            {
                return BadRequest();
            }

            _context.Entry(stampSaleAndPurchaseOfProperty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StampSaleAndPurchaseOfPropertyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StampSaleAndPurchaseOfProperties
        [HttpPost]
        [EnableCors("projectAllowSpecificOrigins")]
        public ActionResult<StampSaleAndPurchaseOfProperty> PostStampSaleAndPurchaseOfProperty([FromBody]StampSaleAndPurchaseOfProperty stampSaleAndPurchaseOfProperty)
        {
            int output1 = 0;

            string documentReferenceNumber = ReferenceNumber();
            decimal? stampDutyCalculation = stampSaleAndPurchaseOfProperty.StampDutyCalculation;

            List<SqlParameter> sp = new List<SqlParameter>()
            {

                new SqlParameter() {ParameterName = "@StampSaleAndPurchaseOfPropertyId", SqlDbType = SqlDbType.NVarChar, Value= stampSaleAndPurchaseOfProperty.StampSaleAndPurchaseOfPropertyId},
                new SqlParameter() {ParameterName = "@IsActive", SqlDbType = SqlDbType.NVarChar, Value = stampSaleAndPurchaseOfProperty.IsActive},
                new SqlParameter() {ParameterName = "@AreYouStampingYourOwnDocument", SqlDbType = SqlDbType.Bit, Value =stampSaleAndPurchaseOfProperty.AreYouStampingYourOwnDocument },
                new SqlParameter() {ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = stampSaleAndPurchaseOfProperty.Name},
                new SqlParameter() {ParameterName = "@ContactNumber", SqlDbType = SqlDbType.VarChar, Value = stampSaleAndPurchaseOfProperty.ContactNumber},
                new SqlParameter(){ParameterName = "@EamilId", SqlDbType = SqlDbType.VarChar, Value =stampSaleAndPurchaseOfProperty.EamilId },
                new SqlParameter() { ParameterName = "@DocumentTypeId", SqlDbType = SqlDbType.Int, Value =stampSaleAndPurchaseOfProperty.DocumentTypeId },
                new SqlParameter() { ParameterName = "@DateOfTheDocument", SqlDbType = SqlDbType.DateTime, Value = System.DateTime.Now },
                new SqlParameter() { ParameterName = "@OverseasDate", SqlDbType = SqlDbType.DateTime, Value =System.DateTime.Now },
                new SqlParameter() { ParameterName = "@PurchasePriseOrConsideration", SqlDbType = SqlDbType.Decimal,Value= stampSaleAndPurchaseOfProperty.PurchasePriseOrConsideration },
                new SqlParameter() { ParameterName = "@ShareOfPropertyTransferred", SqlDbType = SqlDbType.VarChar, Value =stampSaleAndPurchaseOfProperty.ShareOfPropertyTransferred },
                new SqlParameter() { ParameterName = "@FloorArear_sqm", SqlDbType = SqlDbType.VarChar, Value =stampSaleAndPurchaseOfProperty.FloorArearSqm },
                new SqlParameter() { ParameterName = "@DocumentUrl", SqlDbType = SqlDbType.VarChar, Value =stampSaleAndPurchaseOfProperty.DocumentUrl },
                new SqlParameter() { ParameterName = "@DocumentRefNumber", SqlDbType = SqlDbType.VarChar, Value =documentReferenceNumber},
                new SqlParameter() { ParameterName = "@DocumentRefYear", SqlDbType = SqlDbType.VarChar, Value = DateTime.Now.Year.ToString() },
                new SqlParameter() { ParameterName = "@id", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output, Value = output1 },
                new SqlParameter() { ParameterName = "@YourReferenceNumber", SqlDbType = SqlDbType.VarChar, Value = stampSaleAndPurchaseOfProperty.YourReferenceNumber },
                new SqlParameter() { ParameterName = "@AdditionalComments", SqlDbType = SqlDbType.VarChar, Value = stampSaleAndPurchaseOfProperty.AdditionalComments },
                new SqlParameter() { ParameterName = "@StampDutyCalculation", SqlDbType = SqlDbType.Decimal, Value = stampDutyCalculation},
                new SqlParameter() { ParameterName = "@PaymentDate", SqlDbType = SqlDbType.DateTime, Value = DateTime.Now },
                new SqlParameter() { ParameterName = "@PaymentDueDate", SqlDbType = SqlDbType.DateTime, Value = DateTime.Now.AddDays(10) },



            };
            var i = _context.Database.ExecuteSqlCommand(@"InsertIntoStampSalesAndPurchase 
                                                            @StampSaleAndPurchaseOfPropertyId,
                                                            @IsActive,
                                                            @AreYouStampingYourOwnDocument,
                                                            @Name,
                                                            @ContactNumber,
                                                            @EamilId,
                                                            @DocumentTypeId,
                                                            @DateOfTheDocument,
                                                            @OverseasDate,
                                                            @PurchasePriseOrConsideration,
                                                            @ShareOfPropertyTransferred,
                                                            @FloorArear_sqm,
                                                            @DocumentUrl,
                                                            @DocumentRefNumber,
                                                            @DocumentRefYear,@id OUTPUT,@YourReferenceNumber,@AdditionalComments,@StampDutyCalculation,@PaymentDate,@PaymentDueDate", sp
                                                  );

            int id = _context.StampSaleAndPurchaseOfProperty.LastOrDefault().Id;


            if (stampSaleAndPurchaseOfProperty.VendorTransaction != null)
            {
                foreach (var vendorTransaction in stampSaleAndPurchaseOfProperty.VendorTransaction)
                {
                    if (!(string.IsNullOrEmpty(vendorTransaction.VendorName)) && !(vendorTransaction.VendorName.Equals("string")))
                    {
                        //InsertIntoVendorTransaction
                        List<SqlParameter> sp1 = new List<SqlParameter>()
                        {
                            new SqlParameter() {ParameterName = "@SalesDutyId", SqlDbType = SqlDbType.Int, Value= id},
                            new SqlParameter() {ParameterName = "@IsActive", SqlDbType = SqlDbType.NVarChar,Value = "Y"},
                            new SqlParameter() {ParameterName = "@VendorName", SqlDbType = SqlDbType.NVarChar, Value = vendorTransaction.VendorName},
                            new SqlParameter() {ParameterName = "@IdentityTypeId", SqlDbType = SqlDbType.Int, Value = vendorTransaction.IdentityTypeId},
                            new SqlParameter() { ParameterName = "@IdentityNumber", SqlDbType = SqlDbType.Decimal, Value = vendorTransaction.IdentityNumber },

                        };
                        _context.Database.ExecuteSqlCommand(@"InsertIntoVendorTransaction 
                                                                    @SalesDutyId,
                                                                    @IsActive,
                                                                    @VendorName,
                                                                    @IdentityTypeId,
                                                                    @IdentityNumber", sp1
                                                         );
                    }

                }
            }

            if (stampSaleAndPurchaseOfProperty.PropertyDetailsTransaction != null)
            {
                foreach (var propertyDetailsTransaction in stampSaleAndPurchaseOfProperty.PropertyDetailsTransaction)
                {

                    //InsertIntoVendorTransaction
                    if (!(string.IsNullOrEmpty(propertyDetailsTransaction.StreetName) && string.IsNullOrEmpty(propertyDetailsTransaction.HouseNumbe)))
                    {
                        List<SqlParameter> sp1 = new List<SqlParameter>()
                            {
                                new SqlParameter() {ParameterName = "@SalesDutyId", SqlDbType = SqlDbType.Int, Value= id},
                                new SqlParameter() {ParameterName = "@PostalCodeId", SqlDbType = SqlDbType.Int,Value = propertyDetailsTransaction.PostalCodeId},
                                new SqlParameter() {ParameterName = "@HouseNumbe", SqlDbType = SqlDbType.NVarChar, Value = propertyDetailsTransaction.HouseNumbe},
                                new SqlParameter() {ParameterName = "@StreetName", SqlDbType = SqlDbType.NVarChar, Value = propertyDetailsTransaction.StreetName},
                                new SqlParameter() { ParameterName = "@PropertyTypeId", SqlDbType = SqlDbType.Int, Value = propertyDetailsTransaction.PropertyTypeId },
                                new SqlParameter() { ParameterName = "@PurchaseLiableToAdditionalBuyersStampDuty", SqlDbType = SqlDbType.Bit, Value = propertyDetailsTransaction.PurchaseLiableToAdditionalBuyersStampDuty },
                                new SqlParameter() { ParameterName = "@IsActive", SqlDbType = SqlDbType.VarChar, Value = "Y"},

                            };
                        _context.Database.ExecuteSqlCommand(@"InsertIntoPropertyDetailsTransaction 
                                                                            @SalesDutyId,
                                                                            @PostalCodeId,
                                                                            @HouseNumbe,
                                                                            @StreetName,
                                                                            @PropertyTypeId,@PurchaseLiableToAdditionalBuyersStampDuty,@IsActive", sp1
                                                         );
                    }

                }
            }


            if (stampSaleAndPurchaseOfProperty.PartyPropertyDetailsTransaction != null)
            {
                foreach (var partyPropertyDetailsTransaction in stampSaleAndPurchaseOfProperty.PartyPropertyDetailsTransaction)
                {
                    if (partyPropertyDetailsTransaction.Name != null)
                    {
                        List<SqlParameter> sp1 = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@SalesDutyId", SqlDbType = SqlDbType.Int, Value= id},
                new SqlParameter() {ParameterName = "@Name", SqlDbType = SqlDbType.VarChar,Value = partyPropertyDetailsTransaction.Name},
                new SqlParameter() {ParameterName = "@ProfileTypeId", SqlDbType = SqlDbType.Int, Value = partyPropertyDetailsTransaction.ProfileTypeId},
                new SqlParameter() {ParameterName = "@CountyId", SqlDbType = SqlDbType.Int, Value = partyPropertyDetailsTransaction.CountyId},
                new SqlParameter() { ParameterName ="@PurchaseLiableAdditional", SqlDbType = SqlDbType.VarChar, Value = partyPropertyDetailsTransaction.PurchaseLiableAdditional },
                new SqlParameter() { ParameterName ="@IdentityTypeId", SqlDbType = SqlDbType.Int, Value = partyPropertyDetailsTransaction.IdentityTypeId },
                new SqlParameter() { ParameterName ="@IdentityNumber", SqlDbType = SqlDbType.VarChar, Value = partyPropertyDetailsTransaction.IdentityNumber},
                new SqlParameter() {ParameterName = "@MailingAddress_Country", SqlDbType = SqlDbType.VarChar, Value= partyPropertyDetailsTransaction.MailingAddressCountry},
                new SqlParameter() {ParameterName = "@PostalCodeId", SqlDbType = SqlDbType.Int,Value = partyPropertyDetailsTransaction.PostalCodeId},
                new SqlParameter() {ParameterName = "@HouseNumber", SqlDbType = SqlDbType.VarChar, Value = partyPropertyDetailsTransaction.HouseNumber},
                new SqlParameter() {ParameterName = "@StreetNumber", SqlDbType = SqlDbType.VarChar, Value = partyPropertyDetailsTransaction.StreetNumber},
                new SqlParameter() { ParameterName ="@LevelUnit1", SqlDbType = SqlDbType.VarChar, Value = partyPropertyDetailsTransaction.LevelUnit1 },
                new SqlParameter() { ParameterName ="@LevelUnit2", SqlDbType = SqlDbType.VarChar, Value = partyPropertyDetailsTransaction.LevelUnit2 },
                new SqlParameter() { ParameterName ="@TotalNumberOfOwned", SqlDbType = SqlDbType.Int, Value = partyPropertyDetailsTransaction.TotalNumberOfOwned},
            };

                        _context.Database.ExecuteSqlCommand(@"InsertIntoPartyPropertyDetailsTransaction  
                                                @SalesDutyId,
                                                @Name,
                                                @ProfileTypeId,
                                                @CountyId,
                                                @PurchaseLiableAdditional,
                                                @IdentityTypeId,
                                                @IdentityNumber,
                                                @MailingAddress_Country,
                                                @PostalCodeId,
                                                @HouseNumber,
                                                @StreetNumber,
                                                @LevelUnit1,
                                                @LevelUnit2,
                                                @TotalNumberOfOwned", sp1
                        );
                    }
                }
            }



            //(stampSaleAndPurchaseOfProperty.PropertyDetailsTransaction.FirstOrDefault());
            stampSaleAndPurchaseOfProperty.Id = id;

            return CreatedAtAction("GetStampSaleAndPurchaseOfProperty", new { id = id }, stampSaleAndPurchaseOfProperty);
        }

        // DELETE: api/StampSaleAndPurchaseOfProperties/5
        [HttpDelete("{id}")]
        [EnableCors("projectAllowSpecificOrigins")]
        public async Task<ActionResult<StampSaleAndPurchaseOfProperty>> DeleteStampSaleAndPurchaseOfProperty(int id)
        {
            var stampSaleAndPurchaseOfProperty = await _context.StampSaleAndPurchaseOfProperty.FindAsync(id);
            if (stampSaleAndPurchaseOfProperty == null)
            {
                return NotFound();
            }

            _context.StampSaleAndPurchaseOfProperty.Remove(stampSaleAndPurchaseOfProperty);
            await _context.SaveChangesAsync();

            return stampSaleAndPurchaseOfProperty;
        }

        [HttpGet]
        [EnableCors("projectAllowSpecificOrigins")]
        public async Task<List<CountryMaster>> GetCountry()
        {
            return await Task.Run(() => _context.CountryMaster.AsNoTracking().Where(p => p.IsActive == true).ToList());
        }

        [HttpGet]
        [EnableCors("projectAllowSpecificOrigins")]
        public decimal StampDutyCalculation(int price)
        {
            return price + ( price * Convert.ToInt32(_context.StampDutyCalculation.Where(a => a.MinSlab <= price && a.MaxSlab >= price).FirstOrDefault().Percentage) / 100);

           // return _context.StampDutyCalculation.Where(a => a.MinSlab<= price && a.MaxSlab >= price).FirstOrDefault().Percentage;
        }

        [HttpGet]
        [EnableCors("projectAllowSpecificOrigins")]
        public async Task<List<Message>> GetLandingPage(string user)
        {
            List<Message> messages = new List<Message>();
            List<StampSaleAndPurchaseOfProperty> values = await _context.StampSaleAndPurchaseOfProperty.OrderByDescending(a => a.Id).Where(x => x.EamilId == user).ToListAsync();
            foreach (StampSaleAndPurchaseOfProperty value in values)
            {
                Message msg = new Message();
                msg.MessageDescription = "Your correspondence for document reference no.: " + value.DocumentRefNumber + "has been submitted by IRAS for E-Stamping";
                msg.Date = value.DateOfTheDocument.ToString();

                messages.Add(msg);
            }
            return messages;
        }

        private string GenerateDocumentID()
        {
            int currentyear = DateTime.Now.Year;
            int a = _context.StampSaleAndPurchaseOfProperty.Where(x => x.DocumentRefYear == currentyear.ToString()).Count();
            string documentID = currentyear + DateTime.Now.Month + DateTime.Now.Day + "000" + (a + 1);
            return documentID;
        }
        private bool StampSaleAndPurchaseOfPropertyExists(int id)
        {
            return _context.StampSaleAndPurchaseOfProperty.Any(e => e.Id == id);
        }

        private string ReferenceNumber()
        {
            int i = _context.StampSaleAndPurchaseOfProperty.Where(a => a.DocumentRefYear.Trim() == DateTime.Now.Year.ToString()).Count();
            string str = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + AppendingZeros(i.ToString()) + i.ToString();
            return str;
        }

        private string AppendingZeros(string i)
        {
            switch (i.Length)
            {
                case 1:
                    return "0000";
                case 2:
                    return "000";
                case 3:
                    return "00";
                case 4:
                    return "0";
                default:
                    return "";
            }
        }


        [HttpGet("{documentRefNo}")]
        [EnableCors("projectAllowSpecificOrigins")]
        public async Task<List<StampSaleAndPurchaseOfProperty>> GetStampSaleAndPurchaseOfPropertyForDocRefNo(string documentRefNo)
        {
            List<StampSaleAndPurchaseOfProperty> stampSaleAndPurchaseOfProperty = new List<StampSaleAndPurchaseOfProperty>();
            stampSaleAndPurchaseOfProperty = await _context.StampSaleAndPurchaseOfProperty.Include(a => a.VendorTransaction).Include(a => a.PropertyDetailsTransaction).Include(a => a.PartyPropertyDetailsTransaction).Where(x => x.DocumentRefNumber.Equals(documentRefNo, StringComparison.CurrentCultureIgnoreCase)).ToListAsync();

            if (stampSaleAndPurchaseOfProperty == null)
            {
                return null;
            }

            return stampSaleAndPurchaseOfProperty;
        }
    }
}

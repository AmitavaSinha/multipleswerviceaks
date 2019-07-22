using eFormProcessingService.Models.DB;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace eFormProcessingService.Repositories
{
    public interface IEFormRepository
    {
        Task<List<DocumentTypeMaster>> GetDocumentType(CancellationToken ct = default(CancellationToken));
        Task<List<IdentityTypeMaster>> GetIdentityType(CancellationToken ct = default(CancellationToken));
        Task<List<PostalCodeMaster>> GetPostalCode(CancellationToken ct = default(CancellationToken));
        Task<List<PropertyTypeMaster>> GetPropertyType(CancellationToken ct = default(CancellationToken));
        Task<List<ProfileMaster>> GetProfile(CancellationToken ct = default(CancellationToken));
        Task<List<PostalCodeMaster>> GetPostalCodeByID(string id,CancellationToken ct = default(CancellationToken));
    }
}

/*
@StampSaleAndPurchaseOfPropertyId  varchar(50)--;-- ='1';
@IsActive char(1)--;-- = '1';
@AreYouStampingYourOwnDocument bit--;-- = 1;
@Name varchar(250)--;-- ='NAME';
@ContactNumber varchar(20)--;-- ='123456';
@EamilId varchar(100)--;-- ='Test';
@DocumentTypeId int--;-- =1;
@DateOfTheDocument datetime--;-- = '01-01-2019';
@OverseasDate datetime--;-- = '01-01-2019';
@PurchasePriseOrConsideration decimal(18,0)--;-- =1000.00;
@ShareOfPropertyTransferred varchar(10)--;-- = 'Y';
@FloorArear_sqm decimal(18,0)--;-- =100 ;
@DocumentUrl varchar(250)--;-- = null;
@DocumentRefNumber varchar(20)--;-- = '2019140600001';
@DocumentRefYear char(4)--;-- ='2019';
@id INT--;
@PostalCodeId int--;-- = 1;
@HouseNumbe varchar(50)--;-- = '12-12-509';
@StreetName varchar(50)--;-- ='Old Bunk';
@PropertyTypeId int--;-- = 1;
@PurchaseLiableToAdditionalBuyersStampDuty bit--;-- = 1;
@SalesDutyId int =  @id--;
@VendorName varchar(100)--;-- = 'Vendor Name';
@IdentityTypeId int--;-- = 1;
@IdentityNumber numeric(18,0)--;-- = 100001;
)
     
     
     */

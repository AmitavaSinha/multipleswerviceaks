using eFormProcessingService.Models.DB;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eFormProcessingService.Repositories
{
    public class EFormRepository:IEFormRepository
    {
        private readonly iras_stampdutyDBContext _context;
        public EFormRepository(iras_stampdutyDBContext context)
        {
            _context = context;
        }

        public async Task<List<DocumentTypeMaster>> GetDocumentType(CancellationToken ct = default(CancellationToken))
        {
            return await Task.Run(() => _context.DocumentTypeMaster.AsNoTracking().Where(p=>p.IsActive == true).ToListAsync(ct));
        }
        public async Task<List<IdentityTypeMaster>> GetIdentityType(CancellationToken ct = default(CancellationToken))
        {
            return await Task.Run(() => _context.IdentityTypeMaster.AsNoTracking().Where(p => p.IsActive == true).ToListAsync(ct));
        }
        public async Task<List<PostalCodeMaster>> GetPostalCode(CancellationToken ct = default(CancellationToken))
        {
            return await Task.Run(() => _context.PostalCodeMaster.AsNoTracking().Where(p => p.IsActive == true).ToListAsync(ct));
        }
        public async Task<List<PropertyTypeMaster>> GetPropertyType(CancellationToken ct = default(CancellationToken))
        {
            return await Task.Run(() => _context.PropertyTypeMaster.AsNoTracking().Where(p => p.IsActive == true).ToListAsync(ct));
        }
        public async Task<List<ProfileMaster>> GetProfile(CancellationToken ct = default(CancellationToken))
        {
            return await Task.Run(() => _context.ProfileMaster.AsNoTracking().Where(p => p.IsActive == true).ToListAsync(ct));
        }
       public async Task<List<PostalCodeMaster>> GetPostalCodeByID(string id, CancellationToken ct = default(CancellationToken))
        {
            return await Task.Run(() => _context.PostalCodeMaster.AsNoTracking().Where(p => p.IsActive == true && p.PostalCode==id).ToListAsync(ct));
        }



    }
}

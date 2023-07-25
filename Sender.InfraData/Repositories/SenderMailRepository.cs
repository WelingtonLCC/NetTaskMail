
namespace Sender.InfraData.Repositories
{
    public class SenderMailRepository : ISenderMailDomain
    {
        private SenderApplicationDbContext _context;

        public SenderMailRepository(SenderApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SenderMailDomain> Create(SenderMailDomain senderMailDomain)
        {
            _context.Add(senderMailDomain);
            await _context.SaveChangesAsync();
            return senderMailDomain;
        }

        public async Task<SenderMailDomain> Delete(SenderMailDomain senderMailDomain)
        {
            _context.Remove(senderMailDomain);
            await _context.SaveChangesAsync();
            return senderMailDomain;
        }

        public async Task<SenderMailDomain> GetMailById(int id)
        {
            return await _context.SenderMailDomain.SingleOrDefaultAsync(p => p.Sender_id == id);
        }

        public async Task<IEnumerable<SenderMailDomain>> GetMails()
        {
            return await _context.SenderMailDomain.ToListAsync();
        }

        public async Task<SenderMailDomain> SendID(SenderMailDomain senderMailDomain)
        {
            _context.Update(senderMailDomain);
            await _context.SaveChangesAsync();
            return senderMailDomain;
        }

        public Task<IEnumerable<SenderMailDomain>> SendMails()
        {
            throw new NotImplementedException();
        }

        public async Task<SenderMailDomain> Update(SenderMailDomain senderMailDomain)
        {
            _context.Update(senderMailDomain);
            await _context.SaveChangesAsync();
            return senderMailDomain;
        }
    }
}

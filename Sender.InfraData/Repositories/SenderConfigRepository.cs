
namespace Sender.InfraData.Repositories
{
    public class SenderConfigRepository : ISenderConfigDomain
    {
        private SenderApplicationDbContext _context;

        public SenderConfigRepository(SenderApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<SenderConfigDomain> Create(SenderConfigDomain senderConfigDomain)
        {
            _context.Add(senderConfigDomain);
            await _context.SaveChangesAsync();
            return senderConfigDomain;
        }

        public async Task<SenderConfigDomain> Delete(SenderConfigDomain senderConfigDomain)
        {
            _context.Remove(senderConfigDomain);
            await _context.SaveChangesAsync();
            return senderConfigDomain;
        }

        public async Task<SenderConfigDomain> GetSender()
        {
            return await _context.SenderConfigDomain.FirstOrDefaultAsync();
        }

        public async Task<SenderConfigDomain> Update(SenderConfigDomain senderConfigDomain)
        {
            _context.Update(senderConfigDomain);
            await _context.SaveChangesAsync();
            return senderConfigDomain;

        }
    }
}

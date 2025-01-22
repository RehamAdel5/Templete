using AutoMapper;
using Domain.Abstractions;
using Domain.ViewModels;
using External.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace External.Infrastructure.Persistence.Repositories
{
    public class AskedQuestionRepository : BaseRepository<AskedQuestionsViewModel>, IAskedQuestionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AskedQuestionRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

     

        public async Task<List<AskedQuestionsViewModel>> GetAskedQuestionAsync()
        {

            var AskedQuestionUs = await _context.AskedQuestions.ToListAsync();

            return _mapper.Map<List<AskedQuestionsViewModel>>(AskedQuestionUs);
        }
    }
}

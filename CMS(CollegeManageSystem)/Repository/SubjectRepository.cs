using CMS_CollegeManageSystem_.Data;
using CMS_CollegeManageSystem_.Models;
using CMS_CollegeManageSystem_.Repository.IRepository;

namespace CMS_CollegeManageSystem_.Repository
{
    public class SubjectRepository : Repository<Subjects>, ISubjectRepository
    {
        private ApplicationDbContext _dbContext;
        public SubjectRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Update(SubjectRepository subject)
        {
            throw new NotImplementedException();
        }
    }
}

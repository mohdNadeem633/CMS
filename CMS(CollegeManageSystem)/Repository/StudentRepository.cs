using CMS_CollegeManageSystem_.Data;
using CMS_CollegeManageSystem_.Models;
using CMS_CollegeManageSystem_.Repository.IRepository;

namespace CMS_CollegeManageSystem_.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private ApplicationDbContext _dbContext;
        public StudentRepository(ApplicationDbContext dbContext):base(dbContext) {
            _dbContext=dbContext;
        }
       
        public void Update(StudentRepository student)
        {
            throw new NotImplementedException();
        }
    }
}

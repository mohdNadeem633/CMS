using CMS_CollegeManageSystem_.Data;
using CMS_CollegeManageSystem_.Models;
using CMS_CollegeManageSystem_.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CMS_CollegeManageSystem_.Repository
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        private ApplicationDbContext _context;
        public TeacherRepository( ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(TeacherRepository teacher)
        {
            throw new NotImplementedException();
        }
    }
}

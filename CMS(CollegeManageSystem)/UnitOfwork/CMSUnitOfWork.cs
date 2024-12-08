using CMS_CollegeManageSystem_.Data;
using CMS_CollegeManageSystem_.Repository;
using CMS_CollegeManageSystem_.Repository.IRepository;
using CMS_CollegeManageSystem_.UnitOfwork.IUnitOfwork;

namespace CMS_CollegeManageSystem_.UnitOfwork
{

    public class CMSUnitOfWork : ICMSUnitOfWork
    {
        private ApplicationDbContext _db;


        public ITeacherRepository Teacher { get; private set; }
        public IStudentRepository Student { get; private set; }
        public ISubjectRepository Subject { get; private set; }  

        public CMSUnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Student = new StudentRepository(_db);
            Teacher = new TeacherRepository(_db);
            Subject = new SubjectRepository(_db);
            
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

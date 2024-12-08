using CMS_CollegeManageSystem_.Repository.IRepository;

namespace CMS_CollegeManageSystem_.UnitOfwork.IUnitOfwork
{
    public interface ICMSUnitOfWork
    {
        public ISubjectRepository Subject { get; }
        public ITeacherRepository Teacher { get; }
        public IStudentRepository Student { get; }
        void Save();
    }
}

using CMS_CollegeManageSystem_.Models;

namespace CMS_CollegeManageSystem_.Repository.IRepository
{
    public interface ISubjectRepository:IRepository<Subjects>
    {
        void Update(SubjectRepository subject);
    }
}

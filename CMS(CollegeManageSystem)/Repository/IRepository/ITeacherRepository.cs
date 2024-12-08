using CMS_CollegeManageSystem_.Models;

namespace CMS_CollegeManageSystem_.Repository.IRepository
{
    public interface ITeacherRepository:IRepository<Teacher>
    {
        void Update(TeacherRepository teacher);
    }
}

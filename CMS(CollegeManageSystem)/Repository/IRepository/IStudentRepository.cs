using CMS_CollegeManageSystem_.Models;

namespace CMS_CollegeManageSystem_.Repository.IRepository
{
    public interface IStudentRepository:IRepository<Student>
    {
        void Update(StudentRepository student);
    }
}

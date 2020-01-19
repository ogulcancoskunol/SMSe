using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SMSe.BLL.Config;
using SMSe.BLL.ModelViews;
using SMSe.BLL.Service.Interface;
using SMSe.DAL;
using SMSe.DAL.Repository;
using SMSe.DAL.Repository.Interface;

namespace SMSe.BLL.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork unitOfWork;

        public TeacherService()
        {
            AutoMapperConfig.Configure();
            unitOfWork = new UnitOfWork();
        }

        public void Create(TeacherView teacher)
        {
            unitOfWork.Repository<Teacher>().Create(Mapper.Map<Teacher>(teacher));
        }

        public IQueryable<TeacherView> GetAll()
        {
            IQueryable<Teacher> result = unitOfWork.Repository<Teacher>().Get(orderBy: q => q.OrderBy(d => d.id));
            return result.ProjectTo<TeacherView>();
        }

        public TeacherView GetById(object id)
        {
            Teacher result = unitOfWork.Repository<Teacher>().GetById(id);
            return Mapper.Map<TeacherView>(result);
        }

        public void Update(TeacherView teacher)
        {
            unitOfWork.Repository<Teacher>().Update(Mapper.Map<Teacher>(teacher));
        }

        public void Delete(int id)
        {
            Teacher deleteResult = unitOfWork.Repository<Teacher>().GetById(id);
            unitOfWork.Repository<Teacher>().Delete(deleteResult);
        }

        public void Save()
        {
            unitOfWork.Save();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork unitOfWork;

        public SubjectService()
        {
            AutoMapperConfig.Configure();
            unitOfWork = new UnitOfWork();
        }

        public void Create(SubjectView subject, int teacher_id)
        {
            unitOfWork.Repository<Subject>().Create(Mapper.Map<Subject>(subject));
        }

        public IQueryable<SubjectView> GetAll(int id)
        {
            IQueryable<Subject_Teacher> result = unitOfWork.Repository<Subject_Teacher>().Get().Where(c => c.teacher_id==id);
            return result.ProjectTo<SubjectView>();
        }

        public SubjectView GetById(int id)
        {
            Subject result = unitOfWork.Repository<Subject>().GetById(id);
            return Mapper.Map<SubjectView>(result);
        }

        public void Update(SubjectView subject)
        {
            unitOfWork.Repository<Subject>().Update(Mapper.Map<Subject>(subject));
        }

        public void Delete(int id)
        {
            Subject deleteResult = unitOfWork.Repository<Subject>().GetById(id);
            unitOfWork.Repository<Subject>().Delete(deleteResult);
        }

        public void Save()
        {
            unitOfWork.Save();
        }
    }
}

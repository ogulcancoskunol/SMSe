using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSe.BLL.ModelViews;

namespace SMSe.BLL.Service.Interface
{
    public interface ISubjectService
    {
        void Create(SubjectView subject, int id);
        IQueryable<SubjectView> GetAll(int id);
        SubjectView GetById(int id);
        void Update(SubjectView subject);
        void Delete(int id);
        void Save();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSe.BLL.ModelViews;
using SMSe.DAL;

namespace SMSe.BLL.Service.Interface
{
    public interface ITeacherService
    {
        void Create(TeacherView teacher);
        IQueryable<TeacherView> GetAll();
        TeacherView GetById(object id);
        void Update(TeacherView teacher);
        void Delete(int id);
        void Save();
    }
}

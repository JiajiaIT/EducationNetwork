using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
using Factory;

namespace BLL
{
    public class B_StudentWorks : I_StudentWorks
    {
        public void Add(StudentWorks entity)
        {
            Factory.CreateFactory.GetStudentWorks().Add(entity);
        }

        public void Delete(int id)
        {
            Factory.CreateFactory.GetStudentWorks().Delete(id);
        }

        public StudentWorks FindByID(int id)
        {
            return Factory.CreateFactory.GetStudentWorks().FindByID(id);
        }

        public List<StudentWorks> List()
        {
            return Factory.CreateFactory.GetStudentWorks().List();
        }

        public void Update(int id, StudentWorks entity)
        {
            Factory.CreateFactory.GetStudentWorks().Update(id, entity);
        }
    }
}

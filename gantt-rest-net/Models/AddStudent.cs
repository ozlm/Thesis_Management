using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gantt_rest_net.Models
{
    public class AddStudent : Inheritance
    {
        public AddStudent()
        {
            base.db = new Data.Entities7();
        }

        public bool New(Data.student model)
        {
            try
            {
                db.addStudent(model.studentName, model.studentSurname, model.studentEmail, model.studentPassword);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
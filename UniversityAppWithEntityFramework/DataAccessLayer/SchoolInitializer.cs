using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityAppWithEntityFramework.Models;

namespace UniversityAppWithEntityFramework.DataAccessLayer
{

    public class SchoolInitializer : System.Data.Entity.
DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var students = new List<student> {
                new student{firstmidname="Carson",lastname="Alexander",enrollmentdate=DateTime.Parse("2005-09-01")},
                new student{firstmidname="Meredith",lastname="Alonso",enrollmentdate=DateTime.Parse("2002-09-01")},
                new student{firstmidname="Arturo",lastname="Anand",enrollmentdate=DateTime.Parse("2003-09-01")},
                new student{firstmidname="Gytis",lastname="Barzdukas",enrollmentdate=DateTime.Parse("2002-09-01")},
                new student{firstmidname="Yan",lastname="Li",enrollmentdate=DateTime.Parse("2002-09-01")},

                new student{firstmidname="Peggy",lastname="Justice",enrollmentdate=DateTime.Parse("2001-09-01")},
                new student{firstmidname="Laura",lastname="Norman",enrollmentdate=DateTime.Parse("2003-09-01")},
                new student{firstmidname="Nino",lastname="Olivetto",enrollmentdate=DateTime.Parse("2005-09-01")}
            };
            students.ForEach(s => context.students.Add(s));
            context.SaveChanges();
            var courses = new List<course> {
                 new course{courseid=1050,title="Chemistry",credits=3,},
                 new course{courseid=4022,title="Microeconomics",credits=3,},
                 new course{courseid=4041,title="Macroeconomics",credits=3,},

                 new course{courseid=1045,title="Calculus",credits=4,},
                 new course{courseid=3141,title="Trigonometry",credits=4,},
                 new course{courseid=2021,title="Composition",credits=3,},
                 new course{courseid=2042,title="Literature",credits=4,}
                 };
            courses.ForEach(s => context.courses.Add(s));
            context.SaveChanges();
            var enrollments = new List<enrollment>{
                 new enrollment{studentid=1,courseid=1050,grade=1},
                 new enrollment{studentid=1,courseid=4022,grade=3},
                 new enrollment{studentid=1,courseid=4041,grade=2},
                 new enrollment{studentid=2,courseid=1045,grade=2},

                 new enrollment{studentid=2,courseid=3141,grade=6},
                 new enrollment{studentid=2,courseid=2021,grade=6},
                 new enrollment{studentid=3,courseid=1050},
                 new enrollment{studentid=4,courseid=1050,},
                 new enrollment{studentid=4,courseid=4022,grade=6},
                 new enrollment{studentid=5,courseid=4041,grade=3},
                 new enrollment{studentid=6,courseid=1045},
                 new enrollment{studentid=7,courseid=3141,grade=1},
                 };
            enrollments.ForEach(s => context.enrollments.Add(s));
            context.SaveChanges();
        }
    }
}
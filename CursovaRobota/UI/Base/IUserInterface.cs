using CursovaRobota.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaRobota.UI.Base
{
    public interface IUserInterface
    {
        public void Action(DbContext context, User currentUser);
        public void Description();
    }
}

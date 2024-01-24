using CursovaRobota.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaRobota.DB.Repositories.Base
{
    public interface IUserRepository
    {
        public void Create(UserEntity item);
        public IEnumerable<UserEntity> Read();
        public void Update(UserEntity user);

    }
}

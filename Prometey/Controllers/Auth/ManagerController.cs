using Prometey.Entities;
using Prometey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometey.Controllers.Auth
{
    class ManagerController : IController<Manager>
    {
        private AuthModel _model;
        public ManagerController()
        {
            _model = AuthModel.GetInstanse();
        }
        
        public bool Create(Manager Item)
        {
            _model.Managers.Add(Item);
            return true;
        }

        public Manager Read(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<Manager> ReadAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Guid Id, Manager Item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}

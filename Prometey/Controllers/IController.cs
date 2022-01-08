using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometey.Controllers
{
    public interface IController<Entity>
    {/// <summary>
     /// Создать элемент
     /// </summary>
     /// <param name="Item">Новая сущность</param>
     /// <returns>результат создания сущности (Да нет)</returns>
        public bool Create(Entity Item);

        public Entity Read(Guid Id);

        public List<Entity> ReadAll();

        public bool Update(Guid Id, Entity Item);

        public bool Delete(Guid Id);
    }
}

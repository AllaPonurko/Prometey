using Prometey.Entities;
using Prometey.Exceptions.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Prometey.Models
{ 
        public class AuthModel : IModels
        {
            /// <summary>
            /// Текущий пользователь
            /// </summary>
            public Manager CurentManager { get; set; }

            public List<Manager> Managers { get; set; } = new List<Manager>();
            
            private static AuthModel _instanse;

            private AuthModel()
            {
                try
                {
                    Load();
                }
                catch (Exception e)
                {
                    Seed();
                    CurentManager = Managers.First(m=> m.Name == "guest");
                    FileName = "auth";
                }
            }
            public static AuthModel GetInstanse() => _instanse ??= new AuthModel();


            public void Seed()
            {
                // Супер администратор
                
                Manager uRoot = new Manager() { Name = "root" };

            Managers.Add(uRoot);


            // Для обычного пользователя

            Manager uGuest = new Manager() { Name = "guest" };
            Managers.Add(uGuest);
                
            }


            public string FileName { get; set; }

            public void Load()
            {
                XmlSerializer formatterUser = new XmlSerializer(typeof(List<Manager>));
                try
                {
                    using (FileStream fs = new FileStream(FileName + ".users.xml", FileMode.Open))
                    {
                    Managers = (List<Manager>)formatterUser.Deserialize(fs);
                    }
                }
                catch (Exception e)
                {
                    throw new ExceptionModelsFile();
                }

            }

            public void Save()
            {
                XmlSerializer formatterUser = new XmlSerializer(typeof(List<Manager>));
                try
                {
                    using (FileStream fs = new FileStream(FileName + ".users.xml", FileMode.OpenOrCreate))
                    {
                        formatterUser.Serialize(fs, Managers);
                    }

                }
                catch (Exception e)
                {
                    throw new ExceptionModelsFile();
                }

            }
        }
    
}

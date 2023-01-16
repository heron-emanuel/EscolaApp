using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace EscolaApp
{
    static class NProfessor
    {
        private static List<Professor> profs = new List<Professor>();

        public static void Inserir(Professor p)
        {
            Abrir();
            profs.Add(p);
            Salvar();
        }

        public static List<Professor> Listar()
        {
            Abrir();
            return profs;
        }

        public static void Excluir(Professor p)
        {
            Abrir();
            profs.Remove(p);
            Salvar();
        }

        public static void Atualizar(Professor p)
        {
            Abrir();
            var elem = profs.Find(x => x.Id == p.Id);
            if (elem != null)
            {
                elem.Nome = p.Nome;
                elem.Matricula = p.Matricula;
                elem.Area = p.Area;
            }
            Salvar();
        }

        public static void Abrir()
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Professor>));
                using (StreamReader f = new StreamReader("./professor.xml"))
                {
                    profs = (List<Professor>)xml.Deserialize(f);
                }
            }
            catch
            {
                profs = new List<Professor>();
            }
        }
        public static void Salvar()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Professor>));
            using (StreamWriter f = new StreamWriter("./professor.xml", false))
            {
                xml.Serialize(f, profs);

            }
        }
    }
}

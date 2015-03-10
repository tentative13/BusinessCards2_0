using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBC.DapperData
{
    public class SelectPersona
    {
        public QueryObject All()
        {
            return new QueryObject(@"select * from Personas p
                                     inner join BusinessCards bc
                                     ON p.ID = bc.Persona_ID");
        }

        public QueryObject ById(int PersonaId)
        {
            return new QueryObject(All().SqlString + @" where p.Id = @Id", new { Id = PersonaId });
        }

        public QueryObject ByIdWithMyCards(int PersonaId)
        {
            throw new NotImplementedException();
        }

        public QueryObject ByIdWithAllNonMyCards(int PersonaId)
        {
            throw new NotImplementedException();
        }
    }
}

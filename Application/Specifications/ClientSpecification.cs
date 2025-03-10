using Ardalis.Specification;
using Domain.Entities;
using System.Xml.Linq;

namespace Application.Specifications
{
    public class ClientSpecification : Specification<Client>
    {
        public ClientSpecification(string IdenticacionCode, string Name, string Lastnames, string Mail, int? IdTypeIdentification, string Address, DateTime? BornDate, string Phone, string? Gender)
        {
            if (!string.IsNullOrEmpty(IdenticacionCode))  Query.Where(x => x.IdenticacionCode== IdenticacionCode);
            if (!string.IsNullOrEmpty(Name))  Query.Search(x => x.Name, "%"+Name+"%"); 
            if (!string.IsNullOrEmpty(Lastnames))  Query.Search(x => x.Lastnames, "%"+Lastnames+"%"); 
            if (!string.IsNullOrEmpty(Mail))  Query.Search(x => x.Mail, "%"+Mail+"%"); 
            if (!string.IsNullOrEmpty(Address))  Query.Search(x => x.Address, "%"+Address+"%"); 
            if ((IdTypeIdentification!=null))  Query.Where(x => x.IdTypeIdentification== IdTypeIdentification); 
        }

    }
}

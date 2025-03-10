namespace Application.Features.Clients.Queries.GetAllClients
{
    public class GelAllClientsParameters
    {
        public string? IdenticacionCode { get; set; }
        public string? Name { get; set; }
        public string? Lastnames { get; set; }
        public string? Mail { get; set; }
        public int?   IdTypeIdentification { get; set; }
        public string? Address { get; set; }
        public DateTime? BornDate { get; set; }
        public string? Phone { get; set; }
        public string? Gender { get; set; }
    }
}

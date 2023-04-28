using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TicketModel
    {
        public static readonly string GETALL = "select t.Id_Ticket as [Ticket], a.Id_Address as [OTicket], a.Street as [AOrigin], a.Number as [ANumber],a.Neighborhood as [ANeighborhood], a.Cep as [ACep],a.Complement as [AComplement], a.DtRegister_Address as [ODtRegister], c.Description as [CityO],ad.Street as [DStreet],ad.Number as [DNumber],ad.Neighborhood as [DNeighborhood],ad.Cep as [DCep],ad.Complement as [DComplement], cd.Description as [CityD],cl.Name_Client as [ClientName],cl.Phone as [ClientPhone],t.Ticket_Value as [TicketValue] FROM Ticket t JOIN Address a on t.Id_Address_Origin = a.Id_Address JOIN City c on a.Id_City_Address = c.Id_City JOIN Address ad on t.Id_Address_Destiny = ad.Id_Address JOIN City cd on ad.Id_City_Address = cd.Id_City JOIN Client cl on t.Id_Client_Ticket = cl.Id_Client";

        public static readonly string INSERT = "insert into Ticket (Id_Address_Origin, Id_Address_Destiny, Id_Client_Ticket, DtTicket, Ticket_Value) values (@Id_Address_Origin, @Id_Address_Destiny," +
                    "@Id_Client_Ticket, @DtTicket, @Ticket_Value); Select cast(scope_identity() as int)";

        public static readonly string DELETE = "delete from Ticket where Id_Ticket = @Id_Ticket";

        public static readonly string UPDATE = "update Ticket set Ticket_Value = @Ticket_Value, DtTicket = @DtTicket, Id_Address_Origin = @Id_Address_Origin, Id_Address_Destiny = @Id_Address_Destiny, Id_Client_Ticket = @Id_Client_Ticket where Id_Ticket = @Id_Ticket";
        
        
        [Key]
        public int Id_Ticket { get; set; }
        public AddressModel Id_Address_Origin { get; set; }

        public AddressModel Id_Address_Destiny { get; set; }

        public ClientModel Id_Client_Ticket { get; set; }

        public DateTime DtTicket { get; set; }

        public decimal Ticket_Value { get; set; }
    }
}

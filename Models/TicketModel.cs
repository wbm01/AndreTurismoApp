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

        public static readonly string GETALL = "select t.Id_Ticket, a.Id_Address, a.Street, a.Number, a.Neighborhood, a.Cep, a.Complement, a.DtRegister_Address, c.Id_City, c.Description, c.DtRegister_City, ad.Id_Address, ad.Street, ad.Number, ad.Neighborhood, ad.Cep, ad.Complement, ad.DtRegister_Address, ci.Id_City, ci.Description, ci.DtRegister_City, cl.Id_Client, cl.Name_Client, cl.Phone, adc.Id_Address, adc.Street, adc.Number, adc.Neighborhood, adc.Cep, adc.Complement, adc.DtRegister_Address, cic.Id_City, cic.Description, cic.DtRegister_City, t.Ticket_Value FROM Ticket t JOIN Address a on t.Id_Address_Origin = a.Id_Address JOIN City c on a.Id_City_Address = c.Id_City JOIN Address ad on t.Id_Address_Destiny = ad.Id_Address JOIN City ci on ad.Id_City_Address = ci.Id_City JOIN Client cl on t.Id_Client_Ticket = cl.Id_Client JOIN Address adc on cl.Id_Address_Client = adc.Id_Address JOIN City cic on adc.Id_City_Address = cic.Id_City";
        public static readonly string INSERT = "insert into Ticket (Id_Address_Origin, Id_Address_Destiny, Id_Client_Ticket, DtTicket, Ticket_Value) values (@Id_Address_Origin, @Id_Address_Destiny, @Id_Client_Ticket, @DtTicket, @Ticket_Value); Select cast(scope_identity() as int)";
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

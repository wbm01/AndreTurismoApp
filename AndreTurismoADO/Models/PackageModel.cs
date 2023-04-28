using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;

namespace AndreTurismoADO.Models
{
    public class PackageModel
    {
        public static readonly string GETALL = "select h.Name_Hotel as [HotelName], h.Hotel_Value as [HotelValue], ah.Street as [HotelStreet], ah.Number as [HotelNumber],ah.Neighborhood as [HotelNeighborhood], ah.Cep as [HotelCep],ah.Complement as [HotelComplement],ch.Description as [CityH],p.Id_Ticket_Package as [Ticket], p.Dt_Register_Package as [DatePackage],a.Street as [AOrigin], a.Number as [ANumber],a.Neighborhood as [ANeighborhood], a.Cep as [ACep],a.Complement as [AComplement],c.Description as [CityO],ad.Street as [DStreet],ad.Number as [DNumber],ad.Neighborhood as [DNeighborhood],ad.Cep as [DCep],ad.Complement as [DComplement], cd.Description as [CityD],cl.Name_Client as [ClientName],cl.Phone as [ClientPhone],p.Package_Value as [PackageValue], t.Ticket_Value as [TicketValue] FROM Package p JOIN Address a on p.Id_Ticket_Package = a.Id_Address JOIN City c on a.Id_City_Address = c.Id_City JOIN Address ad on p.Id_Ticket_Package = ad.Id_Address JOIN City cd on ad.Id_City_Address = cd.Id_City JOIN Client cl on p.Id_Client_Package = cl.Id_Client JOIN Hotel h on p.Id_Hotel_Package = h.Id_Hotel JOIN Address ah on p.Id_Hotel_Package = ah.Id_Address JOIN City ch on ah.Id_City_Address = ch.Id_City JOIN Ticket t on p.Id_Ticket_Package = t.Id_Ticket";
        public static readonly string INSERT = "insert into Package (Id_Hotel_Package, Id_Ticket_Package, Dt_Register_Package, Package_Value, Id_Client_Package) values (@Id_Hotel_Package, @Id_Ticket_Package,@Dt_Register_Package, @Package_Value, @Id_Client_Package)";
        public static readonly string DELETE = "delete from Package where Id_Package = @Id_Package";
        public static readonly string UPDATE = "update Package set Dt_Register_Package = @Dt_Register_Package, Package_Value = @Package_Value, Id_Hotel_Package = @Id_Hotel_Package, Id_Ticket_Package = @Id_Ticket_Package, Id_Client_Package = @Id_Client_Package where Id_Package = @Id_Package";

        public int Id_Package { get; set; }
        public Hotel Id_Hotel_Package { get; set; }
        public Ticket Id_Ticket_Package { get; set; }
        public DateTime Dt_Register_Package { get; set; }
        public double Package_Value { get; set; }

        public Client Id_Client_Package { get; set; }
    }
}

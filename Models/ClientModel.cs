using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Models
{
    public class ClientModel
    {
        public static readonly string GETALL = "select c.Id_Client, c.Name_Client, c.Phone, a.Id_Address, a.Street, a.Number,a.Neighborhood, a.Cep, a.Complement, a.DtRegister_Address, ci.Id_City, ci.Description, ci.DtRegister_City FROM Client c JOIN Address a on c.Id_Address_Client= a.Id_Address join City ci on ci.Id_City = a.Id_City_Address";
        public static readonly string INSERT = "insert into Client (Name_Client, Phone, Id_Address_Client, DtRegister_Client) values (@Name_Client,@Phone,@Id_Address_Client,@DtRegister_Client); Select cast(scope_identity() as int)";
        public static readonly string DELETE = "delete from Client where Id_Client = @Id_Client";
        public static readonly string UPDATE = "update Client set Name_Client = @Name_Client, Phone = @Phone, DtRegister_Client = @DtRegister_Client where Id_Client = @Id_Client";

        [Key]
        public int Id_Client { get; set; }

        public string Name_Client { get; set; }

        public string Phone { get; set; }

        public AddressModel Id_Address_Client { get; set; }

        public DateTime DtRegister_Client { get; set; }
    }
}
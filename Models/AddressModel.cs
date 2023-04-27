﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AddressModel
    {
        public static readonly string GETALL = "select a.Id_Address, a.Street, a.Number,a.Neighborhood, a.Cep, a.Complement, a.DtRegister_Address, ci.Id_City, ci.Description, ci.DtRegister_City FROM Address a JOIN City ci on a.Id_City_Address = ci.Id_City";
        public static readonly string INSERT = "insert into Address (Street, Number, Neighborhood, Cep, Complement, Id_City_Address, DtRegister_Address) values (@Street, @Number, @Neighborhood, @Cep, @Complement, @Id_City_Address, @DtRegister_Address); Select cast(scope_identity() as int)";
        public static readonly string DELETE = "delete from Address where Id_Address = @Id_Address";
        public static readonly string UPDATE = "update Address set Street = @Street, Number = @Number, Neighborhood = @Neighborhood,Cep = @Cep, Complement = @Complement, DtRegister_Address = @DtRegister_Address  where Id_Address = @Id_Address";

        [Key]
        public int Id_Address { get; set; }

        public string Street { get; set; }

        public int Number { get; set; }

        public string Neighborhood { get; set; }

        public string Cep { get; set; }

        public string Complement { get; set; }

        public CityModel Id_City_Address { get; set; }

        public DateTime DtRegister_Address { get; set; }
    }
}

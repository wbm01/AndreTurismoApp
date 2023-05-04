using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Models.DTO
{
    public class AddressDTO
    {
        public int Id { get; set; }
        /*[JsonProperty("pais")]
        public string? Country { get; set; }*/
        [JsonProperty("cep")]
        public string CEP { get; set; }
        [JsonProperty("bairro")]
        public string Bairro { get; set; }
        [JsonProperty("localidade")]
        public string City { get; set; }
        [JsonProperty("uf")]
        public string State { get; set; }
        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }
        [JsonProperty("gia")]
        public int Number { get; set; }
        [JsonProperty("complemento")]
        public string Complemento { get; set; }


        /*public Address(AddressModel addressDTO)
        {
            this.Street = addressDTO.Logradouro;
            this.Number = addressDTO.Number;
            this.Neighborhood = addressDTO.Bairro;
            this.Cep = addressDTO.CEP;
            this.Complement = addressDTO.Complemento;
            this.Id_City_Address = new City { Description = addressDTO.City };
            this.DtRegister_Address = DateTime.Now;

        }*/

        /*public Address()
        {

        }*/
    }
}

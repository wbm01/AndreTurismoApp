select p.Id_Package, h.Id_Hotel, h.Name_Hotel, h.Hotel_Value, ah.Id_Address, 
ah.Street, ah.Number,ah.Neighborhood, ah.Cep, ah.Complement, ch.Id_City, 
ch.Description, ch.DtRegister_City, t.Id_Ticket, a.Id_Address, 
a.Street, a.Number, a.Neighborhood, a.Cep, a.Complement, a.DtRegister_Address, 
c.Id_City, c.Description, c.DtRegister_City, ad.Id_Address, ad.Street, 
ad.Number, ad.Neighborhood, ad.Cep, ad.Complement, ad.DtRegister_Address, 
ci.Id_City, ci.Description, ci.DtRegister_City, p.Dt_Register_Package, 
p.Package_Value, cl.Id_Client, cl.Name_Client, cl.Phone, adc.Id_Address, 
adc.Street, adc.Number, adc.Neighborhood, adc.Cep, adc.Complement, 
adc.DtRegister_Address, cic.Id_City, cic.Description, cic.DtRegister_City 
FROM Package p 
JOIN Client cl on p.Id_Client_Package = cl.Id_Client 
JOIN Address adc on cl.Id_Address_Client = adc.Id_Address 
JOIN City cic on adc.Id_City_Address = cic.Id_City
JOIN Hotel h on p.Id_Hotel_Package = h.Id_Hotel
JOIN Address ah on h.Id_Address_Hotel = ah.Id_Address
JOIN City ch on ah.Id_City_Address = ch.Id_City
JOIN Ticket t on p.Id_Ticket_Package = t.Id_Ticket
JOIN Address a on t.Id_Address_Origin = a.Id_Address
JOIN City c on a.Id_City_Address = c.Id_City 
JOIN Address ad on t.Id_Address_Destiny = ad.Id_Address 
JOIN City ci on t.Id_Address_Destiny = c.Id_City

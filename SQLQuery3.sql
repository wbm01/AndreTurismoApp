select t.Id_Ticket, a.Id_Address, a.Street, a.Number, a.Neighborhood, a.Cep, 
a.Complement, a.DtRegister_Address, c.Id_City, c.Description, 
c.DtRegister_City, ad.Id_Address, ad.Street, ad.Number, ad.Neighborhood, 
ad.Cep, ad.Complement, ad.DtRegister_Address, ci.Id_City, ci.Description, 
ci.DtRegister_City, cl.Id_Client, cl.Name_Client, cl.Phone, adc.Id_Address, 
adc.Street, adc.Number, adc.Neighborhood, adc.Cep, adc.Complement, 
adc.DtRegister_Address, cic.Id_City, cic.Description, cic.DtRegister_City, 
t.Ticket_Value FROM Ticket t 
JOIN Address a on t.Id_Address_Origin = a.Id_Address 
JOIN City c on a.Id_City_Address = c.Id_City 
JOIN Address ad on t.Id_Address_Destiny = ad.Id_Address 
JOIN City ci on ad.Id_City_Address = ci.Id_City 
JOIN Client cl on t.Id_Client_Ticket = cl.Id_Client 
JOIN Address adc on cl.Id_Address_Client = adc.Id_Address
JOIN City cic on adc.Id_City_Address = cic.Id_City
select p.Id_Package as [IdPackage], h.Id_Hotel as [IdHotel], h.Name_Hotel as [NomeHotel], h.Hotel_Value as [ValorHotel], ah.Id_Address as [AIdHotel], 
ah.Street as [ASHotel], ah.Number as [ANHotel],ah.Neighborhood as [ANEHotel], ah.Cep as [ACHotel], ah.Complement as [ACOHotel], ch.Id_City as [CIHotel], 
ch.Description as [CDHotel], ch.DtRegister_City as [CDTHotel], t.Id_Ticket as [TIHotel], a.Id_Address as [AOID], 
a.Street as [AOS], a.Number as [AON], a.Neighborhood as [ANEO], a.Cep as [AOC], a.Complement as [AOCO], a.DtRegister_Address as [AODT], 
c.Id_City as [AOCID], c.Description as [AOCD], c.DtRegister_City as [AOCDT], ad.Id_Address as [ADID], ad.Street as [ADS], 
ad.Number as [ADN], ad.Neighborhood as [ADNEI], ad.Cep as [ADCEP], ad.Complement as [ADCOM], ad.DtRegister_Address as [ADDT], 
ci.Id_City as [ADCID], ci.Description as [ADCD], ci.DtRegister_City as [ADCDT], p.Dt_Register_Package as [ADDTP], 
p.Package_Value as [PValue], cl.Id_Client as [CID], cl.Name_Client as [CName], cl.Phone as [CPhone], adc.Id_Address as [CAID], 
adc.Street as [CAS], adc.Number as [CAN], adc.Neighborhood as [CANEI], adc.Cep as [CACEP], adc.Complement as [CACOM], 
adc.DtRegister_Address as [CADT], cic.Id_City as [CACID], cic.Description as [CACD], cic.DtRegister_City as [CCADT]
FROM Package p 
JOIN Hotel h on p.Id_Hotel_Package = h.Id_Hotel
JOIN Address ah on h.Id_Address_Hotel = ah.Id_Address
JOIN City ch on ah.Id_City_Address = ch.Id_City
JOIN Ticket t on p.Id_Ticket_Package = t.Id_Ticket
JOIN Address a on t.Id_Address_Origin = a.Id_Address
JOIN City c on a.Id_City_Address = c.Id_City 
JOIN Address ad on t.Id_Address_Destiny = ad.Id_Address 
JOIN City ci on t.Id_Address_Destiny = ci.Id_City
JOIN Client cl on p.Id_Client_Package = cl.Id_Client 
JOIN Address adc on cl.Id_Address_Client = adc.Id_Address 
JOIN City cic on adc.Id_City_Address = cic.Id_City


select p.Id_Package, h.Id_Hotel, h.Name_Hotel, h.Hotel_Value, ah.Id_Address, ah.Street, ah.Number, ah.Neighborhood, ah.Cep, ah.Complement, ch.Id_City, ch.Description, ch.DtRegister_City, t.Id_Ticket, a.Id_Address, a.Street, a.Number, a.Neighborhood, a.Cep, a.Complement, a.DtRegister_Address, c.Id_City, c.Description, c.DtRegister_City, ad.Id_Address, ad.Street, ad.Number, ad.Neighborhood, ad.Cep, ad.Complement, ad.DtRegister_Address, ci.Id_City, ci.Description, ci.DtRegister_City, p.Dt_Register_Package, p.Package_Value, cl.Id_Client, cl.Name_Client, cl.Phone, adc.Id_Address, adc.Street, adc.Number, adc.Neighborhood, adc.Cep, adc.Complement, adc.DtRegister_Address, cic.Id_City, cic.Description, cic.DtRegister_City FROM Package p JOIN Hotel h on p.Id_Hotel_Package = h.Id_Hotel JOIN Address ah on h.Id_Address_Hotel = ah.Id_Address JOIN City ch on ah.Id_City_Address = ch.Id_City JOIN Ticket t on p.Id_Ticket_Package = t.Id_Ticket JOIN Address a on t.Id_Address_Origin = a.Id_Address JOIN City c on a.Id_City_Address = c.Id_City JOIN Address ad on t.Id_Address_Destiny = ad.Id_Address JOIN City ci on t.Id_Address_Destiny = ci.Id_City JOIN Client cl on p.Id_Client_Package = cl.Id_Client JOIN Address adc on cl.Id_Address_Client = adc.Id_Address JOIN City cic on adc.Id_City_Address = cic.Id_City 





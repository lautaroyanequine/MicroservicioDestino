
using Application.Interfaces;
using Application.UseCase;
using Domain.Entities;
using Infrastructure.Client;
using Infrastructure.Command;
using Infrastructure.Data;
using Infrastructure.Persistence;
using Infrastructure.Query;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom
var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<DestinosContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IPaisService, PaisService>();
builder.Services.AddScoped<IPaisCommand, PaisCommand>();
builder.Services.AddTransient<IPaisQuery, PaisQuery>();

builder.Services.AddScoped<IProvinciaService, ProvinciaService>();
builder.Services.AddScoped<IProvinciaCommand, ProvinciaCommand>();
builder.Services.AddTransient<IProvinciaQuery, ProvinciaQuery>();

builder.Services.AddScoped<ICiudadService, CiudadService>();
builder.Services.AddScoped<ICiudadCommand, CiudadCommand>();
builder.Services.AddTransient<ICiudadQuery, CiudadQuery>();

builder.Services.AddScoped<IViajeCiudadService, ViajeCiudadService>();
builder.Services.AddScoped<IViajeCiudadCommand, ViajeCiudadCommand>();
builder.Services.AddTransient<IViajeCiudadQuery, ViajeCiudadQuery>();

builder.Services.AddScoped<IEscalaService, EscalaService>();
builder.Services.AddScoped<IEscalaCommand, EscalaCommand>();
builder.Services.AddTransient<IEscalaQuery, EscalaQuery>();
builder.Services.AddScoped<IClientViaje, ClientViaje>();


//await PaisData.SeedPaises(); // HAY QUE EJCUTAR ESTA LINEA PARA TENER TODOS LOS PAISES,NO SE PUEDE DESCOMENTAR PQ NO DEJA HACER LA MIGRACION


/*INSERT INTO pais (nombre, codigo) VALUES ('Jordania', 'JOR');
INSERT INTO pais (nombre, codigo) VALUES('Islas Marianas del Norte', 'MNP');
INSERT INTO pais (nombre, codigo) VALUES('Serbia', 'SRB');
INSERT INTO pais (nombre, codigo) VALUES('Andorra', 'AND');
INSERT INTO pais (nombre, codigo) VALUES('Islas Turks y Caicos', 'TCA');
INSERT INTO pais (nombre, codigo) VALUES('Bermudas', 'BER');
INSERT INTO pais (nombre, codigo) VALUES('Antártida', 'ATA');
INSERT INTO pais (nombre, codigo) VALUES('Bolivia', 'BOL');
INSERT INTO pais (nombre, codigo) VALUES('Libia', 'LBA');
INSERT INTO pais (nombre, codigo) VALUES('Mali', 'MLI');
INSERT INTO pais (nombre, codigo) VALUES('Armenia', 'ARM');
INSERT INTO pais (nombre, codigo) VALUES('Mauricio', 'MRI');
INSERT INTO pais (nombre, codigo) VALUES('Maldivas', 'MDV');
INSERT INTO pais (nombre, codigo) VALUES('Samoa Americana', 'ASA');
INSERT INTO pais (nombre, codigo) VALUES('Macedonia del Norte', 'MKD');
INSERT INTO pais (nombre, codigo) VALUES('Etiopía', 'ETH');
INSERT INTO pais (nombre, codigo) VALUES('Groenlandia', 'GRL');
INSERT INTO pais (nombre, codigo) VALUES('Irak', 'IRQ');
INSERT INTO pais (nombre, codigo) VALUES('Guatemala', 'GUA');
INSERT INTO pais (nombre, codigo) VALUES('Trinidad y Tobago', 'TTO');
INSERT INTO pais (nombre, codigo) VALUES('Perú', 'PER');
INSERT INTO pais (nombre, codigo) VALUES('Surinam', 'SUR');
INSERT INTO pais (nombre, codigo) VALUES('Suecia', 'SWE');
INSERT INTO pais (nombre, codigo) VALUES('Nueva Caledonia', 'NCL');
INSERT INTO pais (nombre, codigo) VALUES('Polinesia Francesa', 'PYF');
INSERT INTO pais (nombre, codigo) VALUES('Benín', 'BEN');
INSERT INTO pais (nombre, codigo) VALUES('Estonia', 'EST');
INSERT INTO pais (nombre, codigo) VALUES('Islas Malvinas', 'FLK');
INSERT INTO pais (nombre, codigo) VALUES('Guam', 'GUM');
INSERT INTO pais (nombre, codigo) VALUES('Zimbabue', 'ZIM');
INSERT INTO pais (nombre, codigo) VALUES('República Eslovaca', 'SVK');
INSERT INTO pais (nombre, codigo) VALUES('Países Bajos', 'NED');
INSERT INTO pais (nombre, codigo) VALUES('Ecuador', 'ECU');
INSERT INTO pais (nombre, codigo) VALUES('Arabia Saudí', 'KSA');
INSERT INTO pais (nombre, codigo) VALUES('Emiratos Árabes Unidos', 'UAE');
INSERT INTO pais (nombre, codigo) VALUES('Afganistán', 'AFG');
INSERT INTO pais (nombre, codigo) VALUES('Islas Ultramarinas Menores de Estados Unidos', 'UMI');
INSERT INTO pais (nombre, codigo) VALUES('República Centroafricana', 'CAF');
INSERT INTO pais (nombre, codigo) VALUES('Panamá', 'PAN');
INSERT INTO pais (nombre, codigo) VALUES('Ciudad del Vaticano', 'VAT');
INSERT INTO pais (nombre, codigo) VALUES('Siria', 'SYR');
INSERT INTO pais (nombre, codigo) VALUES('Vanuatu', 'VAN');
INSERT INTO pais (nombre, codigo) VALUES('Honduras', 'HON');
INSERT INTO pais (nombre, codigo) VALUES('Kiribati', 'KIR');
INSERT INTO pais (nombre, codigo) VALUES('Chile', 'CHI');
INSERT INTO pais (nombre, codigo) VALUES('Burkina Faso', 'BUR');
INSERT INTO pais (nombre, codigo) VALUES('San Cristóbal y Nieves', 'SKN');
INSERT INTO pais (nombre, codigo) VALUES('San Bartolomé', 'BLM');
INSERT INTO pais (nombre, codigo) VALUES('México', 'MEX');
INSERT INTO pais (nombre, codigo) VALUES('China', 'CHN');
INSERT INTO pais (nombre, codigo) VALUES('Timor Oriental', 'TLS');
INSERT INTO pais (nombre, codigo) VALUES('Territorio Británico del Océano Índico', 'IOT');
INSERT INTO pais (nombre, codigo) VALUES('Sudán del Sur', 'SSD');
INSERT INTO pais (nombre, codigo) VALUES('Suazilandia', 'SWZ');
INSERT INTO pais (nombre, codigo) VALUES('Uzbekistán', 'UZB');
INSERT INTO pais (nombre, codigo) VALUES('Indonesia', 'INA');
INSERT INTO pais (nombre, codigo) VALUES('Paraguay', 'PAR');
INSERT INTO pais (nombre, codigo) VALUES('Mónaco', 'MON');
INSERT INTO pais (nombre, codigo) VALUES('Grenada', 'GRN');
INSERT INTO pais (nombre, codigo) VALUES('Croacia', 'CRO');
INSERT INTO pais (nombre, codigo) VALUES('Polonia', 'POL');
INSERT INTO pais (nombre, codigo) VALUES('Bosnia y Herzegovina', 'BIH');
INSERT INTO pais (nombre, codigo) VALUES('Canadá', 'CAN');
INSERT INTO pais (nombre, codigo) VALUES('Portugal', 'POR');
INSERT INTO pais (nombre, codigo) VALUES('Brasil', 'BRA');
INSERT INTO pais (nombre, codigo) VALUES('Mauritania', 'MTN');
INSERT INTO pais (nombre, codigo) VALUES('Israel', 'ISR');
INSERT INTO pais (nombre, codigo) VALUES('Curazao', 'CUW');
INSERT INTO pais (nombre, codigo) VALUES('Brunei', 'BRU');
INSERT INTO pais (nombre, codigo) VALUES('Angola', 'ANG');
INSERT INTO pais (nombre, codigo) VALUES('Malta', 'MLT');
INSERT INTO pais (nombre, codigo) VALUES('Bielorrusia', 'BLR');
INSERT INTO pais (nombre, codigo) VALUES('Turquía', 'TUR');
INSERT INTO pais (nombre, codigo) VALUES('Finlandia', 'FIN');
INSERT INTO pais (nombre, codigo) VALUES('Gibraltar', 'GIB');
INSERT INTO pais (nombre, codigo) VALUES('Bután', 'BHU');
INSERT INTO pais (nombre, codigo) VALUES('España', 'ESP');
INSERT INTO pais (nombre, codigo) VALUES('Venezuela', 'VEN');
INSERT INTO pais (nombre, codigo) VALUES('Catar', 'QAT');
INSERT INTO pais (nombre, codigo) VALUES('Chequia', 'CZE');
INSERT INTO pais (nombre, codigo) VALUES('Kuwait', 'KUW');
INSERT INTO pais (nombre, codigo) VALUES('Montenegro', 'MNE');
INSERT INTO pais (nombre, codigo) VALUES('Isla Bouvet', 'BVT');
INSERT INTO pais (nombre, codigo) VALUES('India', 'IND');
INSERT INTO pais (nombre, codigo) VALUES('Nueva Zelanda', 'NZL');
INSERT INTO pais (nombre, codigo) VALUES('Jamaica', 'JAM');
INSERT INTO pais (nombre, codigo) VALUES('Islas Caimán', 'CAY');
INSERT INTO pais (nombre, codigo) VALUES('San Marino', 'SMR');
INSERT INTO pais (nombre, codigo) VALUES('Congo', 'CGO');
INSERT INTO pais (nombre, codigo) VALUES('Pakistán', 'PAK');
INSERT INTO pais (nombre, codigo) VALUES('Francia', 'FRA');
INSERT INTO pais (nombre, codigo) VALUES('Kazajistán', 'KAZ');
INSERT INTO pais (nombre, codigo) VALUES('Bahrein', 'BHR');
INSERT INTO pais (nombre, codigo) VALUES('Fiyi', 'FIJ');
INSERT INTO pais (nombre, codigo) VALUES('Islandia', 'ISL');
INSERT INTO pais (nombre, codigo) VALUES('Myanmar', 'MYA');
INSERT INTO pais (nombre, codigo) VALUES('Bangladesh', 'BAN');
INSERT INTO pais (nombre, codigo) VALUES('Filipinas', 'PHI');
INSERT INTO pais (nombre, codigo) VALUES('Guinea Ecuatorial', 'GEQ');
INSERT INTO pais (nombre, codigo) VALUES('Irlanda', 'IRL');
INSERT INTO pais (nombre, codigo) VALUES('Nepal', 'NEP');
INSERT INTO pais (nombre, codigo) VALUES('Yemen', 'YEM');
INSERT INTO pais (nombre, codigo) VALUES('Corea del Sur', 'KOR');
INSERT INTO pais (nombre, codigo) VALUES('Dinamarca', 'DEN');
INSERT INTO pais (nombre, codigo) VALUES('Omán', 'OMA');
INSERT INTO pais (nombre, codigo) VALUES('San Vicente y Granadinas', 'VIN');
INSERT INTO pais (nombre, codigo) VALUES('Eritrea', 'ERI');
INSERT INTO pais (nombre, codigo) VALUES('Australia', 'AUS');
INSERT INTO pais (nombre, codigo) VALUES('Iran', 'IRI');
INSERT INTO pais (nombre, codigo) VALUES('El Salvador', 'ESA');
INSERT INTO pais (nombre, codigo) VALUES('Tanzania', 'TAN');
INSERT INTO pais (nombre, codigo) VALUES('Guadalupe', 'GLP');
INSERT INTO pais (nombre, codigo) VALUES('Islas Salomón', 'SOL');
INSERT INTO pais (nombre, codigo) VALUES('Kenia', 'KEN');
INSERT INTO pais (nombre, codigo) VALUES('República Dominicana', 'DOM');
INSERT INTO pais (nombre, codigo) VALUES('Grecia', 'GRE');
INSERT INTO pais (nombre, codigo) VALUES('Guernsey', 'GGY');
INSERT INTO pais (nombre, codigo) VALUES('Ruanda', 'RWA');
INSERT INTO pais (nombre, codigo) VALUES('San Pedro y Miquelón', 'SPM');
INSERT INTO pais (nombre, codigo) VALUES('Tuvalu', 'TUV');
INSERT INTO pais (nombre, codigo) VALUES('Taiwán', 'TPE');
INSERT INTO pais (nombre, codigo) VALUES('Guyana', 'GUY');
INSERT INTO pais (nombre, codigo) VALUES('Seychelles', 'SEY');
INSERT INTO pais (nombre, codigo) VALUES('Corea del Norte', 'PRK');
INSERT INTO pais (nombre, codigo) VALUES('Botswana', 'BOT');
INSERT INTO pais (nombre, codigo) VALUES('Camboya', 'CAM');
INSERT INTO pais (nombre, codigo) VALUES('Barbados', 'BAR');
INSERT INTO pais (nombre, codigo) VALUES('Colombia', 'COL');
INSERT INTO pais (nombre, codigo) VALUES('Ucrania', 'UKR');
INSERT INTO pais (nombre, codigo) VALUES('Costa de Marfil', 'CIV');
INSERT INTO pais (nombre, codigo) VALUES('Nauru', 'NRU');
INSERT INTO pais (nombre, codigo) VALUES('Namibia', 'NAM');
INSERT INTO pais (nombre, codigo) VALUES('Chad', 'CHA');
INSERT INTO pais (nombre, codigo) VALUES('Tonga', 'TGA');
INSERT INTO pais (nombre, codigo) VALUES('Argentina', 'ARG');
INSERT INTO pais (nombre, codigo) VALUES('Isla de Navidad', 'CXR');
INSERT INTO pais (nombre, codigo) VALUES('Níger', 'NIG');
INSERT INTO pais (nombre, codigo) VALUES('Islas Marshall', 'MHL');
INSERT INTO pais (nombre, codigo) VALUES('Costa Rica', 'CRC');
INSERT INTO pais (nombre, codigo) VALUES('Ghana', 'GHA');
INSERT INTO pais (nombre, codigo) VALUES('Austria', 'AUT');
INSERT INTO pais (nombre, codigo) VALUES('Santa Elena, Ascensión y Tristán de Acuña', 'SHN');
INSERT INTO pais (nombre, codigo) VALUES('Palestina', 'PLE');
INSERT INTO pais (nombre, codigo) VALUES('Cuba', 'CUB');
INSERT INTO pais (nombre, codigo) VALUES('Hungría', 'HUN');
INSERT INTO pais (nombre, codigo) VALUES('Micronesia', 'FSM');
INSERT INTO pais (nombre, codigo) VALUES('Belice', 'BIZ');
INSERT INTO pais (nombre, codigo) VALUES('Bahamas', 'BAH');
INSERT INTO pais (nombre, codigo) VALUES('Aruba', 'ARU');
INSERT INTO pais (nombre, codigo) VALUES('Santo Tomé y Príncipe', 'STP');
INSERT INTO pais (nombre, codigo) VALUES('Rusia', 'RUS');
INSERT INTO pais (nombre, codigo) VALUES('Luxemburgo', 'LUX');
INSERT INTO pais (nombre, codigo) VALUES('Islas Faroe', 'FRO');
INSERT INTO pais (nombre, codigo) VALUES('Nicaragua', 'NCA');
INSERT INTO pais (nombre, codigo) VALUES('Túnez', 'TUN');
INSERT INTO pais (nombre, codigo) VALUES('Congo (Rep. Dem.)', 'COD');
INSERT INTO pais (nombre, codigo) VALUES('Islas Svalbard y Jan Mayen', 'SJM');
INSERT INTO pais (nombre, codigo) VALUES('Sudáfrica', 'RSA');
INSERT INTO pais (nombre, codigo) VALUES('Sierra Leone', 'SLE');
INSERT INTO pais (nombre, codigo) VALUES('Lesotho', 'LES');
INSERT INTO pais (nombre, codigo) VALUES('Islas Georgias del Sur y Sandwich del Sur', 'SGS');
INSERT INTO pais (nombre, codigo) VALUES('Italia', 'ITA');
INSERT INTO pais (nombre, codigo) VALUES('Djibouti', 'DJI');
INSERT INTO pais (nombre, codigo) VALUES('Islas Heard y McDonald', 'HMD');
INSERT INTO pais (nombre, codigo) VALUES('Sri Lanka', 'SRI');
INSERT INTO pais (nombre, codigo) VALUES('Santa Lucía', 'LCA');
INSERT INTO pais (nombre, codigo) VALUES('Samoa', 'SAM');
INSERT INTO pais (nombre, codigo) VALUES('Islas Cocos o Islas Keeling', 'CCK');
INSERT INTO pais (nombre, codigo) VALUES('Puerto Rico', 'PUR');
INSERT INTO pais (nombre, codigo) VALUES('Gabón', 'GAB');
INSERT INTO pais (nombre, codigo) VALUES('Turkmenistán', 'TKM');
INSERT INTO pais (nombre, codigo) VALUES('Letonia', 'LAT');
INSERT INTO pais (nombre, codigo) VALUES('Senegal', 'SEN');
INSERT INTO pais (nombre, codigo) VALUES('Bélgica', 'BEL');
INSERT INTO pais (nombre, codigo) VALUES('Moldavia', 'MDA');
INSERT INTO pais (nombre, codigo) VALUES('Liechtenstein', 'LIE');
INSERT INTO pais (nombre, codigo) VALUES('Malawi', 'MAW');
INSERT INTO pais (nombre, codigo) VALUES('Líbano', 'LBN');
INSERT INTO pais (nombre, codigo) VALUES('Mongolia', 'MGL');
INSERT INTO pais (nombre, codigo) VALUES('Noruega', 'NOR');
INSERT INTO pais (nombre, codigo) VALUES('Islas Vírgenes del Reino Unido', 'IVB');
INSERT INTO pais (nombre, codigo) VALUES('Camerún', 'CMR');
INSERT INTO pais (nombre, codigo) VALUES('Tailandia', 'THA');
INSERT INTO pais (nombre, codigo) VALUES('Nigeria', 'NGR');
INSERT INTO pais (nombre, codigo) VALUES('Reunión', 'REU');
INSERT INTO pais (nombre, codigo) VALUES('Cabo Verde', 'CPV');
INSERT INTO pais (nombre, codigo) VALUES('Jersey', 'JEY');
INSERT INTO pais (nombre, codigo) VALUES('Argelia', 'ALG');
INSERT INTO pais (nombre, codigo) VALUES('Laos', 'LAO');
INSERT INTO pais (nombre, codigo) VALUES('Caribe Neerlandés', 'BES');
INSERT INTO pais (nombre, codigo) VALUES('Azerbaiyán', 'AZE');
INSERT INTO pais (nombre, codigo) VALUES('Sint Maarten', 'SXM');
INSERT INTO pais (nombre, codigo) VALUES('Marruecos', 'MAR');
INSERT INTO pais (nombre, codigo) VALUES('Alandia', 'ALA');
INSERT INTO pais (nombre, codigo) VALUES('Bulgaria', 'BUL');
INSERT INTO pais (nombre, codigo) VALUES('Burundi', 'BDI');
INSERT INTO pais (nombre, codigo) VALUES('Uganda', 'UGA');
INSERT INTO pais (nombre, codigo) VALUES('Kosovo', 'KOS');
INSERT INTO pais (nombre, codigo) VALUES('Mozambique', 'MOZ');
INSERT INTO pais (nombre, codigo) VALUES('Georgia', 'GEO');
INSERT INTO pais (nombre, codigo) VALUES('Reino Unido', 'GBR');
INSERT INTO pais (nombre, codigo) VALUES('Wallis y Futuna', 'WLF');
INSERT INTO pais (nombre, codigo) VALUES('Islas Pitcairn', 'PCN');
INSERT INTO pais (nombre, codigo) VALUES('Rumania', 'ROU');
INSERT INTO pais (nombre, codigo) VALUES('Vietnam', 'VIE');
INSERT INTO pais (nombre, codigo) VALUES('Tierras Australes y Antárticas Francesas', 'ATF');
INSERT INTO pais (nombre, codigo) VALUES('Sahara Occidental', 'ESH');
INSERT INTO pais (nombre, codigo) VALUES('Japón', 'JPN');
INSERT INTO pais (nombre, codigo) VALUES('Egipto', 'EGY');
INSERT INTO pais (nombre, codigo) VALUES('Liberia', 'LBR');
INSERT INTO pais (nombre, codigo) VALUES('Lituania', 'LTU');
INSERT INTO pais (nombre, codigo) VALUES('Haití', 'HAI');
INSERT INTO pais (nombre, codigo) VALUES('Islas Vírgenes de los Estados Unidos', 'ISV');
INSERT INTO pais (nombre, codigo) VALUES('Papúa Nueva Guinea', 'PNG');
INSERT INTO pais (nombre, codigo) VALUES('Hong Kong', 'HKG');
INSERT INTO pais (nombre, codigo) VALUES('Kirguizistán', 'KGZ');
INSERT INTO pais (nombre, codigo) VALUES('Palau', 'PLW');
INSERT INTO pais (nombre, codigo) VALUES('Madagascar', 'MAD');
INSERT INTO pais (nombre, codigo) VALUES('Gambia', 'GAM');
INSERT INTO pais (nombre, codigo) VALUES('Togo', 'TOG');
INSERT INTO pais (nombre, codigo) VALUES('Islas Tokelau', 'TKL');
INSERT INTO pais (nombre, codigo) VALUES('Eslovenia', 'SLO');
INSERT INTO pais (nombre, codigo) VALUES('Singapur', 'SGP');
INSERT INTO pais (nombre, codigo) VALUES('Guayana Francesa', 'GUF');
INSERT INTO pais (nombre, codigo) VALUES('Estados Unidos', 'USA');
INSERT INTO pais (nombre, codigo) VALUES('Montserrat', 'MSR');
INSERT INTO pais (nombre, codigo) VALUES('Malasia', 'MAS');
INSERT INTO pais (nombre, codigo) VALUES('Alemania', 'GER');
INSERT INTO pais (nombre, codigo) VALUES('Antigua y Barbuda', 'ANT');
INSERT INTO pais (nombre, codigo) VALUES('Saint Martin', 'MAF');
INSERT INTO pais (nombre, codigo) VALUES('Somalia', 'SOM');
INSERT INTO pais (nombre, codigo) VALUES('Macao', 'MAC');
INSERT INTO pais (nombre, codigo) VALUES('Albania', 'ALB');
INSERT INTO pais (nombre, codigo) VALUES('Mayotte', 'MYT');
INSERT INTO pais (nombre, codigo) VALUES('Dominica', 'DMA');
INSERT INTO pais (nombre, codigo) VALUES('Zambia', 'ZAM');
INSERT INTO pais (nombre, codigo) VALUES('Anguilla', 'AIA');
INSERT INTO pais (nombre, codigo) VALUES('Islas Cook', 'COK');
INSERT INTO pais (nombre, codigo) VALUES('Martinica', 'MTQ');
INSERT INTO pais (nombre, codigo) VALUES('Guinea', 'GUI');
INSERT INTO pais (nombre, codigo) VALUES('Comoras', 'COM');
INSERT INTO pais (nombre, codigo) VALUES('Niue', 'NIU');
INSERT INTO pais (nombre, codigo) VALUES('Suiza', 'SUI');
INSERT INTO pais (nombre, codigo) VALUES('Isla de Norfolk', 'NFK');
INSERT INTO pais (nombre, codigo) VALUES('Isla de Man', 'IMN');
INSERT INTO pais (nombre, codigo) VALUES('Sudán', 'SUD');
INSERT INTO pais (nombre, codigo) VALUES('Tayikistán', 'TJK');
INSERT INTO pais (nombre, codigo) VALUES('Uruguay', 'URU');
INSERT INTO pais (nombre, codigo) VALUES('Chipre', 'CYP');
INSERT INTO pais (nombre, codigo) VALUES('Guinea-Bisáu', 'GBS');
INSERT INTO pais (nombre, codigo) VALUES('ARGENTINA', 'ARG');
*/

/*

INSERT INTO Provincia (nombre, paisId) VALUES('Buenos Aires', '135');
INSERT INTO Provincia (nombre, paisId) VALUES('Catamarca', '135');
INSERT INTO Provincia (nombre, paisId) VALUES('Chaco', '135');
INSERT INTO Provincia (nombre, paisId) VALUES('Chubut', '135');
INSERT INTO Provincia (nombre, paisId) VALUES('Córdoba', '135');
INSERT INTO Provincia (nombre, paisId) VALUES('Corrientes', '135');
INSERT INTO Provincia (nombre, paisId) VALUES('Entre Ríos', '135');
INSERT INTO Provincia (nombre, paisId) VALUES('Formosa', '135');
INSERT INTO Provincia (nombre, paisId) VALUES('Jujuy', '135');
INSERT INTO Provincia (nombre, paisId) VALUES('La Pampa', '135');
INSERT INTO Provincia (nombre, paisId) VALUES('La Rioja', '135');
INSERT INTO Provincia (nombre, paisId) VALUES('Mendoza', '135');
INSERT INTO Provincia (nombre, paisId) VALUES('Misiones', '135');
INSERT INTO Provincia (nombre, paisId) VALUES('Neuquén', '135');
INSERT INTO Provincia (nombre, paisId) VALUES('Río Negro', '135');
INSERT INTO Provincia (nombre, paisId) VALUES('Salta', '135');
INSERT INTO Provincia (nombre, paisId) VALUES('San Juan', '135');
INSERT INTO Provincia (nombre, paisId) VALUES('San Luis', '135');
INSERT INTO Provincia (nombre, paisId) VALUES('Santa Cruz', '135');
INSERT INTO Provincia (nombre, paisId) VALUES('Santa Fe', '135');
INSERT INTO Provincia (nombre, paisId) VALUES('Santiago Del Estero', '135');
INSERT INTO Provincia (nombre, paisId) VALUES('Tierra del Fuego', '135');
INSERT INTO Provincia (nombre, paisId) VALUES('Tucumán', '135');

*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


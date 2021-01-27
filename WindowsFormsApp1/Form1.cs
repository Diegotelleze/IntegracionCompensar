using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string resultado = teste();
                MessageBox.Show(resultado);
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    errorMsg += $"\\r\\n {ex.Message}";
                }
                MessageBox.Show($"Error: {errorMsg}");
            }
        }

        private void serializar<H>(object data)
        {
            XmlSerializer xs = new XmlSerializer(typeof(H));
            TextWriter txtWriter = new StreamWriter(@"D:\Serializationcliente.xml");
            xs.Serialize(txtWriter, data);
            txtWriter.Close();
        }

        private string teste()
        {
            var serviceClient = new CompensarReference.AdministrarClientesClient();
            var header = GetObjectFromXml<CompensarReference.headerMessage>(Properties.Resources.xmlHeader);
            var cliente = GetObjectFromXml<CompensarReference.Cliente>(Properties.Resources.xmlCliente);
            
            //var client = new CompensarReference.AdministrarClientesClient();
            var request = new CompensarReference.CrearVinculacionClienteRequest()
            {
                crearVinculacionCliente = new CompensarReference.CrearVinculacionCliente()
                {
                    cliente = cliente
                    //cliente = GetClient()
                }
            };

            var response = serviceClient.CrearVinculacion(header, request);

            if (response.resultadoOperacion)
                return "OK";
            else
                return response.resultadoMensaje;
        }

        private CompensarReference.Cliente GetClient()
        {
            return new CompensarReference.Cliente()
            {
                legalID = 900877788,
                tipoIdentificacion = 2,
                id = 9999805069127038,
                datosEmpresa = new CompensarReference.DatosEmpresa()
                {
                    razonSocial = "-",
                    nombreComercial = "-",
                    motivoInactivacion = new CompensarReference.MotivoInactivacionREF()
                    {
                        id = "0"
                    }
                },
                sucursal = new List<CompensarReference.Sucursal>()
                {
                    new CompensarReference.Sucursal()
                    {
                        id=0,
                        sucursalID=0,
                        centroCostosID=0
                    }
                }.ToArray(),
                contacto = new List<CompensarReference.Contacto>()
                {
                    new CompensarReference.Contacto()
                    {
                        tipoContacto="-",
                        orden=-1
                    }
                }.ToArray(),
                afiliacion = new List<CompensarReference.Afiliacion>()
                {
                    new CompensarReference.Afiliacion()
                    {
                        cantidadVinculacion=4,
                        categoriaAfiliacion="K",
                        motivoRetiro = new CompensarReference.MotivoRetiroMIN()
                        {
                            id=7,
                            nombre="-"
                        },
                        clienteResponsable = new List<CompensarReference.ClienteResponsable>()
                        {
                            new CompensarReference.ClienteResponsable()
                            {
                                tipoResponsable="1",
                                centroCostosID=0,
                                sucursalID=0,
                                id=0,
                                nombre="Persona",
                                legalID=0,
                                tipoIdentificacion=0
                            },
                            new CompensarReference.ClienteResponsable()
                            {
                                tipoResponsable="2",
                                centroCostosID=0,
                                sucursalID=0,
                                id=0,
                                nombre="Empresa",
                                legalID=0,
                                tipoIdentificacion=0
                            },
                            new CompensarReference.ClienteResponsable()
                            {
                                tipoResponsable="3",
                                centroCostosID=0,
                                sucursalID=0,
                                id=0,
                                nombre="Sucursal",
                                legalID=0,
                                tipoIdentificacion=0
                            },
                            new CompensarReference.ClienteResponsable()
                            {
                                tipoResponsable="4",
                                centroCostosID=0,
                                sucursalID=0,
                                id=0,
                                nombre="Centro de Costos",
                                legalID=0,
                                tipoIdentificacion=0
                            }
                        }.ToArray(),
                        cmnt="A",
                        actualizadoEstado=true,
                        finFecha=new DateTime(2020,11,15),
                        ingresoEmpresaFecha=new DateTime(2020,11,1),
                        inicioFecha=new DateTime(2020,11,1),
                        modificacionFecha=new DateTime(),
                        registroFecha=new DateTime(),
                        retiroFecha=new DateTime(2020,11,15),
                        valorVinculacion=0,
                        variableRetiro="CRETEMP",
                        programa = new List<CompensarReference.Programa>()
                        {
                            new CompensarReference.Programa()
                            {
                                condicion=1,
                                id=1011,
                                tipoParentesco="EM",
                                sigla="CJ",
                                nombrePrograma="Empresas Afiliadas Caja",
                                esPersona=true//,
								//requisitos = new List<CompensarReference.Requisito>()
								//{

								//}.ToArray()
							}
                        }.ToArray(),
                    id=24633637,
                    clienteID=9999805069127038
                    }
                }.ToArray(),
                programa = new CompensarReference.Programa()
                {
                    id = -1,
                    clientePropietarioID = 0
                }
            };
        }

        private CompensarReference.Cliente GetClient2()
        {
            var client = new CompensarReference.Cliente();

            client.legalID = 900877788;
            client.tipoIdentificacion = 2;
            client.id = 9999805069127038;
            client.datosEmpresa = new CompensarReference.DatosEmpresa()
            {
                razonSocial = "-",
                nombreComercial = "-",
                motivoInactivacion = new CompensarReference.MotivoInactivacionREF()
                {
                    id = "0"
                }
            };
            client.sucursal = new List<CompensarReference.Sucursal>()
                {
                    new CompensarReference.Sucursal()
                    {
                        id=0,
                        sucursalID=0,
                        centroCostosID=0
                    }
                }.ToArray();
            client.contacto = new List<CompensarReference.Contacto>()
                {
                    new CompensarReference.Contacto()
                    {
                        tipoContacto="-",
                        orden=-1
                    }
                }.ToArray();
            client.afiliacion = new List<CompensarReference.Afiliacion>()
                {
                    new CompensarReference.Afiliacion()
                    {
                        cantidadVinculacion=4,
                        categoriaAfiliacion="K",
                        motivoRetiro = new CompensarReference.MotivoRetiroMIN()
                        {
                            id=7,
                            nombre="-"
                        },
                        clienteResponsable = new List<CompensarReference.ClienteResponsable>()
                        {
                            new CompensarReference.ClienteResponsable()
                            {
                                tipoResponsable="1",
                                centroCostosID=0,
                                sucursalID=0,
                                id=0,
                                nombre="Persona",
                                legalID=0,
                                tipoIdentificacion=0
                            },
                            new CompensarReference.ClienteResponsable()
                            {
                                tipoResponsable="2",
                                centroCostosID=0,
                                sucursalID=0,
                                id=0,
                                nombre="Empresa",
                                legalID=0,
                                tipoIdentificacion=0
                            },
                            new CompensarReference.ClienteResponsable()
                            {
                                tipoResponsable="3",
                                centroCostosID=0,
                                sucursalID=0,
                                id=0,
                                nombre="Sucursal",
                                legalID=0,
                                tipoIdentificacion=0
                            },
                            new CompensarReference.ClienteResponsable()
                            {
                                tipoResponsable="4",
                                centroCostosID=0,
                                sucursalID=0,
                                id=0,
                                nombre="Centro de Costos",
                                legalID=0,
                                tipoIdentificacion=0
                            }
                        }.ToArray(),
                        cmnt="A",
                        actualizadoEstado=true,
                        finFecha=new DateTime(2020,11,15),
                        ingresoEmpresaFecha=new DateTime(2020,11,1),
                        inicioFecha=new DateTime(2020,11,1),
                        modificacionFecha=new DateTime(),
                        registroFecha=new DateTime(),
                        retiroFecha=new DateTime(2020,11,15),
                        valorVinculacion=0,
                        variableRetiro="CRETEMP",
                        programa = new List<CompensarReference.Programa>()
                        {
                            new CompensarReference.Programa()
                            {
                                condicion=1,
                                id=1011,
                                tipoParentesco="EM",
                                sigla="CJ",
                                nombrePrograma="Empresas Afiliadas Caja",
                                esPersona=true,
                                requisitos = new List<CompensarReference.Requisito>(){}.ToArray()
                            }
                        }.ToArray(),
                    id=24633637,
                    clienteID=9999805069127038
                    }
                }.ToArray();
            client.programa = new CompensarReference.Programa()
            {
                id = -1,
                clientePropietarioID = 0
            };

            return client;
        }

        private dynamic GetObjectFromXml<H>(string xmlContent)
        {
            object result = null;
            var serializer = new XmlSerializer(typeof(H));

            //using (var stream = new StringReader(Properties.Resources.AdministrarClientes_Desvincular_Empresa_Request))
            using (var stream = new StringReader(xmlContent))
            using (var reader = XmlReader.Create(stream))
            {
                result = (H)serializer.Deserialize(reader);
            }
            return result;
        }
    }
}

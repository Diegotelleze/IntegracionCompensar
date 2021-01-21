using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

		private string teste()
		{
			var client = new CompensarReference1.AdministrarClientesClient();
			var request = new CompensarReference1.CrearVinculacionClienteRequest()
			{
				crearVinculacionCliente = new CompensarReference1.CrearVinculacionCliente()
				{
					cliente = GetClient()
				}
			};
			var header = new CompensarReference1.headerMessage
			{
				userName = "1022948279",
				idAplicacion = "SWPR108"
			};
			var response = client.CrearVinculacion(header,request);

			if (response.resultadoOperacion)
				return "OK";
			else
				return response.resultadoMensaje;
		}

		private CompensarReference1.Cliente GetClient()
		{
			return new CompensarReference1.Cliente()
			{
				legalID = 1,
				tipoIdentificacion = 2,
				id = 0,
				datosEmpresa = new CompensarReference1.DatosEmpresa()
				{
					razonSocial = "",
					nombreComercial = "",
					motivoInactivacion = new CompensarReference1.MotivoInactivacionREF()
					{
						id = "0"
					}
				},
				sucursal = new List<CompensarReference1.Sucursal>()
				{
					new CompensarReference1.Sucursal()
					{
						id=0,
						sucursalID=0,
						centroCostosID=0
					}
				}.ToArray(),
				contacto = new List<CompensarReference1.Contacto>()
				{
					new CompensarReference1.Contacto()
					{
						tipoContacto="-",
						orden=-1
					}
				}.ToArray(),
				afiliacion = new List<CompensarReference1.Afiliacion>()
				{
					new CompensarReference1.Afiliacion()
					{
						cantidadVinculacion=4,
						categoriaAfiliacion="K",
						motivoRetiro = new CompensarReference1.MotivoRetiroMIN()
						{
							id=7,
							nombre="-"
						},
						clienteResponsable = new List<CompensarReference1.ClienteResponsable>()
						{
							new CompensarReference1.ClienteResponsable()
							{
								tipoResponsable="1",
								centroCostosID=0,
								sucursalID=0,
								id=0,
								nombre="Persona",
								legalID=0,
								tipoIdentificacion=0
							},
							new CompensarReference1.ClienteResponsable()
							{
								tipoResponsable="2",
								centroCostosID=0,
								sucursalID=0,
								id=0,
								nombre="Empresa",
								legalID=0,
								tipoIdentificacion=0
							},
							new CompensarReference1.ClienteResponsable()
							{
								tipoResponsable="3",
								centroCostosID=0,
								sucursalID=0,
								id=0,
								nombre="Sucursal",
								legalID=0,
								tipoIdentificacion=0
							},
							new CompensarReference1.ClienteResponsable()
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
						programa = new List<CompensarReference1.Programa>()
						{
							new CompensarReference1.Programa()
							{
								condicion=1,
								id=1011,
								tipoParentesco="EM",
								sigla="CJ",
								nombrePrograma="Empresas Afiliadas Caja",
								esPersona=true,
								requisitos = new List<CompensarReference1.Requisito>()
								{

								}.ToArray()
							}
						}.ToArray(),
					id=24633637,
					clienteID=9999805069127038
					}
				}.ToArray(),
				programa = new CompensarReference1.Programa()
				{
					id = -1,
					clientePropietarioID = 0
				}
			};
		}
	}
}

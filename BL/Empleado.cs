using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
		public static (bool, string, ML.Empleado, Exception) GetById(int IdEmpleado)
		{
			ML.Empleado empleado1 = new ML.Empleado();
			try
			{
				using (DL.PVillaRecursosHumanosEntities context = new DL.PVillaRecursosHumanosEntities())
				{
					var query = context.GetByIdDE(IdEmpleado).FirstOrDefault();
					if (query != null)
					{
						empleado1.IdEmpleado = query.IdEmpleado;
						empleado1.NumeroEmpleado = query.NumeroEmpleado;
						empleado1.Nombre = query.Nombre;
						empleado1.ApellidoPaterno = query.ApellidoPaterno;
						empleado1.ApellidoMaterno = query.ApellidoMaterno;
						empleado1.Email = query.Email;
						empleado1.Genero = query.Genero;
						empleado1.FechaNacimiento = query.FechaNacimiento;
						empleado1.Telefono = query.Telefono;
						empleado1.Celular = query.Celular;
						empleado1.Sueldo = query.Sueldo;
						empleado1.Depto = new ML.Departamento();
						empleado1.Depto.IdDepartamento = query.IdDepartamento;
						empleado1.Depto.NombreDepartamento = query.NombreDepatamento;

						return (true, "registros encontrados", empleado1, null);
					}
					
				else
					{
						return (false, "registros no encontrados", empleado1, null);
					}

			}

			}
			catch (Exception ex)
			{
				return (false, ex.Message, empleado1, ex);
			}
		}


public static (bool, string, ML.Empleado, Exception) GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();   
            try
            {
                using (DL.PVillaRecursosHumanosEntities context = new DL.PVillaRecursosHumanosEntities())
                {
                   var query = context.GetAllDE().ToList();
                    if (query != null)
                    {
                        empleado.empleados = new List<ML.Empleado>();

                        foreach(var registros in  query) 
                        { 
                            ML.Empleado empleado1 = new ML.Empleado();
                            empleado1.IdEmpleado = registros.IdEmpleado;
							empleado1.NumeroEmpleado = registros.NumeroEmpleado;
                            empleado1.Nombre = registros.Nombre;
                            empleado1.ApellidoPaterno = registros.ApellidoPaterno;
                            empleado1.ApellidoMaterno = registros.ApellidoMaterno;
                            empleado1.Email = registros.Email;
                            empleado1.Genero = registros.Genero;
                            empleado1.FechaNacimiento = registros.FechaNacimiento;
                            empleado1.Telefono = registros.Telefono;
                            empleado1.Celular = registros.Celular;
                            empleado1.Sueldo = registros.Sueldo;
                            empleado1.Depto = new ML.Departamento();
                            empleado1.Depto.IdDepartamento = registros.IdDepartamento;
                            empleado1.Depto.NombreDepartamento = registros.NombreDepatamento;

                            empleado.empleados.Add(empleado1);
                        }
                        return (true, "registros encontrados", empleado, null);
                    }
                    else
                    {
						return (false, "registros no encontrados", empleado, null);
					}

                }

            }
            catch(Exception ex)
            {
				return (false, ex.Message, empleado, ex);
			}
        }

		public static (bool, string, Exception) Add(ML.Empleado empleado)
		{
			try
			{
				using(DL.PVillaRecursosHumanosEntities context = new DL.PVillaRecursosHumanosEntities())
				{
					var rowAffected = context.AddED(empleado.NumeroEmpleado,empleado.Nombre,empleado.ApellidoPaterno,empleado.ApellidoMaterno,empleado.Email,empleado.Genero,empleado.FechaNacimiento,empleado.Telefono, empleado.Celular,empleado.Sueldo, empleado.Depto.IdDepartamento);

					if (rowAffected > 0)
					{
						return (true, "Registro agregado", null);
					}
					else
					{
						return (true, "Registro agregado", null);
					}
				}

			}
			catch (Exception ex)
			{
				return (true, ex.Message, ex);
			}
		}



		public static (bool, string, Exception) Update(ML.Empleado empleado)
		{
			try
			{
				using (DL.PVillaRecursosHumanosEntities context = new DL.PVillaRecursosHumanosEntities())
				{
					//var rowAffected = context.AddED(empleado.NumeroEmpleado, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Email, empleado.Genero, empleado.FechaNacimiento, empleado.Telefono, empleado.Celular, empleado.Sueldo, empleado.Depto.IdDepartamento);
					var rowAffected = context.UpdateEmpleado(empleado.NumeroEmpleado, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Email, empleado.Genero, empleado.FechaNacimiento, empleado.Telefono, empleado.Celular, empleado.Sueldo, empleado.Depto.IdDepartamento, empleado.IdEmpleado);
					if (rowAffected > 0)
					{
						return (true, "Registro actualizado", null);
					}
					else
					{
						return (false, "Registro no actualizado", null);
					}
				}

			}
			catch (Exception ex)
			{
				return (false, ex.Message, ex);
			}
		}


		public static (bool, string, Exception) Delete(int IdEmpleado)
		{
			try
			{
				using (DL.PVillaRecursosHumanosEntities context = new DL.PVillaRecursosHumanosEntities())
				{
					var rowAffected = context.DeleteE(IdEmpleado);
					if (rowAffected > 0)
					{
						return (true, "Registro eliminado", null);
					}
					else
					{
						return (false, "Registro no eliminado", null);
					}
				}

			}
			catch (Exception ex)
			{
				return (false, ex.Message, ex);
			}
		}





	}
}

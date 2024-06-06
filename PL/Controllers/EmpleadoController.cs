using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Depto = new ML.Departamento();

            var result = BL.Empleado.GetAll();
            if (result.Item1)
            {
                empleado.empleados = new List<ML.Empleado>();
                empleado.empleados = result.Item3.empleados;

            }

            return View(empleado);
        }

        public ActionResult Form(int? IdEmpleado)
        {
            if(IdEmpleado > 0)
            {
                var result = BL.Empleado.GetById(IdEmpleado.Value);
                if(result.Item1)
                {
                    ML.Empleado empleado = new ML.Empleado();

                  empleado =  result.Item3;

                    return View(empleado);
                }
                else
                {
                    ViewBag.Text = "No hay Registro";
                    return PartialView("Modal");
                }
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult Form(ML.Empleado empleado)
        {
            if (empleado.IdEmpleado > 0)
            {

                var result = BL.Empleado.Update(empleado);
                if (result.Item1)
                {
					ViewBag.Text = "El Registro se actualizo correctamente";
					return PartialView("Modal");
				}
                else
                {
					ViewBag.Text = "El Registro no actualizo correctamente";
					return PartialView("Modal");
				}
            }
            else
            {

                var result = BL.Empleado.Add(empleado);
                if (result.Item1)
                {
					ViewBag.Text = "El Registro se agrego correctamente";
					return PartialView("Modal");
				}
				else
				{
					ViewBag.Text = "El Registro no se agrego correctamente";
					return PartialView("Modal");
				}

			}

        }


        public ActionResult Delete(int IdEmpleado)
        {
            if(IdEmpleado > 0)
            {
                var result = BL.Empleado.Delete(IdEmpleado);
                if(result.Item1)
                {
					ViewBag.Text = "El Registro se elimino correctamente";
					return PartialView("Modal");
				}
				else
				{
					ViewBag.Text = "El Registro no se elimino correctamente";
					return PartialView("Modal");
				}

			}
            else
            {
				ViewBag.Text = "El Registro no se elimino correctamente";
				return PartialView("Modal");
			}
        }



    }
}
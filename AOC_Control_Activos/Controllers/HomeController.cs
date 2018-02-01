using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AOC_Control_Activos.Models;

namespace AOC_Control_Activos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Empleado empleado = Session["empleado"] as Empleado;
            if(empleado != null)
            {
                return View("Index");
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult Login(FormCollection data)
        {
            Empleado empleado= null;

            string user = data["correo"];
            string pass = data["contrasenia"];

            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["aoc"].ToString());

            var command = new SqlCommand("SELECT * FROM Empleado WHERE correo = @correo " +
                "AND contrasenia = @contrasenia", connection);

            command.Parameters.Clear();
            command.Parameters.AddWithValue("@correo", user);
            command.Parameters.AddWithValue("@contrasenia", pass);

            try
            {
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    empleado = new Empleado
                    {
                        IDEmpleado = Int32.Parse(reader["IDEmpleado"].ToString()),
                        nombre = reader["nombre"].ToString(),
                        correo = reader["correo"].ToString(),
                        telefono = reader["telefono"].ToString(),
                        tipo_acceso = Int32.Parse(reader["tipo_acceso"].ToString())
                    };
                }

                connection.Close();
            }
            catch (SqlException ex)
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            if (empleado == null)
            {
                Session["message"] = "Usuario o contraseña incorrectos.";
                return RedirectToAction("Index");
            }
            else
            {
                Session["empleado"] = empleado;
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
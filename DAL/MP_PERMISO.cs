using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using BE;
using System.Data.Common;
using System.Text.RegularExpressions;
using System;
using BE.Composite;
using System.ComponentModel;
namespace DAL
{

    public class MP_PERMISO
    {

        Acceso acceso;
        bool accesopropio;

        public MP_PERMISO()
        {

            accesopropio = true;
            acceso = new Acceso();
        }

        internal MP_PERMISO(Acceso ac)
        {

            acceso = ac;
            accesopropio = false;
        }

        private void Abrir()
        {

            if (accesopropio)
            {

                acceso.Abrir();
            }

        }

        private void IniciarTx()
        {

            if (accesopropio)
            {

                acceso.ComenzarTransaccion();
            }

        }

        private void FinalizarTx(int i)
        {

            if (accesopropio)
            {

                if (i >= 0) { acceso.ConfirmarTransaccion(); } else { acceso.CancelarTransaccion(); }
            }

        }

        private void Cerrar()
        {

            if (accesopropio)
            {

                acceso.Cerrar();
            }

        }




        public List<string> GetAllPermission()
        {
            List<string> permisos = new List<string>();


            Abrir();
            IniciarTx();
            DataTable tabla = acceso.Leer("permiso_listar");
            foreach (DataRow registro in tabla.Rows)
            {
                permisos.Add(registro["permiso"].ToString());
            }
            tabla = null;
           // FinalizarTx(1);
            Cerrar();

            return permisos;
        }

        public Componente GuardarComponente(Componente p, bool esfamilia)
        {
            try
            {
                Abrir();
                IniciarTx();
                List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@nombre", p.Nombre) };
                if (esfamilia)
                {
                    parametros.Add(new SqlParameter("@permiso", DBNull.Value));
                }
                else
                {
                    parametros.Add(new SqlParameter("@permiso", p.Permiso.ToString()));
                }

                acceso.Escribir("permiso_guardar", parametros);

                Cerrar();


                //FinalizarTx(1);
                return p;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }



        public void GuardarFamilia(Familia c)
        {

            try
            {
                Abrir();
                IniciarTx();
                List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("id", c.Id) };

                acceso.Escribir("borrar_permiso_permiso", parametros);
                
                Cerrar();
               
                Abrir();
                IniciarTx();
                foreach (var item in c.Hijos)
                {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("id_permiso_padre", c.Id));
                    parameters.Add(new SqlParameter("id_permiso_hijo", item.Id));
                    
                    
                    acceso.Escribir("familia_guardar", parameters);

                }
                Cerrar();
                //FinalizarTx(1);


            }
            catch (Exception)
            {
                FinalizarTx(-1);
                throw;

            }
        }




        public IList<Patente> GetAllPatentes()
        {


            //Abrir();
            //IniciarTx();


            List<Patente> permisos = new List<Patente>();

            string con = @"Integrated Security=SSPI;Data Source=.\SQLEXPRESS;Initial Catalog=CRM";
            using (SqlConnection cone = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand("select * from permiso where permiso is not null", cone);
                cone.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Patente c = new Patente();

                        c.Id = int.Parse(reader["id"].ToString());
                        c.Nombre = reader["nombre"].ToString();
                        c.Permiso = reader["permiso"].ToString();
                        permisos.Add(c);

                    }
                }
            }
            return permisos;
        }

        //    acceso.Abrir();
            
        //    var lista = new List<Patente>();

        //    DataTable tabla = acceso.Leer("permiso_listar");
        //    foreach (DataRow registro in tabla.Rows)

        //    {


        //        Patente c = new Patente();

        //        c.Id = int.Parse(registro["id"].ToString());
        //        c.Nombre = registro["nombre"].ToString();
        //        c.Permiso = registro["permiso"].ToString();
        //        lista.Add(c);



        //    }
        //    tabla = null;
        //    //FinalizarTx(1);
        //    Cerrar();
            


        //    return lista;
        //}



        public IList<Familia> GetAllFamilias()
        {
            var lista = new List<Familia>();

            Abrir();
            IniciarTx();
            DataTable tabla = acceso.Leer("familias_listar");
            foreach (DataRow registro in tabla.Rows)
            {

                Familia c = new Familia();
                
                c.Id = int.Parse(registro["id"].ToString());
                c.Nombre = registro["nombre"].ToString();
                
                lista.Add(c);
            }

            return lista;
        }

        private Componente GetComponent(int id, IList<Componente> lista)
        {

            Componente component = lista != null ? lista.Where(i => i.Id.Equals(id)).FirstOrDefault() : null;

            if (component == null && lista != null)
            {
                foreach (var c in lista)
                {

                    var l = GetComponent(id, c.Hijos);
                    if (l != null && l.Id == id) return l;
                    else
                    if (l != null)
                        return GetComponent(id, l.Hijos);

                }
            }



            return component;



        }


        public IList<Componente> GetAll(string familia)
        {
            var lista = new List<Componente>();

            try
            {
                Abrir();
                IniciarTx();

                string query = @"
                    WITH recursivo AS (
                        SELECT sp2.permiso_padre_id, sp2.permiso_hijo_id
                        FROM permiso_permisos sp2
                        WHERE sp2.permiso_padre_id = @familia
                        UNION ALL
                        SELECT sp.permiso_padre_id, sp.permiso_hijo_id
                        FROM permiso_permisos sp
                        INNER JOIN recursivo r ON r.permiso_hijo_id = sp.permiso_padre_id
                    )
                    SELECT r.permiso_padre_id, r.permiso_hijo_id, p.permiso_id, p.nombre, p.descripcion
                    FROM recursivo r
                INNER JOIN permisos p ON r.permiso_hijo_id = p.permiso_id;";


                using (SqlConnection cone = new SqlConnection(@"Integrated Security=SSPI;Data Source=.\SQLEXPRESS;Initial Catalog=CRM"))
                {
                    SqlCommand cmd = new SqlCommand(query, cone);
                    cmd.Parameters.AddWithValue("@familia", string.IsNullOrEmpty(familia) ? (object)DBNull.Value : familia);
                    cone.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id_padre = reader.IsDBNull(reader.GetOrdinal("permiso_padre_id")) ? 0 : reader.GetInt32(reader.GetOrdinal("permiso_padre_id"));
                            int id = reader.GetInt32(reader.GetOrdinal("permiso_id"));
                            string nombre = reader.GetString(reader.GetOrdinal("nombre"));
                            string permiso = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? string.Empty : reader.GetString(reader.GetOrdinal("descripcion"));

                            Componente c;
                            if (string.IsNullOrEmpty(permiso))
                            {
                                c = new Familia();
                            }
                            else
                            {
                                c = new Patente();
                                c.Permiso = permiso;
                            }
                            c.Id = id;
                            c.Nombre = nombre;

                            var padre = GetComponent(id_padre, lista);

                            if (padre == null)
                            {
                                lista.Add(c);
                            }
                            else
                            {
                                padre.AgregarHijo(c);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los permisos", ex);
            }
            finally
            {
                Cerrar();
            }

            return lista;
        }


        //public IList<Componente> GetAll(string familia)
        //{
        //    var lista = new List<Componente>();

        //    try
        //    {

        //        Abrir();
        //        IniciarTx();


        //        List<SqlParameter> parametros = new List<SqlParameter>
        //            {
        //                new SqlParameter("@familia", string.IsNullOrEmpty(familia) ? (object)DBNull.Value : familia)
        //            };




        //        DataTable tabla = acceso.Leer("GetAllPermissions",parametros);
        //        {
        //            foreach (DataRow registro in tabla.Rows)
        //            {
        //                int id_padre = 0;
        //                if (registro["id_permiso_padre"] != DBNull.Value)

        //                {
        //                    id_padre = int.Parse(registro["id_permiso_padre"].ToString());
        //                }

        //                int id = int.Parse(registro["id"].ToString());
        //                string Nombre = registro["nombre"].ToString();
        //                var permiso = string.Empty;
        //                if (registro["permiso"] != DBNull.Value)

        //                {
        //                    permiso = registro["permiso"].ToString();
        //                }

        //                Componente c;
        //                if (string.IsNullOrEmpty(permiso))
        //                    c = new Familia();
        //                else
        //                    c = new Patente();
        //                c.Id = id;
        //                c.Nombre = Nombre;
        //                if (!string.IsNullOrEmpty(permiso))
        //                    c.Permiso = permiso;


        //                var padre = GetComponent(id_padre, lista);

        //                if (padre == null)
        //                {
        //                    lista.Add(c);
        //                }
        //                else
        //                {
        //                    padre.AgregarHijo(c);
        //                }

        //            }
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error al obtener los permisos", ex);
        //    }

        //    return lista;
        //}




        //public void FillUserComponents(Usuario u)
        //{
        //    Abrir();
        //    IniciarTx();

        //    List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@id", u.Id.ToString()) };





        //    DataTable tabla = acceso.Leer("fillusercomponents", parametros);

        //    u.Permisos.Clear();
        //    foreach (DataRow registro in tabla.Rows)
        //    {


        //        var idp =int.Parse(registro["id"].ToString());
        //        var nombrep = registro["nombre"].ToString();

        //        var permisop = String.Empty;
        //        if (registro["permiso"] != DBNull.Value)
        //            permisop = registro["permiso"].ToString();

        //        Componente c1;
        //        if (!String.IsNullOrEmpty(permisop))
        //        {
        //            c1 = new Patente();
        //            c1.Id = idp;
        //            c1.Nombre = nombrep;
        //            c1.Permiso = permisop;
        //            u.Permisos.Add(c1);
        //        }
        //        else
        //        {
        //            c1 = new Familia();
        //            c1.Id = idp;
        //            c1.Nombre = nombrep;

        //            var f = GetAll(idp.ToString());

        //            foreach (var familia in f)
        //            {
        //                c1.AgregarHijo(familia);
        //            }
        //            u.Permisos.Add(c1);
        //        }



        //    }
        //    //FinalizarTx(1);
        //    Cerrar();

        //}
        public void FillUserComponents(Usuario u)
        {
            // Limpiar permisos actuales del usuario
            u.Permisos.Clear();

            string con = @"Integrated Security=SSPI;Data Source=.\SQLEXPRESS;Initial Catalog=CRM";
            using (SqlConnection cone = new SqlConnection(con))
            {
                string query = "SELECT p.* FROM usuario_permisos up INNER JOIN permisos p ON up.permiso_id = p.permiso_id WHERE usuario_id = @id_usuario";
                SqlCommand cmd = new SqlCommand(query, cone);
                cmd.Parameters.AddWithValue("@id_usuario", u.Id);

                cone.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idp = reader.GetInt32(reader.GetOrdinal("permiso_id"));
                        string nombrep = reader.GetString(reader.GetOrdinal("nombre"));
                        string permisop = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? string.Empty : reader.GetString(reader.GetOrdinal("descripcion"));

                        Componente c1;

                        if (!string.IsNullOrEmpty(permisop))
                        {
                            c1 = new Patente
                            {
                                Id = idp,
                                Nombre = nombrep,
                                Permiso = permisop
                            };
                            u.Permisos.Add(c1);
                        }
                        else
                        {
                            c1 = new Familia
                            {
                                Id = idp,
                                Nombre = nombrep
                            };

                            var f = GetAll(idp.ToString());

                            foreach (var familia in f)
                            {
                                c1.AgregarHijo(familia);
                            }

                            u.Permisos.Add(c1);
                        }
                    }
                }
            }
        }


        //public void FillUserComponents(Usuario u)
        //{
        //    try
        //    {
        //        Abrir();
        //        IniciarTx();

        //        List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@id", u.Id.ToString()) };

        //        DataTable tabla = acceso.Leer("fillusercomponents", parametros);

        //        u.Permisos.Clear();
        //        foreach (DataRow registro in tabla.Rows)
        //        {
        //            var idp = int.Parse(registro["id"].ToString());
        //            var nombrep = registro["nombre"].ToString();

        //            var permisop = string.Empty;
        //            if (registro["permiso"] != DBNull.Value)
        //                permisop = registro["permiso"].ToString();

        //            Componente c1;
        //            if (!string.IsNullOrEmpty(permisop))
        //            {
        //                c1 = new Patente();
        //                c1.Id = idp;
        //                c1.Nombre = nombrep;
        //                c1.Permiso = permisop;
        //                u.Permisos.Add(c1);
        //            }
        //            else
        //            {
        //                c1 = new Familia();
        //                c1.Id = idp;
        //                c1.Nombre = nombrep;

        //                var f = GetAll(idp.ToString());

        //                foreach (var familia in f)
        //                {
        //                    c1.AgregarHijo(familia);
        //                }
        //                u.Permisos.Add(c1);
        //            }
        //        }
        //        FinalizarTx(1);

        //        //ConfirmarTransaccion(); // Confirmar transacción al final
        //    }
        //    catch (Exception ex)
        //    {
        //        //CancelarTransaccion(); // Cancelar transacción en caso de error
        //        throw ex;
        //    }
        //    finally
        //    {
        //        Cerrar(); // Asegurarse de cerrar la conexión
        //    }
        //}

        public void FillFamilyComponents(Familia familia)
        {
            familia.VaciarHijos();
            foreach (var item in GetAll(familia.Id.ToString()))
            {
                familia.AgregarHijo(item);
            }
        }

    }
}

    
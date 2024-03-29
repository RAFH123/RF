﻿

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Distribuidora.RF.Entities;
using System.Data;

namespace Distribuidora.RF.DataAccessLayer
{
    public class PerfilDao
    {
        public IList<Perfil> GetAll()
        {
            List<Perfil> listadoPerfiles = new List<Perfil>();

            var strSql = "SELECT * From Perfiles WHERE id_perfil <> 1 AND borrado=0" ;

            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoPerfiles.Add(ObjectMapping(row));
            }

            return listadoPerfiles;
        }

        private Perfil ObjectMapping(DataRow row)
        {
            Perfil oPerfil = new Perfil
            {
                IdP = Convert.ToInt32(row["id_Perfil"].ToString()),
                Nombre = row["descripcion"].ToString()
            };

            return oPerfil;
        }
    }

}
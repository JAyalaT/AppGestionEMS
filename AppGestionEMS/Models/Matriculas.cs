﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppGestionEMS.Models
{
	public class Matriculas
	{
		public int Id { get; set; }

		[Display(Name = "Curso")]
		public int CursoId { get; set; }
		public virtual Cursos Curso { get; set; }

		[Display(Name = "GrupoClase")]
		public int GrupoClaseId { get; set; }
		public virtual GrupoClases Grupo { get; set; }

		[Display(Name = "Alumno")]
		public int UserId { get; set; }
		public virtual ApplicationUser User { get; set; }
	}
}
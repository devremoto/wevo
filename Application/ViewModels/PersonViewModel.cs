﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public partial class PersonViewModel
    {
		[Key]
		public Guid Id{ get; set; }
		public string Nome{ get; set; }
		public string CPF{ get; set; }
		public string Email{ get; set; }
		public string Telefone{ get; set; }
		public DateTime DataNascimento{ get; set; }
    }
}

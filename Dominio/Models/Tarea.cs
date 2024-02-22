﻿using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Models;

public class Tarea
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo obligatorio"), MinLength(3)]
    public string Descripcion { get; set; } = string.Empty;


    [Required(ErrorMessage = "Campo obligatorio"), MinLength(3)]
    public string HombreClave { get; set; } = string.Empty;


    [Required(ErrorMessage = "Campo obligatorio"), MinLength(3)]
    public string Telefono { get; set; } = string.Empty;


    [Required(ErrorMessage = "Campo obligatorio")]
    public DateTime Inicio { get; set; } = DateTime.Now;


    [Required(ErrorMessage = "Campo obligatorio")]
    public DateTime Fim { get; set; } = DateTime.Now;


}

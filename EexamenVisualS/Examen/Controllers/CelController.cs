using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackElectronicos.Controllers
{
    [Route("api/[controller]")]
    public class CelController : Controller
    {
        //Variable de contexto de BD
        private readonly TiendaCEl _baseDatos;

        public CelController(TiendaCEl baseDatos)
        {
            this._baseDatos = baseDatos;
        }



        //Método GET ListaTareas
        [HttpGet]
        [Route("ListaElectronicos")]
        public async Task<IActionResult> Lista()
        {
            var listaElectronicos = await _baseDatos.Productos.ToListAsync();
            return Ok(listaElectronicos);

        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using Buffet.Data;
using Microsoft.EntityFrameworkCore;

namespace Buffet.Models.Buffet.ConvidadosDoEvento
{
    public class ConvidadoService
    {
        private readonly DatabaseContext _databaseContext;

        public ConvidadoService(
            DatabaseContext databaseContext
        )
        {
            _databaseContext = databaseContext;
        }
 
       
    }
}
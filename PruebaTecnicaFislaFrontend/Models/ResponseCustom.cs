using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaFislaFrontend.Request {
    public class ResponseCustom {
        public bool IsValid { get; set; }
        public List<Validation> Validations { get; set; }
    }
}

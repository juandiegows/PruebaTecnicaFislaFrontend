using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Request {
    public class Reponse {
        public string IsValid { get; set; }
        public List<Validation> Validations { get; set; }
    }
}

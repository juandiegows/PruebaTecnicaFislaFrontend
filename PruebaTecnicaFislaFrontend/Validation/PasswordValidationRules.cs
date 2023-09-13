using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaFislaFrontend {
    public class PasswordValidationRules {

        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public bool RequireSpecialCharacter { get; set; }
        public bool RequireNumeric { get; set; }
        public bool RequireMaxLength { get; set; }
        public bool RequireMinLength { get; set; }
        public bool RequireUppercase { get; set; }
        public bool RequireLowercase { get; set; }
        public int MinGroupCount { get; set; }
        public bool AllowSequences { get; set; }
        public bool AllowRepeatingCharacters { get; set; }
        public bool AllowWhitespace { get; set; }

        public static PasswordValidationRules getInstancia() {

            return new PasswordValidationRules() {
                AllowRepeatingCharacters = true,
                AllowSequences = true,
                AllowWhitespace = true,
                MaxLength = 10,
                MinGroupCount = 4,
                MinLength = 2,
                RequireLowercase = true,
                RequireNumeric = true,
                RequireSpecialCharacter = true,
                RequireUppercase = true,
                RequireMaxLength= true,
                RequireMinLength = true,
            };
        }
    }
}

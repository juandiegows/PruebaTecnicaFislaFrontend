using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller {
    public class PasswordValidationRules {

        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public bool RequireSpecialCharacter { get; set; }
        public bool RequireNumeric { get; set; }
        public bool RequireUppercase { get; set; }
        public bool RequireLowercase { get; set; }
        public int MinGroupCount { get; set; }
        public bool DisallowSequences { get; set; }
        public bool DisallowRepeatingCharacters { get; set; }
        public bool DisallowWhitespace { get; set; }

        public PasswordValidationRules getInstancia() {
            string jsonContent = File.ReadAllText(Environment.CurrentDirectory + "appsettings.json");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PasswordValidationRules>(jsonContent);
        }
    }
}

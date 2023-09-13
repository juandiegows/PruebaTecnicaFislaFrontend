using PruebaTecnicaFislaFrontend.Request;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace PruebaTecnicaFislaFrontend.Validation {
    public class Validator {
        public Validator() { }
        public static ResponseCustom getValidation(string pass) {
            var response = new ResponseCustom() {
                Validations = new List<Request.Validation>()
            };
            var rules = PasswordValidationRules.getInstancia();
            response.IsValid = true;
            int count = 0;
            var valid = true;
            bool errorCritico = false;
            //maxima
            if (rules.RequireMaxLength) {


                if (pass.Length > rules.MaxLength) {
                    valid = response.IsValid = false;
                }
                if (!valid) {
                    errorCritico = true;
                }
                response.Validations.Add(new Request.Validation() {
                    IsValid = valid,
                    Name = $"Longitud Máxima de {rules.MaxLength} caracteres permitidos"
                });
            }


            //minima
            if (rules.RequireMinLength) {
                valid = true;

                if (pass.Length < rules.MinLength) {
                    valid = response.IsValid = false;
                }
                if (!valid) {
                    errorCritico = true;
                }
                response.Validations.Add(new Request.Validation() {
                    IsValid = valid,
                    Name = $"Longitud mínima {rules.MinLength}  caracteres permitidos"
                });
            }





            //caracteres especiales
            valid = true;

            if (rules.RequireSpecialCharacter) {
                if (!ContainsSpecialCharacter(pass)) {
                    valid = response.IsValid = false;
                }

                if (valid) {
                    count++;
                }
                response.Validations.Add(new Request.Validation() {
                    IsValid = valid,
                    Name = $"La contraseña debe de contener al menos 1 carácter Especial"
                });
            }



            //caracteres es numero

            valid = true;
            if (rules.RequireNumeric) {
                if (!ContainsNumber(pass)) {
                    valid = response.IsValid = false;
                }

                if (valid) {
                    count++;
                }
                response.Validations.Add(new Request.Validation() {
                    IsValid = valid,
                    Name = $" la contraseña debe de contener al menos 1 carácter numérico\r"
                });
            }
            //caracteres es numero

            valid = true;
            if (rules.RequireUppercase) {
                if (!ContainsUpper(pass)) {
                    valid = response.IsValid = false;
                }


                if (valid) {
                    count++;
                }
                response.Validations.Add(new Request.Validation() {
                    IsValid = valid,
                    Name = $" la contraseña debe de contener al menos 1 carácter en mayúsculas\r"
                });
            }
            valid = true;
            if (rules.RequireLowercase) {
                if (!ContainsLower(pass)) {
                    valid = response.IsValid = false;
                }

                if (valid) {
                    count++;
                }
                response.Validations.Add(new Request.Validation() {
                    IsValid = valid,
                    Name = $" la contraseña debe de contener al menos 1 carácter en minúsculas\r"
                });
            }


            valid = rules.AllowWhitespace ? true : !ContainsWhiteSpace(pass);
            if (!valid) {
                errorCritico = true;
            }
            response.Validations.Add(new Request.Validation() {
                IsValid = valid,
                Name = $"Contener espacios en blanco\r"
            });
        
            valid = true;
            if (count >= rules.MinGroupCount) {
                response.IsValid = count >= rules.MinGroupCount;
                response.Validations.Add(new Request.Validation() {
                    IsValid = true,
                    Name = $"La contraseña debe de contener al menos {rules.MinGroupCount} grupos de los cuatro (Especiales, numero, mayúsculas, minúsculas)\r\r"
                });
            }else {
                response.Validations.Add(new Request.Validation() {
                    IsValid = false,
                    Name = $"La contraseña debe de contener al menos {rules.MinGroupCount} grupos de los cuatro (Especiales, numero, mayúsculas, minúsculas)\r\r"
                });
            }
            if (errorCritico) {
                response.IsValid = false;
                return response;
            }

            return response;
        }
      
        private static bool ContainsSpecialCharacter(string pass) {
            string specialCharacters = "!@#$%^&*()_+-=[]{}|;:,.<>?/";
            return pass.Any(c => specialCharacters.Contains(c));
        }
        private static bool ContainsNumber(string pass) {
            foreach (var c in pass) {
                if (Char.IsDigit(c)) {
                    return true;
                }
            }
            return false;
        }
        private static bool ContainsUpper(string pass) {
            foreach (var c in pass) {
                if (Char.IsUpper(c)) {
                    return true;
                }
            }
            return false;
        }
        private static bool ContainsLower(string pass) {
            foreach (var c in pass) {
                if (Char.IsLower(c)) {
                    return true;
                }
            }
            return false;
        }

        private static bool ContainsWhiteSpace(string pass) {
            foreach (var c in pass) {
                if (Char.IsWhiteSpace(c)) {
                    return true;
                }
            }
            return false;
        }
    }
}
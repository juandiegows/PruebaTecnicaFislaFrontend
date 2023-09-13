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
            //maxima
            if (rules.RequireMaxLength) {
            

                if (pass.Length > rules.MaxLength) {
                    valid = response.IsValid = false;
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
                Count(valid, count);
                response.Validations.Add(new Request.Validation() {
                    IsValid = valid,
                    Name = $"La contraseña debe de contener al menos 1 carácter Especial"
                });
            }



            //caracteres es numero
         

            if (rules.RequireNumeric) {
                if (!ContainsNumber(pass)) {
                    valid = response.IsValid = false;
                }
                Count(valid, count);
                response.Validations.Add(new Request.Validation() {
                    IsValid = valid,
                    Name = $" la contraseña debe de contener al menos 1 carácter numérico\r"
                });
            }
            //caracteres es numero


            if (rules.RequireUppercase) {
                if (!ContainsUpper(pass)) {
                    valid = response.IsValid = false;
                }

                Count(valid, count);
                response.Validations.Add(new Request.Validation() {
                    IsValid = valid,
                    Name = $" la contraseña debe de contener al menos 1 carácter en mayúsculas\r"
                });
            }

            if (rules.RequireLowercase) {
                if (!ContainsLower(pass)) {
                    valid = response.IsValid = false;
                }
            
                Count(valid, count);
                response.Validations.Add(new Request.Validation() {
                    IsValid = valid,
                    Name = $" la contraseña debe de contener al menos 1 carácter en minúsculas\r"
                });
            }

            
                valid = rules.AllowWhitespace ? true : !ContainsLower(pass);
              
                response.Validations.Add(new Request.Validation() {
                    IsValid = valid,
                    Name = $"Contener espacios en blanco\r"
                });
            if(count >= rules.MinGroupCount) {
                response.IsValid = true;
            }
            return response;
        }
        public static void Count(bool valid, int num) {
            if(valid) {
                num++;
            }
        
        }
        private static bool ContainsSpecialCharacter(string pass) {
            string specialCharacters = "!@#$%^&*()_+-=[]{}|;:,.<>?/";
            return pass.Any(c => specialCharacters.Contains(c));
        }
        private static bool ContainsNumber(string pass) {
            return pass.Any(c => Char.IsDigit(c));
        }
        private static bool ContainsUpper(string pass) {
            return pass.Any(c => Char.IsUpper(c));
        }
        private static bool ContainsLower(string pass) {
            return pass.Any(c => Char.IsLower(c));
        }

        private static bool ContainsWhiteSpace(string pass) {
            return pass.Any(c => Char.IsWhiteSpace(c));
        }
    }
}
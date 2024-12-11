

namespace ShopApp.DAL.Models.ValidatorModel
{
    public abstract class GenericValidator
    {
        // Método abstracto para realizar validaciones específicas
        public abstract bool Validate(object model);

        // Validación común para cadenas que no contengan números y longitud máxima
        public bool ValidateStringWithoutDigits(string input, int maxLength)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("El valor no puede ser vacío.");
            }

            if (input.Length > maxLength)
            {
                throw new ArgumentException($"El valor no debe exceder los {maxLength} caracteres.");
            }

            if (HasDigits(input))
            {
                throw new ArgumentException("El valor no debe contener números.");
            }

            return true;
        }

        // Validación de números negativos
        public bool ValidateNonNegativeNumber(int number)
        {
            if (number <= 0) // Cambiado para asegurar que no sea negativo ni cero
            {
                throw new ArgumentException("El número no puede ser negativo ni cero.");
            }
            return true;
        }

        // Validación de fechas no nulas ni en el futuro
        public bool ValidateDateNotInFuture(DateTime date)
        {
            if (date == default(DateTime) || date > DateTime.Now)
            {
                throw new ArgumentException("La fecha no puede estar vacía ni ser en el futuro.");
            }
            return true;
        }

        public bool ValidateStringWithNumbers(string input,int maxLength)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("El valor no puede ser vacío.");
            }

            if ( input.Length > maxLength)
            {
                throw new ArgumentException($"El valor debe tener {maxLength} caracteres.");
            }

            if (!HasDigits(input))  // Verifica si la cadena tiene al menos un número
            {
                throw new ArgumentException("El valor debe contener al menos un número.");
            }

            return true;
        }

        // Función común para verificar si una cadena contiene dígitos
        public bool HasDigits(string input)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("El correo electrónico no puede estar vacío.");
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                throw new ArgumentException("El correo electrónico no tiene un formato válido.");
            }

           

            return true;
        }

      
    }



 

 
}

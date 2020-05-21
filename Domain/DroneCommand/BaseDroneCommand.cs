using Algorithm.Logic.Enum;
using Algorithm.Logic.Interfaces;
using System;

namespace Algorithm.Logic.Domain
{
    public abstract class BaseDroneCommand : IDroneCommand
    {
        /// <summary>
        /// Comando puro, string como era originalmente
        /// </summary>
        public string RawCommand { get; set; }

        /// <summary>
        /// Quantidade de vezes que o comando deve executar
        /// </summary>
        public decimal Quantity { get; protected set; }

        /// <summary>
        /// Indica se o comando foi ou não removico através do comando X (Cancel)
        /// </summary>
        public bool Removed { get; protected set; }

        /// <summary>
        /// Natureza do comando se é N, S, O, L
        /// </summary>
        protected CommandType Type;

        /// <summary>
        /// String com o comando original. Exemplo: N2
        /// </summary>
        /// <param name="input"></param>
        public BaseDroneCommand(string input)
        {
            RawCommand = input;
            FillQuantity();
            Removed = false;
        }

        /// <summary>
        /// Atribui a quantidade de vezes que um comando deve ser executado
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private void FillQuantity()
        {
            
            if (NoQuantityNumber())
            {
                Quantity = 1;
            }
            else
            {
                FillQuantityNumber();
            }
        }

        /// <summary>
        /// Se o comando tem somente um caracter, este é o próprio comando. 
        /// Exemplo: N, O, X e etc, então a quantidade de vezes para executar é 1.
        /// </summary>
        /// <returns></returns>
        private bool NoQuantityNumber() => RawCommand.Length == 1;        

        private void FillQuantityNumber()
        {
            decimal quantity;
            string number = RawCommand.Substring(1);
            bool valid = decimal.TryParse(number, out quantity);

            if (!valid)
            {
                throw new Exception($"Número (${number}) inválido.");
            }

            Quantity = quantity;
        }

        public override string ToString()
        {
            if (Quantity == 1)
            {
                return Type.ToString();
            }

            return $"{Type.ToString()}{Quantity.ToString()}";
        }

        public void Remove() => Removed = true;

        public bool Is(CommandType type) => Type == type;

        public bool IsCancel() => Is(CommandType.X);        

        public abstract DroneMove GetMove();        
    }
}

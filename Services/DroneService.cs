using Algorithm.Logic.Interfaces;

namespace Algorithm.Logic.Services
{
    public class DroneService : IDroneService
    {
        private ICommandService CommandService;
        private IValidationService ValidationService;
        private IPositionService PositionService;

        public DroneService(ICommandService commandService, 
            IValidationService validationService,
            IPositionService positionService)
        {
            CommandService = commandService;
            ValidationService = validationService;
            PositionService = positionService;
        }

        public DronePosition GetPosition(string input)
        {
            try
            {
                if (!ValidationService.IsValid(input))
                {
                    return DronePosition.InvalidPosition;
                }

                // Retorna uma lista de comandos a partir da string de entrada
                var droneCommands = CommandService.GetCommands(input);

                // Retorna uma lista simplificada de comandos (removendo os X e os respectivos comandos)
                ISimplifyService simplifyService = new SimplifyService(droneCommands);
                droneCommands = simplifyService.Simplify();

                // Retorna a posição final do drone
                return PositionService.GetPosition(droneCommands);
            }
            catch
            {
                return DronePosition.InvalidPosition;
            }
        }                
    }
}
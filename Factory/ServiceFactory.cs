using Algorithm.Logic.Interfaces;
using Algorithm.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Logic.Factory
{
    public sealed class ServiceFactory
    {
        private static IDroneService DroneService;
        private static ICommandService CommandService;
        private static IValidationService ValidationService;
        private static IPositionService PositionService;

        private static readonly Lazy<ServiceFactory> lazy = new Lazy<ServiceFactory>
                                                            (() => new ServiceFactory());

        public static ServiceFactory Instance { get { return lazy.Value; } }

        private ServiceFactory()
        {
            CommandService = new CommandService();
            ValidationService = new ValidationService();
            PositionService = new PositionService();
            DroneService = new DroneService(CommandService, ValidationService, PositionService);
        }

        public ICommandService GetCommandService() => CommandService;
        public IValidationService GetValidationService() => ValidationService;
        public IPositionService GetPositionService() => PositionService;
        public IDroneService GetDroneService() => DroneService;
    }
}

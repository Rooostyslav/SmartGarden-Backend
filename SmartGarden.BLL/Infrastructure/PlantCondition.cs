using SmartGarden.DAL.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Infrastructure
{
	public class PlantCondition
	{
		private const double actionsMaxRate = 60;
		private const double resourcesMaxRate = 40;
		private const int enoughResources = 10;
		private readonly IUnitOfWork unitOfWork;

		public PlantCondition(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public async Task<double> GetCondition(int plantId)
		{
			var plant = await unitOfWork.Plants.FindByIdAsync(plantId);

			if (plant != null)
			{
				double actionsRate = await CalculateActionsRate(plantId);
				double resourcesRate = await CalculateResourcesRate(plant.GardenId);

				double condition = actionsRate + resourcesRate;
				return condition;
			}

			return 0;
		}

		private async Task<double> CalculateActionsRate(int plantId)
		{
			var allActions = await unitOfWork.Actions.FindWithIncludesAsync(a => a.PlantId == plantId);
			int countAllActions = allActions.Count();

			var realizedActions = allActions.Where(a => a.Status);
			int countRealizedActions = realizedActions.Count();

			double oneActionRate = 1;
			if (countAllActions != 0)
			{
				 oneActionRate = actionsMaxRate / countAllActions;
			}
			
			return (countRealizedActions * oneActionRate);
		}

		private async Task<double> CalculateResourcesRate(int gardenId)
		{
			var resousces = await unitOfWork.Resourсes.FindWithIncludesAsync(r => r.GardenId == gardenId);
			int countResources = resousces.Count();

			double oneResourceRate = 1;
			if (countResources != 0)
			{
				oneResourceRate = resourcesMaxRate / countResources;
			}
			
			int sufficientResources = resousces.Where(r => r.Amount >= enoughResources).Count();
			return (sufficientResources * oneResourceRate);
		}
	}
}

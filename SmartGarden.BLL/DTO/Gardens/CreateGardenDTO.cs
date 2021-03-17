using SmartGarden.BLL.DTO.Shared;

namespace SmartGarden.BLL.DTO.Gardens
{
	public class CreateGardenDTO : BaseDTO
	{
		public string Description { get; set; }

		public int UserId { get; set; }
	}
}

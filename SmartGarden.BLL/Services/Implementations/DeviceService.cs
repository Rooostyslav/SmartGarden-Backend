using AutoMapper;
using SmartGarden.BLL.DTO.Devices;
using SmartGarden.BLL.Infrastructure;
using SmartGarden.DAL.Entity;
using SmartGarden.DAL.Repositories;
using SmartGarden.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarden.BLL.Services.Implementations
{
	public class DeviceService : IDeviceService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRepository<Device> _devices;
		private readonly IMapper _mapper;

		public DeviceService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<IEnumerable<DeviceDTO>> FindAllAsync()
		{
			var devices = await _devices.GetAllAsync();
			return _mapper.Map<IEnumerable<DeviceDTO>>(devices);
		}

		public async Task<DeviceDTO> FindByIdAsync(int id)
		{
			var device = await _devices.GetByIdAsync(id);
			return _mapper.Map<DeviceDTO>(device);
		}

		public async Task<DeviceDTO> CreateAsync(CreateDeviceDTO deviceToCreate)
		{
			var device = _mapper.Map<Device>(deviceToCreate);
			device.HashedPassword = HashAlgorithm.CreateMD5(deviceToCreate.Password);

			var created = await _devices.InsertAsync(device);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<DeviceDTO>(created);
		}

		public async Task<DeviceDTO> UpdateAsync(UpdateDeviceDTO deviceToUpdate)
		{
			var device = await _devices.GetByIdAsync(deviceToUpdate.Id);
			device = _mapper.Map(deviceToUpdate, device);
			device.HashedPassword = HashAlgorithm.CreateMD5(deviceToUpdate.Password);

			var updated = await _devices.UpdateAsync(device);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<DeviceDTO>(updated);
		}

		public async Task<DeviceDTO> DeleteAsync(int id)
		{
			var deleted = await _devices.DeleteAsync(id);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<DeviceDTO>(deleted);
		}

		public async Task<bool> ExistLoginAsync(string login)
		{
			var device = await _devices.GetFirstOrDefaultAsync(d => d.Login == login);
			return device != null;
		}
	}
}

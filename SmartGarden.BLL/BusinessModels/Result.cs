using System.Collections.Generic;

namespace SmartGarden.BLL.BusinessModels
{
	public class Result<T>
	{
		public T Value { get; set; }

		public bool Success { get; set; }

		public IEnumerable<string> Errors { get; set; }

		public Result(T value)
		{
			Success = true;
			Value = value;
			Errors = new List<string>();
		}

		public Result(IEnumerable<string> errors)
		{
			Success = false;
			Errors = errors;
		}
	}
}

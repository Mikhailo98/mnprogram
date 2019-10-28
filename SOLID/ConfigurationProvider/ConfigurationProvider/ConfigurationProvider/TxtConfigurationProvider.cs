using SolidTask.ConfigurationProvider.Base;
using SolidTask.ConfigurationProvider.Parser;
using SolidTask.ConfigurationProvider.Reader;

namespace SolidTask.ConfigurationProvider.ConfigurationProvider
{
	public class TxtConfigurationProvider : Base.ConfigurationProvider
	{
		public TxtConfigurationProvider() : base(new TxtConfigReader(new TxtConfigParser()))
		{
		}

		public TxtConfigurationProvider(IConfigReader configReader) : base(configReader)
		{
		}
	}
}
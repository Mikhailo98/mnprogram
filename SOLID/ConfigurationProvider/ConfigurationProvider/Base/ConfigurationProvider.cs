using SolidTask.ConfigurationProvider.Collections;
using SolidTask.ConfigurationProvider.Helpers;

namespace SolidTask.ConfigurationProvider.Base
{
	public abstract class ConfigurationProvider
	{
		private static KeyedByTypeCollection _keyedByTypeCollection;
		private readonly IConfigReader _configReader;
		private readonly IObjectCreator _objectCreator;

		protected ConfigurationProvider(IConfigReader configReader) : this(configReader, new ObjectCreator())
		{
		}

		protected ConfigurationProvider(IConfigReader configReader, IObjectCreator objectCreator)
		{
			_configReader = configReader;
			_objectCreator = objectCreator;
		}

		public TConfig Get<TConfig>() where TConfig : class, new()
		{
			if (_keyedByTypeCollection == null)
				_keyedByTypeCollection = _configReader.ReadConfigs(TxtLocalStorage.GetConfigFiles());

			return _objectCreator.Create<TConfig>(_keyedByTypeCollection.Get(typeof(TConfig)));
		}
	}
}